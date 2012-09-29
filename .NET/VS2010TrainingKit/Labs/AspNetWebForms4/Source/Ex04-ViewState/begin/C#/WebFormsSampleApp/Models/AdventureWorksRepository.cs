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

using System.Linq;
using System.Data.Linq;

namespace WebFormsSampleApp.Models
{
    public class AdventureWorksRepository
    {
        public ProductCategory[] GetCategories()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            return (from c in db.ProductCategories
                    where c.ParentProductCategoryID == null
                    select c).ToArray();
        }

        public ProductCategory[] GetSubcategories(string category)
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();

            return (from c in db.ProductCategories
                    where c.ParentProductCategoryID == GetCategoryId(category)
                    select c).ToArray();
        }

        public int GetProductsCount()
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            return db.Products.Count();
        }

        public int GetProductsCountByCategories(int[] categoryIds)
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            return (from p in db.Products
                    where categoryIds.Contains(p.ProductCategoryID.Value)
                    select p).Count();
        }

        public Product[] GetProductsByCategories(int[] categoryIds, int page, int pageSize)
        {
            int startRowIndex = (page-1) * pageSize;
            int maximumRows = pageSize;
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            return (from p in db.Products
                    where categoryIds.Contains(p.ProductCategoryID.Value)
                    orderby p.Name ascending
                    select p)
                    .Skip(startRowIndex)
                    .Take(maximumRows)
                    .ToArray();
        }

        public byte[] GetProductImage(int productId)
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            return (from p in db.Products
                    where p.ProductID == productId
                    select p.ThumbNailPhoto).SingleOrDefault<Binary>().ToArray();
        }

        public Product GetProduct(int productId)
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            return db.Products.Where(p => p.ProductID == productId).SingleOrDefault();
        }

        private int GetCategoryId(string category)
        {
            AdventureWorksDataContext db = new AdventureWorksDataContext();
            var result = (from c in db.ProductCategories
                          where c.Name == category
                          select c.ProductCategoryID);

            return (result.Count<int>() > 0) ? result.First<int>() : -1;
        }
    }
}
