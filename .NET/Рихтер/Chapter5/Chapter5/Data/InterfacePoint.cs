using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5.Data
{
	class InterfacePoint : IChangeBoxedPoint
	{
		private int _x, _y;

		public InterfacePoint(int x, int y)
		{
			_x = x;
			_y = y;
		}

		// Override ToString() method inherited from System.ValueType
		public override string ToString()
		{
			return string.Format("({0}, {1})", _x, _y);
		}

		public void Change(int x, int y)
		{
			_x = x;
			_y = y;
		}
	}
}
