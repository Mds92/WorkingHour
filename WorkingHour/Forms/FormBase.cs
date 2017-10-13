using System.Windows.Forms;
using WorkingHour.Data.Services;

namespace WorkingHour
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private ProjectService _projectService;
        protected ProjectService ProjectService
        {
            get
            {
                if (_projectService != null) return _projectService;
                _projectService = new ProjectService();
                return _projectService;
            }
        }

        protected void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
