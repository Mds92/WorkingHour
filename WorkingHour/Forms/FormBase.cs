using System.Windows.Forms;

namespace WorkingHour
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        protected void ShowErrorMessage(string errorMessage)
        {
            MessageBox.Show(errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
