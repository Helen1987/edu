using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace BGWork
{
    /// <summary>
    /// Demonstrates the use of the BackgroundWorker class (and associated pattern)
    /// for performing background work in a UI application.
    /// </summary>
    public partial class FileCopyForm : Form
    {
        public FileCopyForm()
        {
            InitializeComponent();
        }

        private void sourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a source folder to copy";
            fbd.ShowNewFolderButton = false;
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == DialogResult.OK)
                source.Text = fbd.SelectedPath;
        }

        private void destBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a destination folder to copy";
            fbd.ShowNewFolderButton = true;
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == DialogResult.OK)
                source.Text = fbd.SelectedPath;
        }

        private void asyncCopy_Click(object sender, EventArgs e)
        {
            if (asyncCopy.Text == "Copy")
            {
                backgroundWorker.RunWorkerAsync();
                asyncCopy.Text = "Cancel";
            }
            else
            {
                backgroundWorker.CancelAsync();
                asyncCopy.Text = "Copy";
            }
        }

        /// <summary>
        /// Performs the actual background work by copying files from one directory to another.
        /// Progress is reported after every file, and cancellation is supported by aborting the
        /// operation if cancellation is pending.
        /// </summary>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Flattens the directory hierarchy of the source in the destination copy:
            string[] filesToCopy = Directory.GetFiles(source.Text, "*.*", SearchOption.AllDirectories);
            for (int i = 0; i < filesToCopy.Length; ++i)
            {
                string dest = Path.Combine(destination.Text, Path.GetFileName(filesToCopy[i]));
                File.Copy(filesToCopy[i], dest, true);
                backgroundWorker.ReportProgress((int)((100.0f * i) / filesToCopy.Length));

                Thread.Sleep(500);  //Introduce an artificial wait

                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }

            e.Result = filesToCopy.Length;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            asyncCopy.Text = "Copy";
            progress.Value = 0;

            if (e.Cancelled)
            {
                MessageBox.Show("The copy operation was cancelled");
            }
            else
            {
                if (e.Error != null)
                {
                    MessageBox.Show("An error occured during the copy operation");
                }
                else
                {
                    MessageBox.Show("The copy operation completed successfully, copied " + e.Result + " files");
                }
            }
        }
    }
}
