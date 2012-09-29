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
using System.Windows.Shapes;

namespace SilverlightWebBrowser
{
    public partial class InstallPrompt : UserControl
    {
        public InstallPrompt()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(InstallPrompt_Loaded);
            this.InstallButton.Click +=new RoutedEventHandler(InstallButton_Click);
        }

        void InstallPrompt_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.InstallState == InstallState.Installed)
            {
                InstallPanel.Visibility = Visibility.Collapsed;
                AlreadyInstalledPanel.Visibility = Visibility.Visible;
            }
            else
            {
                InstallPanel.Visibility = Visibility.Visible;
                AlreadyInstalledPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Install();
        }
    }
}
