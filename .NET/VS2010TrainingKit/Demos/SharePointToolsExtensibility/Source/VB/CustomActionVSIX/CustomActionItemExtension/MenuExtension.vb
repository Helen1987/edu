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
Imports Microsoft.VisualStudio.SharePoint

Namespace Contoso.SharePointProjectItems.CustomAction

    Partial Friend Class CustomActionProvider

        Private Const DesignerMenuItemText As String = "View Custom Action Designer"

        Private Sub ProjectItemMenuItemsRequested(ByVal Sender As Object, _
            ByVal e As SharePointProjectItemMenuItemsRequestedEventArgs)
            Dim viewDesignerMenuItem As IMenuItem = e.ViewMenuItems.Add(DesignerMenuItemText)
            AddHandler viewDesignerMenuItem.Click, AddressOf MenuItemClick
        End Sub

        Private Sub MenuItemClick(ByVal Sender As Object, ByVal e As MenuItemEventArgs)
            Dim projectItem As ISharePointProjectItem = CType(e.Owner, ISharePointProjectItem)
            Dim message As String = String.Format("You clicked the menu on the {0} item. " & _
                "You could perform some related task here, such as displaying a designer " & _
                "for the custom action.", projectItem.Name)
            System.Windows.Forms.MessageBox.Show(message, "Contoso Custom Action")
        End Sub
    End Class
End Namespace