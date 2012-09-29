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
using System.Collections.ObjectModel;
using SilverlightCustomerViewer.CustomerService.Proxies;
using SilverlightCustomerViewer.ServiceAgents;
using SilverlightCustomerViewer.Commanding;

namespace SilverlightCustomerViewer.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private Customer _CurrentCustomer;
        private ObservableCollection<Customer> _Customers;
        private string _StatusMessage;

        public MainPageViewModel() : this(new CustomersServiceAgent())
        {
        }

        public MainPageViewModel(ICustomersServiceAgent serviceAgent)
        {
            if (!IsDesignTime)
            {
                if (serviceAgent != null) ServiceAgent = serviceAgent;
                GetCustomers();
                WireCommands();
            }
        }

        private void WireCommands()
        {
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer);
        }

        #region Commands

        public RelayCommand UpdateCustomerCommand
        {
            get;
            private set;
        }

        public RelayCommand DeleteCustomerCommand
        {
            get;
            private set;
        }

        #endregion

        #region Properties

        private ICustomersServiceAgent ServiceAgent { get; set; }


        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _Customers;
            }

            set
            {
                if (_Customers != value)
                {
                    _Customers = value;
                    OnPropertyChanged("Customers");
                }
            }
        }

        public Customer CurrentCustomer
        {
            get
            {
                return _CurrentCustomer;
            }

            set
            {
                if (_CurrentCustomer != value)
                {
                    _CurrentCustomer = value;
                    OnPropertyChanged("CurrentCustomer");
                    StatusMessage = String.Empty;
                    UpdateCustomerCommand.IsEnabled = true;
                    DeleteCustomerCommand.IsEnabled = true;
                }
            }
        }

        public string StatusMessage
        {
            get
            {
                return _StatusMessage;
            }

            set
            {
                if (_StatusMessage != value)
                {
                    _StatusMessage = value;
                    OnPropertyChanged("StatusMessage");
                }
            }
        }
        
        #endregion

        private void GetCustomers()
        {
            ServiceAgent.GetCustomers((s, e) => Customers = e.Result);
        }

        public void UpdateCustomer()
        {
            SaveCustomer(ObjectState.Modified);
        }

        public void DeleteCustomer()
        {
            SaveCustomer(ObjectState.Deleted);
            Customers.Remove(CurrentCustomer);
            CurrentCustomer = null;
        }

        private void SaveCustomer(ObjectState state)
        {
            CurrentCustomer.ChangeTracker.State = state;
            ServiceAgent.SaveCustomer(CurrentCustomer, (s, e) =>
            {
                StatusMessage = (e.Result.Status) ? "Success!" : "Unable to complete operation";
            });
        }
    }
}
