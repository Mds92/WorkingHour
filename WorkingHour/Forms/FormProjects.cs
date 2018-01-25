using System;
using System.Drawing;
using System.IO;
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
        }

        #region TabPage

        private void TabPageProjects_Enter(object sender, EventArgs e)
        {
            LoadListViewProjects();
            FillComboBoxProjects();
        }

        private void TabPageTimes_Enter(object sender, EventArgs e)
        {
            FillComboBoxProjects();
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
        }

        private void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxProjects.SelectedItem as ComboBoxItem;
            if (string.IsNullOrWhiteSpace(selectedItem?.Value)) return;
            LoadListViewTimes(selectedItem.Value);
        }

        #endregion

        #region Button

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, @"Are you sure to delete project?", @"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            int.TryParse(maskedTextBoxId.Text, out var id);
            if (id <= 0)
            {
                errorProvider1.SetError(maskedTextBoxId, "Enter valid Id");
                return;
            }
            try
            {
                ProjectService.Delete(id);
                LoadListViewProjects();
                ButtonNewProject_Click(null, null);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void ButtonNewProject_Click(object sender, EventArgs e)
        {
            maskedTextBoxId.Text = textBoxTitle.Text = maskedTextBoxInitialTimeDuration.Text = "";
            maskedTextBoxId.Enabled = textBoxTitle.Enabled = maskedTextBoxInitialTimeDuration.Enabled = true;
            buttonSubmitProject.Enabled = true;
            buttonNewProject.Enabled = buttonEditProject.Enabled = buttonDeleteProject.Enabled = buttonExportData.Enabled = false;
        }

        private void ButtonEditProject_Click(object sender, EventArgs e)
        {
            buttonNewProject.Enabled = buttonSubmitProject.Enabled =
            maskedTextBoxId.Enabled = textBoxTitle.Enabled =
            maskedTextBoxInitialTimeDuration.Enabled = buttonExportData.Enabled = true;
            buttonEditProject.Enabled = false;
        }

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

                worksheet.Column(1).Width = 30;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 40;

                worksheet.Row(1).Height = 25;

                // عنوان بالا
                worksheet.Cells["A1:C1"].Merge = true;
                worksheet.Cells["A1:C1"].Value = $"{project.Title}, {project.RegisterPersianDateTime.ToLongDateTimeString()}";
                FormatExcelRange(worksheet.Cells["A1:C1"], true);
                worksheet.Cells["A1:C1"].Style.Font.Bold = true;

                // عناوین هر ستون
                worksheet.Cells["A2"].Value = "Date";
                worksheet.Cells["B2"].Value = "Time";
                worksheet.Cells["C2"].Value = "Description";
                FormatExcelRange(worksheet.Cells["A2"], true);
                FormatExcelRange(worksheet.Cells["B2"], true);
                FormatExcelRange(worksheet.Cells["C2"], true);
                worksheet.Cells["A2:C2"].Style.Font.Bold = true;

                // ساعات ماه های قبل
                worksheet.Cells["A3"].Value = "";
                worksheet.Cells["B3"].Value = project.InitialDuration;
                worksheet.Cells["C3"].Value = "از ماه های قبل";
                FormatExcelRange(worksheet.Cells["A3"]);
                FormatExcelRange(worksheet.Cells["B3"]);
                FormatExcelRange(worksheet.Cells["C3"]);
                worksheet.Cells["A3:C3"].Style.Numberformat.Format = timeFormat;

                var row = 4;
                foreach (var timeModel in times)
                {
                    var cellName1 = $"A{row}";
                    var cellName2 = $"B{row}";
                    var cellName3 = $"C{row}";
                    worksheet.Cells[cellName1].Value = timeModel.RegisterPersianDateTime.ToLongDateString();
                    worksheet.Cells[cellName2].Value = timeModel.Duration;
                    worksheet.Cells[cellName3].Value = timeModel.Description;
                    FormatExcelRange(worksheet.Cells[cellName1]);
                    FormatExcelRange(worksheet.Cells[cellName2]);
                    FormatExcelRange(worksheet.Cells[cellName3]);
                    worksheet.Cells[cellName2].Style.Numberformat.Format = timeFormat;
                    row++;
                }

                var sumCellName = $"B{row}";
                worksheet.Cells[sumCellName].Formula = $"SUM(B3:B{row - 1})";
                FormatExcelRange(worksheet.Cells[sumCellName], true);
                worksheet.Cells[sumCellName].Style.Numberformat.Format = timeFormat;

                excelPackage.Save();
            }
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            int.TryParse(maskedTextBoxId.Text, out int id);
            if (id <= 0)
            {
                errorProvider1.SetError(maskedTextBoxId, "Enter valid Id");
                return;
            }

            var title = textBoxTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(title))
            {
                errorProvider1.SetError(textBoxTitle, "Enter valid Title");
                return;
            }

            var timeDuration = maskedTextBoxInitialTimeDuration.Text.Trim().StandardTimeSpanParse();
            if (timeDuration <= TimeSpan.MinValue)
            {
                errorProvider1.SetError(textBoxTitle, "Enter valid Time duration");
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
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
            finally
            {
                maskedTextBoxId.Enabled = textBoxTitle.Enabled = maskedTextBoxInitialTimeDuration.Enabled = false;
                buttonSubmitProject.Enabled = false;
                buttonNewProject.Enabled = buttonEditProject.Enabled = true;
            }
        }

        #endregion

        #region ListView

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
                    project.RegisterPersianDateTime.ToString(),
                    project.InitialDuration.ToStandardString(),
                    project.TotalDuration.ToStandardString(),
                })
                {
                    Name = $@"Item_{project.Id}"
                };
                listViewProjects.Items.Add(listViewItem);
            }
        }

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
                    timeModel.StartPersianDateTime.ToString(),
                    timeModel.StopPersianDateTime.ToString(),
                    timeModel.RegisterPersianDateTime.ToString(),
                    timeModel.Description
                })
                {
                    Name = $@"Item_{counter}"
                };
                listViewTimes.Items.Add(listViewItem);
            }
        }

        private void ListViewProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedTextBoxId.Enabled = textBoxTitle.Enabled = maskedTextBoxInitialTimeDuration.Enabled = false;
            buttonSubmitProject.Enabled = buttonEditProject.Enabled = buttonDeleteProject.Enabled = false;
            if (listViewProjects.SelectedItems.Count <= 0) return;
            var selectedItem = listViewProjects.SelectedItems[0];
            if (selectedItem == null) return;
            maskedTextBoxId.Text = selectedItem.SubItems[0].Text;
            textBoxTitle.Text = selectedItem.SubItems[1].Text;
            maskedTextBoxInitialTimeDuration.Text = selectedItem.SubItems[3].Text;
            buttonEditProject.Enabled = buttonDeleteProject.Enabled = buttonExportData.Enabled = buttonNewProject.Enabled = true;
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
    }
}
