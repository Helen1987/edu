using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var proxy = new MyContractClient())
			{
				proxy.MyMethod();
				proxy.MyMethod();
				var sessionId = proxy.InnerChannel.SessionId;
				Trace.WriteLine("1. SessionId is " + sessionId);
			}

			using (var proxy = new MySessionContractClient())
			{
				proxy.MyMethod();
				proxy.MyMethod();
				var sessionId = proxy.InnerChannel.SessionId;
				Trace.WriteLine("2. SessionId is " + sessionId);
			}

			Console.ReadLine();
		}
	}
}
