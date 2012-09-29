' ----------------------------------------------------------------------------------
' Microsoft Developer & Platform Evangelism
' 
' Copyright (c) Microsoft Corporation. All rights reserved.
' 
' THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
' EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
' OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
' ----------------------------------------------------------------------------------
' The example companies, organizations, products, domain names,
' e-mail addresses, logos, people, places, and events depicted
' herein are fictitious.  No association with any real company,
' organization, product, domain name, email address, logo, person,
' places, or events is intended or should be inferred.
' ----------------------------------------------------------------------------------

Option Explicit On
Option Strict On

Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Permissions
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.Security

''' <summary>
''' This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
''' </summary>
''' <remarks>
''' The GUID attached to this class may be used during packaging and should not be modified.
''' </remarks>

<GuidAttribute("bf091a26-454d-45b2-ad74-0dba03802b3c")> _
Public Class MainEventReceiver 
    Inherits SPFeatureReceiver

    ' Uncomment the method below to handle the event raised after a feature has been activated.

    Public Overrides Sub FeatureActivated(ByVal properties As SPFeatureReceiverProperties)
        Dim siteCollection = TryCast(properties.Feature.Parent, SPSite)

        If siteCollection IsNot Nothing Then
            ' save top site's original Title and SiteLogoUrl
            Dim site = siteCollection.RootWeb
            site.Properties("OriginalTitle") = site.Title
            site.Properties.Update()

            ' update the Title and SiteIconUrl
            site.Title = "VS 2010 SPT Rocks"
            site.SiteLogoUrl = "_layouts/images/ContosoWebParts/SiteIcon.gif"
            site.Update()
        End If
    End Sub


    ' Uncomment the method below to handle the event raised before a feature is deactivated.

    Public Overrides Sub FeatureDeactivating(ByVal properties As SPFeatureReceiverProperties)
        Dim siteCollection = TryCast(properties.Feature.Parent, SPSite)

        If siteCollection IsNot Nothing Then
            ' restore top site's original Title and SiteLogoUrl
            Dim site = siteCollection.RootWeb
            site.Title = site.Properties("OriginalTitle")
            site.SiteLogoUrl = String.Empty
            site.Update()
        End If
    End Sub


    ' Uncomment the method below to handle the event raised after a feature has been installed.

    'Public Overrides Sub FeatureInstalled(ByVal properties As SPFeatureReceiverProperties)
    'End Sub


    ' Uncomment the method below to handle the event raised before a feature is uninstalled.

    'Public Overrides Sub FeatureUninstalling(ByVal properties As SPFeatureReceiverProperties)
    'End Sub

    ' Uncomment the method below to handle the event raised when a feature is upgrading.

    'Public Overrides Sub FeatureUpgrading(ByVal properties As Microsoft.SharePoint.SPFeatureReceiverProperties, ByVal upgradeActionName As String, ByVal parameters As System.Collections.Generic.IDictionary(Of String, String))
    'End Sub

End Class
