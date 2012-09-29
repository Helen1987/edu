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

Imports System.Windows.Controls
Imports System.Windows.Navigation

''' <summary>
''' Home page for the application.
''' </summary>
Partial Public Class Home
    Inherits Page
    Dim _Context As New AdventureWorksLTDomainContext()
    Public Sub New()
        InitializeComponent()

        Me.Title = ApplicationStrings.HomePageTitle
    End Sub

    ''' <summary>
    ''' Executes when the user navigates to this page.
    ''' </summary>
    Protected Overloads Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
        CustomersComboBox.ItemsSource = _Context.Customers
        OrdersDataGrid.ItemsSource = _Context.SalesOrderHeaders
        _Context.Load(_Context.GetCustomersQuery())
    End Sub

    Private Sub CustomersComboBox_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)
        Dim custID As Integer = (CType(CustomersComboBox.SelectedItem, Customer)).CustomerID
        If _Context.EntityContainer IsNot Nothing Then
            _Context.EntityContainer.GetEntitySet(Of SalesOrderHeader)().Clear()
        End If
        _Context.Load(_Context.GetOrdersByCustomerIDQuery(custID))

    End Sub

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If _Context.HasChanges Then
            _Context.SubmitChanges(Sub(so)
                                       Dim errorMsg As String = If(so.HasError, "failed", "succeeded")
                                       MessageBox.Show("Update " + errorMsg)
                                   End Sub, Nothing)
        Else
            MessageBox.Show("No changes have been made!")
        End If

    End Sub
End Class