namespace DigitalLog
{
	partial class DigitalLog
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
			this.textBoxP = new System.Windows.Forms.TextBox();
			this.textBoxG = new System.Windows.Forms.TextBox();
			this.textBoxH = new System.Windows.Forms.TextBox();
			this.labelP = new System.Windows.Forms.Label();
			this.labelG = new System.Windows.Forms.Label();
			this.labelH = new System.Windows.Forms.Label();
			this.labelResult = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonFind = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxP
			// 
			this.textBoxP.Location = new System.Drawing.Point(58, 73);
			this.textBoxP.Multiline = true;
			this.textBoxP.Name = "textBoxP";
			this.textBoxP.Size = new System.Drawing.Size(579, 90);
			this.textBoxP.TabIndex = 0;
			// 
			// textBoxG
			// 
			this.textBoxG.Location = new System.Drawing.Point(58, 180);
			this.textBoxG.Multiline = true;
			this.textBoxG.Name = "textBoxG";
			this.textBoxG.Size = new System.Drawing.Size(579, 90);
			this.textBoxG.TabIndex = 1;
			// 
			// textBoxH
			// 
			this.textBoxH.Location = new System.Drawing.Point(58, 288);
			this.textBoxH.Multiline = true;
			this.textBoxH.Name = "textBoxH";
			this.textBoxH.Size = new System.Drawing.Size(579, 90);
			this.textBoxH.TabIndex = 2;
			// 
			// labelP
			// 
			this.labelP.AutoSize = true;
			this.labelP.Location = new System.Drawing.Point(36, 76);
			this.labelP.Name = "labelP";
			this.labelP.Size = new System.Drawing.Size(16, 13);
			this.labelP.TabIndex = 3;
			this.labelP.Text = "p:";
			// 
			// labelG
			// 
			this.labelG.AutoSize = true;
			this.labelG.Location = new System.Drawing.Point(36, 183);
			this.labelG.Name = "labelG";
			this.labelG.Size = new System.Drawing.Size(16, 13);
			this.labelG.TabIndex = 4;
			this.labelG.Text = "g:";
			// 
			// labelH
			// 
			this.labelH.AutoSize = true;
			this.labelH.Location = new System.Drawing.Point(36, 291);
			this.labelH.Name = "labelH";
			this.labelH.Size = new System.Drawing.Size(16, 13);
			this.labelH.TabIndex = 5;
			this.labelH.Text = "h:";
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Location = new System.Drawing.Point(36, 422);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(40, 13);
			this.labelResult.TabIndex = 7;
			this.labelResult.Text = "Result:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(82, 419);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(555, 90);
			this.textBox1.TabIndex = 6;
			// 
			// buttonFind
			// 
			this.buttonFind.Location = new System.Drawing.Point(308, 530);
			this.buttonFind.Name = "buttonFind";
			this.buttonFind.Size = new System.Drawing.Size(75, 23);
			this.buttonFind.TabIndex = 8;
			this.buttonFind.Text = "Find";
			this.buttonFind.UseVisualStyleBackColor = true;
			this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
			// 
			// DigitalLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(699, 575);
			this.Controls.Add(this.buttonFind);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.labelH);
			this.Controls.Add(this.labelG);
			this.Controls.Add(this.labelP);
			this.Controls.Add(this.textBoxH);
			this.Controls.Add(this.textBoxG);
			this.Controls.Add(this.textBoxP);
			this.Name = "DigitalLog";
			this.Text = "Digital Log";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxP;
		private System.Windows.Forms.TextBox textBoxG;
		private System.Windows.Forms.TextBox textBoxH;
		private System.Windows.Forms.Label labelP;
		private System.Windows.Forms.Label labelG;
		private System.Windows.Forms.Label labelH;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button buttonFind;
	}
}

