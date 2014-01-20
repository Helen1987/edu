using Cipher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockCipher
{
	public partial class BlockCiphers : Form
	{
		public BlockCiphers()
		{
			InitializeComponent();
		}

		private void btnEncrypt_Click(object sender, EventArgs e)
		{
			txtCipherHex.Text = CBC.EncryptMessage(txtMessage.Text);
		}

		private void btnDecrypt_Click(object sender, EventArgs e)
		{
			txtMessage.Text = AESModeCBC.DecryptMessage(txtCipherHex.Text, 
				CipherHelper.ConvertFromHexString(txtKey.Text).ToArray<byte>());
		}
	}
}
