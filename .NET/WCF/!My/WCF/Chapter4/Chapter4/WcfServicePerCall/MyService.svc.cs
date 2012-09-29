using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;


namespace WcfServicePerCall
{
	[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
	public class MyService : IMyContract
	{
		int counter = 0;

		public MyService()
		{
			
			Trace.WriteLine("MyService.MyService()");
			
		}

		public void MyMethod(Param stateIdentifier)
		{
			GetSate(stateIdentifier);
			counter++;
			Trace.WriteLine("Counter = " + counter);
			SaveState(stateIdentifier);
		}

		public void Dispose()
		{
			Trace.WriteLine("MyService.Dispose()");
		}

		void GetSate(Param stateIdentifier)
		{ }

		void SaveState(Param stateIdentifier)
		{ }
	}
}
