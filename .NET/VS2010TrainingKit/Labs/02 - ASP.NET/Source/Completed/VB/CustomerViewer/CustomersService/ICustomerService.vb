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

Imports System.ServiceModel
Imports System.ServiceModel.Web
Imports CustomersService.Model.Entities

Namespace CustomersService
	<ServiceContract>
	Public Interface ICustomerService
		<OperationContract>
		Function GetCustomers() As List(Of Customer)

		<OperationContract>
		Function SaveCustomer(ByVal customer As Customer) As OperationStatus

		<OperationContract, WebInvoke(Method := "GET", UriTemplate := "DeleteCustomer/{custID}", ResponseFormat := WebMessageFormat.Json)>
		Function DeleteCustomer(ByVal custID As String) As OperationStatus

		<OperationContract, WebInvoke(Method := "GET", UriTemplate := "UpdateCustomer?CustomerID={customerID}&FirstName={firstName}&" & "LastName={lastName}&CompanyName={companyName}&" & "EmailAddress={emailAddress}&Phone={phone}", ResponseFormat := WebMessageFormat.Json)>
		Function UpdateCustomer(ByVal customerID As String, ByVal firstName As String, ByVal lastName As String, ByVal companyName As String, ByVal emailAddress As String, ByVal phone As String) As OperationStatus

		<OperationContract, WebInvoke(Method:="GET", UriTemplate := "GetCustomer/{custID}", ResponseFormat := WebMessageFormat.Json)>
		Function GetCustomer(ByVal custID As String) As Customer

	End Interface
End Namespace
