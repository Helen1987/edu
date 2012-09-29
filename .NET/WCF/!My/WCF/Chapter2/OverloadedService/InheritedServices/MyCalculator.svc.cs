using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace InheritedServices
{
	class MyCalculator : IScientificCalculator
	{
		public int Multiply(int arg1, int arg2)
		{
			return arg1 * arg2;
		}

		public int Add(int arg1, int arg2)
		{
			return arg1 + arg2;
		}
	}
}
