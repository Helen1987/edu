#define INEFFICIENT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chapter5
{
	class BoxingUnboxing
	{
		public void Write()
		{
			int v = 5;

#if INEFFICIENT
			// When compiling the following code line, v is boxed
			// three times, wasting time and memory
			Console.WriteLine("{0}, {1}, {2}", v, v, v);
#else
			// The lines below have the same result, execute
			// much faster, and use less memory
			Object o = v;

			Console.WriteLine("{0}, {1}, {2}", o, o, o);
#endif
		}
	}
}
