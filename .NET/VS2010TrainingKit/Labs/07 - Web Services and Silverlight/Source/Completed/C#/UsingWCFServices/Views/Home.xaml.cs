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
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UsingWCFServices.WebServiceProxies;

namespace UsingWCFServices
{
    public partial class Home : Page
    {
        CustomersServiceClient _Proxy = new CustomersServiceClient();

        public Home()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _Proxy.GetCustomersCompleted += (s, args) => CustomersComboBox.ItemsSource = args.Result;
            _Proxy.GetOrdersByCustomerIDCompleted += (s, args) => OrdersDataGrid.ItemsSource = args.Result;
            _Proxy.UpdateSalesOrderHeaderCompleted += (s,args) =>
            {
                //Check returned OperationStatus object for status
                string errorMsg = (args.Result.Status) ? "succeeded" : "failed";
                MessageBox.Show("Update " + errorMsg);
            };
            _Proxy.GetCustomersAsync();
        }

        private void CustomersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int custID = ((Customer)CustomersComboBox.SelectedItem).CustomerID;
            _Proxy.GetOrdersByCustomerIDAsync(custID);
        }

        private void OrderDataForm_EditEnded(object sender, DataFormEditEndedEventArgs e)
        {
            if (e.EditAction == DataFormEditAction.Commit)
            {
                var order = OrderDataForm.CurrentItem as SalesOrderHeader;
                _Proxy.UpdateSalesOrderHeaderAsync(order);
            }
        }
    }
}