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
                _dataBasePath = ZlpPathHelper.Combine(Application.ExecutablePath, "/Data/WorkingHourDb.xml");
                return _dataBasePath;
            }
        }

        protected XDocument GetDataBaseXDocumentInstance => XDocument.Load(DataBasePath);
    }
}
