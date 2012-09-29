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

Imports System.Data.Services.Common

Namespace Containment
    Public Class ContainmentObjectModel
        Private _customers As IEnumerable(Of Customer)
        Private _orders As IEnumerable(Of Order)
        Private _orderDetails As IEnumerable(Of OrderDetail)
        Private _products As IEnumerable(Of ContainmentProduct)

        Public Sub New()
            _products = New List(Of ContainmentProduct)(
                {
                    New ContainmentProduct With
                    {.Id = 1, .Name = "XBOX 360", .Price = 300.99F},
                    New ContainmentProduct With
                    {.Id = 2, .Name = "Fishing Pole", .Price = 12.36F},
                    New ContainmentProduct With
                    {.Id = 3, .Name = "Bunny Bread", .Price = 1.89F},
                    New ContainmentProduct With
                    {.Id = 4, .Name = "Grand Piano", .Price = 13000.0F}})

            _orderDetails = {
                    New OrderDetail With
                    {.Id = 1, .Product = _products.Single(Function(p) p.Id = 1), .Quantity = 100},
                    New OrderDetail With
                    {.Id = 2, .Product = _products.Single(Function(p) p.Id = 2), .Quantity = 50}}

            _orders = {
                New Order() With
                {.Id = 1, .SubTotal = 50.0F, .Tax = 10.0F, .Total = 60.0F, .OrderDetails = _orderDetails.ToArray()},
                New Order() With
                {.Id = 2, .SubTotal = 100.0F, .Tax = 20.0F, .Total = 120.0F, .OrderDetails = _orderDetails.ToArray()}}

            _customers = New List(Of Customer)(
                {
                    New Customer With
                    {.Id = 1, .FirstName = "Jonathan", .LastName = "Carter", .Orders = _orders.ToArray()},
                New Customer With
                {.Id = 2, .FirstName = "Drew", .LastName = "Robbins", .Orders = _orders.ToArray()},
                New Customer With
                {.Id = 3, .FirstName = "Jason", .LastName = "Olson", .Orders = _orders.ToArray()}})
        End Sub

        Public ReadOnly Property Orders As IQueryable(Of Order)
            Get
                Return _orders.AsQueryable()
            End Get
        End Property

        Public ReadOnly Property OrderDetails As IQueryable(Of OrderDetail)
            Get
                Return _orderDetails.AsQueryable()
            End Get
        End Property

        Public ReadOnly Property Products As IQueryable(Of ContainmentProduct)
            Get
                Return _products.AsQueryable()
            End Get
        End Property

        Public ReadOnly Property Customers As IQueryable(Of Customer)
            Get
                Return _customers.AsQueryable()
            End Get
        End Property
    End Class

    <DataServiceKey("Id")>
    Public Class Customer
        Public Property Id As Integer
        Public Property FirstName As String
        Public Property LastName As String
        Public Property Orders As Order()
    End Class

    <DataServiceKey("Id")>
    Public Class Order
        Public Property Id As Integer
        Public Property SubTotal As Single
        Public Property Tax As Single
        Public Property Total As Single
        Public Property OrderDetails As OrderDetail()
    End Class

    <DataServiceKey("Id")>
    Public Class OrderDetail
        Public Property Id As Integer
        Public Property Quantity As Integer
        Public Property Product As ContainmentProduct
    End Class

    <DataServiceKey("Id")>
    Public Class ContainmentProduct
        Public Property Id As Integer
        Public Property Name As String
        Public Property Price As Single
    End Class
End Namespace