using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MD.PersianDateTime;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using WorkingHour.Assets;
using WorkingHour.Data.Models;
using WorkingHour.Data.Services;

namespace WorkingHour.Forms
{
    public partial class FormProjects : FormBase
    {
        public FormProjects()
        {
            InitializeComponent();

            ChangeProjectFormStatus(FormStatusEnum.None);
        }

        #region TabPage

        private void TabPageProjects_Enter(object sender, EventArgs e)
        {
            LoadListViewProjects();
            FillComboBoxProjects();
            ChangeProjectFormStatus(FormStatusEnum.None);
        }

        private void TabPageTimes_Enter(object sender, EventArgs e)
        {
            FillComboBoxProjects();
            ChangeTimesFormStatus(FormStatusEnum.None);
        }

        #endregion

        #region ComboBox

        private bool _ignoreFillComboBoxProjects;

        private void FillComboBoxProjects()
        {
            if (_ignoreFillComboBoxProjects)
            {
                _ignoreFillComboBoxProjects = false;
                return;
            }
            comboBoxProjects.Items.Clear();
            var projects = ProjectService.SelectAll();
            foreach (var project in projects)
            {
                var comboboxItem = new ComboBoxItem
                {
                    Value = project.Id.ToString(),
                    Text = project.Title
                };
                comboBoxProjects.Items.Add(comboboxItem);
            }
            listViewTimes.Items.Clear();
        }

        private void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxProjects.SelectedItem as ComboBoxItem;
            if (string.IsNullOrWhiteSpace(selectedItem?.Value)) return;
            LoadListViewTimes(selectedItem.Value);
        }

        #endregion

        #region Button

        #region Projects

        private void ChangeProjectFormStatus(FormStatusEnum status)
        {
            switch (status)
            {
                case FormStatusEnum.None:
                    buttonProjectNew.Visible = true;
                    buttonProjectCancel.Visible = buttonProjectSubmit.Visible = buttonDeleteProject.Visible = false;
                    maskedTextBoxProjectId.Enabled = textBoxProjectTitle.Enabled = maskedTextBoxProjectInitialTimeDuration.Enabled = false;
                    maskedTextBoxProjectId.Text = textBoxProjectTitle.Text = maskedTextBoxProjectInitialTimeDuration.Text = "";
                    break;

                case FormStatusEnum.New:
                    buttonProjectNew.Visible = buttonDeleteProject.Visible = false;
                    buttonProjectCancel.Visible = buttonProjectSubmit.Visible = true;
                    maskedTextBoxProjectId.Enabled = textBoxProjectTitle.Enabled = maskedTextBoxProjectInitialTimeDuration.Enabled = true;
                    maskedTextBoxProjectId.Text = textBoxProjectTitle.Text = maskedTextBoxProjectInitialTimeDuration.Text = "";
                    break;

                case FormStatusEnum.Edit:
                    buttonProjectNew.Visible = buttonProjectCancel.Visible = true;
                    buttonProjectSubmit.Visible = buttonDeleteProject.Visible = true;
                    maskedTextBoxProjectId.Enabled = textBoxProjectTitle.Enabled = maskedTextBoxProjectInitialTimeDuration.Enabled = true;
                    break;
            }
        }

        private void ButtonProjectDelete_Click(object sender, EventArgs e)
        {
            if (listViewProjects.SelectedItems.Count <= 0) return;
            var selectedListViewItem = listViewProjects.SelectedItems[0];
            if (selectedListViewItem == null || !int.TryParse(selectedListViewItem.SubItems[0].Text, out var id)) return;
            if (MessageBox.Show(this, @"Are you sure to delete project?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                ProjectService.Delete(id);
                selectedListViewItem.Remove();
                ChangeTimesFormStatus(FormStatusEnum.None);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void ButtonProjectNew_Click(object sender, EventArgs e)
        {
            ChangeProjectFormStatus(FormStatusEnum.New);
            listViewProjects.SelectedItems.Clear();
        }
        private void ButtonProjectCancel_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            ChangeProjectFormStatus(FormStatusEnum.None);
        }
        private void ButtonProjectSubmit_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            int.TryParse(maskedTextBoxProjectId.Text, out var id);
            if (id <= 0)
            {
                errorProvider1.SetError(maskedTextBoxProjectId, "Enter valid Id");
                return;
            }

            var title = textBoxProjectTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                errorProvider1.SetError(textBoxProjectTitle, "Enter valid Title");
                return;
            }

            var timeDuration = maskedTextBoxProjectInitialTimeDuration.Text.Trim().StandardTimeSpanParse();
            if (timeDuration <= TimeSpan.MinValue)
            {
                errorProvider1.SetError(textBoxProjectTitle, "Enter valid Time duration");
                return;
            }

            var projectModel = new ProjectModel
            {
                Id = id,
                Title = title,
                InitialDuration = timeDuration
            };
            try
            {
                ProjectService.Save(projectModel);
                LoadListViewProjects();
                FillComboBoxProjects();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
            finally
            {
                ChangeProjectFormStatus(FormStatusEnum.None);
            }
        }

        #endregion

        #region Times

        private void ChangeTimesFormStatus(FormStatusEnum status)
        {
            switch (status)
            {
                case FormStatusEnum.None:
                    buttonTimeNew.Visible = true;
                    buttonTimeCancel.Visible = buttonTimeSubmit.Visible = buttonDeleteTime.Visible = false;
                    maskedTextBoxTimeDuration.Enabled = maskedTextBoxTimeStartDateTime.Enabled = maskedTextBoxTimeStopDateTime.Enabled = textBoxTimeDescription.Enabled = false;
                    maskedTextBoxTimeDuration.Text = maskedTextBoxTimeStartDateTime.Text = maskedTextBoxTimeStopDateTime.Text = textBoxTimeDescription.Text = "";
                    break;

                case FormStatusEnum.New:
                    buttonTimeNew.Visible = buttonDeleteTime.Visible = false;
                    buttonTimeCancel.Visible = buttonTimeSubmit.Visible = true;
                    maskedTextBoxTimeDuration.Enabled = maskedTextBoxTimeStartDateTime.Enabled = maskedTextBoxTimeStopDateTime.Enabled = textBoxTimeDescription.Enabled = true;
                    maskedTextBoxTimeDuration.Text = maskedTextBoxTimeStartDateTime.Text = maskedTextBoxTimeStopDateTime.Text = textBoxTimeDescription.Text = "";
                    break;

                case FormStatusEnum.Edit:
                    buttonTimeNew.Visible = buttonTimeCancel.Visible = true;
                    buttonTimeSubmit.Visible = buttonDeleteTime.Visible = true;
                    maskedTextBoxTimeDuration.Enabled = maskedTextBoxTimeStartDateTime.Enabled = maskedTextBoxTimeStopDateTime.Enabled = textBoxTimeDescription.Enabled = true;
                    break;
            }
        }

        private void ButtonTimeDelete_Click(object sender, EventArgs e)
        {
            if (listViewTimes.SelectedItems.Count <= 0) return;
            var selectedListViewItem = listViewTimes.SelectedItems[0];
            if (selectedListViewItem == null || !Guid.TryParse(selectedListViewItem.Tag.ToString(), out var id)) return;
            if (MessageBox.Show(this, @"Are you sure to delete time?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                TimeService.Delete(id);
                selectedListViewItem.Remove();
                ChangeTimesFormStatus(FormStatusEnum.None);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
        private void ButtonTimeNew_Click(object sender, EventArgs e)
        {
            ChangeTimesFormStatus(FormStatusEnum.New);
            listViewTimes.SelectedItems.Clear();
            var persianDateTimeNow = PersianDateTime.Now;
            var persianDateTime2HoursBefore = PersianDateTime.Now.AddHours(-2);
            maskedTextBoxTimeStartDateTime.Text = persianDateTime2HoursBefore.ToStandardString();
            maskedTextBoxTimeStopDateTime.Text = persianDateTimeNow.ToStandardString();
            maskedTextBoxTimeDuration.Text = "0001:00:00";
        }
        private void ButtonTimeCancel_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            ChangeTimesFormStatus(FormStatusEnum.None);
        }
        private void ButtonTimeSubmit_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            var id = Guid.NewGuid();
            var description = textBoxTimeDescription.Text.Trim();
            var editModel = false;
            var registerDateTime = PersianDateTime.Now;
            if (listViewTimes.SelectedItems.Count > 0)
            {
                var selectedListViewItem = listViewTimes.SelectedItems[0];
                if (selectedListViewItem != null)
                {
                    if (!Guid.TryParse(selectedListViewItem.Tag.ToString(), out id)) return;
                    editModel = true;
                    if (!PersianDateTime.TryParse(selectedListViewItem.SubItems[4].Text.Trim(), out registerDateTime))
                    {
                        ShowErrorMessage("Register date time is invalid");
                        return;
                    }
                }
            }

            if (!(comboBoxProjects.SelectedItem is ComboBoxItem selectedProjectItem))
            {
                errorProvider1.SetError(comboBoxProjects, "Select a project");
                return;
            }
            int.TryParse(selectedProjectItem.Value, out var projectId);
            if (projectId <= 0) return;

            if (!PersianDateTime.TryParse(maskedTextBoxTimeStartDateTime.Text.Trim(), out var startDateTime))
            {
                errorProvider1.SetError(maskedTextBoxTimeStartDateTime, "Enter valid persian date time");
                return;
            }

            if (!PersianDateTime.TryParse(maskedTextBoxTimeStopDateTime.Text.Trim(), out var stopDateTime))
            {
                errorProvider1.SetError(maskedTextBoxTimeStopDateTime, "Enter valid persian date time");
                return;
            }

            if (stopDateTime <= startDateTime)
            {
                errorProvider1.SetError(maskedTextBoxTimeStopDateTime, "Stop time must be bigger than start time");
                return;
            }

            var timeDuration = maskedTextBoxTimeDuration.Text.Trim().StandardTimeSpanParse();
            if (timeDuration <= new TimeSpan(0, 0, 0, 0))
            {
                errorProvider1.SetError(maskedTextBoxTimeDuration, "Enter valid Time duration");
                return;
            }
            if (timeDuration > stopDateTime - startDateTime)
            {
                errorProvider1.SetError(maskedTextBoxTimeDuration, "TimeDuration must be bigger than duration between start and stop time");
                return;
            }

            var timeModel = new TimeModel
            {
                Id = id,
                Description = description,
                Duration = timeDuration,
                StartDateTime = startDateTime,
                ProjectId = projectId,
                StopDateTime = stopDateTime,
                RegisterDateTime = editModel ? registerDateTime : DateTime.Now
            };
            try
            {
                TimeService.Save(timeModel);
                LoadListViewTimes(projectId.ToString());
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
            finally
            {
                ChangeTimesFormStatus(FormStatusEnum.None);
            }
        }

        #endregion

        #region Export

        private readonly Font _font = new Font("Segoe UI", 10);
        private readonly Color _borderColor = Color.FromArgb(161, 161, 161);
        private void FormatExcelRange(ExcelRange excelRange, bool setBackgroundColor = false)
        {
            excelRange.Style.Font.SetFromFont(_font);
            excelRange.Style.Border.BorderAround(ExcelBorderStyle.Thin, _borderColor);
            excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
            excelRange.Style.Fill.BackgroundColor.SetColor(Color.White);
            excelRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            excelRange.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            excelRange.Style.WrapText = true;
            if (setBackgroundColor)
                excelRange.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(237, 237, 237));
        }
        private void ButtonExportData_Click(object sender, EventArgs e)
        {
            if (!(comboBoxProjects.SelectedItem is ComboBoxItem selectedItem)) return;
            int.TryParse(selectedItem.Value, out var projectId);
            if (projectId <= 0) return;
            saveFileDialog1.FileName = PersianDateTime.Now.ToString("yyyy-MM-dd");
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            var fileName = saveFileDialog1.FileName;
            var project = ProjectService.SelectById(projectId.ToString());
            var times = TimeService.SelectAllByProjectId(projectId.ToString());
            const string timeFormat = "[h]:mm:ss";
            if (times.Count <= 0) return;
            using (var excelPackage = new ExcelPackage(new FileInfo(fileName)))
            {
                var worksheet = excelPackage.Workbook.Worksheets["Working Hour"] ?? excelPackage.Workbook.Worksheets.Add("Working Hour");

                worksheet.Column(1).Width = 40;
                worksheet.Column(2).Width = 40;
                worksheet.Column(3).Width = 10;
                worksheet.Column(4).Width = 100;

                worksheet.Row(1).Height = 25;

                // عنوان بالا
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1:D1"].Value = $"{project.Title}";
                FormatExcelRange(worksheet.Cells["A1:D1"], true);
                worksheet.Cells["A1:D1"].Style.Font.Bold = true;

                // عناوین هر ستون
                worksheet.Cells["A2"].Value = "Start Date Time";
                worksheet.Cells["B2"].Value = "End Date Time";
                worksheet.Cells["C2"].Value = "Duration";
                worksheet.Cells["D2"].Value = "Description";
                FormatExcelRange(worksheet.Cells["A2"], true);
                FormatExcelRange(worksheet.Cells["B2"], true);
                FormatExcelRange(worksheet.Cells["C2"], true);
                FormatExcelRange(worksheet.Cells["D2"], true);
                worksheet.Cells["A2:D2"].Style.Font.Bold = true;

                var row = 3;
                foreach (var timeModel in times)
                {
                    var cellName1 = $"A{row}";
                    var cellName2 = $"B{row}";
                    var cellName3 = $"C{row}";
                    var cellName4 = $"D{row}";
                    worksheet.Cells[cellName1].Value = timeModel.StartPersianDateTime.ToLongDateTimeString();
                    worksheet.Cells[cellName2].Value = timeModel.StopPersianDateTime.ToLongDateTimeString();
                    worksheet.Cells[cellName3].Value = timeModel.Duration;
                    worksheet.Cells[cellName4].Value = timeModel.Description?.Replace("\r\n", "\n");
                    FormatExcelRange(worksheet.Cells[cellName1]);
                    FormatExcelRange(worksheet.Cells[cellName2]);
                    FormatExcelRange(worksheet.Cells[cellName3]);
                    FormatExcelRange(worksheet.Cells[cellName4]);
                    worksheet.Cells[cellName3].Style.Numberformat.Format = timeFormat;
                    row++;
                }

                var sumCellName = $"C{row}";
                worksheet.Cells[sumCellName].Formula = $"SUM(C3:C{row - 1})";
                FormatExcelRange(worksheet.Cells[sumCellName], true);
                worksheet.Cells[sumCellName].Style.Numberformat.Format = timeFormat;

                excelPackage.Save();
            }
        }

        #endregion

        #region Merge

        private void ButtonSelectDataBase_Click(object sender, EventArgs e)
        {
            if (openFileDialogForXml.ShowDialog() != DialogResult.OK) return;
            labelProjectNumber.Text = "";
            labelMegingInfo.Text = "";
            try
            {
                var databaseFilePath = openFileDialogForXml.FileName;
                textBoxDatabaseFilePath.Text = databaseFilePath;
                var mergingService = new MergingService(databaseFilePath);
                var projects = ProjectService.SelectAll();
                var theSameProjectsCount = mergingService.GetTheSameProjectsCount(projects);
                var newProjectsCount = mergingService.GetNewProjectsCount(projects);
                labelMegingInfo.Text = $@"Found {theSameProjectsCount} project(s) with the same name And {newProjectsCount} new project(s)";
                if (theSameProjectsCount <= 0 && newProjectsCount <= 0)
                    labelMegingInfo.Text += $"{Environment.NewLine}There are nothing to merge";
                buttonMerge.Visible = theSameProjectsCount > 0 || newProjectsCount > 0;
            }
            catch (Exception exception)
            {
                ShowErrorMessage($"Selected Database is invalid {Environment.NewLine} {exception.Message}");
            }
        }

        private void ButtonMerge_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, @"Are you sure to want merge?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                var databaseFilePath = textBoxDatabaseFilePath.Text.Trim();
                var mergingService = new MergingService(databaseFilePath);
                var projectsOfCurrentDataBase = ProjectService.SelectAll();

                var theSameProjects = mergingService.GetTheSameProjects(projectsOfCurrentDataBase);
                var timeModelsToSave = new List<TimeModel>();
                Parallel.ForEach(theSameProjects, theSameProject =>
                {
                    var projectOfCurrentDatabase = projectsOfCurrentDataBase.Find(q => q.Title.Equals(theSameProject.Title, StringComparison.InvariantCultureIgnoreCase));
                    if (projectOfCurrentDatabase == null) return;
                    foreach (var timeModel in theSameProject.Times)
                    {
                        timeModel.ProjectId = projectOfCurrentDatabase.Id;
                        timeModelsToSave.Add(timeModel);
                    }
                });
                TimeService.Save(timeModelsToSave);
                timeModelsToSave = new List<TimeModel>();
                if (checkBoxAddNewProjects.Checked)
                {
                    var newProjects = mergingService.GetNewProjects(projectsOfCurrentDataBase);
                    Parallel.ForEach(newProjects, newProject =>
                    {
                        var project = ProjectService.Insert(newProject);
                        foreach (var timeModel in newProject.Times)
                        {
                            timeModel.ProjectId = project.Id;
                            timeModelsToSave.Add(timeModel);
                        }
                    });
                }
                TimeService.Save(timeModelsToSave);
                ShowSuccessMessage("The databases merged successfully");
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        #endregion

        #endregion

        #region ListView

        #region Projects

        private void LoadListViewProjects()
        {
            listViewProjects.Items.Clear();
            var projects = ProjectService.SelectAll();
            foreach (var project in projects)
            {
                var listViewItem = new ListViewItem(new[]
                {
                    project.Id.ToString(),
                    project.Title,
                    project.RegisterPersianDateTime.ToStandardString(),
                    project.InitialDuration.ToStandardString(),
                    project.TotalDuration.ToStandardString(),
                })
                {
                    Name = $@"Item_{project.Id}"
                };
                listViewProjects.Items.Add(listViewItem);
            }
        }

        private void ListViewProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProjects.SelectedItems.Count <= 0) return;
            var selectedItem = listViewProjects.SelectedItems[0];
            if (selectedItem == null) return;
            maskedTextBoxProjectId.Text = selectedItem.SubItems[0].Text;
            textBoxProjectTitle.Text = selectedItem.SubItems[1].Text;
            maskedTextBoxProjectInitialTimeDuration.Text = selectedItem.SubItems[3].Text;
            ChangeProjectFormStatus(FormStatusEnum.Edit);
        }

        private void ListViewProjects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var info = listViewProjects.HitTest(e.X, e.Y);
            var selectedItem = info.Item;
            var projectId = selectedItem?.SubItems[0].Text;
            var projectTitle = selectedItem?.SubItems[1].Text;
            if (string.IsNullOrWhiteSpace(projectId) || string.IsNullOrWhiteSpace(projectTitle)) return;
            comboBoxProjects.SelectedIndex = comboBoxProjects.FindStringExact(projectTitle);
            _ignoreFillComboBoxProjects = true;
            tabControl.SelectTab(nameof(tabPageTimes));
        }

        #endregion

        #region Times

        private void LoadListViewTimes(string projectId)
        {
            listViewTimes.Items.Clear();
            var counter = 0;
            var times = TimeService.SelectAllByProjectId(projectId);
            foreach (var timeModel in times)
            {
                counter++;
                var listViewItem = new ListViewItem(new[]
                {
                    counter.ToString(),
                    timeModel.Duration.ToStandardString(),
                    timeModel.StartPersianDateTime.ToStandardString(),
                    timeModel.StopPersianDateTime.ToStandardString(),
                    timeModel.RegisterPersianDateTime.ToStandardString(),
                    timeModel.Description
                })
                {
                    Name = $@"Item_{counter}",
                    Tag = timeModel.Id
                };
                listViewTimes.Items.Add(listViewItem);
            }
        }

        private void ListViewTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTimes.SelectedItems.Count <= 0) return;
            var selectedItem = listViewTimes.SelectedItems[0];
            if (selectedItem == null) return;
            maskedTextBoxTimeDuration.Text = selectedItem.SubItems[1].Text;
            maskedTextBoxTimeStartDateTime.Text = selectedItem.SubItems[2].Text;
            maskedTextBoxTimeStopDateTime.Text = selectedItem.SubItems[3].Text;
            textBoxTimeDescription.Text = selectedItem.SubItems[5].Text;
            ChangeTimesFormStatus(FormStatusEnum.Edit);
        }

        #endregion

        #endregion
    }
}