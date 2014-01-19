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
			this.txtCipherText = new System.Windows.Forms.TextBox();
			this.labelCipherText = new System.Windows.Forms.Label();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.groupBoxXor.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxXor
			// 
			this.groupBoxXor.Controls.Add(this.txtCipherHex);
			this.groupBoxXor.Controls.Add(this.labelCipherHEX);
			this.groupBoxXor.Controls.Add(this.labelKey);
			this.groupBoxXor.Controls.Add(this.txtKey);
			this.groupBoxXor.Controls.Add(this.btnDecrypt);
			this.groupBoxXor.Controls.Add(this.txtCipherText);
			this.groupBoxXor.Controls.Add(this.labelCipherText);
			this.groupBoxXor.Controls.Add(this.lblMessage);
			this.groupBoxXor.Controls.Add(this.btnEncrypt);
			this.groupBoxXor.Controls.Add(this.txtMessage);
			this.groupBoxXor.Location = new System.Drawing.Point(25, 24);
			this.groupBoxXor.Name = "groupBoxXor";
			this.groupBoxXor.Size = new System.Drawing.Size(610, 530);
			this.groupBoxXor.TabIndex = 13;
			this.groupBoxXor.TabStop = false;
			this.groupBoxXor.Text = "XOR operations";
			// 
			// txtCipherHex
			// 
			this.txtCipherHex.Location = new System.Drawing.Point(125, 324);
			this.txtCipherHex.Multiline = true;
			this.txtCipherHex.Name = "txtCipherHex";
			this.txtCipherHex.Size = new System.Drawing.Size(458, 73);
			this.txtCipherHex.TabIndex = 15;
			// 
			// labelCipherHEX
			// 
			this.labelCipherHEX.AutoSize = true;
			this.labelCipherHEX.Location = new System.Drawing.Point(21, 327);
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
			this.btnDecrypt.Location = new System.Drawing.Point(338, 501);
			this.btnDecrypt.Name = "btnDecrypt";
			this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
			this.btnDecrypt.TabIndex = 11;
			this.btnDecrypt.Text = "Decrypt";
			this.btnDecrypt.UseVisualStyleBackColor = true;
			this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
			// 
			// txtCipherText
			// 
			this.txtCipherText.Location = new System.Drawing.Point(125, 231);
			this.txtCipherText.Multiline = true;
			this.txtCipherText.Name = "txtCipherText";
			this.txtCipherText.Size = new System.Drawing.Size(458, 73);
			this.txtCipherText.TabIndex = 10;
			// 
			// labelCipherText
			// 
			this.labelCipherText.AutoSize = true;
			this.labelCipherText.Location = new System.Drawing.Point(21, 234);
			this.labelCipherText.Name = "labelCipherText";
			this.labelCipherText.Size = new System.Drawing.Size(86, 13);
			this.labelCipherText.TabIndex = 9;
			this.labelCipherText.Text = "Cipher text (text):";
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
			this.btnEncrypt.Location = new System.Drawing.Point(195, 501);
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
			// BlockCiphers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 585);
			this.Controls.Add(this.groupBoxXor);
			this.Name = "BlockCiphers";
			this.Text = "Block Ciphers";
			this.groupBoxXor.ResumeLayout(false);
			this.groupBoxXor.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBoxXor;
		private System.Windows.Forms.TextBox txtCipherHex;
		private System.Windows.Forms.Label labelCipherHEX;
		private System.Windows.Forms.Label labelKey;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Button btnDecrypt;
		private System.Windows.Forms.TextBox txtCipherText;
		private System.Windows.Forms.Label labelCipherText;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Button btnEncrypt;
		private System.Windows.Forms.TextBox txtMessage;
	}
}

