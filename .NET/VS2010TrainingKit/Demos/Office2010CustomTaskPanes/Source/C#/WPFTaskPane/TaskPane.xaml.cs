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
using Word = Microsoft.Office.Interop.Word;

namespace WPFTaskPane
{
    /// <summary>
    /// Interaction logic for TaskPane.xaml
    /// </summary>
    public partial class TaskPane : UserControl
    {
        Word.Application m_application;

        public TaskPane(Word.Application application)
        {
            m_application = application;

            InitializeComponent();

            Snippets.Items.Clear();
            Snippets.Items.Add(new Snippet("Header", "Header information", "This is the header"));
            Snippets.Items.Add(new Snippet("Footer", "Footer information", "This is the footer"));
        }

        private void Snippets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            m_application.Selection.Range.Text = (Snippets.SelectedItem as Snippet).Content;
        }
    }
}
