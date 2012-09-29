using System;
using System.Windows.Forms;

namespace PictureFeed_Solution
{
    static class PictureFeedMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PictureFeedForm());
        }
    }
}
