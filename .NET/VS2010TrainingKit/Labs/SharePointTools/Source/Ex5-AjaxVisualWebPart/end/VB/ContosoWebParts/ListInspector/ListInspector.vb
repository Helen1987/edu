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

Imports System
Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.SharePoint
Imports Microsoft.SharePoint.WebControls

<ToolboxItemAttribute(false)> _
Public Class ListInspector
    Inherits WebPart

    ' Visual Studio might automatically update this path when you change the Visual Web Part project item.
    Private Const _ascxPath As String = "~/_CONTROLTEMPLATES/ContosoWebParts/ListInspector/ListInspectorUserControl.ascx"

    Protected Overrides Sub CreateChildControls()
        Dim control As Control = Page.LoadControl(_ascxPath)
        Controls.Add(control)
    End Sub

End Class
