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
using System.Net;
using System.Runtime.InteropServices.Automation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightWebBrowser.Data;

namespace SilverlightWebBrowser
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            // Register Click events for the buttons in the WindowControlsPanel
            this.OnTopButton.Click += new RoutedEventHandler(OnTopButton_Click);
            this.MinimizeButton.Click += new RoutedEventHandler(MinimizeButton_Click);
            this.MaximizeButton.Click += new RoutedEventHandler(MaximizeButton_Click);
            this.CloseButton.Click += new RoutedEventHandler(CloseButton_Click);

            // Register Click events for the Export buttons
            this.ExcelButton.Click += new RoutedEventHandler(ExcelButton_Click);
            this.WordButton.Click += new RoutedEventHandler(WordButton_Click);
            this.OutlookButton.Click += new RoutedEventHandler(OutlookButton_Click);
            this.PowerPointButton.Click += new RoutedEventHandler(PowerPointButton_Click);
        }

        void ExcelButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic excel = AutomationFactory.CreateObject("Excel.Application");
            excel.Visible = true;

            dynamic workbook = excel.workbooks;
            workbook.Add();

            dynamic sheet = excel.ActiveSheet;
            dynamic cell = null;
            int i = 1;

            // Populate the excel sheet
            foreach (var item in (LayoutRoot.DataContext as Bookmarks).Sites)
            {
                cell = sheet.Cells[i, 1];
                cell.Value = item.Title;

                cell = sheet.Cells[i, 2];
                cell.Value = item.Uri;
                cell.ColumnWidth = 100;

                i++;
            }
        }

        void WordButton_Click(object sender, RoutedEventArgs e)
        {
            if (AutomationFactory.IsAvailable)
            {
                dynamic word = AutomationFactory.CreateObject("Word.Application");
                word.Visible = true;

                word.Documents.Add();
                word.Selection.TypeText("Bookmarks");
                word.Selection.TypeText(string.Format("Exported at: {0}", DateTime.Today.ToShortDateString()));
                word.Selection.TypeParagraph();
                foreach (var item in (LayoutRoot.DataContext as Bookmarks).Sites)
                {
                    word.Selection.TypeText(string.Format("{0} \vURL: {1}\v", item.Title, item.Uri));
                }
                word.ActiveDocument.SaveAs("BookmarksFromSL");
            }
        }

        void OutlookButton_Click(object sender, RoutedEventArgs e)
        {
            if (AutomationFactory.IsAvailable)
            {
                dynamic outlook = AutomationFactory.CreateObject("Outlook.Application");
                dynamic mail = outlook.CreateItem(0);
                mail.To = "me@myname.com";
                mail.Subject = "My Bookmarks";
                StringBuilder sb = new StringBuilder();
                foreach (var item in (LayoutRoot.DataContext as Bookmarks).Sites)
                {
                    sb.Append(string.Format("{0} \vURL: {1}\v\v", item.Title, item.Uri));
                }
                mail.Body = sb.ToString();
                mail.Display();
            }
        }

        void PowerPointButton_Click(object sender, RoutedEventArgs e)
        {
            if (AutomationFactory.IsAvailable)
            {
                dynamic cmd = AutomationFactory.CreateObject("WScript.Shell");
                cmd.Run(@"c:\windows\notepad.exe", 1, true);
            }
        }


        void OnTopButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle between being on top and not
            Application.Current.MainWindow.TopMost = !Application.Current.MainWindow.TopMost;
        }

        void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Minimize the application
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            // Toggle between the Normal and Maximized state
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }

        void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.MainWindow.Close();
        }

    }
}
