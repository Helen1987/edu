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

using System.ServiceModel.DomainServices.Client;
using System.Windows;
using UsingRIAServices.Web.Models;
using UsingRIAServices.Web.Services;

namespace UsingRIAServices
{
    using System.Windows.Controls;
    using System.Windows.Navigation;

    /// <summary>
    /// Home page for the application.
    /// </summary>
    public partial class Home : Page
    {
        AdventureWorksLTDomainContext _Context = new AdventureWorksLTDomainContext();

        public Home()
        {
            InitializeComponent();

            this.Title = ApplicationStrings.HomePageTitle;
        }

        /// <summary>
        /// Executes when the user navigates to this page.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CustomersComboBox.ItemsSource = _Context.Customers;
            OrdersDataGrid.ItemsSource = _Context.SalesOrderHeaders;
            _Context.Load(_Context.GetCustomersQuery());
        }

        private void CustomersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int custID = ((Customer)CustomersComboBox.SelectedItem).CustomerID;
            if (_Context.EntityContainer != null) _Context.EntityContainer.GetEntitySet<SalesOrderHeader>().Clear();
            _Context.Load(_Context.GetOrdersByCustomerIDQuery(custID));
        }

        private void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_Context.HasChanges)
            {
                _Context.SubmitChanges(so =>
                    {
                        string errorMsg = (so.HasError) ? "failed" : "succeeded";
                        MessageBox.Show("Update " + errorMsg);
                    }, null);
            }
            else
            {
                MessageBox.Show("No changes have been made!");
            }
        }
    }
}