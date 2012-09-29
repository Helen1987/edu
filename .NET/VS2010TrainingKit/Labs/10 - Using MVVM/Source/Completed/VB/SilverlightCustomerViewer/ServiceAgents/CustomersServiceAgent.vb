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

Imports CustomerService.Proxies

Namespace SilverlightCustomerViewer.ServiceAgents
	Public Interface ICustomersServiceAgent
		Sub GetCustomers(ByVal callback As EventHandler(Of GetCustomersCompletedEventArgs))
		Sub SaveCustomer(ByVal cust As Customer, ByVal callback As EventHandler(Of SaveCustomerCompletedEventArgs))
	End Interface

	Public Class CustomersServiceAgent
        Implements ICustomersServiceAgent

		Private _Proxy As New CustomerServiceClient()

		#Region "ICustomersServiceAgent Members"

		Public Sub GetCustomers(ByVal callback As EventHandler(Of GetCustomersCompletedEventArgs)) Implements ICustomersServiceAgent.GetCustomers
			AddHandler _Proxy.GetCustomersCompleted, callback
			_Proxy.GetCustomersAsync()
		End Sub

		Public Sub SaveCustomer(ByVal cust As Customer, ByVal callback As EventHandler(Of SaveCustomerCompletedEventArgs)) Implements ICustomersServiceAgent.SaveCustomer
			AddHandler _Proxy.SaveCustomerCompleted, callback
			_Proxy.SaveCustomerAsync(cust)
		End Sub

		#End Region
	End Class
End Namespace
