using System;
using System.Windows.Forms;
using ErrorControlSystem;

namespace NugetDownloader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ErrorControlSystem.ExceptionHandler.Engine.Start(".", "UsersManagements",
                    ErrorHandlingOptions.Default & ~ErrorHandlingOptions.DisplayUnhandledExceptions);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
