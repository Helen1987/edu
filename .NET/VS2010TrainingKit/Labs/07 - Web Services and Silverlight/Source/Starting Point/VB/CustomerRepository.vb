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

Imports System.Data.Objects
Imports CustomersService.Repository
Imports UsingWCFServices.Web.Models

Namespace UsingWCFServices.Models
	Public Interface ICustomerRepository
		Function GetCustomers() As List(Of Customer)
	End Interface

	Public Class CustomerRepository
		Inherits RepositoryBase(Of AdventureWorksLT_DataEntities)
		Implements ICustomerRepository
		#Region "ICustomerRepository Members"

		Public Function GetCustomers() As List(Of Customer) Implements ICustomerRepository.GetCustomers
			Return (
			    From c In DataContext.Customers
			    Join o In DataContext.SalesOrderHeaders On c.CustomerID Equals o.CustomerID
			    Order By c.LastName
			    Select c).ToList()
		End Function

		#End Region


	End Class
End Namespace