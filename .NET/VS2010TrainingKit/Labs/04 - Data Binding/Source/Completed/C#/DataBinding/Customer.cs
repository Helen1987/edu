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
using System.ComponentModel;

namespace DataBinding
{
    public class Customer : INotifyPropertyChanged
    {
        string _Name;
        string _City;
        string _State;
        string _ImageUrl;
        private bool _IsGold;
        private DateTime _Birthday;

        public string Name {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public bool IsGold
        {
            get
            {
                return _IsGold;
            }

            set
            {
                if (_IsGold != value)
                {
                    _IsGold = value;
                    OnPropertyChanged("IsGold");
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                return _Birthday;
            }

            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value;
                    OnPropertyChanged("Birthday");
                }
            }
        }

        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged("City");
                }
            }
        }
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                if (_State != value)
                {
                    _State = value;
                    OnPropertyChanged("State");
                }
            }
        }

        public string ImageUrl
        {
            get
            {
                return _ImageUrl;
            }
            set
            {
                if (_ImageUrl != value)
                {
                    _ImageUrl = value;
                    OnPropertyChanged("ImageUrl");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
