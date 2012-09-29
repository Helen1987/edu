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

Imports System.Linq
Imports System.Data.Linq

Namespace WebFormsSampleApp.Models
	Public Class AdventureWorksRepository
		Public Function GetCategories() As ProductCategory()
			Dim db As New AdventureWorksDataContext()
			Return ( _
			    From c In db.ProductCategories _
			    Where c.ParentProductCategoryID Is Nothing _
			    Select c).ToArray()
		End Function

		Public Function GetSubcategories(ByVal category As String) As ProductCategory()
			Dim db As New AdventureWorksDataContext()

			Return ( _
			    From c In db.ProductCategories _
			    Where c.ParentProductCategoryID.Equals(GetCategoryId(category)) _
			    Select c).ToArray()
		End Function

		Public Function GetProductsCount() As Integer
			Dim db As New AdventureWorksDataContext()
			Return db.Products.Count()
		End Function

		Public Function GetProductsCountByCategories(ByVal categoryIds() As Integer) As Integer
			Dim db As New AdventureWorksDataContext()
			Return ( _
			    From p In db.Products _
			    Where categoryIds.Contains(p.ProductCategoryID.Value) _
			    Select p).Count()
		End Function

		Public Function GetProductsByCategories(ByVal categoryIds() As Integer, ByVal page As Integer, ByVal pageSize As Integer) As Product()
			Dim startRowIndex As Integer = (page-1) * pageSize
			Dim maximumRows As Integer = pageSize
			Dim db As New AdventureWorksDataContext()
			Return ( _
			    From p In db.Products _
			    Where categoryIds.Contains(p.ProductCategoryID.Value) _
			    Order By p.Name Ascending _
			    Select p).Skip(startRowIndex).Take(maximumRows).ToArray()
		End Function

		Public Function GetProductImage(ByVal productId As Integer) As Byte()
			Dim db As New AdventureWorksDataContext()
            Return ( _
                From p In db.Products _
                Where p.ProductID = productId _
                Select p.ThumbNailPhoto).SingleOrDefault().ToArray()
		End Function

		Public Function GetProduct(ByVal productId As Integer) As Product
			Dim db As New AdventureWorksDataContext()
			Return db.Products.Where(Function(p) p.ProductID = productId).SingleOrDefault()
		End Function

		Private Function GetCategoryId(ByVal category As String) As Integer
			Dim db As New AdventureWorksDataContext()
			Dim result = ( _
			    From c In db.ProductCategories _
			    Where c.Name = category _
			    Select c.ProductCategoryID)

            Return If((result.Count() > 0), result.First(), -1)
		End Function
	End Class
End Namespace
