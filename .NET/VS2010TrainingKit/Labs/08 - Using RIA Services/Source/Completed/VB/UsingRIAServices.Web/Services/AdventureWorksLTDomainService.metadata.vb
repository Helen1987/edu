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
Imports System.Data.Objects.DataClasses
Imports System.Linq
Imports System.ServiceModel.DomainServices.Hosting
Imports System.ServiceModel.DomainServices.Server
Imports UsingRIAServices


'The MetadataTypeAttribute identifies CustomerMetadata as the class
' that carries additional metadata for the Customer class.
<MetadataTypeAttribute(GetType(Customer.CustomerMetadata))>  _
Partial Public Class Customer
    
    'This class allows you to attach custom attributes to properties
    ' of the Customer class.
    '
    'For example, the following marks the Xyz property as a
    ' required property and specifies the format for valid values:
    '    <Required()>
    '    <RegularExpression("[A-Z][A-Za-z0-9]*")>
    '    <StringLength(32)>
    '    Public Property Xyz As String
    Friend NotInheritable Class CustomerMetadata
        
        'Metadata classes are not meant to be instantiated.
        Private Sub New()
            MyBase.New
        End Sub
        
        Public Property CompanyName As String
        
        Public Property CustomerID As Integer
        
        Public Property EmailAddress As String
        
        Public Property FirstName As String
        
        Public Property LastName As String
        
        Public Property MiddleName As String
        
        Public Property ModifiedDate As DateTime
        
        Public Property NameStyle As Boolean
        
        Public Property PasswordHash As String
        
        Public Property PasswordSalt As String
        
        Public Property Phone As String
        
        Public Property rowguid As Guid
        
        Public Property SalesOrderHeaders As EntityCollection(Of SalesOrderHeader)
        
        Public Property SalesPerson As String
        
        Public Property Suffix As String
        
        Public Property Title As String
    End Class
End Class

'The MetadataTypeAttribute identifies SalesOrderHeaderMetadata as the class
' that carries additional metadata for the SalesOrderHeader class.
<MetadataTypeAttribute(GetType(SalesOrderHeader.SalesOrderHeaderMetadata))>  _
Partial Public Class SalesOrderHeader
    
    'This class allows you to attach custom attributes to properties
    ' of the SalesOrderHeader class.
    '
    'For example, the following marks the Xyz property as a
    ' required property and specifies the format for valid values:
    '    <Required()>
    '    <RegularExpression("[A-Z][A-Za-z0-9]*")>
    '    <StringLength(32)>
    '    Public Property Xyz As String
    Friend NotInheritable Class SalesOrderHeaderMetadata
        
        'Metadata classes are not meant to be instantiated.
        Private Sub New()
            MyBase.New
        End Sub
        
        Public Property AccountNumber As String
        
        Public Property BillToAddressID As Nullable(Of Integer)

        <Required()>
        Public Property Comment As String
        
        Public Property CreditCardApprovalCode As String
        
        Public Property Customer As Customer
        
        Public Property CustomerID As Integer
        
        Public Property DueDate As DateTime
        
        Public Property Freight As Decimal
        
        Public Property ModifiedDate As DateTime
        
        Public Property OnlineOrderFlag As Boolean

        <CustomValidation(GetType(DateValidator), "ValidateDate")>
        Public Property OrderDate As DateTime
        
        Public Property PurchaseOrderNumber As String
        
        Public Property RevisionNumber As Byte
        
        Public Property rowguid As Guid
        
        Public Property SalesOrderDetails As EntityCollection(Of SalesOrderDetail)
        
        Public Property SalesOrderID As Integer
        
        Public Property SalesOrderNumber As String
        
        Public Property ShipDate As Nullable(Of DateTime)
        
        Public Property ShipMethod As String
        
        Public Property ShipToAddressID As Nullable(Of Integer)
        
        Public Property Status As Byte
        
        Public Property SubTotal As Decimal
        
        Public Property TaxAmt As Decimal
        
        Public Property TotalDue As Decimal
    End Class
End Class

