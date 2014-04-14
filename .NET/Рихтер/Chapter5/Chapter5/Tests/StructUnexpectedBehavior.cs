using Chapter5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5.Tests
{
	class StructUnexpectedBehavior
	{
		public static void Run() {
			var p = new SimplePoint(1, 1);

			Console.WriteLine(p);

			p.Change(2, 2);
			Console.WriteLine(p);

			Object o = p;
			Console.WriteLine(o);

			((SimplePoint)o).Change(3, 3);
			Console.WriteLine(o); // !!!!! (3, 3) а должно (2, 2)???
		}
	}
}
