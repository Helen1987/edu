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

namespace ContosoAutomotive.Common
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public abstract class CarQueryBase : ICarQuery, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<Car> _results;
        public List<Car> Results
        {
            get { return this._results; }
            set { this._results = value; this.ResultsCount = this._results.Count(); this.NotifyPropertyChanged("Results"); }
        }

        private int _resultsCount;
        public int ResultsCount
        {
            get { return this._resultsCount; }
            set { this._resultsCount = value; this.NotifyPropertyChanged("ResultsCount"); }
        }

        protected CarQueryBase()
        {
        }

        private void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void Run(IEnumerable<Car> cars, bool longRunning)
        {
            if (longRunning)
            {
                System.Threading.Thread.SpinWait(80000000);
            }

            this.Results = this.RunQuery(cars).ToList();
        }

        protected abstract IEnumerable<Car> RunQuery(IEnumerable<Car> cars);
    }
}
