using System;
using System.Windows.Forms;
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

        private void TabPageProjects_Enter(object sender, EventArgs e)
        {
            LoadListViewProjects();
        }

        private void ListViewProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonNewProject.Enabled = true;
            buttonSubmitProject.Enabled = false;
            maskedTextBoxId.Enabled = textBoxTitle.Enabled = maskedTextBoxInitialTimeDuration.Enabled = false;
            buttonEditProject.Enabled = buttonDeleteProject.Enabled = false;
            if (listViewProjects.SelectedItems.Count <= 0) return;
            var selectedItem = listViewProjects.SelectedItems[0];
            if(selectedItem == null) return;
            maskedTextBoxId.Text = selectedItem.SubItems[0].Text;
            textBoxTitle.Text = selectedItem.SubItems[1].Text;
            maskedTextBoxInitialTimeDuration.Text = selectedItem.SubItems[3].Text;
            buttonEditProject.Enabled = buttonDeleteProject.Enabled = true;
        }

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
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }

        private void buttonNewProject_Click(object sender, EventArgs e)
        {
            maskedTextBoxId.Text = textBoxTitle.Text = maskedTextBoxInitialTimeDuration.Text = "";
            maskedTextBoxId.Enabled = textBoxTitle.Enabled = maskedTextBoxInitialTimeDuration.Enabled = true;
            buttonSubmitProject.Enabled = true;
            buttonNewProject.Enabled = buttonEditProject.Enabled = buttonDeleteProject.Enabled = false;
        }

        private void buttonEditProject_Click(object sender, EventArgs e)
        {
            buttonSubmitProject.Enabled = true;
            maskedTextBoxId.Enabled = textBoxTitle.Enabled = maskedTextBoxInitialTimeDuration.Enabled = true;
            buttonNewProject.Enabled = buttonEditProject.Enabled = false;
        }
    }
}
