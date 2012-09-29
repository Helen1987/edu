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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Collections.ObjectModel;
using Microsoft.Samples.Discovery.Contracts;

namespace ChatProxy
{
    [ServiceBehavior(
    InstanceContextMode = InstanceContextMode.Single,
    ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ChatDiscoveryProxy : DiscoveryProxy
    {
        private static ChatServiceCollection cache = new ChatServiceCollection();

        internal static ChatServiceCollection Cache
        {
            get { return cache; }
        }

        protected override IAsyncResult OnBeginOnlineAnnouncement(DiscoveryMessageSequence messageSequence,
                                                EndpointDiscoveryMetadata endpointDiscoveryMetadata,
                                                AsyncCallback callback,
                                                object state)
        {
            if (endpointDiscoveryMetadata == null)
            {
                throw new ArgumentNullException("endpointDiscoveryMetadata");
            }

            // We care only about ISimpleChatService services
            FindCriteria criteria = new FindCriteria(typeof(ISimpleChatService));

            if (criteria.IsMatch(endpointDiscoveryMetadata))
            {
                endpointDiscoveryMetadata.WriteLine("Adding");
                Cache.Add(endpointDiscoveryMetadata);
            }

            return new CompletedAsyncResult(callback, state);
        }

        protected override IAsyncResult OnBeginOfflineAnnouncement(DiscoveryMessageSequence messageSequence, EndpointDiscoveryMetadata endpointDiscoveryMetadata, AsyncCallback callback, object state)
        {
            try
            {
                if (endpointDiscoveryMetadata == null)
                {
                    throw new ArgumentNullException("endpointDiscoveryMetadata");
                }

                // We care only about ISimpleChatService services
                FindCriteria criteria = new FindCriteria(typeof(ISimpleChatService));

                if (criteria.IsMatch(endpointDiscoveryMetadata))
                {
                    endpointDiscoveryMetadata.WriteLine("Removing");
                    Cache.Remove(endpointDiscoveryMetadata.Address.Uri);
                }
            }
            catch (KeyNotFoundException)
            {
                // No problem if it does not exist in the cache
            }

            return new CompletedAsyncResult(callback, state);
        }

        protected override IAsyncResult OnBeginFind(FindRequestContext findRequestContext, AsyncCallback callback, object state)
        {
            if (findRequestContext == null)
            {
                throw new ArgumentNullException("findRequestContext");
            }

            Console.WriteLine(
                "Find request for contract {0}",
                findRequestContext.Criteria.ContractTypeNames.FirstOrDefault());

            // Query to find the matching endpoints
            var query = from service in Cache
                        where findRequestContext.Criteria.IsMatch(service)
                        select service;

            // Collection to contain the results of the query
            var matchingEndpoints = new Collection<EndpointDiscoveryMetadata>();

            // Execute the query and add the matching endpoints
            foreach (EndpointDiscoveryMetadata metadata in query)
            {
                metadata.WriteLine("\tFound");
                matchingEndpoints.Add(metadata);
                findRequestContext.AddMatchingEndpoint(metadata);
            }

            return new FindAsyncResult(matchingEndpoints, callback, state);
        }

        protected override void OnEndFind(IAsyncResult result)
        {
            FindAsyncResult.End(result);
        }

        protected override IAsyncResult OnBeginResolve(ResolveCriteria resolveCriteria, AsyncCallback callback, object state)
        {
            return new CompletedAsyncResult(callback, state);
        }

        protected override EndpointDiscoveryMetadata OnEndResolve(IAsyncResult result)
        {
            return CompletedAsyncResult<EndpointDiscoveryMetadata>.End(result);
        }

        protected override void OnEndOfflineAnnouncement(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }

        protected override void OnEndOnlineAnnouncement(IAsyncResult result)
        {
            CompletedAsyncResult.End(result);
        }



    }
}
