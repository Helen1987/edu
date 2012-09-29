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

Imports System.Collections.ObjectModel
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports CustomerService.Proxies

Namespace SilverlightCustomerViewer
	Partial Public Class MainPage
		Inherits UserControl

		Public Sub New()
			InitializeComponent()
			AddHandler Loaded, AddressOf MainPage_Loaded
		End Sub

		Private Sub MainPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim proxy = New CustomerServiceClient()
			AddHandler proxy.GetCustomersCompleted, AddressOf proxy_GetCustomersCompleted
			proxy.GetCustomersAsync()
		End Sub

		Private Sub proxy_GetCustomersCompleted(ByVal sender As Object, ByVal e As GetCustomersCompletedEventArgs)
			CustomersComboBox.ItemsSource = e.Result
		End Sub

		Private Sub UpdateButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim proxy = New CustomerServiceClient()
			Dim cust = TryCast(CustomersComboBox.SelectedItem, Customer)
			cust.ChangeTracker.State = ObjectState.Modified

			AddHandler proxy.SaveCustomerCompleted, Sub(s, args)
				Dim opStatus = args.Result
				Dim msg As String = If(opStatus.Status, "Customer Updated!", "Unable to update Customer: " & opStatus.Message)
				MessageBox.Show(msg)
			End Sub
			proxy.SaveCustomerAsync(cust)
		End Sub

		Private Sub DeleteButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim proxy = New CustomerServiceClient()
			Dim cust = TryCast(CustomersComboBox.SelectedItem, Customer)
			cust.ChangeTracker.State = ObjectState.Deleted
			AddHandler proxy.SaveCustomerCompleted, Sub(s, args)
				Dim opStatus As OperationStatus = args.Result
				If opStatus.Status Then
					CType(CustomersComboBox.ItemsSource, ObservableCollection(Of Customer)).Remove(cust)
					MessageBox.Show("Customer deleted!")
				Else
					MessageBox.Show("Unable to delete Customer: " & opStatus.Message)
				End If
			End Sub
			proxy.SaveCustomerAsync(cust)
		End Sub
	End Class
End Namespace
