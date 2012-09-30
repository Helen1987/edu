using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;

namespace WcfServicePerSession
{
	public class MySessionService : IMySessionContract, IDisposable
	{
		int counter = 0;

		public MySessionService()
		{
			Trace.WriteLine("MySessionService.MySessionService()");
		}

		public void MyMethod()
		{
			counter++;
			var sessionId = OperationContext.Current.SessionId;
			Trace.WriteLine(string.Format("Counter = {0}, SessionId = {1}", counter, sessionId));
		}

		// only if service implement IDisposable interface
		public void Dispose()
		{
			Trace.WriteLine("MySessionService.Dispose()");
		}
	}
}
