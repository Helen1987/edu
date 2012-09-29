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

Imports System
Imports WebFormsSampleApp.Models

Namespace WebFormsSampleApp.UserControls
	Partial Public Class ShoppingCartControl
		Inherits System.Web.UI.UserControl
		Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs)
			Dim cart As ShoppingCart = ShoppingCartFactory.GetInstance()

			ExpandedItemsCountLabel.Text = cart.TotalItems.ToString()
			CollapsedItemsCountLabel.Text = cart.TotalItems.ToString()
			ExpandedTotalLabel.Text = cart.Subtotal.ToString("c")
			CollapsedTotalLabel.Text = cart.Subtotal.ToString("c")

			Me.ShopCartExpandedEmpty.Visible = cart.TotalItems = 0
			Me.ShopCartExpandedNonEmpty.Visible = cart.TotalItems <> 0

            ShoppingCartItemsLists.DataSource = cart.Items
            ShoppingCartItemsLists.DataBind()
		End Sub
	End Class
End Namespace