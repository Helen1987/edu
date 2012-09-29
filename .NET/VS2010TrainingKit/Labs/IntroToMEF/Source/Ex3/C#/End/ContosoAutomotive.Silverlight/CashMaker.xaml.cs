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
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using ContosoAutomotive.Common;
using System.Threading;

namespace ContosoAutomotive.Silverlight
{
    [Export]
    public partial class CashMaker : UserControl, IPartImportsSatisfiedNotification
    {
        int numberOfCarsToGenerate = 200000;

        List<Car> cars = new List<Car>();

        bool SearchEnabled = false;

        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<Lazy<ICarQuery, IQueryMetadata>> CarQueries { get; set; }

        public CashMaker()
        {
            InitializeComponent();
            new Thread(() => this.GenerateCars()).Start();
        }

        private void GenerateCars()
        {
            this.DisableSearch();
            var generator = new CarGenerator();

            for (int i = 0; i < this.numberOfCarsToGenerate; i++)
            {
                this.cars.Add(generator.Generate());

                if (i % 10000 == 0)
                {
                    int progress = (int)(((double)i / numberOfCarsToGenerate) * 100);
                    Dispatcher.BeginInvoke(() => this.progressBar.Value = progress);
                }
            }

            this.EnableSearch();
            Dispatcher.BeginInvoke(() => this.progressBar.Visibility = Visibility.Collapsed);
        }

        private void DisableSearch()
        {
            this.SearchEnabled = false;
        }

        private void EnableSearch()
        {
            this.SearchEnabled = true;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Do something more interesting in the future
            MessageBox.Show("Buying Cars. We're going to be RICH");
        }

        private void commandList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.SearchEnabled)
            {
                this.DisableSearch();

                var thread = new Thread(() =>
                {
                    if (e.AddedItems.Count > 0)
                    {
                        var query = e.AddedItems[0] as Lazy<ICarQuery, IQueryMetadata>;

                        if (query != null)
                        {
                            query.Value.Run(this.cars, true);
                        }

                        Dispatcher.BeginInvoke(() => this.Results.ItemsSource = query.Value.Results);
                    }

                    this.EnableSearch();
                });

                thread.Start();
                thread.Join();
            }
        }

        public void OnImportsSatisfied()
        {
            this.commandGrid.DataContext = this.CarQueries;
        }
    }
}