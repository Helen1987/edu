using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
	public class AESModeCRT
	{
		private const int blockSize = 16;
		private const int keySize = 128;
		private static byte[] _cipherBytes;
		private static byte[] _messageBytes;

		public static string DecryptMessage(string cipherText, byte[] key)
		{
			_cipherBytes = CipherHelper.ConvertFromHexString(cipherText).ToArray<byte>();

			var currentIV = new byte[blockSize];
			var currentPlainText = new byte[blockSize];
			var currentCipherText = new byte[blockSize];

			// first 16 byte of ciphertext is IV
			currentIV = _cipherBytes.Take<byte>(blockSize).ToArray<byte>();
			_cipherBytes = _cipherBytes.Skip<byte>(blockSize).ToArray<byte>();
			_messageBytes = new byte[_cipherBytes.Length];

			using (var aesAlg = Aes.Create())
			{
				aesAlg.Mode = CipherMode.ECB;
				aesAlg.KeySize = keySize;
				aesAlg.BlockSize = keySize;
				aesAlg.Padding = PaddingMode.None;

				// could pass any value as IV. it should be ignored in ECB mode
				using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(key, key))
				{
					using (MemoryStream memStream = new MemoryStream())
					{
						using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
						{
							using (var srEncrypt = new BinaryWriter(cryptoStream))
							{
								byte[] blockToXor = new byte[blockSize];
								for (var i = 0; i <= _cipherBytes.Length / blockSize; ++i)
								{
									// encrypt current IV
									srEncrypt.Write(currentIV);
									srEncrypt.Flush();
									currentCipherText = _cipherBytes.Skip<byte>(blockSize * i).Take<byte>(blockSize).ToArray<byte>();
									blockToXor = memStream.ToArray().Skip<byte>(blockSize * i).Take<byte>(currentCipherText.Length).ToArray<byte>();

									// XOR first 16 bytes of ciphetText and 16-bytes of encrypted IV
									currentPlainText = CipherHelper.Xor(currentCipherText, blockToXor);

									currentPlainText.CopyTo(_messageBytes, blockSize * i);

									currentIV = IncreaseIV(currentIV);
								}
							}
						}
					}
				}
			}
			return CipherHelper.GetASCIIString(_messageBytes);
		}

		private static byte[] IncreaseIV(byte[] oldIV)
		{
			var oldValue = new BigInteger(oldIV);
			byte[] oneArray = new byte[blockSize];
			oneArray[blockSize - 1] = 1;
			var one = new BigInteger(oneArray);
			var newValue = oldValue + one;
			return newValue.ToByteArray();
		}
	}
}
