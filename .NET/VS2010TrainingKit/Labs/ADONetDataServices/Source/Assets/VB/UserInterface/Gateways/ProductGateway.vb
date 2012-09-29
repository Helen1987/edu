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

Imports System.Configuration
Imports System.Data.Services.Client
Imports UserInterface.AdventureWorks

Public Class ProductGateway
    Implements IProductGateway
    Private context As AdventureWorksLTEntities

    Public Sub New()
        Dim serviceUri As New Uri(ConfigurationManager.AppSettings("ServiceUri"))
        Me.context = New AdventureWorksLTEntities(serviceUri)
        Me.context.MergeOption = MergeOption.AppendOnly
    End Sub

    Public Function GetProducts(ByVal productName As String, ByVal category As ProductCategory) As IList(Of Product) Implements IProductGateway.GetProducts
        Return Nothing
    End Function

    Public Function GetCategories() As IList(Of ProductCategory) Implements IProductGateway.GetCategories
        Return Nothing
    End Function

    Public Sub DeleteProduct(ByVal product As Product) Implements IProductGateway.DeleteProduct
    End Sub

    Public Sub UpdateProduct(ByVal product As Product) Implements IProductGateway.UpdateProduct
    End Sub

    Public Sub AddProduct(ByVal product As Product) Implements IProductGateway.AddProduct
    End Sub
End Class