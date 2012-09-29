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


namespace UsingRIAServices.Web.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using UsingRIAServices.Web.Models;


    // Implements application logic using the AdventureWorksLT_DataEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class AdventureWorksLTDomainService : LinqToEntitiesDomainService<AdventureWorksLT_DataEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Customers' query.
        public IQueryable<Customer> GetCustomers()
        {
            return from c in ObjectContext.Customers
                   join o in ObjectContext.SalesOrderHeaders on c.CustomerID equals o.CustomerID
                   orderby c.LastName
                   select c;
        }

       // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SalesOrderHeaders' query.
        public IQueryable<SalesOrderHeader> GetOrdersByCustomerID(int customerID)
        {
            return this.ObjectContext.SalesOrderHeaders.Where(so => so.CustomerID == customerID);
        }

        public void InsertSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            if ((salesOrderHeader.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(salesOrderHeader, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SalesOrderHeaders.AddObject(salesOrderHeader);
            }
        }

        public void UpdateSalesOrderHeader(SalesOrderHeader currentSalesOrderHeader)
        {
            this.ObjectContext.SalesOrderHeaders.AttachAsModified(currentSalesOrderHeader, this.ChangeSet.GetOriginal(currentSalesOrderHeader));
        }

        public void DeleteSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            if ((salesOrderHeader.EntityState == EntityState.Detached))
            {
                this.ObjectContext.SalesOrderHeaders.Attach(salesOrderHeader);
            }
            this.ObjectContext.SalesOrderHeaders.DeleteObject(salesOrderHeader);
        }
    }
}


