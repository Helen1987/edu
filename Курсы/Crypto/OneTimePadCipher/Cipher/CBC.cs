using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
	public class CBC
	{
		private const int blockSize = 16;

		public static string EncryptMessage(string message){
			// generate random 16-byte IV
			//var IV = new byte[blockSize];
			//rngCsp.GetBytes(IV);

			var cipherBytes = new byte[blockSize + message.Length];
			// CBC encryption
			var messageBytes = CipherHelper.GetASCIIValues(message);
			//var tempArray = new byte[blockSize];
			// 1. first step of CBC:
			// XOR IV and first 16-bytes of message
			//messageBytes.CopyTo(tempArray, 0);
			//var blockToEncrypt = CipherHelper.Xor(IV, tempArray);
			using (var aesAlg = Aes.Create())
			{
				aesAlg.Mode = CipherMode.CBC;
				aesAlg.KeySize = 128;
				using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)) {
					using (MemoryStream memStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
						{
							cryptoStream.Write(messageBytes, 0, messageBytes.Length);
							cryptoStream.FlushFinalBlock();
							cipherBytes = memStream.ToArray();
						}
					}
				}
			}

			return CipherHelper.GetHexValue(cipherBytes);
		}

		public static string DecryptMessage(string message, string key)
		{
			var textBytes = new byte[message.Length-blockSize];
			// CBC encryption
			var cipherBytes = CipherHelper.ConvertFromHexString(message).ToArray<byte>();
			var keyBytes = CipherHelper.ConvertFromHexString(key).ToArray<byte>();

			using (var aesAlg = Aes.Create())
			{
				aesAlg.Mode = CipherMode.CBC;
				aesAlg.KeySize = 128;
				aesAlg.Padding = PaddingMode.PKCS7;
				aesAlg.Key = keyBytes;
				using (ICryptoTransform decryptor = aesAlg.CreateDecryptor())
				{
					using (MemoryStream memStream = new MemoryStream(cipherBytes))
					{
						using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
						{
							cryptoStream.Read(textBytes, 0, textBytes.Length);
						}
					}
				}
			}

			return CipherHelper.GetASCIIString(cipherBytes);
		}
	}
}
