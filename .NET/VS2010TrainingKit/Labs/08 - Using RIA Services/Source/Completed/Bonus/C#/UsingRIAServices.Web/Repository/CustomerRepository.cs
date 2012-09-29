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
using System.Data;
using System.Data.Objects;
using System.Linq;
using UsingRIAServices.Models;
using UsingRIAServices.Web.Models;

namespace CustomersService.Repository
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
    }

    public class CustomerRepository : RepositoryBase<AdventureWorksLT_DataEntities>, ICustomerRepository
    {
        #region ICustomerRepository Members

        public IQueryable<Customer> GetCustomers()
        {
            return from c in DataContext.Customers
            join o in DataContext.SalesOrderHeaders on c.CustomerID equals o.CustomerID
            orderby c.LastName
            select c;
        }

        #endregion


    }
}