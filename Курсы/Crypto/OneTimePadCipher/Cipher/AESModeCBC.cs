using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
	public class AESModeCBC
	{
		private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
		private const int blockSize = 16;
		private static byte[] cipherBytes;

		public static string EncryptMessage(string message)
		{
			// generate random 16-byte IV
			var IV = new byte[blockSize];
			rngCsp.GetBytes(IV);

			cipherBytes = new byte[blockSize + message.Length];
			// first 16 byte of ciphertext is IV
			IV.CopyTo(cipherBytes, blockSize);

			// CBC encryption
			var messageBytes = CipherHelper.GetASCIIValues(message);
			var tempArray = new byte[blockSize];
			// 1. first step of CBC:
			// XOR IV and first 16-bytes of message
			messageBytes.CopyTo(tempArray, 0);
			var blockToEncrypt = CipherHelper.Xor(IV, tempArray);

			using (var aesAlg = Aes.Create())
			{
				aesAlg.Mode = CipherMode.ECB;
				aesAlg.KeySize = 128;
				aesAlg.BlockSize = 128;

				using (ICryptoTransform encryptor = aesAlg.CreateEncryptor())
				{
					using (MemoryStream memStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
						{
							AppendNewCipherText(cryptoStream, blockToEncrypt, memStream, blockSize);
							for (var i = 0; i < message.Length / blockSize - 1; ++i) {
								messageBytes.CopyTo(tempArray, blockSize* (i + 1));
								IV = 
								blockToEncrypt = CipherHelper.Xor(IV, tempArray);
							}
						}
					}
				}
			}

			return CipherHelper.GetHexValue(cipherBytes);
		}

		private static void AppendNewCipherText(CryptoStream cryptoStream, byte[] blockToEncrypt, 
			MemoryStream memStream, int position)
		{
			cryptoStream.Write(blockToEncrypt, 0, blockSize);
			cryptoStream.FlushFinalBlock();
			byte[] cipherBlock = memStream.ToArray();
			cipherBlock.CopyTo(cipherBytes, position);
		}
	}
}
