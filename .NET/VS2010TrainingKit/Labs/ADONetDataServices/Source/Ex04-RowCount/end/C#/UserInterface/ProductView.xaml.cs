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
    using System.Windows;
    using UserInterface.AdventureWorks;
    using UserInterface.Gateways;

    /// <summary>
    /// Interaction logic for Window2.xaml .
    /// </summary>
    public partial class ProductView : Window
    {
        private bool formCreateMode = true;

        public ProductView()
        {
            InitializeComponent();
        }

        private bool FormCreateMode
        {
            get
            {
                return this.formCreateMode;
            }

            set
            {
                this.formCreateMode = value;
            }
        }

        private Product Product
        {
            get;
            set;
        }

        public void UpdateProduct(Product product)
        {
            ProductGateway gateway = new ProductGateway();
            this.Product = gateway.GetProducts(product.Name, product.ProductCategory, 1, 0)[0];
            this.FormCreateMode = false;
            this.Title = "Edit " + product.Name;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.BindCategories();
            if (this.FormCreateMode)
            {
                Product = new Product();
            }

            this.BindProduct();
        }

        private void BindProduct()
        {
            txtProductNumber.DataContext = Product;
            txtName.DataContext = Product;
            txtListPrice.DataContext = Product;
            txtColor.DataContext = Product;
            CategoryComboBoxProductDetail.DataContext = Product;
            txtModifiedDate.DataContext = Product;
            txtSellStartDate.DataContext = Product;
            txtStandardCost.DataContext = Product;
        }

        private void BindCategories()
        {
            ProductGateway gateway = new ProductGateway();
            CategoryComboBoxProductDetail.ItemsSource = gateway.GetCategories();
            CategoryComboBoxProductDetail.SelectedIndex = 0;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            ProductGateway gateway = new ProductGateway();
            if (this.FormCreateMode)
            {
                Product.ProductCategory = (ProductCategory)CategoryComboBoxProductDetail.SelectedItem;
                gateway.AddProduct(Product);
            }
            else
            {
                Product.ProductCategory = (ProductCategory)CategoryComboBoxProductDetail.SelectedItem;
                gateway.UpdateProduct(Product);
            }

            this.Close();
        }
    }
}
