using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWcfApplication.MyService;

namespace TestWcfApplication
{
	class Program
	{
		static void Main(string[] args)
		{
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
