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
		private static byte[] _cipherBytes;
		private static byte[] _messageBytes;

		public static string EncryptMessage(string message)
		{
			_messageBytes = CipherHelper.GetASCIIValues(message);
			_cipherBytes = new byte[blockSize + message.Length];

			var currentCipherText = new byte[blockSize];
			var currentPlainText = new byte[blockSize];
			// generate random 16-byte IV
			// initialy store IV in currentCipherText
			rngCsp.GetBytes(currentCipherText);
			// first 16 byte of ciphertext is IV
			currentCipherText.CopyTo(_cipherBytes, blockSize);

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
							byte[] blockToEncrypt = new byte[blockSize];
							for (var i = 0; i < message.Length / blockSize - 1; ++i) {
								// copy another block of the message
								_messageBytes.CopyTo(currentPlainText, blockSize*i);
								// 1. first step of CBC:
								// XOR first 16 bytes of ciphetText and first 16-bytes of message
								blockToEncrypt = CipherHelper.Xor(currentCipherText, currentPlainText);
								
								currentCipherText = AppendNewCipherText(cryptoStream, blockToEncrypt, memStream, blockSize*(i+1));
							}
						}
					}
				}
			}

			return CipherHelper.GetHexValue(_cipherBytes);
		}

		private static byte[] AppendNewCipherText(CryptoStream cryptoStream, byte[] blockToEncrypt, 
			MemoryStream memStream, int position)
		{
			cryptoStream.Write(blockToEncrypt, 0, blockSize);
			cryptoStream.FlushFinalBlock();
			byte[] cipherBlock = memStream.ToArray();
			cipherBlock.CopyTo(_cipherBytes, position);
			return cipherBlock;
		}

		public static string DecryptMessage(string cipherText, byte[] key)
		{
			_cipherBytes = CipherHelper.ConvertFromHexString(cipherText).ToArray<byte>();

			var currentCipherText = new byte[blockSize];
			var currentPlainText = new byte[blockSize];

			// first 16 byte of ciphertext is IV
			currentCipherText = _cipherBytes.Take<byte>(blockSize).ToArray<byte>();
			_cipherBytes = _cipherBytes.Skip<byte>(blockSize).ToArray<byte>();
			_messageBytes = new byte[_cipherBytes.Length];

			using (var aesAlg = Aes.Create())
			{
				aesAlg.Mode = CipherMode.ECB;
				aesAlg.KeySize = 128;
				aesAlg.BlockSize = 128;
				aesAlg.Padding = PaddingMode.None;

				// could pass any value as IV. it should be ignored in ECB mode
				using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(key, currentCipherText))
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
									currentPlainText = CipherHelper.Xor(currentCipherText, blockToXor);

									currentPlainText.CopyTo(_messageBytes, blockSize * i);

									// assign new currentCipherText value
									currentCipherText = _cipherBytes.Skip<byte>(blockSize*i).Take<byte>(blockSize).
										ToArray<byte>();
								}
							}
						}
					}
				}
			}

			// we have padding
			if (_messageBytes[_messageBytes.Length - 1] > 0 && _messageBytes[_messageBytes.Length - 1] <= 16) {
				Console.WriteLine("We have padding " + _messageBytes[_messageBytes.Length - 1]);
				_messageBytes = _messageBytes.Take<byte>(_messageBytes.Length - _messageBytes[_messageBytes.Length - 1]).ToArray<byte>();
			}

			return CipherHelper.GetASCIIString(_messageBytes);
		}
	}
}
