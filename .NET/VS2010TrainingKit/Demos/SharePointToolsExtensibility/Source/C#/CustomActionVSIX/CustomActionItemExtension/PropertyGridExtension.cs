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

using Microsoft.VisualStudio.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Contoso.SharePointProjectItems.CustomAction
{
    internal partial class CustomActionProvider
    {
        private void ProjectItemPropertiesRequested(object sender,
            SharePointProjectItemPropertiesRequestedEventArgs e)
        {
            CustomActionProperties properties;

            // If the properties object already exists, get it from the project item's annotations.
            if (!e.ProjectItem.Annotations.TryGetValue(out properties))
            {
                // Otherwise, create a new properties object and add it to the annotations.
                properties = new CustomActionProperties(e.ProjectItem);
                e.ProjectItem.Annotations.Add(properties);
            }

            e.PropertySources.Add(properties);
        }
    }

    internal class CustomActionProperties
    {
        private ISharePointProjectItem projectItem;
        private const string testPropertyId = "Contoso.CustomActionTestProperty";
        private const string propertyDefaultValue = "This is a test value.";

        internal CustomActionProperties(ISharePointProjectItem projectItem)
        {
            this.projectItem = projectItem;
        }

        // Gets or sets a simple string property. The property value is stored in the ExtensionData property
        // of the project item. Data in the ExtensionData property persists when the project is closed.
        [DisplayName("Custom Action Property")]
        [DescriptionAttribute("This is a test property for the Contoso Custom Action project item.")]
        [DefaultValue(propertyDefaultValue)]
        public string TestProperty
        {
            get
            {
                string propertyValue;

                // Get the current property value if it already exists; otherwise, return a default value.
                if (!projectItem.ExtensionData.TryGetValue(testPropertyId, out propertyValue))
                {
                    propertyValue = propertyDefaultValue;
                }
                return propertyValue;
            }
            set
            {
                if (value != propertyDefaultValue)
                {
                    projectItem.ExtensionData[testPropertyId] = value;
                }
                else
                {
                    // Do not save the default value.
                    projectItem.ExtensionData.Remove(testPropertyId);
                }
            }
        }
    }
}
