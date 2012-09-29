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

Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.ServiceModel.Web
Imports System.Text
Imports CustomersService.Repository
Imports CustomersService.Model.Entities

Namespace CustomersService
	<AspNetCompatibilityRequirements(RequirementsMode := AspNetCompatibilityRequirementsMode.Allowed)>
	Public Class CustomerService
		Implements ICustomerService

		#Region "ICustomerService Members"

		Public Function GetCustomers() As List(Of Customer) Implements ICustomerService.GetCustomers
			Return New CustomerRepository().GetCustomers()
		End Function

		Public Function SaveCustomer(ByVal customer_Renamed As Customer) As OperationStatus Implements ICustomerService.SaveCustomer
			Return New CustomerRepository().SaveCustomer(customer_Renamed)
		End Function

		Public Function DeleteCustomer(ByVal custID As String) As OperationStatus Implements ICustomerService.DeleteCustomer
			Return New CustomerRepository().DeleteCustomer(custID)
		End Function

		Public Function UpdateCustomer(ByVal customerID As String, ByVal firstName As String, ByVal lastName As String, ByVal companyName As String, ByVal emailAddress As String, ByVal phone As String) As OperationStatus Implements ICustomerService.UpdateCustomer
			Return New CustomerRepository().UpdateCustomer(customerID, firstName, lastName, companyName, emailAddress, phone)
		End Function

		Public Function GetCustomer(ByVal custID As String) As Customer Implements ICustomerService.GetCustomer
			Dim id As Integer = Integer.Parse(custID)
			Return New CustomerRepository().GetCustomer(id)
		End Function

		#End Region
	End Class
End Namespace
