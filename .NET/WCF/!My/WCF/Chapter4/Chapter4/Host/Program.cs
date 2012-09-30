using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;

namespace Host
{
	class Program
	{
		static void Main(string[] args)
		{
			var host = new ServiceHost(typeof(MyContractClient));

			ServiceThrottlingBehavior throttle = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
			if (throttle == null)
			{
				throttle = new ServiceThrottlingBehavior();
				throttle.MaxConcurrentCalls = 12;
				throttle.MaxConcurrentSessions = 34;
				throttle.MaxConcurrentInstances = 56;
				host.Description.Behaviors.Add(throttle);
			}

			host.Open();
			Thread.Sleep(1000);
			host.Close();
		}
	}
}
