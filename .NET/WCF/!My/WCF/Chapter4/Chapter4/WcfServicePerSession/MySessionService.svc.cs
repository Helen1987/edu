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
			Trace.WriteLine("Counter = " + counter);
		}

		// only if service implement IDisposable interface
		public void Dispose()
		{
			Trace.WriteLine("MySessionService.Dispose()");
		}
	}
}
