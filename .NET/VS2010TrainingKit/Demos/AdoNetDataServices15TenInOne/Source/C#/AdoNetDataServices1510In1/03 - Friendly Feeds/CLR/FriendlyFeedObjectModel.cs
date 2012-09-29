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
using System.Web;
using System.Data.Services.Common;

namespace AdoNetDataServices1510In1.FriendlyFeeds.CLR
{
    public class FriendlyFeedObjectModel
    {
        private IList<Product> _products;

        public FriendlyFeedObjectModel()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "XBOX 360",
                    Author="Andersen, Elizabeth A.",
                    Price = 300.99f,
                    Category=new Category { Id = 1, Name = "Games" }
                },
                new Product
                {
                    Id = 2,
                    Name = "Fishing Pole",
                    Author="Dunton, Bryn Paul",
                    Price = 12.36f
                },
                new Product
                {
                    Id = 3,
                    Name = "Bunny Bread",
                    Author="Shortt, Patrick",
                    Price = 1.89f
                },
                new Product
                {
                    Id = 4,
                    Name = "Grand Piano",
                    Author="Roland, Alex",
                    Price = 13000f
                }
            };
        }

        public IQueryable<Product> Products
        {
            get
            {
                return _products.AsQueryable();
            }
        }
    }

    [EntityPropertyMapping("Name", SyndicationItemProperty.Title, SyndicationTextContentKind.Plaintext, true)]
    [EntityPropertyMapping("Author", SyndicationItemProperty.AuthorName, SyndicationTextContentKind.Plaintext, true)]
    [EntityPropertyMapping("Price", "price", "money", "http://tempuri.org/money", true)]
    [EntityPropertyMapping("Category/Name", "category", "category", "http://tempuri.org/category", true)]
    [DataServiceKey("Id")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public Category Category { get; set; }
    }

    [DataServiceKey("Id")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}