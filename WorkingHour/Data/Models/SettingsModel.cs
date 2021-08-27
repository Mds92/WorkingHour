namespace WorkingHour.Data.Models
{
    public class SettingsModel
    {
        public SettingsModel()
        {
            BackupPath = "";
        }

        public string BackupPath { get; set; }
        public int RestTimeInMinutes { get; set; }
        public int DeleteBackupFilesOlderThanDays { get; set; }
    }
}
