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

Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports UsingWCFServices.CustomersService.Proxies
Imports WebServiceProxies

Namespace UsingWCFServices
	Partial Public Class Home
		Inherits Page
		Private _Proxy As New CustomersServiceClient()

		Public Sub New()
			InitializeComponent()
		End Sub

		' Executes when the user navigates to this page.
		Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
            AddHandler _Proxy.GetOrdersByCustomerIDCompleted, Sub(s, args) OrdersDataGrid.ItemsSource = args.Result
            AddHandler _Proxy.GetCustomersCompleted, Sub(s, args) CustomersComboBox.ItemsSource = args.Result
            AddHandler _Proxy.UpdateSalesOrderHeaderCompleted, Sub(s, args)
                                                                   'Check returned OperationStatus object for status
                                                                   Dim errorMsg As String = If(args.Result.Status, "succeeded", "failed")
                                                                   MessageBox.Show("Update " & errorMsg)
                                                               End Sub
            _Proxy.GetCustomersAsync()
		End Sub

		Private Sub CustomersComboBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
			Dim custID As Integer = (CType(CustomersComboBox.SelectedItem, Customer)).CustomerID
            _Proxy.GetOrdersByCustomerIDAsync(custID)
		End Sub

        Private Sub OrderDataForm_EditEnded(ByVal sender As System.Object, ByVal e As System.Windows.Controls.DataFormEditEndedEventArgs) Handles OrderDataForm.EditEnded
            If e.EditAction = DataFormEditAction.Commit Then
                Dim order = CType(OrderDataForm.CurrentItem, SalesOrderHeader)
                _Proxy.UpdateSalesOrderHeaderAsync(order)
            End If

        End Sub
    End Class
End Namespace