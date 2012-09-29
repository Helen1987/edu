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

Imports System.ComponentModel
Imports System.Text
Imports CustomerService.Proxies


Namespace CustomerViewer
	Partial Public Class CustomerForm
		Inherits Form
		Private _BindingSource As BindingSource
		Private _Proxy As CustomerServiceClient

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub CustomerForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			_Proxy = New CustomerServiceClient()
			Try
                AddHandler _Proxy.GetCustomersCompleted, Sub(s, args)
                                                             Dim custs = args.Result
                                                             If custs IsNot Nothing Then
                                                                 SetBindings(custs)
                                                             Else
                                                                 ShowMessageBox("No customers found.")
                                                             End If
                                                         End Sub
				_Proxy.GetCustomersAsync()
			Catch exp As Exception
				ShowMessageBox("Error fetching customers: " & exp.Message)
			End Try
		End Sub

		Private Sub SetBindings(ByVal custs As List(Of Customer))
			_BindingSource = New BindingSource(custs, Nothing)
			CustomersComboBox.DataSource = _BindingSource
			CustomerIDLabel.DataBindings.Add("Text", _BindingSource, "CustomerID")
			FirstNameTextBox.DataBindings.Add("Text", _BindingSource, "FirstName")
			LastNameTextBox.DataBindings.Add("Text", _BindingSource, "LastName")
			CompanyNameTextBox.DataBindings.Add("Text", _BindingSource, "CompanyName")
			EmailTextBox.DataBindings.Add("Text", _BindingSource, "EmailAddress")
			PhoneTextBox.DataBindings.Add("Text", _BindingSource, "Phone")
			CustomerDetailsGroupBox.Visible = True
		End Sub

		Private Sub UpdateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UpdateButton.Click
			Dim msg As String
			Dim cust = TryCast(CustomersComboBox.SelectedItem, Customer)
			cust.ChangeTracker.State = ObjectState.Modified
			Try
				Dim opStatus As OperationStatus = _Proxy.SaveCustomer(cust)
				_BindingSource.ResetCurrentItem()
				msg = If(opStatus.Status, "Customer Updated!", "Unable to update Customer: " & opStatus.Message)
			Catch exp As Exception
				msg = "Error updating Customer: " & exp.Message
			End Try

			ShowMessageBox(msg)
		End Sub

		Private Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles DeleteButton.Click
			If MessageBox.Show("Delete Customer?", "Delete?", MessageBoxButtons.YesNo) = DialogResult.Yes Then
				Dim msg As String
				Dim cust = TryCast(CustomersComboBox.SelectedItem, Customer)
				cust.ChangeTracker.State = ObjectState.Deleted
				Try
					Dim opStatus As OperationStatus = _Proxy.SaveCustomer(cust)
					If opStatus.Status Then
						_BindingSource.Remove(cust)
						msg = "Customer deleted!"
					Else
						msg = "Unable to delete Customer: " & opStatus.Message
					End If
				Catch exp As Exception
					msg = "Error deleting Customer: " & exp.Message
				End Try

				ShowMessageBox(msg)
			End If
		End Sub

		Private Sub ShowMessageBox(ByVal msg As String)
			MessageBox.Show(msg)
		End Sub
	End Class
End Namespace
