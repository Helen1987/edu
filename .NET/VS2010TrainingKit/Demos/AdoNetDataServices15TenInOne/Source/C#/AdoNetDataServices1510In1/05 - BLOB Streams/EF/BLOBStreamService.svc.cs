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
using System.Data.Services;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using System.Data.Services.Common;
using System.ServiceModel;
using System.Data.Services.Providers;
using AdoNetDataServices1510In1.BLOBStreams.EF;
using System.IO;

namespace AdoNetDataServices1510In1.BLOBStreams
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BLOBStreamService : DataService<BLOBStreamContext>, IServiceProvider
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.SetEntitySetAccessRule("Products", EntitySetRights.All);
            config.SetEntitySetPageSize("Products", 10);
        }

        public object GetService(Type serviceType)
        {
            if (serviceType != typeof(IDataServiceStreamProvider))
                return null;

            return new ProductStreamProvider();
        }
    }

    public class ProductStreamProvider : IDataServiceStreamProvider
    {
        public System.IO.Stream GetReadStream(object entity, string etag, bool? checkETagForEquality, DataServiceOperationContext operationContext)
        {
            var product = entity as Product;

            if (product == null)
                return null;

            using (var context = new BLOBStreamContext())
            {
                var photo = context.ProductPhotos.First(p => p.Id == product.Id);
                var stream = new MemoryStream(photo.Photo);
                return stream;
            }
        }

        public Uri GetReadStreamUri(object entity, DataServiceOperationContext operationContext)
        {
            return null;
        }

        public string GetStreamContentType(object entity, DataServiceOperationContext operationContext)
        {
            return "image/jpeg";
        }

        public string GetStreamETag(object entity, DataServiceOperationContext operationContext)
        {
            return null;
        }

        public int StreamBufferSize
        {
            get { return 64; }
        }

        public void DeleteStream(object entity, DataServiceOperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public System.IO.Stream GetWriteStream(object entity, string etag, bool? checkETagForEquality, DataServiceOperationContext operationContext)
        {
            throw new NotImplementedException();
        }

        public string ResolveType(string entitySetName, DataServiceOperationContext operationContext)
        {
            throw new NotImplementedException();
        }
    }
}