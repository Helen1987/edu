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
        Dim categoryId = category.ProductCategoryID

        Dim products = Me.context.Execute(Of Product)(
            New Uri(Me.context.BaseUri.ToString() &
                "/ProductCategory(" & categoryId & ")/Product?$filter=indexof(Name,'" & productName & "') gt -1 or '' eq '" & productName & "'"))

        Dim productsSet As New List(Of Product)()
        For Each p In products
            Me.context.LoadProperty(p, "ProductCategory")
            productsSet.Add(p)
        Next

        Return productsSet
    End Function

    Public Function GetCategories() As IList(Of ProductCategory) Implements IProductGateway.GetCategories
        Dim productCategories = From c In Me.context.ProductCategory
                        Order By c.Name
                        Select c

        Return productCategories.ToList()
    End Function

    Public Sub DeleteProduct(ByVal product As Product) Implements IProductGateway.DeleteProduct
        Me.context.AttachTo("Product", product)
        Me.context.DeleteObject(product)
        Me.context.SaveChanges()
    End Sub

    Public Sub UpdateProduct(ByVal product As Product) Implements IProductGateway.UpdateProduct
        Dim newCategory = product.ProductCategory
        Me.context.AttachTo("Product", product)
        Me.context.LoadProperty(product, "ProductCategory")
        If newCategory.Name <> product.ProductCategory.Name Then
            Me.context.DeleteLink(product, "ProductCategory", product.ProductCategory)
            Me.context.AttachTo("ProductCategory", newCategory)
            Me.context.AddLink(product, "ProductCategory", newCategory)
        End If

        Me.context.UpdateObject(product)
        Me.context.SaveChanges()
    End Sub

    Public Sub AddProduct(ByVal product As Product) Implements IProductGateway.AddProduct
        product.rowguid = Guid.NewGuid()
        Me.context.AddObject("Product", product)
        product.ProductCategory.Product.Add(product)
        Me.context.AttachTo("ProductCategory", product.ProductCategory)
        Me.context.AddLink(product.ProductCategory, "Product", product)
        Me.context.SaveChanges()
    End Sub
End Class