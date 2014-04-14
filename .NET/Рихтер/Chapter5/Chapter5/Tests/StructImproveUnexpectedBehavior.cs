using Chapter5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5.Tests
{
	class StructImproveUnexpectedBehavior
	{
		public static void Run()
		{
			var p = new InterfacePoint(1, 1);

			Console.WriteLine(p);

			p.Change(2, 2);
			Console.WriteLine(p);

			Object o = p;
			Console.WriteLine(o);

			((InterfacePoint)o).Change(3, 3);
			Console.WriteLine(o);

			// Boxes p, changes the boxed object and discards it
			((IChangeBoxedPoint)p).Change(4, 4);
			Console.WriteLine(p); // displays (4, 4) but should (2, 2)

			// Changes the boxed object and shows it
			((IChangeBoxedPoint)o).Change(5, 5);
			Console.WriteLine(o);
		}
	}
}
