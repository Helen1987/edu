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
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.ComponentModel.Composition
Imports Microsoft.VisualStudio.SharePoint

Namespace Contoso.SharePointProjectItems.CustomAction

    ' Export attribute: Enables Visual Studio to discover and load this extension.
    ' SharePointProjectItemType attribute: Specifies the ID for this new project item type. This string must 
    '     match the value of the Type attribute of the ProjectItem element in the .spdata file for 
    '     the project item.
    ' SharePointProjectItemIcon attribute: Specifies the icon to display with this project item in Solution Explorer.
    ' CustomActionProvider class: Defines a new type of project item that can be used to create a custom 
    '     action on a SharePoint site.
    <Export(GetType(ISharePointProjectItemTypeProvider))> _
    <SharePointProjectItemType("Contoso.CustomAction")> _
    <SharePointProjectItemIcon("ProjectItemDefinition.CustomAction_SolutionExplorer.ico")> _
    Partial Friend Class CustomActionProvider
        Implements ISharePointProjectItemTypeProvider

        Private projectService As ISharePointProjectService

        ' Configures the behavior of the project item type.
        Private Sub InitializeType(ByVal projectItemTypeDefinition As ISharePointProjectItemTypeDefinition) _
                Implements ISharePointProjectItemTypeProvider.InitializeType

            projectItemTypeDefinition.Name = "CustomAction"
            projectItemTypeDefinition.SupportedDeploymentScopes = _
                SupportedDeploymentScopes.Site Or SupportedDeploymentScopes.Web
            projectItemTypeDefinition.SupportedTrustLevels = SupportedTrustLevels.All

            ' Get the service so that other code in this class can use it.
            projectService = projectItemTypeDefinition.ProjectService

            ' Handle some project item events.
            AddHandler projectItemTypeDefinition.ProjectItemInitialized, AddressOf ProjectItemInitialized
            AddHandler projectItemTypeDefinition.ProjectItemNameChanged, AddressOf ProjectItemNameChanged
            AddHandler projectItemTypeDefinition.ProjectItemDisposing, AddressOf ProjectItemDisposing

            'Handle events to create a custom property and shortcut menu item for this project item.
            AddHandler projectItemTypeDefinition.ProjectItemPropertiesRequested, AddressOf ProjectItemPropertiesRequested
            AddHandler projectItemTypeDefinition.ProjectItemMenuItemsRequested, AddressOf ProjectItemMenuItemsRequested
        End Sub

        Private Sub ProjectItemInitialized(ByVal Sender As Object, ByVal e As SharePointProjectItemEventArgs)
            ' Handle a project event.
            AddHandler e.ProjectItem.Project.PropertyChanged, AddressOf ProjectPropertyChanged
        End Sub

        Private Sub ProjectItemNameChanged(ByVal Sender As Object, ByVal e As NameChangedEventArgs)
            Dim projectItem As ISharePointProjectItem = CType(Sender, ISharePointProjectItem)
            Dim message As String = String.Format("The name of the {0} item changed to: {1}", _
                e.OldName, projectItem.Name)
            projectService.Logger.WriteLine(message, LogCategory.Message)
        End Sub

        Private Sub ProjectPropertyChanged(ByVal Sender As Object, ByVal e As PropertyChangedEventArgs)
            Dim project As ISharePointProject = CType(Sender, ISharePointProject)
            Dim message As String = String.Format("The following property of the {0} project was changed: {1}", _
                    project.Name, e.PropertyName)
            projectService.Logger.WriteLine(message, LogCategory.Message)
        End Sub

        Private Sub ProjectItemDisposing(ByVal Sender As Object, ByVal e As SharePointProjectItemEventArgs)
            RemoveHandler e.ProjectItem.Project.PropertyChanged, AddressOf ProjectPropertyChanged
        End Sub
    End Class
End Namespace