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

Imports Microsoft.VisualStudio.SharePoint
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

Namespace Contoso.SharePointProjectItems.CustomAction

    Partial Friend Class CustomActionProvider

        Private Sub ProjectItemPropertiesRequested(ByVal Sender As Object, _
            ByVal e As SharePointProjectItemPropertiesRequestedEventArgs)

            Dim properties As CustomActionProperties = Nothing

            ' If the properties object already exists, get it from the project item's annotations.
            If False = e.ProjectItem.Annotations.TryGetValue(properties) Then
                ' Otherwise, create a new properties object and add it to the annotations.
                properties = New CustomActionProperties(e.ProjectItem)
                e.ProjectItem.Annotations.Add(properties)
            End If
            e.PropertySources.Add(properties)
        End Sub
    End Class

    Friend Class CustomActionProperties

        Private projectItem As ISharePointProjectItem
        Private Const testPropertyId As String = "Contoso.CustomActionTestProperty"
        Private Const propertyDefaultValue As String = "This is a test value."

        Friend Sub New(ByVal projectItem As ISharePointProjectItem)
            Me.projectItem = projectItem
        End Sub

        ' Gets or sets a simple string property. The property value is stored in the ExtensionData property
        ' of the project item. Data in the ExtensionData property persists when the project is closed.
        <DisplayName("Custom Action Property")> _
        <DescriptionAttribute("This is a test property for the Contoso Custom Action project item.")> _
        <DefaultValue(propertyDefaultValue)> _
        Public Property TestProperty As String
            Get
                Dim propertyValue As String = Nothing

                ' Get the current property value if it already exists; otherwise, return a default value.
                If False = projectItem.ExtensionData.TryGetValue(testPropertyId, propertyValue) Then
                    propertyValue = propertyDefaultValue
                End If
                Return propertyValue
            End Get
            Set(ByVal value As String)
                If value <> propertyDefaultValue Then
                    projectItem.ExtensionData(testPropertyId) = value
                Else
                    ' Do not save the default value.
                    projectItem.ExtensionData.Remove(testPropertyId)
                End If
            End Set
        End Property
    End Class
End Namespace