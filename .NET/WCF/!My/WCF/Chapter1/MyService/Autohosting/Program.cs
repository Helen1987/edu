using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace Autohosting
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// только не null, ибо возникнет исключение
			//var baseAddress = new Uri("http://localhost:8002/MyService");
			var host = new ServiceHost(typeof(MyContractClient));//, baseAddress);

			host.Open();

			//var otherBaseAddress = new Uri("http://localhost:8001/");
			var otherHost = new ServiceHost(typeof(MyOtherContractClient));//, otherBaseAddress);
			var wsBinding = new BasicHttpBinding();
			var tcpBinding = new NetTcpBinding();
			otherHost.AddServiceEndpoint(typeof(IMyOtherContract), wsBinding, "http://localhost:8001/MyOtherService");
			otherHost.AddServiceEndpoint(typeof(IMyOtherContract), tcpBinding, "net.tcp://localhost:8003/MyOtherService");

			//AddHttpGetMetadata(otherHost);
			AddMexEndpointMetadata(otherHost);

			otherHost.Open();


			// you can access http://localhost:8002/MyService
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Host());

			otherHost.Close();

			host.Close();

			// you can not access http://localhost:8002/MyService
		}

		private static void AddHttpGetMetadata(ServiceHost host)
		{
			var metaDataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
			if (metaDataBehavior == null)
			{
				metaDataBehavior = new ServiceMetadataBehavior { HttpGetEnabled = true };
				host.Description.Behaviors.Add(metaDataBehavior);
			}
		}

		private static void AddMexEndpointMetadata(ServiceHost host)
		{
			var tcpBinding = new TcpTransportBindingElement();
			var customBinding = new CustomBinding(tcpBinding);

			// validate whether ServiceMetadataBehavior is present
			var metaDataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
			if (metaDataBehavior == null)
			{
				metaDataBehavior = new ServiceMetadataBehavior();
				host.Description.Behaviors.Add(metaDataBehavior);
			}
			host.AddServiceEndpoint(typeof(IMetadataExchange), customBinding, "MEX");
		}
	}
}
