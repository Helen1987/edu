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

namespace ContosoAutomotive
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using ContosoAutomotive.Common;

    [Export]
    public partial class CashMaker : Window
    {
        int numberOfCarsToGenerate = 2000000;

        List<Car> cars = new List<Car>();
        Stopwatch stopwatch = new Stopwatch();
        CancellationTokenSource searchOperation = new CancellationTokenSource();

        [ImportMany(typeof(ICarQuery), AllowRecomposition = true)]
        public ObservableCollection<ICarQuery> CarQueries { get; set; }

        public CashMaker()
        {
            this.InitializeComponent();

            this.CarQueries = new ObservableCollection<ICarQuery>();
            this.commandGrid.DataContext = this.CarQueries;

            Task.Factory.StartNew(() => this.GenerateCars());
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            this.searchOperation = new CancellationTokenSource();
            this.RunQueries();
        }

        private void parallelSearchButton_Click(object sender, RoutedEventArgs e)
        {
            this.searchOperation = new CancellationTokenSource();
            this.RunQueriesInParallel();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.searchOperation.Cancel();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Do something more interesting in the future
            MessageBox.Show("Buying Cars. We're going to be RICH");
        }

        private void RunQueries()
        {
            this.DisableSearch();
            Task.Factory.StartNew(() =>
            {
                this.BeginTiming();
                foreach (var query in this.CarQueries)
                {
                    if (this.searchOperation.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    query.Run(this.cars, true);
                };
                this.EndSequentialTiming();
            }, this.searchOperation.Token).ContinueWith(_ => this.EnableSearch());
        }

        private void RunQueriesInParallel()
        {
            this.DisableSearch();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    this.BeginTiming();
                    var options = new ParallelOptions() { CancellationToken = this.searchOperation.Token };
                    Parallel.ForEach(this.CarQueries, options, (query) =>
                    {
                        query.Run(this.cars, true);
                    });
                    this.EndParallelTiming();
                }
                catch (OperationCanceledException) { /* Do nothing as we cancelled it */ }
            }, this.searchOperation.Token).ContinueWith(_ => this.EnableSearch());
        }

        private void CalculateImprovement()
        {
            if (this.runtimeLabel.Content != null && this.parallelRuntimeLabel.Content != null)
            {
                double improvement = ((double)this.runtimeLabel.Content) / ((double)this.parallelRuntimeLabel.Content);
                this.runtimeImprovementLabel.Content = string.Format("{0}x", Math.Round(improvement, 2));
            }
        }

        private void GenerateCars()
        {
            var generator = new CarGenerator();

            for (int i = 0; i < this.numberOfCarsToGenerate; i++)
            {
                this.cars.Add(generator.Generate());

                if (i % 10000 == 0)
                {
                    int progress = (int)(((double)i / 2000000) * 100);
                    Dispatcher.Invoke(new Action(() => this.progressBar.Value = progress));
                }

                if (i % 200000 == 0)
                {
                    var currentCars = this.cars.ToArray();
                    Task.Factory.StartNew(() =>
                    {
                        Parallel.ForEach(this.CarQueries, query =>
                        {
                            query.Run(currentCars, false);
                        });
                    });
                }
            }

            this.EnableSearch();
            Dispatcher.Invoke(new Action(() => this.progressBar.Visibility = Visibility.Collapsed));
        }

        private void BeginTiming()
        {
            this.stopwatch.Reset();
            this.stopwatch.Start();
        }

        private void EndSequentialTiming()
        {
            this.stopwatch.Stop();

            Dispatcher.Invoke(new Action(() =>
            {
                this.runtimeLabel.Content = Math.Round(this.stopwatch.Elapsed.TotalSeconds, 4);
                this.CalculateImprovement();
            }));
        }

        private void EndParallelTiming()
        {
            this.stopwatch.Stop();

            Dispatcher.Invoke(new Action(() =>
            {
                this.parallelRuntimeLabel.Content = Math.Round(this.stopwatch.Elapsed.TotalSeconds, 4);
                this.CalculateImprovement();
            }));
        }

        private void DisableSearch()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                this.searchButton.Opacity = 0.25;
                this.searchButton.IsEnabled = false;
                this.parallelSearchButton.Opacity = 0.25;
                this.parallelSearchButton.IsEnabled = false;
                this.cancelButton.Opacity = 1;
                this.cancelButton.IsEnabled = true;
            }));
        }

        private void EnableSearch()
        {
            Dispatcher.Invoke(new Action(() =>
            {
                this.searchButton.Opacity = 1;
                this.searchButton.IsEnabled = true;
                this.parallelSearchButton.Opacity = 1;
                this.parallelSearchButton.IsEnabled = true;
                this.cancelButton.Opacity = 0.25;
                this.cancelButton.IsEnabled = false;
            }));
        }
    }
}
