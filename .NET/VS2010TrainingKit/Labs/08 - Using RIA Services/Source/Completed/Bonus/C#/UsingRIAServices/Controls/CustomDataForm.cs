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

namespace UsingRIAServices.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using UsingRIAServices.Web;

    /// <summary>
    /// Enhances <see cref="DataForm" /> functionality by using a <see cref="PasswordBox" /> 
    /// control for password fields and exposing a <see cref="CustomDataForm.Fields"/> collection 
    /// to allow runtime access to <see cref="DataForm" /> fields.
    /// </summary>
    public class CustomDataForm : DataForm
    {
        private Dictionary<string, DataField> fields = new Dictionary<string, DataField>();

        /// <summary>
        /// Returns a <c>Dictionary&lt;string,DataField&gt;</c> containing all the
        /// <see cref="DataField" /> controls being displayed keyed by the
        /// property name to which each field is bound.
        /// </summary>
        public Dictionary<string, DataField> Fields
        {
            get { return this.fields; }
        }

        /// <summary>
        /// Extends <see cref="DataForm.OnAutoGeneratingField" /> by replacing <see cref="TextBox"/>es with <see cref="PasswordBox"/>es
        /// whenever applicable
        /// </summary>
        protected override void OnAutoGeneratingField(DataFormAutoGeneratingFieldEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            // Get metadata about the property being defined
            PropertyInfo propertyInfo = this.CurrentItem.GetType().GetProperty(e.PropertyName);

            // Do the password field replacement if that is the case
            if (e.Field.Content is TextBox && this.IsPasswordProperty(propertyInfo))
            {
                e.Field.ReplaceTextBox(new PasswordBox(), PasswordBox.PasswordProperty);
            }

            // Keep this newly generated field accessible through the Fields property
            this.fields[e.PropertyName] = e.Field;

            // Call base implementation (which will call other event listeners)
            base.OnAutoGeneratingField(e);
        }

        /// <param name="propertyInfo">The entity property being analyzed</param>
        /// <summary>
        /// Returns whether the given property should be represented by a <see cref="PasswordBox" /> or not.
        /// The default implementation will simply use a naming convention and returns true if the
        /// property contains the word "Password".
        /// </summary>
        protected virtual bool IsPasswordProperty(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException("propertyInfo");
            }

            // Suggestion: to handle more complex scenarios, allow an entity to override
            // this mechanism by using the System.ComponentModel.DataAnnotations.UIHintAttribute 
            return propertyInfo.Name.IndexOf("Password", StringComparison.OrdinalIgnoreCase) != -1;
        }
    }
}
