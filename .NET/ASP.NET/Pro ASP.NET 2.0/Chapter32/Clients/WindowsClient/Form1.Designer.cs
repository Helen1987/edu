namespace WindowsClient
{
	partial class Form1
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.cmdGetData = new System.Windows.Forms.Button();
			this.cmdTestStateRight = new System.Windows.Forms.Button();
			this.cmdTestStateWrong = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(463, 331);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.Text = "dataGridView1";
			// 
			// cmdGetData
			// 
			this.cmdGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdGetData.Location = new System.Drawing.Point(390, 338);
			this.cmdGetData.Name = "cmdGetData";
			this.cmdGetData.Size = new System.Drawing.Size(75, 29);
			this.cmdGetData.TabIndex = 1;
			this.cmdGetData.Text = "Get Data";
			this.cmdGetData.Click += new System.EventHandler(this.cmdGetData_Click);
			// 
			// cmdTestStateRight
			// 
			this.cmdTestStateRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdTestStateRight.Location = new System.Drawing.Point(3, 338);
			this.cmdTestStateRight.Name = "cmdTestStateRight";
			this.cmdTestStateRight.Size = new System.Drawing.Size(138, 29);
			this.cmdTestStateRight.TabIndex = 2;
			this.cmdTestStateRight.Text = "Test State (Successful)";
			this.cmdTestStateRight.Click += new System.EventHandler(this.cmdTestStateRight_Click);
			// 
			// cmdTestStateWrong
			// 
			this.cmdTestStateWrong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdTestStateWrong.Location = new System.Drawing.Point(147, 338);
			this.cmdTestStateWrong.Name = "cmdTestStateWrong";
			this.cmdTestStateWrong.Size = new System.Drawing.Size(138, 29);
			this.cmdTestStateWrong.TabIndex = 3;
			this.cmdTestStateWrong.Text = "Test State (Unsuccessful)";
			this.cmdTestStateWrong.Click += new System.EventHandler(this.cmdTestStateWrong_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(469, 372);
			this.Controls.Add(this.cmdTestStateWrong);
			this.Controls.Add(this.cmdTestStateRight);
			this.Controls.Add(this.cmdGetData);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button cmdGetData;
		private System.Windows.Forms.Button cmdTestStateRight;
		private System.Windows.Forms.Button cmdTestStateWrong;
	}
}
