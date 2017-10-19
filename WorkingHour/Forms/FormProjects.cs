using System;
using System.Windows.Forms;
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
                    project.TotalDuration.ToString(),
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

            TimeSpan.TryParse(maskedTextBoxTimeDuration.Text.Trim(), out TimeSpan timeDuration);
            if (timeDuration <= TimeSpan.MinValue)
            {
                errorProvider1.SetError(textBoxTitle, "Enter valid Time duration");
                return;
            }

            var projectModel = new ProjectModel
            {
                Id = id,
                Title = title,
                TotalDuration = timeDuration
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
        }

        private void TabPageProjects_Enter(object sender, EventArgs e)
        {
            LoadListViewProjects();
        }

        private void ListViewProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewProjects.SelectedItems.Count <= 0) return;
            var selectedItem = listViewProjects.SelectedItems[0];
            if(selectedItem == null) return;
            maskedTextBoxId.Text = selectedItem.SubItems[0].Text;
            textBoxTitle.Text = selectedItem.SubItems[1].Text;
            maskedTextBoxTimeDuration.Text = selectedItem.SubItems[3].Text;
        }
    }
}
