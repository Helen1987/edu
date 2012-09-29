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
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace ContosoRealtor.Controls
{
    [Export("ListingControl", typeof(FrameworkElement))]
    [PartMetadata("NetworkStatus", "Online")]
    public partial class DownloadListingsControl : UserControl
    {
        [Import("OfflineListingsPath")]
        string OfflineListingsPath { get; set; }

        [Import(typeof(IListingsRepository), AllowRecomposition=true)]
        IListingsRepository ListingsRepository { get; set; }

        [Import(typeof(ILogger))]
        ILogger Logger { get; set; }

        public DownloadListingsControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Logger.WriteLine("Downloading listings and saving to disk");
            using (TextWriter writer = new StreamWriter(OfflineListingsPath))
            {
                var serializer = new XmlSerializer(typeof(List<Listing>));
                serializer.Serialize(writer, ListingsRepository.GetAllListings());
            }

            MessageBox.Show("Listings downloaded");
        }
    }
}
