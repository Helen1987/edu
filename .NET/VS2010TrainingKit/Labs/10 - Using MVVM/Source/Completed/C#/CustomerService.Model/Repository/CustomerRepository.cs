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
using System.Linq;
using CustomerService.Model;
using CustomersService.Model.Entities;

namespace CustomersService.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int custID);
        List<Customer> GetCustomers();
        OperationStatus SaveCustomer(Customer customer);
    }

    public class CustomerRepository : RepositoryBase<AdventureWorksLT_DataEntities>, ICustomerRepository
    {
        #region ICustomerRepository Members

        public Customer GetCustomer(int custID)
        {
            using (DataContext)
            {
                return Get<Customer>(c => c.CustomerID == custID);
            }
        }

        public List<Customer> GetCustomers()
        {
            using (DataContext)
            {
                return GetList<Customer, string>(c => c.LastName).Take(50).ToList();
            }
        }

        //Can handle insert, update or delete
        public OperationStatus SaveCustomer(Customer customer)
        {
            using (DataContext)
            {
                if (customer.ChangeTracker.State == ObjectState.Deleted)
                {
                    //Handle foreign key deletions using sproc
                    return DeleteCustomer(customer.CustomerID);
                }
                return Save(customer);
            }
        }

        private OperationStatus DeleteCustomer(int id)
        {
            OperationStatus opStatus;

            using (DataContext)
            {
                opStatus = ExecuteStoreCommand("exec DeleteCustomer {0}", id);
            }
            if (opStatus.RecordsAffected == 0)
            {
                opStatus.Status = false;
                opStatus.Message = "Unable to delete customer: " + opStatus.Message;
            }
            return opStatus;
        }

        #endregion


    }
}