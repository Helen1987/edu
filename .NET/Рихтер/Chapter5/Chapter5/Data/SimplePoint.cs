using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5.Data
{
	class SimplePoint
	{
		private int _x, _y;

		public SimplePoint(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public void Change(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public override string ToString()
		{
			return string.Format("({0}, {1})", _x, _y);
		}
	}
}
