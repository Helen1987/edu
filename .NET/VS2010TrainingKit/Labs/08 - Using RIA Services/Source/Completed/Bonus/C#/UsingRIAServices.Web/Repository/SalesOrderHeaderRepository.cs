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
using CustomersService.Repository;
using UsingRIAServices.Models;
using UsingRIAServices.Web.Models;

namespace UsingRIAServices.Web.Repository
{
    public interface ISalesOrderHeaderRepository
    {
        IQueryable<SalesOrderHeader> GetOrdersByCustomerID(int custID);
        OperationStatus UpdateSalesOrderHeader(SalesOrderHeader order);
    }

    public class SalesOrderHeaderRepository : RepositoryBase<AdventureWorksLT_DataEntities>, ISalesOrderHeaderRepository
    {
        #region ICustomerRepository Members

        public IQueryable<SalesOrderHeader> GetOrdersByCustomerID(int custID)
        {
             return DataContext.SalesOrderHeaders.Where(so => so.CustomerID == custID);
        }

        public OperationStatus UpdateSalesOrderHeader(SalesOrderHeader order)
        {
            //Allow OrderDate and Comments to be updated
            return Update(order, "OrderDate", "Comment");
        }

        #endregion


    }
}