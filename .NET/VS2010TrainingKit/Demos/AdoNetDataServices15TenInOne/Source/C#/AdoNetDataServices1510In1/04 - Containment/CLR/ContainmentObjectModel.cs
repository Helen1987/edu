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

namespace AdoNetDataServices1510In1.Containment.CLR
{
    public class ContainmentObjectModel
    {
        private IEnumerable<Customer> _customers;
        private IEnumerable<Order> _orders;
        private IEnumerable<OrderDetail> _orderDetails;
        private IEnumerable<Product> _products;

        public ContainmentObjectModel()
        {
            _products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "XBOX 360",
                    Price = 300.99f
                },
                new Product
                {
                    Id = 2,
                    Name = "Fishing Pole",
                    Price = 12.36f
                },
                new Product
                {
                    Id = 3,
                    Name = "Bunny Bread",
                    Price = 1.89f
                },
                new Product
                {
                    Id = 4,
                    Name = "Grand Piano",
                    Price = 13000f
                }
            };

            _orderDetails = new OrderDetail[]
            {
                new OrderDetail()
                {
                    Id = 1,
                    Product = _products.Single(p => p.Id == 1),
                    Quantity = 100,
                },
                new OrderDetail()
                {
                    Id = 2,
                    Product = _products.Single(p => p.Id == 2),
                    Quantity = 50,
                }
            };

            _orders =new Order[]
            {
                new Order()
                {
                    Id = 1,
                    SubTotal = 50f, Tax = 10f, Total = 60f,
                    OrderDetails = _orderDetails.ToArray()
                },
                new Order()
                {
                    Id = 2,
                    SubTotal = 100f, Tax = 20f, Total = 120f,
                    OrderDetails = _orderDetails.ToArray()
                }
            };

            _customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "Jonathan",
                    LastName = "Carter",
                    Orders = _orders.ToArray()
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Drew",
                    LastName = "Robbins",
                    Orders = _orders.ToArray()
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Jason",
                    LastName = "Olson",
                    Orders = _orders.ToArray()
                }
            };
        }

        public IQueryable<Order> Orders
        {
            get
            {
                return _orders.AsQueryable();
            }
        }

        public IQueryable<OrderDetail> OrderDetails
        {
            get
            {
                return _orderDetails.AsQueryable();
            }
        }

        public IQueryable<Product> Products
        {
            get
            {
                return _products.AsQueryable();
            }
        }

        public IQueryable<Customer> Customers
        {
            get
            {
                return _customers.AsQueryable();
            }
        }
    }

    [DataServiceKey("Id")]
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Order[] Orders { get; set; }
    }

    [DataServiceKey("Id")]
    public class Order
    {
        public int Id { get; set; }
        public float SubTotal { get; set; }
        public float Tax { get; set; }
        public float Total { get; set; }
        public OrderDetail[] OrderDetails { get; set; }
    }

    [DataServiceKey("Id")]
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

    [DataServiceKey("Id")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}