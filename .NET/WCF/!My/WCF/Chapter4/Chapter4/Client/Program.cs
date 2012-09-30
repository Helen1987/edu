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

			using (var proxy = new MySingletonContractClient())
			{
				proxy.MyMethod();
				var sessionId = proxy.InnerChannel.SessionId;
				Trace.WriteLine("3. SessionId is " + sessionId);
			}

			using (var proxy = new MyOtherSingletonContractClient())
			{
				proxy.MyOtherMethod();
				var sessionId = proxy.InnerChannel.SessionId;
				Trace.WriteLine("4. SessionId is " + sessionId);
			}

			Console.ReadLine();
		}
	}
}
