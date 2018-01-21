using System;
using System.Text;
using System.Windows.Forms;
using MD.PersianDateTime;
using WorkingHour.Assets;
using WorkingHour.Data.Models;
using WorkingHour.Data.Services;
using ZetaLongPaths;

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
                var comboboxItem = new ComboboxItem
                {
                    Value = project.Id.ToString(),
                    Text = project.Title
                };
                comboBoxProjects.Items.Add(comboboxItem);
            }
        }

        private void ComboBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = comboBoxProjects.SelectedItem as ComboboxItem;
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

        private void ButtonExportData_Click(object sender, EventArgs e)
        {
            int.TryParse(maskedTextBoxId.Text, out var projectId);

            if (projectId <= 0) return;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            var spacer1 = $"{new string('-', 50)}{Environment.NewLine}";

            var fileName = saveFileDialog1.FileName;
            var fileInfo = new ZlpFileInfo(fileName);

            var project = ProjectService.SelectById(projectId.ToString());
            var totalDurationString = project.TotalDuration.ToStandardString();
            var initialDurationString = project.InitialDuration.ToStandardString();

            var times = TimeService.SelectAllByProjectId(projectId.ToString());

            var stringBuilder = new StringBuilder($"\t{project.Title}{Environment.NewLine}");
            stringBuilder.Append(spacer1);

            stringBuilder.Append($"\t{initialDurationString}\t<=>\tمتفرقه{Environment.NewLine}");

            foreach (var timeModel in times)
            {
                var startPersianDateTime = new PersianDateTime(timeModel.StartDateTime);
                var durationString = timeModel.Duration.ToStandardString();
                stringBuilder.Append($"\t{durationString}\t<=>\t{startPersianDateTime.ToLongDateString()}{Environment.NewLine}");
            }

            stringBuilder.Append(spacer1);
            stringBuilder.Append($"\t{totalDurationString}");

            fileInfo.WriteAllText(stringBuilder.ToString(), Encoding.UTF8);
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
                    timeModel.RegisterPersianDateTime.ToString()
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
