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

Imports System.Globalization
Imports UserInterface.AdventureWorks

Public Class ProductList
    Public Sub New()
        Me.InitializeComponent()
        AddHandler ProductsListView.MouseDoubleClick, AddressOf Me.ProductsListView_MouseDoubleClick
    End Sub

    Private Sub BindCategories()
        Dim gateway As New ProductGateway()
        CategoryComboBox.ItemsSource = gateway.GetCategories()
        CategoryComboBox.SelectedIndex = 0
    End Sub

    Private Sub BindProducts()
        If CategoryComboBox.SelectedIndex > -1 Then
            Dim gateway As New ProductGateway()
            ProductsListView.ItemsSource = gateway.GetProducts(NameTextBox.Text, TryCast(CategoryComboBox.SelectedItem, ProductCategory))
        End If
    End Sub

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.BindCategories()
    End Sub

    Private Sub ProductsListView_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        Dim p As Product = TryCast(ProductsListView.SelectedItem, Product)
        Dim window As New ProductView()
        AddHandler window.Closed, AddressOf Me.Window_Closed
        window.UpdateProduct(p)
        window.Show()
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.BindProducts()
    End Sub

    Private Sub BtnNewProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim window As New ProductView()
        AddHandler window.Closed, AddressOf Me.Window_Closed
        window.Show()
    End Sub

    Private Sub BtnDeleteProduct_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Dim p As Product = TryCast(ProductsListView.SelectedItem, Product)
        If p IsNot Nothing Then
            Dim gateway As New ProductGateway()
            gateway.DeleteProduct(p)
            Me.BindProducts()
        End If
    End Sub

    Private Sub Window_Closed(ByVal sender As Object, ByVal e As EventArgs)
        Me.BindProducts()
    End Sub
End Class
