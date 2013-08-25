using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OneWayWcfService
{
	[ServiceContract]
	interface IOneWayService
	{

		[OperationContract(IsOneWay = true)]
		void MyMethodWithError();

		[OperationContract]
		void MyMethodWithoutError();
	}
}
