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

namespace UsingRIAServices
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows.Browser;

    /// <summary>
    /// Wraps access to the strongly typed resource classes so that you can bind
    /// control properties to resource strings in XAML
    /// </summary>
    public sealed class ResourceWrapper
    {
        private static ApplicationStrings applicationStrings = new ApplicationStrings();
        private static SecurityQuestions securityQuestions = new SecurityQuestions();

        /// <summary>
        /// Gets the <see cref="ApplicationStrings"/>.
        /// </summary>
        public ApplicationStrings ApplicationStrings
        {
            get { return applicationStrings; }
        }

        /// <summary>
        /// Gets the <see cref="SecurityQuestions"/>.
        /// </summary>
        public SecurityQuestions SecurityQuestions
        {
            get { return securityQuestions; }
        }
    }
}
