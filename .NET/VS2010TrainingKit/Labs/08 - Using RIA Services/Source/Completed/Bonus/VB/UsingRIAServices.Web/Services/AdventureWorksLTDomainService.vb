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


Option Compare Binary
Option Infer On
Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Data
Imports System.Linq
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server
Imports UsingRIAServices.CustomersService.Repository
Imports UsingRIAServices.UsingRIAServices.Web.Repository


'Implements application logic using the AdventureWorksLT_DataEntities context.
' TODO: Add your application logic to these methods or in additional methods.
' TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
' Also consider adding roles to restrict access as appropriate.
'<RequiresAuthentication> _
<EnableClientAccess()>  _
Public Class AdventureWorksLTDomainService
    Inherits DomainService
    
    Private _CustomerRepository As ICustomerRepository = New CustomerRepository()
    Private _OrderRepository As ISalesOrderHeaderRepository = New SalesOrderHeaderRepository()

    Public Function GetCustomers() As IQueryable(Of Customer)
        Return _CustomerRepository.GetCustomers()
    End Function

    Public Function GetOrdersByCustomerID(ByVal customerID As Integer) As IQueryable(Of SalesOrderHeader)
        Return _OrderRepository.GetOrdersByCustomerID(customerID)
    End Function

    Public Sub UpdateSalesOrderHeader(ByVal order As SalesOrderHeader)
        Dim opStatus As OperationStatus = _OrderRepository.UpdateSalesOrderHeader(order)
        If Not opStatus.Status Then
            Throw New DomainException("Unable to update order.", 1, opStatus.Exception)
        End If
    End Sub
End Class

