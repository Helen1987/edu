using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WcfApplicationProxyGenerating
{
	class Program
	{
		static void Main(string[] args)
		{
			//var client = new MyContractClient("IMyContract");

			// the first way to dispose
			IMyContract client = new MyContractClient();
			client.MyMethod("test");
			IDisposable disp = client as IDisposable;
			if (disp != null)
			{
				disp.Dispose();
			}

			// the second way to dispose
			IMyContract proxy = new MyContractClient();
			using (proxy as IDisposable)
			{
				proxy.MyMethod("test 2");
			}

			using (var service = new MyContractClient())
			{
				Console.WriteLine(service.MyMethod("test MyContractClient: "));
			}

			using (var service = new MyOtherContractClient())
			{
				Console.WriteLine(service.SomeMethod("test MyOtherContractClient: "));
			}

			Console.ReadKey();
		}
	}
}
