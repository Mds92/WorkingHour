using System;
using System.Linq;
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
            var backupPath = backupPathAttribute.Value;
            if (!ZlpIOHelper.DirectoryExists(backupPath)) return false;
            var persianDateTimeNow = PersianDateTime.Now;
            var backupFileName = $"WorkingHourDb {persianDateTimeNow.ToShortDateInt()}.xml";
            var dataBaseBackupPath = ZlpPathHelper.Combine(backupPathAttribute.Value, $"/{backupFileName}");
            ZlpIOHelper.CopyFile(DataBasePath, dataBaseBackupPath, true);
            return true;
        }

        /// <summary>
        /// حذف فایل های قدیمی تر از پارامتر وروردی
        /// </summary>
        public static void DeleteOldFiles(int day)
        {
            var backupPathAttribute = GetRootElement().Attribute(nameof(SettingsModel.BackupPath));
            if (string.IsNullOrWhiteSpace(backupPathAttribute?.Value)) return;
            var backupPath = backupPathAttribute.Value;
            if (!ZlpIOHelper.DirectoryExists(backupPath)) return;
            var files = ZlpIOHelper.GetFiles(backupPath);
            var dateTimeToFindOldBackupFiles = DateTime.Now.AddDays(-day).Date;
            foreach (var zlpFileInfo in files.Where(q => q.DateInfos.CreationTime <= dateTimeToFindOldBackupFiles))
                zlpFileInfo.SafeDelete();
        }
    }
}
