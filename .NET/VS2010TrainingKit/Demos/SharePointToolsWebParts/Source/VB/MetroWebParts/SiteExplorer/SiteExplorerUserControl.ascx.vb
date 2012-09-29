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

Partial Public Class SiteExplorerUserControl
    Inherits UserControl

    Const SITE_IMG As String = "\_layouts\images\FPWEB16.GIF"
    Const FOLDER_IMG As String = "\_layouts\images\FOLDER16.GIF"
    Const GHOSTED_FILE_IMG As String = "\_layouts\images\NEWDOC.GIF"
    Const UNGHOSTED_FILE_IMG As String = "\_layouts\images\RAT16.GIF"

    Protected Overrides Sub OnPreRender(ByVal e As System.EventArgs)
        treeSiteFiles.Nodes.Clear()
        Dim site = SPContext.Current.Web
        Dim rootFolder = site.RootFolder
        Dim rootNode = New TreeNode(site.Url, site.Url, SITE_IMG)
        LoadFolderNodes(rootFolder, rootNode)
        treeSiteFiles.Nodes.Add(rootNode)
        treeSiteFiles.ExpandDepth = 1
    End Sub

    Protected Sub LoadFolderNodes(ByVal folder As SPFolder, ByVal folderNode As TreeNode)
        For Each childFolder As SPFolder In folder.SubFolders
            Dim childFolderNode = New TreeNode(childFolder.Name, childFolder.Name, FOLDER_IMG)
            childFolderNode.NavigateUrl = SPContext.Current.Site.MakeFullUrl(childFolder.Url)
            LoadFolderNodes(childFolder, childFolderNode)
            folderNode.ChildNodes.Add(childFolderNode)
        Next

        For Each file As SPFile In folder.Files
            Dim fileNode As TreeNode
            If (file.CustomizedPageStatus = SPCustomizedPageStatus.Uncustomized) Then
                fileNode = New TreeNode(file.Name, file.Name, GHOSTED_FILE_IMG)
            Else
                fileNode = New TreeNode(file.Name, file.Name, UNGHOSTED_FILE_IMG)
            End If

            fileNode.NavigateUrl = SPContext.Current.Site.MakeFullUrl(file.Url)
            folderNode.ChildNodes.Add(fileNode)
        Next
    End Sub

End Class
