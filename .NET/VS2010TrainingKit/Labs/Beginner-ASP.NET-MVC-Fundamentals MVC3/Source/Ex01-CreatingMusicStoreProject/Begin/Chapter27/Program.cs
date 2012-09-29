using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter27.ClientServer;

namespace Chapter27
{
	class Program {
		static void Main(string[] args) {
			// Start 1 server per CPU
			for (int i = 0; i < Environment.ProcessorCount; ++i) {
				new PipeServer();
			}

			Console.WriteLine("Press <Enter> to terminate this server application");
			Console.ReadLine();
		}
	}
}
