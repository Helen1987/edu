﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    public class CipherHelper
    {
		public static string Xor(string value1, string value2, out string hexValue) {
			var array1 = ConvertFromHexString(value1).ToArray<byte>();
			var array2 = ConvertFromHexString(value2).ToArray<byte>();
			return ConvertBitArrayToASCIIString(CipherHelper.Xor(array1, array2), out hexValue);
		}

		public static byte[] Xor(byte[] value1, byte[] value2) {
			var array1 = new BitArray(value1);
			var array2 = new BitArray(value2);
			var result = array1.Xor(array2);
			byte[] b = new byte[result.Count / 8];
			result.CopyTo(b, 0);
			return b;
		}

		public static string ConvertBitArrayToASCIIString(byte[] array, out string hexValue){
			hexValue = GetHexValue(array);
			return GetASCIIString(array);
		}

		public static byte[] GetASCIIValues(string value) {
			return Encoding.ASCII.GetBytes(value);
		}

		public static bool IsASCIILetterOrSpace(int letter) {
			return letter >= 32 && letter <= 125;
		}

		public static bool IsAZOrSpace(int letter)
		{
			return letter == 32 || (letter >= 65 && letter <= 125);
		}

		public static bool IsASCIILetterOrSpace(char letter)
		{
			return IsASCIILetterOrSpace((int)letter);
		}

		public static string GetASCIIString(byte[] values) {
			for (int i = 0; i < values.Length; ++i) {
				if (!IsASCIILetterOrSpace(values[i]))
				{
					values[i] = 32;
				}
			}
			return Encoding.ASCII.GetString(values);
		}

		public static string GetHexValue(byte[] hex) {
			return BitConverter.ToString(hex).Replace("-", string.Empty);
		}

		public static IEnumerable<byte> ConvertFromHexString(string hexString) {
			for (int i = 0; i <= hexString.Length - 2; i += 2) {
				var tempCode = hexString.Substring(i, 2);
				if (string.IsNullOrWhiteSpace(tempCode))
				{
					yield return 0;
				}
				else
				{
					yield return Convert.ToByte(tempCode, 16);
				}
			}
		}

		public static string GetASCIIHexValues(string value) {
			return GetHexValue(GetASCIIValues(value));
		}

		public static string HexString2Ascii(string hexString)
		{
			return GetASCIIString(ConvertFromHexString(hexString).ToArray<byte>());
		}

		public static string[] GetTheSameLength(string s1, string s2)
		{
			var length = Math.Min(s1.Length, s2.Length);
			return new[] { s1.Substring(0, length), s2.Substring(0, length) };
		}
    }
}
