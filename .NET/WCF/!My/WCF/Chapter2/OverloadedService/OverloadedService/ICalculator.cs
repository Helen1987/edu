using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OverloadedService
{
	[ServiceContract]
	public interface ICalculator
	{
		[OperationContract(Name="AddInt")]
		int Add(int arg1, int arg2);

		[OperationContract(Name="AddDouble")]
		double Add(double arg1, double arg2);
	}
}
