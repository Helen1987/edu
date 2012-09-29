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

namespace UserInterface
{
    using System;
    using System.Globalization;
    using System.Windows;
    using UserInterface.AdventureWorks;
    using UserInterface.Gateways;

    public partial class ProductList
    {
        public ProductList()
        {
            this.InitializeComponent();
            ProductsListView.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ProductsListView_MouseDoubleClick);
        }

        private void BindCategories()
        {
            ProductGateway gateway = new ProductGateway();
            CategoryComboBox.ItemsSource = gateway.GetCategories();
            CategoryComboBox.SelectedIndex = 0;
        }

        private void BindProducts()
        {
            if (CategoryComboBox.SelectedIndex > -1)
            {
                ProductGateway gateway = new ProductGateway();
                ProductsListView.ItemsSource = gateway.GetProducts(NameTextBox.Text, CategoryComboBox.SelectedItem as ProductCategory);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.BindCategories();
        }

        private void ProductsListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Product p = ProductsListView.SelectedItem as Product;
            ProductView window = new ProductView();
            window.Closed += new EventHandler(this.Window_Closed);
            window.UpdateProduct(p);
            window.Show();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.BindProducts();
        }

        private void BtnNewProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductView window = new ProductView();
            window.Closed += new EventHandler(this.Window_Closed);
            window.Show();
        }

        private void BtnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            Product p = ProductsListView.SelectedItem as Product;
            if (p != null)
            {
                ProductGateway gateway = new ProductGateway();
                gateway.DeleteProduct(p);
                this.BindProducts();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.BindProducts();
        }
    }
}
