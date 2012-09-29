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

Imports CustomersService.Model.Entities

Namespace CustomersService.Repository
	Public Interface ICustomerRepository
		Function GetCustomer(ByVal custID As Integer) As Customer
		Function GetCustomers() As List(Of Customer)
		Function SaveCustomer(ByVal customer As Customer) As OperationStatus
	End Interface

	Public Class CustomerRepository
		Inherits RepositoryBase(Of AdventureWorksLT_DataEntities)
		Implements ICustomerRepository
		#Region "ICustomerRepository Members"

		Public Function GetCustomer(ByVal custID As Integer) As Customer Implements ICustomerRepository.GetCustomer
			Using DataContext
				Return [Get](Of Customer)(Function(c) c.CustomerID = custID)
			End Using
		End Function

		Public Function GetCustomers() As List(Of Customer) Implements ICustomerRepository.GetCustomers
			Using DataContext
				Return GetList(Of Customer, String)(Function(c) c.LastName).Take(50).ToList()
			End Using
		End Function

		'Can handle insert, update or delete
		Public Function SaveCustomer(ByVal customer_Renamed As Customer) As OperationStatus Implements ICustomerRepository.SaveCustomer
			Using DataContext
				If customer_Renamed.ChangeTracker.State = ObjectState.Deleted Then
					'Handle foreign key deletions using sproc
					Return DeleteCustomer(customer_Renamed.CustomerID)
				End If
				Return Save(customer_Renamed)
			End Using
		End Function

		Private Function DeleteCustomer(ByVal id As Integer) As OperationStatus
			Dim opStatus As OperationStatus

			Using DataContext
				opStatus = ExecuteStoreCommand("exec DeleteCustomer {0}", id)
			End Using
			If opStatus.RecordsAffected = 0 Then
				opStatus.Status = False
				opStatus.Message = "Unable to delete customer: " & opStatus.Message
			End If
			Return opStatus
		End Function

		#End Region


	End Class
End Namespace