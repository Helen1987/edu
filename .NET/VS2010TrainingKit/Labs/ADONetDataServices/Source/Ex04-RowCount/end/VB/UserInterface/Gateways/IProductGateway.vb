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

Public Interface IProductGateway
    Function GetProducts(ByVal productName As String, ByVal category As ProductCategory, ByVal pageSize As Integer, ByVal pageNumber As Integer) As IList(Of Product)
    Function GetCategories() As IList(Of ProductCategory)
    Sub DeleteProduct(ByVal product As Product)
    Sub UpdateProduct(ByVal product As Product)
    Sub AddProduct(ByVal product As Product)
    Function GetProductsCount(ByVal productName As String, ByVal category As ProductCategory) As Integer
End Interface
