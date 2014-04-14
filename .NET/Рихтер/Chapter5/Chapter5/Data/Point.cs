using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5
{
	internal struct Point : IComparable
	{
		private readonly int _x, _y;

		public Point(int x, int y) {
			_x = x;
			_y = y;
		}

		// Override ToString() method inherited from System.ValueType
		public override string ToString()
		{
			return string.Format("({0}, {1})", _x, _y);
		}

		// Implementation of type-safe CompareTo method
		public int CompareTo(Point other)
		{
			return Math.Sign(Math.Sqrt(_x*_x + _y*_y)
				- Math.Sqrt(other._x * other._x + other._y * other._y));
		}

		public int CompareTo(Object o) 
		{
			if (GetType() != o.GetType())
			{
				throw new ArgumentException("o is not a Point");
			}
			// Call type-safe CompareTo method
			return CompareTo((Point) o);
		}
	}
}
