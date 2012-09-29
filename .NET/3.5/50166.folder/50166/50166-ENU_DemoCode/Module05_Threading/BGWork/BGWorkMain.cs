using System;
using System.Windows.Forms;

namespace BGWork
{
    static class BGWorkMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FileCopyForm());
        }
    }
}
