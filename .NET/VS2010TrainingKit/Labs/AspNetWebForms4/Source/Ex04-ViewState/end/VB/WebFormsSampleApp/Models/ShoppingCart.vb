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

Imports System.Collections.Generic
Imports System.Linq

Namespace WebFormsSampleApp.Models
	Public Class ShoppingCart
        Private _items As List(Of ShoppingCartItem)

        Public Sub New()
            _items = New List(Of ShoppingCartItem)()
        End Sub

        Public Property CartId() As String

        Public ReadOnly Property Items() As ShoppingCartItem()
            Get
                Return _items.ToArray()
            End Get
        End Property

        Public ReadOnly Property TotalItems() As Integer
            Get
                Return ( _
                    From i In _items _
                    Select i.Quantity).Sum()
            End Get
        End Property

        Public ReadOnly Property Subtotal() As Decimal
            Get
                If Items.Length = 0 Then
                    Return 0
                End If

                Dim result As Decimal = 0

                For Each item As ShoppingCartItem In Items
                    result += item.UnitPrice * item.Quantity
                Next item

                Return result
            End Get
        End Property

        Public Function AddItem(ByVal productId As Integer, ByVal productName As String, ByVal unitPrice As Decimal, ByVal quantity As Integer) As Decimal
            Dim item As ShoppingCartItem = Items.Where(Function(i) i.ProductId = productId).SingleOrDefault()

            If item IsNot Nothing Then
                item.Quantity += 1
            Else
                item = New ShoppingCartItem()
                item.ProductId = productId
                item.ProductName = productName
                item.UnitPrice = unitPrice
                item.Quantity = quantity
                _items.Add(item)
            End If

            Return Subtotal
        End Function
	End Class
End Namespace
