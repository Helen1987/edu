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

Imports CustomersService.Repository
Imports UsingWCFServices.Web.Models

Namespace UsingWCFServices.Models
	Public Interface ISalesOrderHeaderRepository
		Function GetOrdersByCustomerID(ByVal custID As Integer) As List(Of SalesOrderHeader)
		Function UpdateSalesOrderHeader(ByVal order As SalesOrderHeader) As OperationStatus
	End Interface

	Public Class SalesOrderHeaderRepository
		Inherits RepositoryBase(Of AdventureWorksLT_DataEntities)
		Implements ISalesOrderHeaderRepository
		#Region "ICustomerRepository Members"

		Public Function GetOrdersByCustomerID(ByVal custID As Integer) As List(Of SalesOrderHeader) Implements ISalesOrderHeaderRepository.GetOrdersByCustomerID
			 Return DataContext.SalesOrderHeaders.Where(Function(so) so.CustomerID = custID).ToList()
		End Function

		Public Function UpdateSalesOrderHeader(ByVal order As SalesOrderHeader) As OperationStatus Implements ISalesOrderHeaderRepository.UpdateSalesOrderHeader
			'Allow OrderDate and Comments to be updated
			Return Update(order, "OrderDate", "Comment")
		End Function

		#End Region


	End Class
End Namespace