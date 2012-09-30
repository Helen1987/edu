using System;
using System.Collections.Generic;
using System.Text;

namespace APress.ProAspNet.Utility
{
    public static class HexEncoding
    {
        public static string GetString(byte[] data)
        {
            StringBuilder Results = new StringBuilder();
            foreach (byte b in data)
            {
                Results.Append(b.ToString("X2"));
            }

            return Results.ToString();
        }

        public static byte[] GetBytes(string data)
        {
            // GetString encodes the hex-numbers with two digits
            byte[] Results = new byte[data.Length / 2];
            for (int i = 0; i < data.Length; i += 2)
            {
                Results[i / 2] = Convert.ToByte(data.Substring(i, 2), 16);
            }

            return Results;
        }
    }
}
