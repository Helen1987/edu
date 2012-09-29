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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace DataBinding
{
    public class CustomerContainer : INotifyPropertyChanged
    {

        const string IMAGE = "Images/blue.png";
        private ObservableCollection<State> _States;
        private ObservableCollection<Customer> _Customers;
        private Customer _CurrentCustomer;
        private State _CurrentState;
        private ObservableCollection<Customer> _FilteredCustomers;


        public CustomerContainer()
        {
            States = new ObservableCollection<State>
            {
                new State{Name="View All"},
                new State{Name="Arizona",Abbreviation="AZ"},
                new State{Name="California",Abbreviation="CA"},
                new State{Name="Nevada",Abbreviation="NV"}
            };

            Customers = new ObservableCollection<Customer>
            {
                new Customer{Name="John Doe",City="Phoenix",
                        State="Arizona",IsGold=true,
                        Birthday=new DateTime(1950,5,10),ImageUrl=IMAGE},
                new Customer{Name="Jane Doe",City="Tempe",
                        State="Arizona",Birthday=new DateTime(1970,4,13),ImageUrl=IMAGE},
                new Customer{Name="Johnny Doe",City="San Diego",
                        State="California",Birthday=new DateTime(1980,8,26),ImageUrl=IMAGE},
                new Customer{Name="James Doe",City="Las Vegas",
                        State="Nevada",IsGold=true,
                        Birthday=new DateTime(1956,8,30),ImageUrl=IMAGE},
                new Customer{Name="Gina Doe",City="Anaheim",
                        State="California",Birthday=new DateTime(1984,2,28),ImageUrl=IMAGE}
            };
            FilteredCustomers = Customers;
        }


        #region Properties

        public ObservableCollection<Customer> FilteredCustomers
        {
            get
            {
                return _FilteredCustomers;
            }

            set
            {
                if (_FilteredCustomers != value)
                {
                    _FilteredCustomers = value;
                    OnPropertyChanged("FilteredCustomers");
                }
            }
        }

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

        public ObservableCollection<State> States
        {
            get
            {
                return _States;
            }

            set
            {
                if (_States != value)
                {
                    _States = value;
                    OnPropertyChanged("States");
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
                }
            }
        }

        public State CurrentState
        {
            get
            {
                return _CurrentState;
            }

            set
            {
                if (_CurrentState != value)
                {
                    _CurrentState = value;
                    OnPropertyChanged("CurrentState");
                    FilterCustomersByState();
                }
            }
        }

        #endregion

        private void FilterCustomersByState()
        {
            if (CurrentState != null)
            {
                if (CurrentState.Name != "View All")
                {
                    var customers = Customers.Where(c => c.State == CurrentState.Name);
                    FilteredCustomers = new ObservableCollection<Customer>(customers);
                }
                else
                {
                    FilteredCustomers = Customers;
                }
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
    }
}
