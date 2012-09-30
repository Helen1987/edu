using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServicePerCall
{
	[ServiceContract]
	public interface IMyContract
	{
		[OperationContract]
		void MyMethod(Param stateIdentifier);
	}

	[DataContract]
	public class Param
	{ }
}
