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
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Xml.Linq;
using System.Collections.Generic;

namespace HTML_Lab
{
    public static class Repository
    {
        public static IList<Product> GetProductsList()
        {
            IList<Product> _products = new List<Product>();

            _products.Add(new Product { Name = "T-Shirt, Green", ProductNumber = "GTS0101", Price = 12.99M, QuantityInStock = 100 });
            _products.Add(new Product { Name = "T-Shirt, Blue", ProductNumber = "BTS0101", Price = 12.99M, QuantityInStock = 50 });
            _products.Add(new Product { Name = "T-Shirt, Yellow", ProductNumber = "YTS0101", Price = 12.99M, QuantityInStock = 66 });
            _products.Add(new Product { Name = "T-Shirt, Red", ProductNumber = "RTS0101", Price = 12.99M, QuantityInStock = 116 });
            _products.Add(new Product { Name = "T-Shirt, Purple", ProductNumber = "PTS0101", Price = 12.99M, QuantityInStock = 105 });
            _products.Add(new Product { Name = "T-Shirt, Orange", ProductNumber = "OTS0101", Price = 12.99M, QuantityInStock = 160 });

            _products.Add(new Product { Name = "Socks, Green", ProductNumber = "GS0101", Price = 2.99M, QuantityInStock = 100 });
            _products.Add(new Product { Name = "Socks, Blue", ProductNumber = "BS0101", Price = 2.99M, QuantityInStock = 50 });
            _products.Add(new Product { Name = "Socks, Yellow", ProductNumber = "YS0101", Price = 2.99M, QuantityInStock = 66 });
            _products.Add(new Product { Name = "Socks, Red", ProductNumber = "RS0101", Price = 2.99M, QuantityInStock = 116 });
            _products.Add(new Product { Name = "Socks, Purple", ProductNumber = "PS0101", Price = 2.99M, QuantityInStock = 105 });
            _products.Add(new Product { Name = "Socks, Orange", ProductNumber = "OS0101", Price = 2.99M, QuantityInStock = 160 });

        

        
            return _products;
        }
    }
}