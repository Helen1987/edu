﻿using System;
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
	public class MyService : IMyContract, IDisposable
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
			var sessionId = OperationContext.Current.SessionId;
			Trace.WriteLine(string.Format("Counter = {0}, SessionId = {1}", counter, sessionId));
			SaveState(stateIdentifier);
		}

		// only if service implement IDisposable interface
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