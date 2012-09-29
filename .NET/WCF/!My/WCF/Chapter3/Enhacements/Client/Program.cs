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
			try
			{
				Console.WriteLine("Start client");
				using (var client = new ContractManagerClient())
				{
					var result = client.GetContacts();
				}
				Console.WriteLine("You'll never see this message");
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Exception was thrown: {0}"), ex.Message);
			}
			Console.ReadKey();
		}
	}
}
