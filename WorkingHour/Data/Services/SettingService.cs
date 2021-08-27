using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class SettingService : BaseService
    {
        public static SettingsModel GetSettings()
        {
            var xElement = GetRootElement();
            var backupPathAttribute = xElement.Attribute(nameof(SettingsModel.BackupPath));
            var restTimeInMinutesAttribute = xElement.Attribute(nameof(SettingsModel.RestTimeInMinutes));
            int.TryParse(restTimeInMinutesAttribute?.Value, out var restTimeInMinutes);
            if (restTimeInMinutes <= 0) restTimeInMinutes = 1;
            var model = new SettingsModel
            {
                RestTimeInMinutes = restTimeInMinutes,
                BackupPath = string.IsNullOrWhiteSpace(backupPathAttribute?.Value) ? "" : backupPathAttribute.Value.Trim()
            };
            return model;
        }
        public static void Save(SettingsModel model)
        {
            if (string.IsNullOrEmpty(model.BackupPath)) model.BackupPath = "";
            var xElement = GetRootElement();
            xElement.SetAttributeValue(nameof(SettingsModel.RestTimeInMinutes), model.RestTimeInMinutes);
            xElement.SetAttributeValue(nameof(SettingsModel.BackupPath), model.BackupPath);
            xElement.SetAttributeValue(nameof(SettingsModel.DeleteBackupFilesOlderThanDays), model.DeleteBackupFilesOlderThanDays);
            SaveChanges();
        }
    }
}
