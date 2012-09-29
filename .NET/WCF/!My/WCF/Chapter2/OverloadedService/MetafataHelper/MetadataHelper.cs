using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Diagnostics;

namespace WpfApplicationTest
{
	public static class MetadataHelper
	{
		const int MessageMultiplier = 5;

		#region Helpers

		static ServiceEndpointCollection QueryMexEndpoint(string mexAddress, BindingElement bindingElement)
		{
			var binding = new CustomBinding(bindingElement);
			var MEXClient = new MetadataExchangeClient(binding);
			var metadata = MEXClient.GetMetadata(new EndpointAddress(mexAddress));
			var importer = new WsdlImporter(metadata);
			return importer.ImportAllEndpoints();
		}

		public static ServiceEndpoint[] GetEndpoints(string mexAddress)
		{
			var address = new Uri(mexAddress);
			ServiceEndpointCollection endpoints = null;

			if (address.Scheme == "net.tcp")
			{
				var tcpBindingElement = new TcpTransportBindingElement();
				tcpBindingElement.MaxReceivedMessageSize *= MessageMultiplier;
				endpoints = QueryMexEndpoint(mexAddress, tcpBindingElement);
			}
			if (address.Scheme == "net.pipe") { }
			if (address.Scheme == "http") { }
			if (address.Scheme == "https") { }

			return endpoints.ToArray();
		}

		#endregion

		public static bool QueryContract(string mexAddress, Type contractType)
		{
			if (contractType.IsInterface == false)
			{
				Debug.Assert(false, contractType + " is not an interface");
				return false;
			}
			var attributes = contractType.GetCustomAttributes(typeof(ServiceContractAttribute), false);
			if (attributes.Length == 0)
			{
				Debug.Assert(false, "Interface " + contractType + " does not have the ServiceContractAttribute");
				return false;
			}
			var attribute = attributes[0] as ServiceContractAttribute;
			if (attribute.Name == null)
			{
				attribute.Name = contractType.ToString();
			}
			if (attribute.Namespace == null)
			{
				attribute.Namespace = "http://tempuri.org/";
			}
			return QueryContract(mexAddress, attribute.Namespace, attribute.Name);
		}

		public static bool QueryContract(string mexAddress, string contractNamespace, string contractName)
		{
			if (string.IsNullOrEmpty(contractNamespace))
			{
				Debug.Assert(false, "Empty namespace");
				return false;
			}
			if (string.IsNullOrEmpty(contractName))
			{
				Debug.Assert(false, "Empty name");
				return false;
			}
			try
			{
				var endpoints = GetEndpoints(mexAddress);
				foreach (var endpoint in endpoints)
				{
					if (endpoint.Contract.Namespace == contractNamespace && endpoint.Contract.Name == contractName)
					{
						return true;
					}
				}
			}
			catch
			{ }
			return false;
		}
	}
}
