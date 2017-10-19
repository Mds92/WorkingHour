using System.Windows.Forms;
using System.Xml.Linq;
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

        protected static void SaveChanges()
        {
            GetDataBaseXDocumentInstance.Save(DataBasePath);
            _xDocument = null;
        }
    }
}
