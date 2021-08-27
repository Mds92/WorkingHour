using System;
using OfficeOpenXml;
using WorkingHour.Forms;
using System.Windows.Forms;

namespace WorkingHour
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                //if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                //{
                //    MessageBox.Show("Instance already running", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
