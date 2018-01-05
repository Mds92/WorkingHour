using System;
using WorkingHour.Data.Models;
using WorkingHour.Data.Services;

namespace WorkingHour.Forms
{
    public partial class FormSettings : FormBase
    {
        public FormSettings()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var model = SettingService.GetSettings();
            textBoxBackupPath.Text = model.BackupPath;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var model = new SettingsModel
            {
                BackupPath = textBoxBackupPath.Text.Trim()
            };
            SettingService.Save(model);
            ButtonCancel_Click(null, null);
        }
    }
}
