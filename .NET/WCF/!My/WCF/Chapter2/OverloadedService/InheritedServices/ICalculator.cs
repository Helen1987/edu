using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace InheritedServices
{
	[ServiceContract]
	interface ISimpleCalculator
	{
		[OperationContract]
		int Add(int arg1, int arg2);
	}

	[ServiceContract]
	interface IScientificCalculator : ISimpleCalculator
	{
		[OperationContract]
		int Multiply(int arg1, int arg2);
	}
}
