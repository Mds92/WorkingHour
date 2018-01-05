using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using MD.PersianDateTime;
using WorkingHour.Assets;
using WorkingHour.Data.Models;
using ZetaLongPaths;

namespace WorkingHour.Data.Services
{
    public class BaseService
    {
        private static string _dataBasePath;
        protected static string DataBasePath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_dataBasePath)) return _dataBasePath;
                _dataBasePath = ZlpPathHelper.Combine(ZlpPathHelper.GetDirectory(Application.ExecutablePath), "/Data/WorkingHourDb.xml");
                return _dataBasePath;
            }
        }

        private static XDocument _xDocument;
        protected static XDocument GetDataBaseXDocumentInstance
        {
            get
            {
                if (_xDocument != null) return _xDocument;
                _xDocument = XDocument.Load(DataBasePath);
                return _xDocument;
            }
        }

        protected static XElement GetRootElement()
        {
            return GetDataBaseXDocumentInstance.Descendants(Constants.RootNodeName).First();
        }

        protected static bool GetBackup()
        {
            var backupPathAttribute = GetRootElement().Attribute(nameof(SettingsModel.BackupPath));
            if (string.IsNullOrWhiteSpace(backupPathAttribute?.Value)) return false;
            var persianDateTimeNow = PersianDateTime.Now;
            var backupFileName = $"WorkingHourDb {persianDateTimeNow.ToShortDateInt()}.xml";
            var dataBaseBackupPath = ZlpPathHelper.Combine(backupPathAttribute.Value, $"/{backupFileName}");
            ZlpIOHelper.CopyFile(DataBasePath, dataBaseBackupPath, true);
            return true;
        }

        protected static void SaveChanges()
        {
            GetDataBaseXDocumentInstance.Save(DataBasePath);
            GetBackup();
            _xDocument = null;
        }
    }
}
