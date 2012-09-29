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
using System.ServiceModel;
using System.ServiceModel.Web;
using CustomerService.Model;
using CustomersService.Model.Entities;

namespace CustomersService
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        OperationStatus SaveCustomer(Customer customer);

        [OperationContract]
        [WebInvoke(Method = "GET",
           UriTemplate = "DeleteCustomer/{custID}",
           ResponseFormat = WebMessageFormat.Json)]
        OperationStatus DeleteCustomer(string custID);

        [OperationContract]
        [WebInvoke(Method = "GET",
           UriTemplate = "UpdateCustomer?CustomerID={customerID}&FirstName={firstName}&" +
                         "LastName={lastName}&CompanyName={companyName}&" + 
                         "EmailAddress={emailAddress}&Phone={phone}",
           ResponseFormat = WebMessageFormat.Json)]
        OperationStatus UpdateCustomer(string customerID, string firstName, string lastName, 
            string companyName, string emailAddress, string phone);

        [OperationContract]
        [WebInvoke(Method="GET",
                   UriTemplate = "GetCustomer/{custID}", 
                   ResponseFormat = WebMessageFormat.Json)]
        Customer GetCustomer(string custID);

    }
}
