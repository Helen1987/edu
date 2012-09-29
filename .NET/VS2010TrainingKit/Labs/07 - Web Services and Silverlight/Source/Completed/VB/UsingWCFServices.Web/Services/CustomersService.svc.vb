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
Imports UsingWCFServices.Models
Imports UsingWCFServices.Web.Models

Namespace UsingWCFServices.Web.Services
	<ServiceContract(Namespace := ""), AspNetCompatibilityRequirements(RequirementsMode := AspNetCompatibilityRequirementsMode.Allowed)>
	Public Class CustomersService
		Private _CustomerRepository As ICustomerRepository = New CustomerRepository()
		Private _OrderRepository As ISalesOrderHeaderRepository = New SalesOrderHeaderRepository()

		<OperationContract>
		Public Function GetCustomers() As List(Of Customer)
			Return _CustomerRepository.GetCustomers()
		End Function

		<OperationContract>
		Public Function GetOrdersByCustomerID(ByVal customerID As Integer) As List(Of SalesOrderHeader)
			Return _OrderRepository.GetOrdersByCustomerID(customerID)
		End Function

		<OperationContract>
		Public Function UpdateSalesOrderHeader(ByVal order As SalesOrderHeader) As OperationStatus
			Return _OrderRepository.UpdateSalesOrderHeader(order)
		End Function
	End Class
End Namespace
