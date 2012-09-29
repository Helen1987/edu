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
Imports System.ServiceModel.DomainServices.EntityFramework
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server
Imports UsingRIAServices


'Implements application logic using the AdventureWorksLT_DataEntities context.
' TODO: Add your application logic to these methods or in additional methods.
' TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
' Also consider adding roles to restrict access as appropriate.
'<RequiresAuthentication> _
<EnableClientAccess()>  _
Public Class AdventureWorksLTDomainService
    Inherits LinqToEntitiesDomainService(Of AdventureWorksLT_DataEntities)
    
    'TODO:
    ' Consider constraining the results of your query method.  If you need additional input you can
    ' add parameters to this method or create additional query methods with different names.
    'To support paging you will need to add ordering to the 'Customers' query.
    Public Function GetCustomers() As IQueryable(Of Customer)
        Return From c In ObjectContext.Customers _
               Join o In ObjectContext.SalesOrderHeaders _
               On c.CustomerID Equals o.CustomerID _
               Order By c.LastName _
               Select c

    End Function
    
    'TODO:
    ' Consider constraining the results of your query method.  If you need additional input you can
    ' add parameters to this method or create additional query methods with different names.
    'To support paging you will need to add ordering to the 'SalesOrderHeaders' query.
    Public Function GetOrdersByCustomerID(ByVal customerID As Integer) As IQueryable(Of SalesOrderHeader)
        Return Me.ObjectContext.SalesOrderHeaders.Where(Function(so) so.CustomerID = customerID)

    End Function
    
    Public Sub InsertSalesOrderHeader(ByVal salesOrderHeader As SalesOrderHeader)
        If ((salesOrderHeader.EntityState = EntityState.Detached)  _
                    = false) Then
            Me.ObjectContext.ObjectStateManager.ChangeObjectState(salesOrderHeader, EntityState.Added)
        Else
            Me.ObjectContext.SalesOrderHeaders.AddObject(salesOrderHeader)
        End If
    End Sub
    
    Public Sub UpdateSalesOrderHeader(ByVal currentSalesOrderHeader As SalesOrderHeader)
        Me.ObjectContext.SalesOrderHeaders.AttachAsModified(currentSalesOrderHeader, Me.ChangeSet.GetOriginal(currentSalesOrderHeader))
    End Sub
    
    Public Sub DeleteSalesOrderHeader(ByVal salesOrderHeader As SalesOrderHeader)
        If (salesOrderHeader.EntityState = EntityState.Detached) Then
            Me.ObjectContext.SalesOrderHeaders.Attach(salesOrderHeader)
        End If
        Me.ObjectContext.SalesOrderHeaders.DeleteObject(salesOrderHeader)
    End Sub
End Class

