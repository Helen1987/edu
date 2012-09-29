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
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace ContosoWebParts.Features.Main
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("49efc0e7-e44a-4362-9648-4bfb2eb93d85")]
    public class MainEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite siteCollection = properties.Feature.Parent as SPSite;

            if (siteCollection != null)
            {
                // save top site's original Title and SiteLogoUrl
                SPWeb site = siteCollection.RootWeb;
                site.Properties["OriginalTitle"] = site.Title;
                site.Properties.Update();

                // update the Title and SiteIconUrl
                site.Title = "VS 2010 SPT Rocks";
                site.SiteLogoUrl = "_layouts/images/ContosoWebParts/SiteIcon.gif";
                site.Update();
            }
        }

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite siteCollection = properties.Feature.Parent as SPSite;

            if (siteCollection != null)
            {
                // restore top site's original Title and SiteLogoUrl
                SPWeb site = siteCollection.RootWeb;
                site.Title = site.Properties["OriginalTitle"];
                site.SiteLogoUrl = string.Empty;
                site.Update();
            }
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
