using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Diagnostics;

namespace Enhancements.Factory
{
	public static class InProcFactory
	{
		struct HostRecord
		{
			public ServiceHost Host { get; private set; }
			public string Address { get; private set; }

			public HostRecord(ServiceHost host, string address) : this()
			{
				Host = host;
				Address = address;
			}
		}

		static readonly Uri BaseAddress = new Uri("net.pipe://localhost/");
		static readonly Binding NamedPipeBinding;
		static Dictionary<Type, HostRecord> _hosts = new Dictionary<Type, HostRecord>();

		static InProcFactory()
		{
			NamedPipeBinding = new NetNamedPipeBinding { TransactionFlow = true };
			AppDomain.CurrentDomain.ProcessExit += ((p1, p2) =>
					{
						foreach (var pair in _hosts)
							pair.Value.Host.Close();
					});
		}

		public static I CreateInstanse<S, I>()
			where I : class
			where S : I
		{
			var hostRecord = GetHostRecord<S, I>();
			return ChannelFactory<I>.CreateChannel(NamedPipeBinding, new EndpointAddress(hostRecord.Address));
		}

		private static HostRecord GetHostRecord<S, I>() where I : class
													where S : I
		{
			HostRecord hostRecord;
			if (_hosts.ContainsKey(typeof(S)))
			{
				hostRecord = _hosts[typeof(S)];
			}
			else
			{
				var host = new ServiceHost(typeof(S), BaseAddress);
				string address = BaseAddress.ToString() + Guid.NewGuid().ToString();
				hostRecord = new HostRecord(host, address);
				_hosts.Add(typeof(S), hostRecord);
				host.AddServiceEndpoint(typeof(I), NamedPipeBinding, address);
				host.Open();
			}
			return hostRecord;
		}

		public static void CloseProxy<I>(I instance) where I : class
		{
			var proxy = instance as ICommunicationObject;
			Debug.Assert(proxy != null);
			proxy.Close();
		}
	}
}
