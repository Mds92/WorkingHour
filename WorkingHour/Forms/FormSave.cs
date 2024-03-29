﻿using System;
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
            labelProjectInfo.Text = $@"Project: {project.Title}   Duration: {StaticAssets.Duration.ToStandardString()}";
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var setting = SettingService.GetSettings();
                var restMinutes = (int)(StaticAssets.Duration.TotalMinutes * setting.RestTimeInMinutes / 60);
                var stopDateTimeNow = StaticAssets.StopDateTime <= DateTime.MinValue
                    ? DateTime.Now.AddMinutes(restMinutes)
                    : StaticAssets.StopDateTime.AddMinutes(restMinutes);
                BackupService.DeleteOldFiles(setting.DeleteBackupFilesOlderThanDays);
                TimeService.Save(new TimeModel
                {
                    ProjectId = int.Parse(_projectId),
                    Duration = StaticAssets.Duration.Add(new TimeSpan(0,0, restMinutes,0)),
                    StopDateTime = stopDateTimeNow,
                    StartDateTime = StaticAssets.StartDateTime,
                    Description = textBoxDescription.Text.Trim()
                });
                ShowSuccessMessage("Time saved successfully");
                StaticAssets.Duration = TimeSpan.Zero;
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
