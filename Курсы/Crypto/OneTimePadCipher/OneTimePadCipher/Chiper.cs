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

namespace OneTimePadCipher
{
	public partial class Cipher : Form
	{
		public Cipher()
		{
			InitializeComponent();
		}

		private void btnDecode_Click(object sender, EventArgs e)
		{
			txtStringValue.Text = CipherHelper.HexString2Ascii(txtEncodedString.Text).ToString();
			txtDecodedClearLetters.Text = FindClearLetters(txtStringValue.Text, txtEncodedString.Text);
		}

		private void btnEncode_Click(object sender, EventArgs e)
		{
			txtEncodedString.Text = CipherHelper.GetASCIIHexValues(txtStringValue.Text);
		}

		private void btnEncrypt_Click(object sender, EventArgs e)
		{
			string[] result = CipherHelper.GetTheSameLength(txtMessage.Text, txtKey.Text);
			string hex;
			txtCipher.Text = CipherHelper.Xor(result[0], result[1], out hex);
			txtCipherHex.Text = hex;
			labelClearLetters.Text = FindClearLetters(txtCipher.Text, hex);
		}

		private string FindClearLetters(string decodedString, string hex)
		{
			string result = String.Empty;
			for (var i = 0; i < decodedString.Length; ++i)
			{
				if (Char.IsLetter(decodedString[i]))
				{
					result += string.Format("{0}-{1}-{2} ", i, decodedString[i],
						hex.Substring(i * 2, 2));
				}
			}
			return result;
		}

		private void btnDecrypt_Click(object sender, EventArgs e)
		{
			string[] result = CipherHelper.GetTheSameLength(txtCipherHex.Text, txtKey.Text);
			string hex;
			var asciiString = CipherHelper.Xor(result[0], result[1], out hex);
			txtMessage.Text = hex;
		}

		private void btnCalculateKey_Click(object sender, EventArgs e)
		{
			var cipher = new OneTimePad();
			cipher.CalculateKeyByDecodedCipherTexts();
			txtExpectedKey.Text = cipher.GetKeyByProbability();
		}

		private void btnCalculateKeyByXor_Click(object sender, EventArgs e)
		{
			var cipher = new OneTimePad();
			cipher.CalculateXors();
			cipher.CalculateKeyBySpace();
			txtExpectedKey.Text = cipher.GetKeyByProbability();
		}
	}
}
