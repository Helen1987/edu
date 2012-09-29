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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Southridge
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Southridge.SouthridgeDataSet SouthridgeDataSet = ((Southridge.SouthridgeDataSet)(this.FindResource("SouthridgeDataSet")));
            // Load data into the table Listings. You can modify this code as needed.
            Southridge.SouthridgeDataSetTableAdapters.ListingsTableAdapter southridgeDataSetListingsTableAdapter = new Southridge.SouthridgeDataSetTableAdapters.ListingsTableAdapter();
            southridgeDataSetListingsTableAdapter.Fill(SouthridgeDataSet.Listings);
            System.Windows.Data.CollectionViewSource listingsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("listingsViewSource")));
            listingsViewSource.View.MoveCurrentToFirst();
        }
    }
}
