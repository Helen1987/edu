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
using System.ServiceModel.Web;
using System.Text;
using CustomerService.Model;
using CustomersService.Repository;
using CustomersService.Model.Entities;

namespace CustomersService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerService : ICustomerService
    {

        #region ICustomerService Members

        public List<Customer> GetCustomers()
        {
            return new CustomerRepository().GetCustomers();
        }

        public OperationStatus SaveCustomer(Customer customer)
        {
            return new CustomerRepository().SaveCustomer(customer);
        }

        public Customer GetCustomer(int custID)
        {
            return new CustomerRepository().GetCustomer(custID);
        }

        #endregion
    }
}
