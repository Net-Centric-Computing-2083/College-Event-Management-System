using System;
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
            Application.Run(new MainForm());
        }
    }
}
