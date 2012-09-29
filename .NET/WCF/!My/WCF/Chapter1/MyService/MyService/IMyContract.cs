using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyService
{
	[ServiceContract(Namespace="MyNamespace")]
	public interface IMyContract
	{

		[OperationContract]
		string MyMethod(string text);

		// не входит в контракт
		string MyOtherMethod(string text);
	}

	[ServiceContract]
	public interface IMyOtherContract
	{
		[OperationContract(Name="SomeMethod")]
		string MyOtherMethod(string text);
	}
}
