namespace PaddingAttack
{
	partial class Attacker
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
			this.labelUrl = new System.Windows.Forms.Label();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.textBoxCiphertext = new System.Windows.Forms.TextBox();
			this.labelCiphertext = new System.Windows.Forms.Label();
			this.textBoxResult = new System.Windows.Forms.TextBox();
			this.labelResult = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// labelUrl
			// 
			this.labelUrl.AutoSize = true;
			this.labelUrl.Location = new System.Drawing.Point(71, 47);
			this.labelUrl.Name = "labelUrl";
			this.labelUrl.Size = new System.Drawing.Size(23, 13);
			this.labelUrl.TabIndex = 0;
			this.labelUrl.Text = "Url:";
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Location = new System.Drawing.Point(133, 44);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.Size = new System.Drawing.Size(468, 20);
			this.textBoxUrl.TabIndex = 1;
			this.textBoxUrl.Text = "http://crypto-class.appspot.com/po?er=";
			// 
			// textBoxCiphertext
			// 
			this.textBoxCiphertext.Location = new System.Drawing.Point(133, 80);
			this.textBoxCiphertext.Multiline = true;
			this.textBoxCiphertext.Name = "textBoxCiphertext";
			this.textBoxCiphertext.Size = new System.Drawing.Size(468, 63);
			this.textBoxCiphertext.TabIndex = 3;
			this.textBoxCiphertext.Text = "f20bdba6ff29eed7b046d1df9fb7000058b1ffb4210a580f748b4ac714c001bd4a61044426fb515da" +
    "d3f21f18aa577c0bdf302936266926ff37dbf7035d5eeb4";
			// 
			// labelCiphertext
			// 
			this.labelCiphertext.AutoSize = true;
			this.labelCiphertext.Location = new System.Drawing.Point(37, 83);
			this.labelCiphertext.Name = "labelCiphertext";
			this.labelCiphertext.Size = new System.Drawing.Size(57, 13);
			this.labelCiphertext.TabIndex = 2;
			this.labelCiphertext.Text = "Ciphertext:";
			// 
			// textBoxResult
			// 
			this.textBoxResult.Location = new System.Drawing.Point(133, 166);
			this.textBoxResult.Multiline = true;
			this.textBoxResult.Name = "textBoxResult";
			this.textBoxResult.Size = new System.Drawing.Size(468, 63);
			this.textBoxResult.TabIndex = 5;
			this.textBoxResult.Text = "f20bdba6ff29eed7b046d1df9fb7000058b1ffb4210a580f748b4ac714c001bd4a61044426fb515da" +
    "d3f21f18aa577c0bdf302936266926ff37dbf7035d5eeb4";
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Location = new System.Drawing.Point(37, 169);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(40, 13);
			this.labelResult.TabIndex = 4;
			this.labelResult.Text = "Result:";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(282, 273);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(75, 23);
			this.buttonStart.TabIndex = 6;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// Attacker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 340);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.textBoxResult);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.textBoxCiphertext);
			this.Controls.Add(this.labelCiphertext);
			this.Controls.Add(this.textBoxUrl);
			this.Controls.Add(this.labelUrl);
			this.Name = "Attacker";
			this.Text = "Padding attack";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelUrl;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.TextBox textBoxCiphertext;
		private System.Windows.Forms.Label labelCiphertext;
		private System.Windows.Forms.TextBox textBoxResult;
		private System.Windows.Forms.Label labelResult;
		private System.Windows.Forms.Button buttonStart;
	}
}

