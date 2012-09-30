using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Enhancements
{
	public class ServiceHost<T> : ServiceHost
	{
		public ServiceHost() : base(typeof(T)) { }

		public ServiceHost(params string[] baseAddresses) :
			base(typeof(T), Convert(baseAddresses)) { }

		public ServiceHost(params Uri[] baseAddress) :
			base(typeof(T), baseAddress) { }

		// for singleton instance
		public ServiceHost(T singleton, params Uri[] baseAddresses) : base(singleton, baseAddresses) { }

		public virtual T Singleton
		{
			get
			{
				if (SingletonInstance == null)
				{
					return default(T);
				}
				return (T)SingletonInstance;
			}
		}

		#region Throttle

		public void SetThrottle(int maxCalls, int maxSessions, int maxInstances)
		{
			var throttle = new ServiceThrottlingBehavior();
			throttle.MaxConcurrentCalls = maxCalls;
			throttle.MaxConcurrentSessions = maxSessions;
			throttle.MaxConcurrentInstances = maxInstances;
			SetThrottle(throttle);
		}

		public void SetThrottle(ServiceThrottlingBehavior serviceThrottle, bool overrideConfig = false)
		{
			if (State == CommunicationState.Opened)
			{
				throw new InvalidOperationException("Host is already opened");
			}
			var throttle = Description.Behaviors.Find<ServiceThrottlingBehavior>();
			if (throttle != null && overrideConfig == false)
			{
				return;
			}
			if (throttle != null) // ovverideCinfig == true, удалить конфигурацию
			{
				Description.Behaviors.Remove(throttle);
			}
			if (throttle == null)
			{
				Description.Behaviors.Add(serviceThrottle);
			}
		}

		public ServiceThrottlingBehavior ThrottleBehavior
		{
			get
			{
				return Description.Behaviors.Find<ServiceThrottlingBehavior>();
			}
		}

		public ServiceThrottle Throttle
		{
			get
			{
				if (State != CommunicationState.Opened)
				{
					throw new InvalidOperationException("Host is not opened");
				}
				var dispatcher = OperationContext.Current.Host.ChannelDispatchers[0] as ChannelDispatcher;
				return dispatcher.ServiceThrottle;
			}
		}

		#endregion

		private static Uri[] Convert(string[] baseAddresses)
		{
			return baseAddresses.Select(elem => new Uri(elem)).ToArray();
		}

		public bool EnableMetadataExchange
		{
			set
			{
				if (State == CommunicationState.Opened)
				{
					throw new InvalidOperationException("Host is already opened");
				}
				var metadataBehavior = Description.Behaviors.Find<ServiceMetadataBehavior>();
				if (metadataBehavior == null)
				{
					metadataBehavior = new ServiceMetadataBehavior();
					Description.Behaviors.Add(metadataBehavior);
				}
				if (value == true)
				{
					if (HasMexEndpoint == false)
					{
						AddAllMexEndpoints();
					}
				}
			}
			get
			{
				var metadataBehavior = Description.Behaviors.Find<ServiceMetadataBehavior>();
				return metadataBehavior == null ? false : metadataBehavior.HttpGetEnabled;
			}
		}

		public bool HasMexEndpoint
		{
			get
			{
				return Description.Endpoints.Any(endpoint =>
					endpoint.Contract.ContractType == typeof(IMetadataExchange));
			}
		}

		public void AddAllMexEndpoints()
		{
			Debug.Assert(HasMexEndpoint == false);

			foreach (var baseAddress in BaseAddresses)
			{
				BindingElement bindingElement = null;
				switch (baseAddress.Scheme)
				{
					case "net.tcp":
						{
							bindingElement = new TcpTransportBindingElement();
							break;
						}
					case "net.pipe":
						{
							bindingElement = new NamedPipeTransportBindingElement();
							break;
						}
					case "http":
						{
							bindingElement = new HttpTransportBindingElement();
							break;
						}
					case "https":
						{
							bindingElement = new HttpsTransportBindingElement();
							break;
						}
				}
				if (bindingElement != null)
				{
					var binding = new CustomBinding(bindingElement);
					AddServiceEndpoint(typeof(IMetadataExchange), binding, "MEX");
				}
			}
		}
	}
}
