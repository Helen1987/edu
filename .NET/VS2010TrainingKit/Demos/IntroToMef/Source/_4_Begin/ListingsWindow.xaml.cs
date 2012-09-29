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
using System.Net.NetworkInformation;

namespace ContosoRealtor
{
    [Export]
    public partial class ListingsWindow : Window, IPartImportsSatisfiedNotification
    {
        [ImportMany(typeof(IListingsRepository))]
        Lazy<IListingsRepository, INetworkAwareness>[] ListingsRepositories { get; set; }

        IListingsRepository ListingsRepository { get; set; }

        public ListingsWindow()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            var status = NetworkInterface.GetIsNetworkAvailable() ? NetworkStatus.Online : NetworkStatus.Offline;
            foreach (var repo in ListingsRepositories)
            {
                if (repo.Metadata.Mode == status)
                {
                    ListingsRepository = repo.Value;
                    break;
                }
            }

            Dispatcher.Invoke(new Action(() =>
            {
                listingsGrid.ItemsSource = ListingsRepository.GetAllListings();
                repositoryStatus.Text = ListingsRepository.Status;
            }));
        }
    }
}
