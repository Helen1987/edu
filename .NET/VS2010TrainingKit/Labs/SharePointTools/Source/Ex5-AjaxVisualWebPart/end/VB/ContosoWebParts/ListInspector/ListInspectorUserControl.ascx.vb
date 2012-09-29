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
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports Microsoft.SharePoint

Partial Public Class ListInspectorUserControl
    Inherits UserControl

    Protected selectedListId As Guid = Guid.Empty
    Protected updateListProperties As Boolean = False

    Protected Sub lslLists_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstLists.SelectedIndexChanged
        selectedListId = New Guid(lstLists.SelectedValue)
        updateListProperties = True
    End Sub

    Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
        If (lstLists.SelectedIndex > -1) AndAlso Not updateListProperties Then
            selectedListId = New Guid(lstLists.SelectedValue)
        End If

        lstLists.Items.Clear()
        Dim site = SPContext.Current.Web
        For Each list As SPList In site.Lists
            Dim listItem = New ListItem(list.Title, list.ID.ToString())
            lstLists.Items.Add(listItem)
        Next

        If Not selectedListId = Guid.Empty Then
            lstLists.Items.FindByValue(selectedListId.ToString()).Selected = True
        End If

        If updateListProperties Then
            Dim list = SPContext.Current.Web.Lists(selectedListId)
            lblListTitle.Text = list.Title
            lblListID.Text = list.ID.ToString().ToUpper()
            lblListIsDocumentLibrary.Text = (TypeOf list Is SPDocumentLibrary).ToString()
            lblListIsHidden.Text = list.Hidden.ToString()
            lblListItemCount.Text = list.ItemCount.ToString()
            lnkListUrl.Text = list.DefaultViewUrl
            lnkListUrl.NavigateUrl = list.DefaultViewUrl
        End If
    End Sub

End Class
