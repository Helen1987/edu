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
using System.Web;

namespace WebFormsSampleApp.Models
{
    public class ShoppingCart
    {
        private List<ShoppingCartItem> items;

        public ShoppingCart()
        {
            items = new List<ShoppingCartItem>();
        }

        public string CartId { get; set; }

        public ShoppingCartItem[] Items
        {
            get
            {
                return items.ToArray();
            }
        }

        public int TotalItems
        {
            get
            {
                return (from i in items
                        select i.Quantity).Sum();
            }
        }

        public decimal Subtotal
        {
            get
            {
                if (Items.Length == 0) return 0;
                decimal subtotal = 0;
                foreach (ShoppingCartItem item in Items)
                {
                    subtotal += item.UnitPrice * item.Quantity;
                }
                return subtotal;
            }
        }

        public decimal AddItem(int productId, string productName, decimal unitPrice, int quantity)
        {
            ShoppingCartItem item = Items.Where(i => i.ProductId == productId).SingleOrDefault();
            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                item = new ShoppingCartItem();
                item.ProductId = productId;
                item.ProductName = productName;
                item.UnitPrice = unitPrice;
                item.Quantity = quantity;
                items.Add(item);
            }
            return Subtotal;
        }
    }
}
