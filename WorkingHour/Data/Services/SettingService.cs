using WorkingHour.Data.Models;

namespace WorkingHour.Data.Services
{
    public class SettingService : BaseService
    {
        public static SettingsModel GetSettings()
        {
            var xElement = GetRootElement();
            var backupPathAttribute = xElement.Attribute(nameof(SettingsModel.BackupPath));
            var model = new SettingsModel
            {
                BackupPath = string.IsNullOrWhiteSpace(backupPathAttribute?.Value) ? "" : backupPathAttribute.Value.Trim()
            };
            return model;
        }
        public static void Save(SettingsModel model)
        {
            if (string.IsNullOrEmpty(model.BackupPath)) model.BackupPath = "";
            var xElement = GetRootElement();
            xElement.SetAttributeValue(nameof(SettingsModel.BackupPath), model.BackupPath);
            SaveChanges();
        }
    }
}
