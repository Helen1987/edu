using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;

namespace WcfSingletonService
{
	[ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
	public class MySingleton : IMySingletonContract, IMyOtherSingletonContract, IDisposable
	{
		int _counter;

		public MySingleton()
		{
			Trace.WriteLine("MySingleton.MySingleton()");
		}

		public void MyMethod()
		{
			_counter++;
			var sessionId = OperationContext.Current.SessionId;
			Trace.WriteLine(string.Format("Counter = {0}, SessionId = {1}", _counter, sessionId));
		}

		public void MyOtherMethod()
		{
			_counter++;
			var sessionId = OperationContext.Current.SessionId;
			Trace.WriteLine(string.Format("Counter = {0}, SessionId = {1}", _counter, sessionId));
		}

		public void Dispose()
		{
			Trace.WriteLine("MySingleton.Dispose");
		}
	}
}
