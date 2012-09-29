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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using UsingWCFServices.Models;
using UsingWCFServices.Web.Models;

namespace UsingWCFServices.Web.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomersService
    {
        ICustomerRepository _CustomerRepository = new CustomerRepository();
        ISalesOrderHeaderRepository _OrderRepository = new SalesOrderHeaderRepository();

        [OperationContract]
        public List<Customer> GetCustomers()
        {
            return _CustomerRepository.GetCustomers();
        }

        [OperationContract]
        public List<SalesOrderHeader> GetOrdersByCustomerID(int customerID)
        {
            return _OrderRepository.GetOrdersByCustomerID(customerID);
        }

        [OperationContract]
        public OperationStatus UpdateSalesOrderHeader(SalesOrderHeader order)
        {
            return _OrderRepository.UpdateSalesOrderHeader(order);
        }
    }
}
