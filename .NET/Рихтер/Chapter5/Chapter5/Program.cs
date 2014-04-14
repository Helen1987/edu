using Chapter5.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5
{
	class Program
	{
		static void Main(string[] args)
		{
			var boxing = new BoxingUnboxing();
			boxing.Write();

			Console.WriteLine("Struct Boxing Behavior");
			StructBoxingBehavior.Run();

			Console.WriteLine("Struct Unexpected Behavior");
			StructUnexpectedBehavior.Run();

			Console.WriteLine("Struct Improve Unexpected Behavior");
			StructImproveUnexpectedBehavior.Run();

			// DYNAMIC
			Console.WriteLine("Dynamic Demo");
			DynamicDemo.Run();

			Console.ReadKey();
		}
	}
}
