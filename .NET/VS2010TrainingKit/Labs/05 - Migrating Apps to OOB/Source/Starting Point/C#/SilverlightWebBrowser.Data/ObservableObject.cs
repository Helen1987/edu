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
using System.Diagnostics;
using System.Reflection;

namespace SilverlightWebBrowser.Data
{
    /// <summary>
    /// Provides an implementation of the INotifyPropertyChanged interface.
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged(params string[] properties)
        {
            if (properties == null || properties.Length == 0)
                throw new ArgumentNullException("properties");

            foreach (var propertyName in properties)
            {
                VerifyProperty(propertyName);

                PropertyChangedEventHandler propertyChangedHandler = PropertyChanged;

                if (propertyChangedHandler != null)
                    propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        [Conditional("DEBUG")]
        private void VerifyProperty(string propertyName)
        {
            PropertyInfo property = GetType().GetProperty(propertyName);

            if (property == null)
            {
                string message = string.Format("Invalid property: {0}", propertyName);
                throw new Exception(message);
            }
        }

        #endregion
    }
}