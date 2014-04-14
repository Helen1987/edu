﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5.Tests
{
	class StructBoxingBehavior
	{
		public static void Run() {
			var p1 = new Point(10, 10);
			var p2 = new Point(20, 20);

			// p1 does NOT get boxed to call ToString (a virtual method)
			Console.WriteLine(p1.ToString()); // (10, 10)

			// p DOES get boxed to call GetType (a non-virtual method)
			Console.WriteLine(p1.GetType()); // Point

			// p1 does NOT get boxed to call CompareTo
			// p2 does NOT get boxed because CompareTo(Point) is called
			Console.WriteLine(p1.CompareTo(p2)); // -1

			// p1 DOES get boxed, and the reference is placed in c
			IComparable c = p1;
			Console.WriteLine(c.GetType()); // Point

			// p1 does NOT get boxed to call ComapreTo
			// Since CompareTo is not being passed a Point variable,
			// CompareTo(Object) is called which requires a reference to
			// a boxed Point
			// c does NOT get boxed because it already refers to a boxed Point
			Console.WriteLine(p1.CompareTo(c)); // 0

			// c does NOT get boxed because it is already refers ti a boxed Point.
			// p2 DOES get boxed because CompareTo(Object) is called
			Console.WriteLine(c.CompareTo(p2)); // -1

			// c is unboxed, and fields are copied into p2
			p2 = (Point)c;

			// Proves that the fields got copied into p2
			Console.WriteLine(p2.ToString()); // (10, 10)
		}
	}
}
