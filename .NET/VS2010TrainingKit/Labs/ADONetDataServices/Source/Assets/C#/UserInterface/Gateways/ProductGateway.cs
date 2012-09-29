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

namespace UserInterface.Gateways
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Services.Client;
    using System.Linq;
    using UserInterface.AdventureWorks;

    public class ProductGateway : IProductGateway
    {
        private AdventureWorksLTEntities context;
        
        public ProductGateway()
        {
            Uri serviceUri = new Uri(ConfigurationManager.AppSettings["ServiceUri"]);
            this.context = new AdventureWorksLTEntities(serviceUri);
            this.context.MergeOption = MergeOption.AppendOnly;
        }

        public IList<Product> GetProducts(string productName, ProductCategory category)
        {
            return null;
        }

        public IList<ProductCategory> GetCategories()
        {
            return null;
        }

        public void DeleteProduct(Product product)
        {
        }

        public void UpdateProduct(Product product)
        {
        }

        public void AddProduct(Product product)
        {
        }
    }
}

