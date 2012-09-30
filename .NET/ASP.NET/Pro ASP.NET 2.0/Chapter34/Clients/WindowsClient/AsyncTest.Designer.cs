namespace WindowsClient
{
	partial class AsyncTest
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
			this.cmdGetEmployees = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.cmdCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// cmdGetEmployees
			// 
			this.cmdGetEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdGetEmployees.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdGetEmployees.Location = new System.Drawing.Point(300, 269);
			this.cmdGetEmployees.Name = "cmdGetEmployees";
			this.cmdGetEmployees.Size = new System.Drawing.Size(96, 28);
			this.cmdGetEmployees.TabIndex = 3;
			this.cmdGetEmployees.Text = "Get Employees";
			this.cmdGetEmployees.Click += new System.EventHandler(this.cmdGetEmployees_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.Location = new System.Drawing.Point(7, 7);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(491, 259);
			this.dataGridView1.TabIndex = 4;
			this.dataGridView1.Text = "dataGridView1";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.Enabled = false;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancel.Location = new System.Drawing.Point(402, 269);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(96, 28);
			this.cmdCancel.TabIndex = 5;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(508, 307);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.cmdGetEmployees);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "Form1";
			this.Text = "EmployeesService Client";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button cmdGetEmployees;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button cmdCancel;
	}
}

