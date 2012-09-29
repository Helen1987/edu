using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
			}

			using (var proxy = new MySessionContractClient())
			{
				proxy.MyMethod();
				proxy.MyMethod();
			}

			Console.ReadLine();
		}
	}
}
