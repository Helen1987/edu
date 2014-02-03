using Cipher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashedStreamVideo
{
	public class StreamVideo
	{
		private static int blockSize = 1024; // in bytes
		private static int hSize = 32; // in bytes

		public static string ComputeH0(string fileName) {
			using (var stream = File.OpenRead(fileName)) {
				int lastBlockSize = (int)(stream.Length % blockSize);
				var lastBlock = new byte[lastBlockSize];

				stream.Seek(-lastBlockSize, SeekOrigin.End);
				stream.Read(lastBlock, 0, lastBlockSize);
				stream.Seek(-lastBlockSize, SeekOrigin.Current);

				SHA256 mySHA256 = SHA256Managed.Create();

				var currentBlock = new byte[blockSize + hSize];
				var tempBlock = mySHA256.ComputeHash(lastBlock);

				while (stream.Position > 0)
				{
					// read new portion of video
					stream.Seek(-blockSize, SeekOrigin.Current);
					stream.Read(currentBlock, 0, blockSize);
					stream.Seek(-blockSize, SeekOrigin.Current);
					// add new hash
					tempBlock.CopyTo(currentBlock, blockSize);

					tempBlock = mySHA256.ComputeHash(currentBlock);
				}

				// now tempBlock stores h0
				return CipherHelper.GetHexValue(tempBlock);
			}
		}
	}
}
