namespace HashedStreamVideo
{
	partial class SelectVideo
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
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.textBoxFileName = new System.Windows.Forms.TextBox();
			this.buttonComputeH0 = new System.Windows.Forms.Button();
			this.labelSelectFile = new System.Windows.Forms.Label();
			this.buttonSelectFile = new System.Windows.Forms.Button();
			this.labelH0 = new System.Windows.Forms.Label();
			this.textBoxExpected = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCompare = new System.Windows.Forms.Button();
			this.labelResult = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBoxFileName
			// 
			this.textBoxFileName.Location = new System.Drawing.Point(159, 56);
			this.textBoxFileName.Name = "textBoxFileName";
			this.textBoxFileName.Size = new System.Drawing.Size(249, 20);
			this.textBoxFileName.TabIndex = 0;
			// 
			// buttonComputeH0
			// 
			this.buttonComputeH0.Location = new System.Drawing.Point(204, 100);
			this.buttonComputeH0.Name = "buttonComputeH0";
			this.buttonComputeH0.Size = new System.Drawing.Size(75, 23);
			this.buttonComputeH0.TabIndex = 1;
			this.buttonComputeH0.Text = "Compute h0";
			this.buttonComputeH0.UseVisualStyleBackColor = true;
			this.buttonComputeH0.Click += new System.EventHandler(this.buttonComputeH0_Click);
			// 
			// labelSelectFile
			// 
			this.labelSelectFile.AutoSize = true;
			this.labelSelectFile.Location = new System.Drawing.Point(41, 59);
			this.labelSelectFile.Name = "labelSelectFile";
			this.labelSelectFile.Size = new System.Drawing.Size(65, 13);
			this.labelSelectFile.TabIndex = 2;
			this.labelSelectFile.Text = "Select a file:";
			// 
			// buttonSelectFile
			// 
			this.buttonSelectFile.Location = new System.Drawing.Point(414, 54);
			this.buttonSelectFile.Name = "buttonSelectFile";
			this.buttonSelectFile.Size = new System.Drawing.Size(25, 23);
			this.buttonSelectFile.TabIndex = 3;
			this.buttonSelectFile.Text = "...";
			this.buttonSelectFile.UseVisualStyleBackColor = true;
			this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
			// 
			// labelH0
			// 
			this.labelH0.AutoSize = true;
			this.labelH0.Location = new System.Drawing.Point(41, 171);
			this.labelH0.Name = "labelH0";
			this.labelH0.Size = new System.Drawing.Size(22, 13);
			this.labelH0.TabIndex = 4;
			this.labelH0.Text = "h0:";
			// 
			// textBoxExpected
			// 
			this.textBoxExpected.Location = new System.Drawing.Point(110, 204);
			this.textBoxExpected.Name = "textBoxExpected";
			this.textBoxExpected.Size = new System.Drawing.Size(562, 20);
			this.textBoxExpected.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 207);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Expected:";
			// 
			// buttonCompare
			// 
			this.buttonCompare.Location = new System.Drawing.Point(333, 241);
			this.buttonCompare.Name = "buttonCompare";
			this.buttonCompare.Size = new System.Drawing.Size(75, 23);
			this.buttonCompare.TabIndex = 8;
			this.buttonCompare.Text = "Compare";
			this.buttonCompare.UseVisualStyleBackColor = true;
			this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
			// 
			// labelResult
			// 
			this.labelResult.Location = new System.Drawing.Point(110, 168);
			this.labelResult.Name = "labelResult";
			this.labelResult.ReadOnly = true;
			this.labelResult.Size = new System.Drawing.Size(562, 20);
			this.labelResult.TabIndex = 9;
			// 
			// SelectVideo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(832, 291);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.buttonCompare);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxExpected);
			this.Controls.Add(this.labelH0);
			this.Controls.Add(this.buttonSelectFile);
			this.Controls.Add(this.labelSelectFile);
			this.Controls.Add(this.buttonComputeH0);
			this.Controls.Add(this.textBoxFileName);
			this.Name = "SelectVideo";
			this.Text = "Select Video";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.TextBox textBoxFileName;
		private System.Windows.Forms.Button buttonComputeH0;
		private System.Windows.Forms.Label labelSelectFile;
		private System.Windows.Forms.Button buttonSelectFile;
		private System.Windows.Forms.Label labelH0;
		private System.Windows.Forms.TextBox textBoxExpected;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCompare;
		private System.Windows.Forms.TextBox labelResult;
	}
}

