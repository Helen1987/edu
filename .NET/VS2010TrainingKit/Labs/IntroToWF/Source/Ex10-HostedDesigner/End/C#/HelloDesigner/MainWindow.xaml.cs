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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Activities.Presentation;
using System.Activities.Statements;
using System.Activities.Presentation.Toolbox;
using System.Activities.Core.Presentation;
using System.Activities.Presentation.Metadata;
using System.ComponentModel;
using HelloWorkflow.Activities;
using HelloWorkflow.Activities.Designers;

namespace HelloDesigner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkflowDesigner workflowDesigner = new WorkflowDesigner();

        public MainWindow()
        {
            InitializeComponent();
            RegisterMetadata();
            AddDesigner();
        }

        private void RegisterMetadata()
        {
            DesignerMetadata metaData = new DesignerMetadata();
            metaData.Register();
            AttributeTableBuilder builder = new AttributeTableBuilder();
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        private ToolboxControl CreateToolboxControl()
        {
            return new ToolboxControl()
            {
                Categories = 
                {
                    new ToolboxCategory("Hello Workflow")
                    {
                        Tools = 
                        {
                            new ToolboxItemWrapper(
                            "System.Activities.Statements.Assign",
                            "System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", 
                            null,
                            "Assign"),

                            new ToolboxItemWrapper(
                            "System.Activities.Statements.Sequence",
                            "System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
                            null,
                            "Sequence"),

                            new ToolboxItemWrapper(
                            "System.Activities.Statements.TryCatch",
                            "System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
                            null,
                            "Try It"), // Can use a different name

                            new ToolboxItemWrapper(
                            "HelloWorkflow.Activities.PrePostSequence",
                            "HelloWorkflow.Activities",
                            null,
                            "PrePostSequence"),

                            new ToolboxItemWrapper(
                            "HelloWorkflow.Activities.DiagnosticTrace",
                            "HelloWorkflow.Activities",
                            null,
                            "Diagnostic Trace")
                        }
                    }
                }
            };
        }

        private void ShowWorkflowXAML(object sender, EventArgs e)
        {
            workflowDesigner.Flush();
            textXAML.Text = workflowDesigner.Text;
        }

        private void AddDesigner()
        {
            //Create an instance of WorkflowDesigner class
            this.workflowDesigner = new WorkflowDesigner();

            //Place the WorkflowDesigner in the middle column of the grid
            Grid.SetColumn(this.workflowDesigner.View, 1);

            // Show the XAML when the model changes
            workflowDesigner.ModelChanged += ShowWorkflowXAML;

            //Load a new Sequence as default.
            this.workflowDesigner.Load(new Sequence());

            //Add the WorkflowDesigner to the grid
            grid1.Children.Add(this.workflowDesigner.View);

            // Add the Property Inspector
            Grid.SetColumn(workflowDesigner.PropertyInspectorView, 2);
            grid1.Children.Add(workflowDesigner.PropertyInspectorView);

            // Add the toolbox
            ToolboxControl tc = CreateToolboxControl();
            Grid.SetColumn(tc, 0);
            grid1.Children.Add(tc);

            // Show the initial XAML
            ShowWorkflowXAML(null, null);
        }

    }
}
