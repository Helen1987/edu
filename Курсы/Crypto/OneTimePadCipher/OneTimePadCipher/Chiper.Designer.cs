namespace OneTimePadCipher
{
	partial class Cipher
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
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.groupBoxHex = new System.Windows.Forms.GroupBox();
			this.txtDecodedClearLetters = new System.Windows.Forms.TextBox();
			this.btnEncode = new System.Windows.Forms.Button();
			this.txtStringValue = new System.Windows.Forms.TextBox();
			this.lblStringValue = new System.Windows.Forms.Label();
			this.lblHexString = new System.Windows.Forms.Label();
			this.btnDecode = new System.Windows.Forms.Button();
			this.txtEncodedString = new System.Windows.Forms.TextBox();
			this.groupBoxXor = new System.Windows.Forms.GroupBox();
			this.labelClearLetters = new System.Windows.Forms.TextBox();
			this.txtCipherHex = new System.Windows.Forms.TextBox();
			this.labelCipherHEX = new System.Windows.Forms.Label();
			this.labelKey = new System.Windows.Forms.Label();
			this.txtKey = new System.Windows.Forms.TextBox();
			this.btnDecrypt = new System.Windows.Forms.Button();
			this.txtCipher = new System.Windows.Forms.TextBox();
			this.labelCipher = new System.Windows.Forms.Label();
			this.lblMessage = new System.Windows.Forms.Label();
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.btnCalculateKey = new System.Windows.Forms.Button();
			this.txtExpectedKey = new System.Windows.Forms.TextBox();
			this.btnCalculateKeyByXor = new System.Windows.Forms.Button();
			this.groupBoxHex.SuspendLayout();
			this.groupBoxXor.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxHex
			// 
			this.groupBoxHex.Controls.Add(this.txtDecodedClearLetters);
			this.groupBoxHex.Controls.Add(this.btnEncode);
			this.groupBoxHex.Controls.Add(this.txtStringValue);
			this.groupBoxHex.Controls.Add(this.lblStringValue);
			this.groupBoxHex.Controls.Add(this.lblHexString);
			this.groupBoxHex.Controls.Add(this.btnDecode);
			this.groupBoxHex.Controls.Add(this.txtEncodedString);
			this.groupBoxHex.Location = new System.Drawing.Point(12, 12);
			this.groupBoxHex.Name = "groupBoxHex";
			this.groupBoxHex.Size = new System.Drawing.Size(610, 349);
			this.groupBoxHex.TabIndex = 1;
			this.groupBoxHex.TabStop = false;
			this.groupBoxHex.Text = "HEX operations";
			// 
			// txtDecodedClearLetters
			// 
			this.txtDecodedClearLetters.Location = new System.Drawing.Point(101, 217);
			this.txtDecodedClearLetters.Multiline = true;
			this.txtDecodedClearLetters.Name = "txtDecodedClearLetters";
			this.txtDecodedClearLetters.ReadOnly = true;
			this.txtDecodedClearLetters.Size = new System.Drawing.Size(482, 82);
			this.txtDecodedClearLetters.TabIndex = 18;
			// 
			// btnEncode
			// 
			this.btnEncode.Location = new System.Drawing.Point(338, 320);
			this.btnEncode.Name = "btnEncode";
			this.btnEncode.Size = new System.Drawing.Size(75, 23);
			this.btnEncode.TabIndex = 11;
			this.btnEncode.Text = "Encode";
			this.btnEncode.UseVisualStyleBackColor = true;
			this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
			// 
			// txtStringValue
			// 
			this.txtStringValue.Location = new System.Drawing.Point(101, 129);
			this.txtStringValue.Multiline = true;
			this.txtStringValue.Name = "txtStringValue";
			this.txtStringValue.Size = new System.Drawing.Size(482, 73);
			this.txtStringValue.TabIndex = 10;
			// 
			// lblStringValue
			// 
			this.lblStringValue.AutoSize = true;
			this.lblStringValue.Location = new System.Drawing.Point(21, 132);
			this.lblStringValue.Name = "lblStringValue";
			this.lblStringValue.Size = new System.Drawing.Size(66, 13);
			this.lblStringValue.TabIndex = 9;
			this.lblStringValue.Text = "String value:";
			// 
			// lblHexString
			// 
			this.lblHexString.AutoSize = true;
			this.lblHexString.Location = new System.Drawing.Point(21, 39);
			this.lblHexString.Name = "lblHexString";
			this.lblHexString.Size = new System.Drawing.Size(61, 13);
			this.lblHexString.TabIndex = 8;
			this.lblHexString.Text = "HEX value:";
			// 
			// btnDecode
			// 
			this.btnDecode.Location = new System.Drawing.Point(195, 320);
			this.btnDecode.Name = "btnDecode";
			this.btnDecode.Size = new System.Drawing.Size(75, 23);
			this.btnDecode.TabIndex = 7;
			this.btnDecode.Text = "Decode";
			this.btnDecode.UseVisualStyleBackColor = true;
			this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
			// 
			// txtEncodedString
			// 
			this.txtEncodedString.Location = new System.Drawing.Point(101, 36);
			this.txtEncodedString.Multiline = true;
			this.txtEncodedString.Name = "txtEncodedString";
			this.txtEncodedString.Size = new System.Drawing.Size(482, 73);
			this.txtEncodedString.TabIndex = 6;
			// 
			// groupBoxXor
			// 
			this.groupBoxXor.Controls.Add(this.labelClearLetters);
			this.groupBoxXor.Controls.Add(this.txtCipherHex);
			this.groupBoxXor.Controls.Add(this.labelCipherHEX);
			this.groupBoxXor.Controls.Add(this.labelKey);
			this.groupBoxXor.Controls.Add(this.txtKey);
			this.groupBoxXor.Controls.Add(this.btnDecrypt);
			this.groupBoxXor.Controls.Add(this.txtCipher);
			this.groupBoxXor.Controls.Add(this.labelCipher);
			this.groupBoxXor.Controls.Add(this.lblMessage);
			this.groupBoxXor.Controls.Add(this.btnEncrypt);
			this.groupBoxXor.Controls.Add(this.txtMessage);
			this.groupBoxXor.Location = new System.Drawing.Point(12, 367);
			this.groupBoxXor.Name = "groupBoxXor";
			this.groupBoxXor.Size = new System.Drawing.Size(610, 530);
			this.groupBoxXor.TabIndex = 12;
			this.groupBoxXor.TabStop = false;
			this.groupBoxXor.Text = "XOR operations";
			// 
			// labelClearLetters
			// 
			this.labelClearLetters.Location = new System.Drawing.Point(125, 412);
			this.labelClearLetters.Multiline = true;
			this.labelClearLetters.Name = "labelClearLetters";
			this.labelClearLetters.ReadOnly = true;
			this.labelClearLetters.Size = new System.Drawing.Size(458, 73);
			this.labelClearLetters.TabIndex = 17;
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
			// txtCipher
			// 
			this.txtCipher.Location = new System.Drawing.Point(125, 231);
			this.txtCipher.Multiline = true;
			this.txtCipher.Name = "txtCipher";
			this.txtCipher.Size = new System.Drawing.Size(458, 73);
			this.txtCipher.TabIndex = 10;
			// 
			// labelCipher
			// 
			this.labelCipher.AutoSize = true;
			this.labelCipher.Location = new System.Drawing.Point(21, 234);
			this.labelCipher.Name = "labelCipher";
			this.labelCipher.Size = new System.Drawing.Size(91, 13);
			this.labelCipher.TabIndex = 9;
			this.labelCipher.Text = "Cipher text (HEX):";
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
			// btnCalculateKey
			// 
			this.btnCalculateKey.Location = new System.Drawing.Point(645, 412);
			this.btnCalculateKey.Name = "btnCalculateKey";
			this.btnCalculateKey.Size = new System.Drawing.Size(95, 53);
			this.btnCalculateKey.TabIndex = 18;
			this.btnCalculateKey.Text = "Calculate key By Decoded Message";
			this.btnCalculateKey.UseVisualStyleBackColor = true;
			this.btnCalculateKey.Click += new System.EventHandler(this.btnCalculateKey_Click);
			// 
			// txtExpectedKey
			// 
			this.txtExpectedKey.Location = new System.Drawing.Point(756, 403);
			this.txtExpectedKey.Multiline = true;
			this.txtExpectedKey.Name = "txtExpectedKey";
			this.txtExpectedKey.ReadOnly = true;
			this.txtExpectedKey.Size = new System.Drawing.Size(343, 317);
			this.txtExpectedKey.TabIndex = 18;
			// 
			// btnCalculateKeyByXor
			// 
			this.btnCalculateKeyByXor.Location = new System.Drawing.Point(645, 471);
			this.btnCalculateKeyByXor.Name = "btnCalculateKeyByXor";
			this.btnCalculateKeyByXor.Size = new System.Drawing.Size(95, 43);
			this.btnCalculateKeyByXor.TabIndex = 19;
			this.btnCalculateKeyByXor.Text = "Calculate key by XOR";
			this.btnCalculateKeyByXor.UseVisualStyleBackColor = true;
			this.btnCalculateKeyByXor.Click += new System.EventHandler(this.btnCalculateKeyByXor_Click);
			// 
			// Cipher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1140, 901);
			this.Controls.Add(this.btnCalculateKeyByXor);
			this.Controls.Add(this.txtExpectedKey);
			this.Controls.Add(this.btnCalculateKey);
			this.Controls.Add(this.groupBoxXor);
			this.Controls.Add(this.groupBoxHex);
			this.Name = "Cipher";
			this.Text = "One Time Pad";
			this.groupBoxHex.ResumeLayout(false);
			this.groupBoxHex.PerformLayout();
			this.groupBoxXor.ResumeLayout(false);
			this.groupBoxXor.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.GroupBox groupBoxHex;
		private System.Windows.Forms.Button btnEncode;
		private System.Windows.Forms.TextBox txtStringValue;
		private System.Windows.Forms.Label lblStringValue;
		private System.Windows.Forms.Label lblHexString;
		private System.Windows.Forms.Button btnDecode;
		private System.Windows.Forms.TextBox txtEncodedString;
		private System.Windows.Forms.GroupBox groupBoxXor;
		private System.Windows.Forms.Label labelKey;
		private System.Windows.Forms.TextBox txtKey;
		private System.Windows.Forms.Button btnDecrypt;
		private System.Windows.Forms.TextBox txtCipher;
		private System.Windows.Forms.Label labelCipher;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Button btnEncrypt;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.TextBox txtCipherHex;
		private System.Windows.Forms.Label labelCipherHEX;
		private System.Windows.Forms.TextBox labelClearLetters;
		private System.Windows.Forms.TextBox txtDecodedClearLetters;
		private System.Windows.Forms.Button btnCalculateKey;
		private System.Windows.Forms.TextBox txtExpectedKey;
		private System.Windows.Forms.Button btnCalculateKeyByXor;
	}
}

