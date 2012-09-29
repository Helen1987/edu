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
using System.Linq.Expressions;

namespace WebSite
{
    public class AdventureWorks : DataService<AdventureWorksLTEntities>
    {
        // This method is called once during service initialization to allow
        // service-specific policies to be set
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.All);

            config.SetServiceOperationAccessRule("GetProducts", ServiceOperationRights.All);

            config.DataServiceBehavior.MaxProtocolVersion = System.Data.Services.Common.DataServiceProtocolVersion.V2;
        }

        [WebGet]
        public IQueryable<Product> GetProducts(string productName, int productCategoryId)
        {
            return from p in this.CurrentDataSource.Product
                   where p.ProductCategory.ProductCategoryID == productCategoryId
                   && (p.Name == productName || String.IsNullOrEmpty(productName))
                   select p;
        }

        [ChangeInterceptor("Product")]
        public void OnChangeProduct(Product product, UpdateOperations action)
        {
            if (action == UpdateOperations.Add ||
                action == UpdateOperations.Change)
            {
                if (String.IsNullOrEmpty(product.Color))
                    throw new DataServiceException("Product must have a color specified");

                DateTime fakeToday = new DateTime(2009, 03, 26);
                product.ModifiedDate = fakeToday;
            }

            if (action == UpdateOperations.Add)
            {
                product.rowguid = Guid.NewGuid();
            }
        }

        [QueryInterceptor("ProductCategory")]
        public Expression<Func<ProductCategory, bool>> OnQueryProductCategory()
        {
            return (pc) => pc.Name.StartsWith("B");
        }
    }
}
