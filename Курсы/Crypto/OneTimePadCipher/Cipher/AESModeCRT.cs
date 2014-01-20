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
				using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(key, currentIV))
				{
					using (MemoryStream memStream = new MemoryStream(_cipherBytes))
					{
						using (CryptoStream cryptoStream = new CryptoStream(memStream, decryptor, CryptoStreamMode.Read))
						{
							using (var srDecrypt = new BinaryReader(cryptoStream))
							{
								byte[] blockToXor = new byte[blockSize];
								for (var i = 0; i < _cipherBytes.Length / blockSize; ++i)
								{
									// get decrypt message
									blockToXor = srDecrypt.ReadBytes(blockSize);

									// XOR first 16 bytes of ciphetText and first 16-bytes of decrypted message
									currentPlainText = CipherHelper.Xor(currentIV, blockToXor);

									currentPlainText.CopyTo(_messageBytes, blockSize * i);

									// assign new currentCipherText value
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
			var newValue = oldValue + 1;
			return newValue.ToByteArray();
		}
	}
}
