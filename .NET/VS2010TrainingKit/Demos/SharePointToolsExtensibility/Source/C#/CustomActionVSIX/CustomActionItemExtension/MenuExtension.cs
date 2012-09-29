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
using Microsoft.VisualStudio.SharePoint;

namespace Contoso.SharePointProjectItems.CustomAction
{
    internal partial class CustomActionProvider
    {
        private const string designerMenuItemText = "View Custom Action Designer";

        private void ProjectItemMenuItemsRequested(
            object sender, SharePointProjectItemMenuItemsRequestedEventArgs e)
        {
            e.ViewMenuItems.Add(designerMenuItemText).Click += MenuItemClick;
        }

        private void MenuItemClick(object sender, MenuItemEventArgs e)
        {
            ISharePointProjectItem projectItem = (ISharePointProjectItem)e.Owner;
            string message = String.Format("You clicked the menu on the {0} item. " +
                "You could perform some related task here, such as displaying a designer " +
                "for the custom action.", projectItem.Name);
            System.Windows.Forms.MessageBox.Show(message, "Contoso Custom Action");
        }
    }
}
