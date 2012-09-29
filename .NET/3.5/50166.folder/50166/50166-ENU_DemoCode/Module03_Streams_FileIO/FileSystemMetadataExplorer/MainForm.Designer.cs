namespace FileSystemMetadataExplorer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.rightSplitter = new System.Windows.Forms.SplitContainer();
            this.previewText = new System.Windows.Forms.TextBox();
            this.metadataProps = new System.Windows.Forms.PropertyGrid();
            this.filesTree = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            this.rightSplitter.Panel1.SuspendLayout();
            this.rightSplitter.Panel2.SuspendLayout();
            this.rightSplitter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 24);
            this.mainSplitter.Name = "mainSplitter";
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.filesTree);
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.rightSplitter);
            this.mainSplitter.Size = new System.Drawing.Size(555, 498);
            this.mainSplitter.SplitterDistance = 228;
            this.mainSplitter.TabIndex = 0;
            // 
            // rightSplitter
            // 
            this.rightSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSplitter.Location = new System.Drawing.Point(0, 0);
            this.rightSplitter.Name = "rightSplitter";
            this.rightSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightSplitter.Panel1
            // 
            this.rightSplitter.Panel1.Controls.Add(this.previewText);
            // 
            // rightSplitter.Panel2
            // 
            this.rightSplitter.Panel2.Controls.Add(this.metadataProps);
            this.rightSplitter.Size = new System.Drawing.Size(323, 498);
            this.rightSplitter.SplitterDistance = 208;
            this.rightSplitter.TabIndex = 0;
            // 
            // previewText
            // 
            this.previewText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewText.Location = new System.Drawing.Point(0, 0);
            this.previewText.Multiline = true;
            this.previewText.Name = "previewText";
            this.previewText.ReadOnly = true;
            this.previewText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.previewText.Size = new System.Drawing.Size(323, 208);
            this.previewText.TabIndex = 0;
            // 
            // metadataProps
            // 
            this.metadataProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metadataProps.Location = new System.Drawing.Point(0, 0);
            this.metadataProps.Name = "metadataProps";
            this.metadataProps.Size = new System.Drawing.Size(323, 286);
            this.metadataProps.TabIndex = 0;
            // 
            // filesTree
            // 
            this.filesTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filesTree.Location = new System.Drawing.Point(0, 0);
            this.filesTree.Name = "filesTree";
            this.filesTree.Size = new System.Drawing.Size(228, 498);
            this.filesTree.TabIndex = 0;
            this.filesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.filesTree_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // chooseFolderToolStripMenuItem
            // 
            this.chooseFolderToolStripMenuItem.Name = "chooseFolderToolStripMenuItem";
            this.chooseFolderToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.chooseFolderToolStripMenuItem.Text = "Choose folder...";
            this.chooseFolderToolStripMenuItem.Click += new System.EventHandler(this.chooseFolderToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 522);
            this.Controls.Add(this.mainSplitter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "File System Metadata Explorer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            this.mainSplitter.ResumeLayout(false);
            this.rightSplitter.Panel1.ResumeLayout(false);
            this.rightSplitter.Panel1.PerformLayout();
            this.rightSplitter.Panel2.ResumeLayout(false);
            this.rightSplitter.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.SplitContainer rightSplitter;
        private System.Windows.Forms.TextBox previewText;
        private System.Windows.Forms.PropertyGrid metadataProps;
        private System.Windows.Forms.TreeView filesTree;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}

