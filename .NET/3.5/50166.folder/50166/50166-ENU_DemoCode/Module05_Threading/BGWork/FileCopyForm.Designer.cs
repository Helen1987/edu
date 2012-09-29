namespace BGWork
{
    partial class FileCopyForm
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
            this.source = new System.Windows.Forms.TextBox();
            this.destination = new System.Windows.Forms.TextBox();
            this.sourceBrowse = new System.Windows.Forms.Button();
            this.destBrowse = new System.Windows.Forms.Button();
            this.asyncCopy = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.Location = new System.Drawing.Point(24, 48);
            this.source.Margin = new System.Windows.Forms.Padding(6);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(580, 33);
            this.source.TabIndex = 0;
            this.source.Text = "C:\\Temp";
            // 
            // destination
            // 
            this.destination.Location = new System.Drawing.Point(24, 135);
            this.destination.Margin = new System.Windows.Forms.Padding(6);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(580, 33);
            this.destination.TabIndex = 1;
            this.destination.Text = "C:\\Temp\\Copy";
            // 
            // sourceBrowse
            // 
            this.sourceBrowse.Location = new System.Drawing.Point(629, 41);
            this.sourceBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.sourceBrowse.Name = "sourceBrowse";
            this.sourceBrowse.Size = new System.Drawing.Size(150, 44);
            this.sourceBrowse.TabIndex = 2;
            this.sourceBrowse.Text = "Browse...";
            this.sourceBrowse.UseVisualStyleBackColor = true;
            this.sourceBrowse.Click += new System.EventHandler(this.sourceBrowse_Click);
            // 
            // destBrowse
            // 
            this.destBrowse.Location = new System.Drawing.Point(629, 128);
            this.destBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.destBrowse.Name = "destBrowse";
            this.destBrowse.Size = new System.Drawing.Size(150, 44);
            this.destBrowse.TabIndex = 3;
            this.destBrowse.Text = "Browse...";
            this.destBrowse.UseVisualStyleBackColor = true;
            this.destBrowse.Click += new System.EventHandler(this.destBrowse_Click);
            // 
            // asyncCopy
            // 
            this.asyncCopy.Location = new System.Drawing.Point(629, 212);
            this.asyncCopy.Margin = new System.Windows.Forms.Padding(6);
            this.asyncCopy.Name = "asyncCopy";
            this.asyncCopy.Size = new System.Drawing.Size(150, 44);
            this.asyncCopy.TabIndex = 4;
            this.asyncCopy.Text = "Copy";
            this.asyncCopy.UseVisualStyleBackColor = true;
            this.asyncCopy.Click += new System.EventHandler(this.asyncCopy_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(24, 212);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(579, 44);
            this.progress.TabIndex = 5;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // FileCopyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 294);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.asyncCopy);
            this.Controls.Add(this.destBrowse);
            this.Controls.Add(this.sourceBrowse);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.source);
            this.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FileCopyForm";
            this.Text = "File Copy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox source;
        private System.Windows.Forms.TextBox destination;
        private System.Windows.Forms.Button sourceBrowse;
        private System.Windows.Forms.Button destBrowse;
        private System.Windows.Forms.Button asyncCopy;
        private System.Windows.Forms.ProgressBar progress;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

