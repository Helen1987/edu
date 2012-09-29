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

namespace UsingRIAServices.Web
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Extensions to the <see cref="User"/> class.
    /// </summary>
    public partial class User
    {
        #region Make DisplayName Bindable

        /// <summary>
        /// Override of the <c>OnPropertyChanged</c> method that generates
        /// property change notifications when <see cref="User.DisplayName"/> changes.
        /// </summary>
        /// <param name="e">The property change event args.</param>
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            base.OnPropertyChanged(e);

            if (e.PropertyName == "Name" || e.PropertyName == "FriendlyName")
            {
                this.RaisePropertyChanged("DisplayName");
            }
        }
        #endregion
    }
}
