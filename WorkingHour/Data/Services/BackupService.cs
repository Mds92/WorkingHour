using MD.PersianDateTime;
using WorkingHour.Data.Models;
using ZetaLongPaths;

namespace WorkingHour.Data.Services
{
    public class BackupService : BaseService
    {
        public static bool GetBackup()
        {
            var backupPathAttribute = GetRootElement().Attribute(nameof(SettingsModel.BackupPath));
            if (string.IsNullOrWhiteSpace(backupPathAttribute?.Value)) return false;
            var persianDateTimeNow = PersianDateTime.Now;
            var backupFileName = $"WorkingHourDb {persianDateTimeNow.ToShortDateInt()}.xml";
            var dataBaseBackupPath = ZlpPathHelper.Combine(backupPathAttribute.Value, $"/{backupFileName}");
            ZlpIOHelper.CopyFile(DataBasePath, dataBaseBackupPath, true);
            return true;
        }
    }
}
