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

Imports UserInterface.AdventureWorks

Public Class ProductView
    Private Property FormCreateMode As Boolean = True
    Private Property Product As Product

    Public Sub UpdateProduct(ByVal product As Product)
        Dim gateway As New ProductGateway()
        Me.Product = gateway.GetProducts(product.Name, product.ProductCategory, 1, 0)(0)
        Me.FormCreateMode = False
        Me.Title = "Edit " & product.Name
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.Close()
    End Sub

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.BindCategories()
        If Me.FormCreateMode Then
            Product = New Product()
        End If

        Me.BindProduct()
    End Sub

    Private Sub BindProduct()
        txtProductNumber.DataContext = Product
        txtName.DataContext = Product
        txtListPrice.DataContext = Product
        txtColor.DataContext = Product
        CategoryComboBoxProductDetail.DataContext = Product
        txtModifiedDate.DataContext = Product
        txtSellStartDate.DataContext = Product
        txtStandardCost.DataContext = Product
    End Sub

    Private Sub BindCategories()
        Dim gateway As New ProductGateway()
        CategoryComboBoxProductDetail.ItemsSource = gateway.GetCategories()
        CategoryComboBoxProductDetail.SelectedIndex = 0
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim gateway As New ProductGateway()
        If Me.FormCreateMode Then
            Product.ProductCategory = DirectCast(CategoryComboBoxProductDetail.SelectedItem, ProductCategory)
            gateway.AddProduct(Product)
        Else
            Product.ProductCategory = DirectCast(CategoryComboBoxProductDetail.SelectedItem, ProductCategory)
            gateway.UpdateProduct(Product)
        End If

        Me.Close()
    End Sub
End Class
