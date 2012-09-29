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

Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.Linq
Imports System.Web.Compilation
Imports System.Web.UI.WebControls
Imports WebFormsSampleApp.Models

Namespace WebFormsSampleApp
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Private Const pageSize As Integer = 8

        Public Property SelectedCategoryName() As String
            Get
                If Me.CategoryNameState.Value Is Nothing Then
                    Me.CategoryNameState.Value = "Bikes"
                End If

                Return Me.CategoryNameState.Value
            End Get
            Set(ByVal value As String)
                Me.CategoryNameState.Value = value
            End Set
        End Property

        Public Property TotalPages() As Integer
            Get
                If TotalPagesState.Value Is Nothing Then
                    TotalPagesState.Value = "0"
                End If

                Return Convert.ToInt32(TotalPagesState.Value)
            End Get
            Set(ByVal value As Integer)
                TotalPagesState.Value = Convert.ToString(value)
            End Set
        End Property

        Public Property SelectedPage() As Integer
            Get
                If Me.SelectedPageState.Value Is Nothing Then
                    Me.SelectedPageState.Value = "1"
                End If

                Return Convert.ToInt32(Me.SelectedPageState.Value)
            End Get
            Set(ByVal value As Integer)
                Me.SelectedPageState.Value = Convert.ToString(value)
            End Set
        End Property

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            If (Not IsPostBack) Then
                Me.SelectedCategoryName = GetCategoryName()
                Me.SelectedPage = GetPageIndex()
            End If

            ApplyProductsFilter()
            CreatePagerLinks()
		End Sub

		Protected Sub AddToCartLinkButton_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim cartLinkButton As LinkButton = TryCast(sender, LinkButton)
			Dim productId As Integer = If((cartLinkButton IsNot Nothing), Convert.ToInt32(cartLinkButton.CommandArgument), 1)
			Dim repository As New AdventureWorksRepository()
			Dim product As Product = repository.GetProduct(productId)

			If product IsNot Nothing Then
				Dim cart As ShoppingCart = ShoppingCartFactory.GetInstance()
				cart.AddItem(product.ProductID, product.ProductNumber, product.ListPrice, 1)
			End If
		End Sub

		Protected Sub CategoryLink_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim link As HyperLink = TryCast(sender, HyperLink)

			If link IsNot Nothing Then
				link.CssClass = If((link.Text = Me.SelectedCategoryName), "selected", "")
			End If
		End Sub

        Private Function GetCategoryName() As String
            Dim category As String = TryCast(RouteData.Values("category"), String)
            Dim repository As New AdventureWorksRepository()

            If category IsNot Nothing Then
                Return category
            End If

            Return repository.GetCategories()(0).Name
        End Function

		Private Function GetPageIndex() As Integer
            Dim page As String = TryCast(RouteData.Values("page"), String)

			If page IsNot Nothing Then
				Return Convert.ToInt32(page)
			End If

			Return 1
		End Function

		Private Sub ApplyProductsFilter()
			Dim repository As New AdventureWorksRepository()
			Dim subcatIds() As Integer = ( _
			    From c In repository.GetSubcategories(Me.SelectedCategoryName) _
			    Select c.ProductCategoryID).ToArray()

			Me.TotalPages = CInt(Fix(Math.Ceiling((CDbl(repository.GetProductsCountByCategories(subcatIds))) / (CDbl(pageSize)))))
			Dim products() As Product = repository.GetProductsByCategories(subcatIds, Me.SelectedPage, CInt(Fix(pageSize)))

			ProductDataList.DataSource = products
			ProductDataList.DataBind()

			ProductListPanel.Visible = True
			PageIndexOverflowPanel.Visible = ((Me.TotalPages < Me.SelectedPage) AndAlso (Me.TotalPages <> 0))
			NoProductsFoundPanel.Visible = ((products.Length = 0) AndAlso (Me.TotalPages = 0))
			PagerPanel.Visible = (Me.TotalPages > 1)
		End Sub

		Private Sub CreatePagerLinks()
			For i As Integer = 1 To Me.TotalPages
				Dim link As New HyperLink() With {.Text = i.ToString()}
				If i = Me.SelectedPage Then
					link.CssClass = "currentPage"
				End If

				PagerPanel.Controls.Add(link)

                Dim expression As String = String.Format(CultureInfo.InvariantCulture, "RouteName={0}, category={1}, page={2}", "CategoryAndPage", Me.SelectedCategoryName, i)
                link.NavigateUrl = RouteUrlExpressionBuilder.GetRouteUrl(Me, expression)
			Next i
		End Sub
	End Class
End Namespace
