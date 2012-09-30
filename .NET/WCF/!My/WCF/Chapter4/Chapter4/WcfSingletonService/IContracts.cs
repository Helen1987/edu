using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfSingletonService
{
	[ServiceContract(SessionMode=SessionMode.Required)]
	public interface IMySingletonContract
	{
		[OperationContract]
		void MyMethod();
	}

	[ServiceContract(SessionMode = SessionMode.NotAllowed)]
	public interface IMyOtherSingletonContract
	{
		[OperationContract]
		void MyOtherMethod();
	}
}
