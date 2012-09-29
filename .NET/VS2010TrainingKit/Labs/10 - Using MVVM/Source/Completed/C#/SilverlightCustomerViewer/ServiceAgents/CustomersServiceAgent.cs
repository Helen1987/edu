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
using SilverlightCustomerViewer.CustomerService.Proxies;

namespace SilverlightCustomerViewer.ServiceAgents
{
    public interface ICustomersServiceAgent
    {
        void GetCustomers(EventHandler<GetCustomersCompletedEventArgs> callback);
        void SaveCustomer(Customer cust, EventHandler<SaveCustomerCompletedEventArgs> callback);
    }

    public class CustomersServiceAgent : ICustomersServiceAgent
    {
        CustomerServiceClient _Proxy = new CustomerServiceClient();

        #region ICustomersServiceAgent Members

        public void GetCustomers(EventHandler<GetCustomersCompletedEventArgs> callback)
        {
            _Proxy.GetCustomersCompleted += callback;
            _Proxy.GetCustomersAsync();
        }

        public void SaveCustomer(Customer cust, EventHandler<SaveCustomerCompletedEventArgs> callback)
        {
            _Proxy.SaveCustomerCompleted += callback;
            _Proxy.SaveCustomerAsync(cust);
        }

        #endregion
    }
}
