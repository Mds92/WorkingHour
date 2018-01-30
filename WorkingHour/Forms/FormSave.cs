using System;
using WorkingHour.Assets;
using WorkingHour.Data.Models;
using WorkingHour.Data.Services;

namespace WorkingHour.Forms
{
    public partial class FormSave : FormBase
    {
        private readonly string _projectId;
        public FormSave(string projectId)
        {
            InitializeComponent();

            _projectId = projectId;
            LoadProjectInfo();
        }

        private void LoadProjectInfo()
        {
            var project = ProjectService.SelectById(_projectId);
            labelProjectInfo.Text = $"Project: {project.Title}   Duration: {StaticAssets.Duration.ToStandardString()}";
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                TimeService.Save(new TimeModel
                {
                    ProjectId = int.Parse(_projectId),
                    Duration = StaticAssets.Duration,
                    StopDateTime = StaticAssets.StopDateTime <= DateTime.MinValue ? DateTime.Now : StaticAssets.StopDateTime,
                    StartDateTime = StaticAssets.StartDateTime,
                    Description = textBoxDescription.Text.Trim()
                });
                ShowSuccessMessage("Time saved successfully");
                StaticAssets.Duration = new TimeSpan(0, 0, 0, 0, 0);
                DraftService.Clear();
                Close();
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
    }
}
