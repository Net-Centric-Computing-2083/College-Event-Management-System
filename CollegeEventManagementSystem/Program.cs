using System;
using System.Configuration;
using System.Windows.Forms;
using CollegeEventManagementSystem.Forms;

namespace CollegeEventManagementSystem
{
    static class Program
    {
        /// <summary>
        /// Entry point of the application. The dashboard (MainForm) is the first window.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Verify database connectivity before launching the main UI.
            try
            {
                if (!Data.DatabaseHelper.CanConnect())
                {
                    MessageBox.Show(
                        "Unable to connect to the database. Please check the connection string in App.config and ensure the database exists.",
                        "Database Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show(
                    "Database configuration error: " + ex.Message,
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unexpected error while checking database connection: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            Application.Run(new MainForm());
        }
    }
}
