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
    <AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
    Public Class CustomerService
        Implements ICustomerService

#Region "ICustomerService Members"

        Public Function GetCustomers() As List(Of Customer) Implements ICustomerService.GetCustomers
            Return New CustomerRepository().GetCustomers()
        End Function

        Public Function SaveCustomer(ByVal customer_Renamed As Customer) As OperationStatus Implements ICustomerService.SaveCustomer
            Return New CustomerRepository().SaveCustomer(customer_Renamed)
        End Function

        Public Function GetCustomer(ByVal custID As Integer) As Customer Implements ICustomerService.GetCustomer
            Return New CustomerRepository().GetCustomer(custID)
        End Function

#End Region
    End Class
End Namespace
