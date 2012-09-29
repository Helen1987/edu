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

Namespace FriendlyFeeds
    Public Class FriendlyFeedObjectModel
        Private _products As IList(Of Product)

        Public Sub New()
            _products = New List(Of Product) From
            {
                New Product With {
                    .Id = 1,
                    .Name = "XBOX 360",
                    .Author = "Andersen, Elizabeth A.",
                    .Price = 300.99F,
                    .Category = New Category With {.Id = 1, .Name = "Games"}},
                New Product With {
                    .Id = 2,
                    .Name = "Fishing Pole",
                    .Author = "Dunton, Bryn Paul",
                    .Price = 12.36F},
                New Product With {
                    .Id = 3,
                    .Name = "Bunny Bread",
                    .Author = "Shortt, Patrick",
                    .Price = 1.89F},
                New Product With {
                    .Id = 4,
                    .Name = "Grand Piano",
                    .Author = "Roland, Alex",
                    .Price = 13000.0F}
            }
        End Sub

        Public ReadOnly Property Products As IQueryable(Of Product)
            Get
                Return _products.AsQueryable()
            End Get
        End Property
    End Class

    <EntityPropertyMapping("Name", SyndicationItemProperty.Title, SyndicationTextContentKind.Plaintext, True)>
    <EntityPropertyMapping("Author", SyndicationItemProperty.AuthorName, SyndicationTextContentKind.Plaintext, True)>
    <EntityPropertyMapping("Price", "price", "money", "http://tempuri.org/money", True)>
    <EntityPropertyMapping("Category/Name", "category", "category", "http://tempuri.org/category", True)>
    <DataServiceKey("Id")>
    Public Class Product

        Public Property Id As Integer
        Public Property Name As String
        Public Property Author As String
        Public Property Price As Single
        Public Property Category As Category
    End Class

    <DataServiceKey("Id")>
    Public Class Category
        Public Property Id As Integer
        Public Property Name As String
    End Class
End Namespace