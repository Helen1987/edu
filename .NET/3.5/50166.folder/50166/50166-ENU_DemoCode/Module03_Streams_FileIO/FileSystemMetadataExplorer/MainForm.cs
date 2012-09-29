using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSystemMetadataExplorer
{
    /// <summary>
    /// A simple file system explorer with a tree view of directories and files,
    /// a text preview area and a metadata view for directory and file information.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillTreeView(@"..\..");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chooseFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Select a new root folder.";
            if (browser.ShowDialog() != DialogResult.OK)
                return;

            FillTreeView(browser.SelectedPath);
        }

        /// <summary>
        /// Fills the tree view with the subdirectories and files under
        /// the specified folder path.  This is performed using an auxiliary
        /// recursive method.  Note that we freeze the tree view (prevent it
        /// from redrawing) during the updating process because it significantly
        /// speeds it up and prevents flickering.
        /// </summary>
        /// <param name="folderPath"></param>
        private void FillTreeView(string folderPath)
        {
            filesTree.BeginUpdate();

            filesTree.Nodes.Clear();
            TreeNode root = filesTree.Nodes.Add(folderPath);
            FillTreeViewHelper(folderPath, root);

            filesTree.EndUpdate();
        }

        private void FillTreeViewHelper(string currentPath, TreeNode currentNode)
        {
            foreach (string directory in Directory.GetDirectories(currentPath))
            {
                TreeNode child = currentNode.Nodes.Add(directory);
                FillTreeViewHelper(directory, child);
            }
            foreach (string file in Directory.GetFiles(currentPath))
            {
                currentNode.Nodes.Add(file);
            }
        }

        /// <summary>
        /// Handles the selection of a new item in the tree.  If the selected
        /// item is a directory, then the property grid is set to display the
        /// directory information using a DirectoryInfo instance.  If the selected
        /// item is a file, then the property grid is set to display the file
        /// information using a FileInfo instance.
        /// </summary>
        private void filesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;

            if (Directory.Exists(e.Node.Text))
            {
                metadataProps.SelectedObject = new DirectoryInfo(e.Node.Text);
                return;
            }

            if (!File.Exists(e.Node.Text))
                return;

            previewText.Text = File.ReadAllText(e.Node.Text);
            metadataProps.SelectedObject = new FileInfo(e.Node.Text);
        }
    }
}
