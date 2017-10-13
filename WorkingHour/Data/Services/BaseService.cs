using System.Windows.Forms;
using System.Xml.Linq;
using ZetaLongPaths;

namespace WorkingHour.Data.Services
{
    public class BaseService
    {
        private string _dataBasePath;
        protected string DataBasePath
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_dataBasePath)) return _dataBasePath;
                _dataBasePath = ZlpPathHelper.Combine(ZlpPathHelper.GetDirectory(Application.ExecutablePath), "/Data/WorkingHourDb.xml");
                return _dataBasePath;
            }
        }

        private XDocument _xDocument;
        protected XDocument GetDataBaseXDocumentInstance
        {
            get
            {
                if (_xDocument != null) return _xDocument;
                _xDocument = XDocument.Load(DataBasePath);
                return _xDocument;
            }
        }

        protected void SaveChanges()
        {
            GetDataBaseXDocumentInstance.Save(DataBasePath);
            _xDocument = null;
        }
    }
}
