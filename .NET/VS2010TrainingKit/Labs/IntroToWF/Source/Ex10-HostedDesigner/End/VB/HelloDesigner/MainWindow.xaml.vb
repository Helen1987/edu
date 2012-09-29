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

Imports System.Activities.Presentation
Imports System.Activities.Statements
Imports System.Activities.Presentation.Toolbox
Imports System.Activities.Core.Presentation
Imports System.Activities.Presentation.Metadata
Imports System.ComponentModel
Imports HelloWorkflow.Activities
Imports HelloWorkflow.Activities.Designers

Class MainWindow
    Private workflowDesigner As WorkflowDesigner = New WorkflowDesigner()

    Public Sub New()
        InitializeComponent()
        RegisterMetadata()
        AddDesigner()
    End Sub


    Public Sub RegisterMetadata()
        Dim metaData As DesignerMetadata = New DesignerMetadata()
        metaData.Register()
        Dim builder As AttributeTableBuilder = New AttributeTableBuilder()
        MetadataStore.AddAttributeTable(builder.CreateTable())
    End Sub

    Private Function CreateToolboxControl() As ToolboxControl
        'Create the ToolBoxControl
        Dim ctrl As ToolboxControl = New ToolboxControl()

        'Create a collection of category items
        Dim category As ToolboxCategory = New ToolboxCategory("Hello Workflow")

        'Creating toolboxItems
        category.Add(New ToolboxItemWrapper(
            "System.Activities.Statements.Assign",
            "System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
            Nothing,
            "Assign"))

        category.Add(New ToolboxItemWrapper(
            "System.Activities.Statements.Sequence",
            "System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
            Nothing,
            "Sequence"))

        category.Add(New ToolboxItemWrapper(
            "System.Activities.Statements.TryCatch",
            "System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
            Nothing,
            "Try It")) ' Can use a different name

        category.Add(New ToolboxItemWrapper(
            "HelloWorkflow.Activities.PrePostSequence",
            "HelloWorkflow.Activities",
            Nothing,
            "PrePostSequence"))

        category.Add(New ToolboxItemWrapper(
            "HelloWorkflow.Activities.DiagnosticTrace",
            "HelloWorkflow.Activities",
            Nothing,
            "Diagnostic Trace"))

        'Adding the category to the ToolBox control.
        ctrl.Categories.Add(category)
        Return ctrl
    End Function

    Private Sub ShowWorkflowXAML(ByVal sender As Object, ByVal e As EventArgs)
        workflowDesigner.Flush()
        textXAML.Text = workflowDesigner.Text
    End Sub

    Private Sub AddDesigner()

        'Create an instance of WorkflowDesigner class
        workflowDesigner = New WorkflowDesigner()

        'Place the WorkflowDesigner in the middle column of the grid
        Grid.SetColumn(workflowDesigner.View, 1)

        ' Setup the Model Changed event handler
        AddHandler workflowDesigner.ModelChanged, AddressOf ShowWorkflowXAML

        'Load a new Sequence as default.
        workflowDesigner.Load(New Sequence())

        'Add the WorkflowDesigner to the grid
        grid1.Children.Add(workflowDesigner.View)

        ' Add the Property Inspector
        Grid.SetColumn(workflowDesigner.PropertyInspectorView, 2)
        grid1.Children.Add(workflowDesigner.PropertyInspectorView)

        ' Add the toolbox
        Dim tc As ToolboxControl = CreateToolboxControl()
        Grid.SetColumn(tc, 0)
        grid1.Children.Add(tc)

        ' Show the initial XAML
        ShowWorkflowXAML(Nothing, Nothing)
    End Sub
End Class
