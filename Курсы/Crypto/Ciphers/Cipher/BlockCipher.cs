using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
	public class AESBlockCipher
	{
		private const int blockSize = 16, keySize = 128;

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
				aesAlg.KeySize = keySize;
				
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

		public static string DecryptMessage(string message, byte[] key, CipherMode mode)
		{
			var cipherBytes = CipherHelper.ConvertFromHexString(message).ToArray<byte>();
			// first 16 bytes of cipher text is IV
			var IV = cipherBytes.Take<byte>(blockSize).ToArray<byte>();
			cipherBytes = cipherBytes.Skip<byte>(blockSize).ToArray<byte>();

			var textBytes = new byte[cipherBytes.Length];

			using (var aesAlg = Aes.Create())
			{
				aesAlg.Mode = mode;
				aesAlg.KeySize = keySize;
				aesAlg.Padding = PaddingMode.PKCS7;
				using(ICryptoTransform decryptor = aesAlg.CreateDecryptor(key, IV))
				{
					using(MemoryStream memStream = new MemoryStream(cipherBytes))
					{
						using(CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
						{
							using (var reader = new BinaryReader(cryptoStream))
							{
								textBytes = reader.ReadBytes(cipherBytes.Length);
							}
						}
					}
				}
			}

			return CipherHelper.GetASCIIString(textBytes);
		}
	}
}
