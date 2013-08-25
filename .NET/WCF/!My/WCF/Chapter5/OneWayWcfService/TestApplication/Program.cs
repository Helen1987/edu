using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var proxy = new OneWayServiceClient())
			{
				proxy.MyMethodWithError();
				proxy.MyMethodWithoutError();
			}
			Console.WriteLine("Complete...");
			Console.ReadLine();
		}
	}
}
