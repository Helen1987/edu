// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

namespace ChatProxy
{
    using System;
    using System.Linq;
    using System.ServiceModel.Discovery;
    using System.Xml.Linq;
    
    public static class EndpointDiscoveryMetadataExtensions
    {
        private const string ConsoleFormat = @"{0} service {1} user {2}";

        public static void WriteLine(this EndpointDiscoveryMetadata metadata, string verb)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata");
            }

            XElement peerNameElement = metadata.Extensions.Elements("Name").FirstOrDefault();
            string name;
            if (peerNameElement != null)
            {
                name = peerNameElement.Value;
            }
            else
            {
                name = metadata.Address.ToString();
            }

            Console.WriteLine(
                ConsoleFormat, 
                verb, 
                metadata.ContractTypeNames.FirstOrDefault(),
                name);
        }
    }
}