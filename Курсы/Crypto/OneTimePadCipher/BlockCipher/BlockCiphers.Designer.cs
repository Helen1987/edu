namespace BlockCipher
{
	partial class BlockCiphers
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
			this.groupBoxXor = new System.Windows.Forms.GroupBox();
			this.txtCipherHex = new System.Windows.Forms.TextBox();
			this.labelCipherHEX = new System.Windows.Forms.Label();
			this.labelKey = new System.Windows.Forms.Label();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.btnDecrypt = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textCTRCipher = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textCTRKey = new System.Windows.Forms.TextBox();
			this.buttonCTRDecypt = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonCTREncrypt = new System.Windows.Forms.Button();
			this.textCTRText = new System.Windows.Forms.TextBox();
			this.groupBoxXor.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxXor
			// 
			this.groupBoxXor.Controls.Add(this.txtCipherHex);
			this.groupBoxXor.Controls.Add(this.labelCipherHEX);
			this.groupBoxXor.Controls.Add(this.labelKey);
			this.groupBoxXor.Controls.Add(this.txtKey);
			this.groupBoxXor.Controls.Add(this.btnDecrypt);
			this.groupBoxXor.Controls.Add(this.lblMessage);
			this.groupBoxXor.Controls.Add(this.btnEncrypt);
			this.groupBoxXor.Controls.Add(this.txtMessage);
			this.groupBoxXor.Location = new System.Drawing.Point(25, 24);
			this.groupBoxXor.Name = "groupBoxXor";
			this.groupBoxXor.Size = new System.Drawing.Size(610, 351);
			this.groupBoxXor.TabIndex = 13;
			this.groupBoxXor.TabStop = false;
			this.groupBoxXor.Text = "CBC";
			// 
			// txtCipherHex
			// 
			this.txtCipherHex.Location = new System.Drawing.Point(125, 226);
			this.txtCipherHex.Multiline = true;
			this.txtCipherHex.Name = "txtCipherHex";
			this.txtCipherHex.Size = new System.Drawing.Size(458, 73);
			this.txtCipherHex.TabIndex = 15;
			// 
			// labelCipherHEX
			// 
			this.labelCipherHEX.AutoSize = true;
			this.labelCipherHEX.Location = new System.Drawing.Point(21, 229);
			this.labelCipherHEX.Name = "labelCipherHEX";
			this.labelCipherHEX.Size = new System.Drawing.Size(91, 13);
			this.labelCipherHEX.TabIndex = 14;
			this.labelCipherHEX.Text = "Cipher text (HEX):";
			// 
			// labelKey
			// 
			this.labelKey.AutoSize = true;
			this.labelKey.Location = new System.Drawing.Point(21, 134);
			this.labelKey.Name = "labelKey";
			this.labelKey.Size = new System.Drawing.Size(88, 13);
			this.labelKey.TabIndex = 13;
			this.labelKey.Text = "Key value (HEX):";
			// 
			// txtKey
			// 
			this.txtKey.Location = new System.Drawing.Point(125, 131);
			this.txtKey.Multiline = true;
			this.txtKey.Name = "txtKey";
			this.txtKey.Size = new System.Drawing.Size(458, 73);
			this.txtKey.TabIndex = 12;
			// 
			// btnDecrypt
			// 
			this.btnDecrypt.Location = new System.Drawing.Point(382, 318);
			this.btnDecrypt.Name = "btnDecrypt";
			this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
			this.btnDecrypt.TabIndex = 11;
			this.btnDecrypt.Text = "Decrypt";
			this.btnDecrypt.UseVisualStyleBackColor = true;
			this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.Location = new System.Drawing.Point(6, 39);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(113, 13);
			this.lblMessage.TabIndex = 8;
			this.lblMessage.Text = "Message value (HEX):";
			// 
			// btnEncrypt
			// 
			this.btnEncrypt.Location = new System.Drawing.Point(239, 318);
			this.btnEncrypt.Name = "btnEncrypt";
			this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
			this.btnEncrypt.TabIndex = 7;
			this.btnEncrypt.Text = "Encrypt";
			this.btnEncrypt.UseVisualStyleBackColor = true;
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			// 
			// txtMessage
			// 
			this.txtMessage.Location = new System.Drawing.Point(125, 36);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.Size = new System.Drawing.Size(458, 73);
			this.txtMessage.TabIndex = 6;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textCTRCipher);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textCTRKey);
			this.groupBox1.Controls.Add(this.buttonCTRDecypt);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.buttonCTREncrypt);
			this.groupBox1.Controls.Add(this.textCTRText);
			this.groupBox1.Location = new System.Drawing.Point(25, 399);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(610, 351);
			this.groupBox1.TabIndex = 16;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "CTR";
			// 
			// textCTRCipher
			// 
			this.textCTRCipher.Location = new System.Drawing.Point(125, 226);
			this.textCTRCipher.Multiline = true;
			this.textCTRCipher.Name = "textCTRCipher";
			this.textCTRCipher.Size = new System.Drawing.Size(458, 73);
			this.textCTRCipher.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(21, 229);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(91, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Cipher text (HEX):";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(21, 134);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Key value (HEX):";
			// 
			// textCTRKey
			// 
			this.textCTRKey.Location = new System.Drawing.Point(125, 131);
			this.textCTRKey.Multiline = true;
			this.textCTRKey.Name = "textCTRKey";
			this.textCTRKey.Size = new System.Drawing.Size(458, 73);
			this.textCTRKey.TabIndex = 12;
			// 
			// buttonCTRDecypt
			// 
			this.buttonCTRDecypt.Location = new System.Drawing.Point(382, 318);
			this.buttonCTRDecypt.Name = "buttonCTRDecypt";
			this.buttonCTRDecypt.Size = new System.Drawing.Size(75, 23);
			this.buttonCTRDecypt.TabIndex = 11;
			this.buttonCTRDecypt.Text = "Decrypt";
			this.buttonCTRDecypt.UseVisualStyleBackColor = true;
			this.buttonCTRDecypt.Click += new System.EventHandler(this.buttonCRTDecypt_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(113, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Message value (HEX):";
			// 
			// buttonCTREncrypt
			// 
			this.buttonCTREncrypt.Location = new System.Drawing.Point(239, 318);
			this.buttonCTREncrypt.Name = "buttonCTREncrypt";
			this.buttonCTREncrypt.Size = new System.Drawing.Size(75, 23);
			this.buttonCTREncrypt.TabIndex = 7;
			this.buttonCTREncrypt.Text = "Encrypt";
			this.buttonCTREncrypt.UseVisualStyleBackColor = true;
			// 
			// textCTRText
			// 
			this.textCTRText.Location = new System.Drawing.Point(125, 36);
			this.textCTRText.Multiline = true;
			this.textCTRText.Name = "textCTRText";
			this.textCTRText.Size = new System.Drawing.Size(458, 73);
			this.textCTRText.TabIndex = 6;
			// 
			// BlockCiphers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 755);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBoxXor);
			this.Name = "BlockCiphers";
			this.Text = "Block Ciphers";
			this.groupBoxXor.ResumeLayout(false);
			this.groupBoxXor.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxXor;
		private System.Windows.Forms.TextBox txtCipherHex;
		private System.Windows.Forms.Label labelCipherHEX;
		private System.Windows.Forms.Label labelKey;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Button btnDecrypt;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Button btnEncrypt;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textCTRCipher;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textCTRKey;
		private System.Windows.Forms.Button buttonCTRDecypt;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonCTREncrypt;
		private System.Windows.Forms.TextBox textCTRText;
	}
}

