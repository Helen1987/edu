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
            int categoryId = category.ProductCategoryID;

            IEnumerable<Product> products = this.context.Execute<Product>(
                new Uri(this.context.BaseUri.ToString() +
                    "/ProductCategory(" + categoryId + ")/Product?$filter=indexof(Name,'" + productName + "') gt -1 or '' eq '" + productName + "'"));

            List<Product> productsSet = new List<Product>();
            foreach (Product p in products)
            {
                this.context.LoadProperty(p, "ProductCategory");
                productsSet.Add(p);
            }

            return productsSet;
        }

        public IList<ProductCategory> GetCategories()
        {
            var productCategories = from c in this.context.ProductCategory
                                    orderby c.Name
                                    select c;

            return productCategories.ToList();
        }

        public void DeleteProduct(Product product)
        {
            this.context.AttachTo("Product", product);
            this.context.DeleteObject(product);
            this.context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            ProductCategory newCategory = product.ProductCategory;
            this.context.AttachTo("Product", product);
            this.context.LoadProperty(product, "ProductCategory");
            if (newCategory.Name != product.ProductCategory.Name)
            {
                this.context.DeleteLink(product, "ProductCategory", product.ProductCategory);
                this.context.AttachTo("ProductCategory", newCategory);
                this.context.AddLink(product, "ProductCategory", newCategory);
            }

            this.context.UpdateObject(product);
            this.context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            product.rowguid = Guid.NewGuid();
            this.context.AddObject("Product", product);
            product.ProductCategory.Product.Add(product);
            this.context.AttachTo("ProductCategory", product.ProductCategory);
            this.context.AddLink(product.ProductCategory, "Product", product);
            this.context.SaveChanges();
        }
    }
}

