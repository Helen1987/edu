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
    using System.Collections.ObjectModel;
    using System.ServiceModel.Discovery;
    
    public class FindAsyncResult : CompletedAsyncResult
    {
        private Collection<EndpointDiscoveryMetadata> matchingEndpoints;

        public FindAsyncResult(
            Collection<EndpointDiscoveryMetadata> matchingEndpoints,
            AsyncCallback callback,
            object state)
            : base(callback, state)
        {
            this.matchingEndpoints = matchingEndpoints;
        }

        // Hides the inherited End from CompletedAsyncResult
        // This method returns a collection of metadata
        public static new Collection<EndpointDiscoveryMetadata>
              End(IAsyncResult result)
        {
            FindAsyncResult thisPtr = AsyncResult.End<FindAsyncResult>(result);
            return thisPtr.matchingEndpoints;
        }
    }
}