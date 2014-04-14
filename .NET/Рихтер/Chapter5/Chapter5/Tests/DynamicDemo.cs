using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5.Tests
{
	class DynamicDemo
	{
		public static void Run() {
			for (int demo = 0; demo < 2; ++demo) {
				dynamic arg = (demo == 0) ? (dynamic)5 : (dynamic)"A";
				dynamic result = Plus(arg);
				M(result);
			}

			Object o1 = 123;
			// explicit cast is required
			//int n1 = o1;
			int n2 = (int)o1;

			dynamic d = 123;
			// don't need explicit cast
			int n3 = d;

			var x = (int)d;
			var dt = new DateTime(d);
		}

		private static dynamic Plus(dynamic arg) { return arg + arg; }

		private static void M(int n)
		{
			Console.WriteLine("M(int): " + n);
		}

		private static void M(string n)
		{
			Console.WriteLine("M(string): " + n);
		}
	}
}
