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
using System.Windows;
using System.Windows.Controls;

namespace DesktopDashboard
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            this.CheckForUpdatesButton.Click += new RoutedEventHandler(CheckForUpdatesButton_Click);
        }


        void CheckForUpdatesButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.CheckAndDownloadUpdateAsync();
            Application.Current.CheckAndDownloadUpdateCompleted += new CheckAndDownloadUpdateCompletedEventHandler(Current_CheckAndDownloadUpdateCompleted);
        }

        void Current_CheckAndDownloadUpdateCompleted(object sender, CheckAndDownloadUpdateCompletedEventArgs e)
        {
            if (e.UpdateAvailable)
            {
                MessageBox.Show("An application update has been downloaded. " +
                    "Restart the application to run the new version.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show(
                    "An application update is available, but an error has occurred.\n" +
                    "This can happen, for example, when the update requires\n" +
                    "a new version of Silverlight or requires elevated trust.\n" +
                    "To install the update, visit the application home page.");
                LogErrorToServer(e.Error);
            }
            else
            {
                MessageBox.Show("There is no update available.");
            }
        }

        private void LogErrorToServer(Exception ex)
        {
            // Not implemented. Logging the exact error to the server can help
            // diagnose any problems that are not resolved by the user reinstalling
            // the application from its home page. 
        }



    }


}
