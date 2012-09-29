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
        private int productSetSize;
        private const int PageSize = 8;
        private int currentPageNumber = 0;

        private int TotalPages
        {
            get
            {
                return (this.productSetSize / PageSize) + (this.productSetSize % PageSize > 0 ? 1 : 0);
            }
        }

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
                ProductsListView.ItemsSource = gateway.GetProducts(NameTextBox.Text, CategoryComboBox.SelectedItem as ProductCategory, PageSize, this.currentPageNumber);
                this.UpdateNavigationButtons();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.BindCategories();
            this.UpdateNavigationButtons();
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
            this.currentPageNumber = 0;
            this.RecalculateProductsSetSize();
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
                this.RecalculateProductsSetSize();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.BindProducts();
            this.RecalculateProductsSetSize();
        }

        private void RecalculateProductsSetSize()
        {
            ProductGateway gateway = new ProductGateway();
            this.productSetSize = gateway.GetProductsCount(NameTextBox.Text, CategoryComboBox.SelectedItem as ProductCategory);
            this.TotalProductsCountLabel.Text = string.Format(CultureInfo.CurrentUICulture, "Total Products in Category: {0}", this.productSetSize);
        }

        private void previousPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentPageNumber -= 1;
            this.BindProducts();
        }

        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentPageNumber += 1;
            this.BindProducts();
        }

        private void UpdateNavigationButtons()
        {
            this.PreviousPageButton.IsEnabled = (this.currentPageNumber > 0);

            this.CurrentPageLabel.Text = string.Format(CultureInfo.CurrentUICulture, "Current Page: {0}", this.currentPageNumber + 1);

            this.NextPageButton.IsEnabled = this.currentPageNumber < (this.TotalPages - 1);
        }
    }
}
