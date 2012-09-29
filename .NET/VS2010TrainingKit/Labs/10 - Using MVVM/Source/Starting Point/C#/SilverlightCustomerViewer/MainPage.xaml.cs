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
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightCustomerViewer.CustomerService.Proxies;

namespace SilverlightCustomerViewer
{
    public partial class MainPage : UserControl
    {

        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var proxy = new CustomerServiceClient();
            proxy.GetCustomersCompleted += proxy_GetCustomersCompleted;
            proxy.GetCustomersAsync();
        }

        void proxy_GetCustomersCompleted(object sender, GetCustomersCompletedEventArgs e)
        {
            CustomersComboBox.ItemsSource = e.Result;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var proxy = new CustomerServiceClient();
            var cust = CustomersComboBox.SelectedItem as Customer;
            cust.ChangeTracker.State = ObjectState.Modified;

            proxy.SaveCustomerCompleted += (s, args) =>
            {
                var opStatus = args.Result;
                string msg = (opStatus.Status) ? "Customer Updated!" : 
                                "Unable to update Customer: " + opStatus.Message;
                MessageBox.Show(msg);                 
            };
            proxy.SaveCustomerAsync(cust);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var proxy = new CustomerServiceClient();
            var cust = CustomersComboBox.SelectedItem as Customer;
            cust.ChangeTracker.State = ObjectState.Deleted;
            proxy.SaveCustomerCompleted += (s, args) =>
            {
                OperationStatus opStatus = args.Result;
                if (opStatus.Status)
                {
                    ((ObservableCollection<Customer>)CustomersComboBox.ItemsSource).Remove(cust);
                    MessageBox.Show("Customer deleted!");
                }
                else
                {
                    MessageBox.Show("Unable to delete Customer: " + opStatus.Message);
                }
            };
            proxy.SaveCustomerAsync(cust);
        }
    }
}
