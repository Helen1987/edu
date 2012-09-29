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


using CustomersService.Repository;
using UsingRIAServices.Models;
using UsingRIAServices.Web.Repository;

namespace UsingRIAServices.Web.Services
{
    using System;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using UsingRIAServices.Web.Models;


    // Implements application logic using the AdventureWorksLT_DataEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class AdventureWorksLTDomainService : DomainService
    {
        ICustomerRepository _CustomerRepository = new CustomerRepository();
        ISalesOrderHeaderRepository _OrderRepository = new SalesOrderHeaderRepository();

        public IQueryable<Customer> GetCustomers()
        {
            return _CustomerRepository.GetCustomers();
        }

        public IQueryable<SalesOrderHeader> GetOrdersByCustomerID(int customerID)
        {
            return _OrderRepository.GetOrdersByCustomerID(customerID);
        }

        public void UpdateSalesOrderHeader(SalesOrderHeader order)
        {
            OperationStatus opStatus = _OrderRepository.UpdateSalesOrderHeader(order);
            if (!opStatus.Status)
            {
                throw new DomainException("Unable to update order.", 1, opStatus.Exception);
            }
        }
    }
}


