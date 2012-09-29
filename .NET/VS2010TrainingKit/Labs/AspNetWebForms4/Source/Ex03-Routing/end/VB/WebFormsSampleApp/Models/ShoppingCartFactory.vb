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

Imports System.Web

Namespace WebFormsSampleApp.Models
	Public NotInheritable Class ShoppingCartFactory
		Private Sub New()
		End Sub
		Public Shared Function GetInstance() As ShoppingCart
			Dim cart As ShoppingCart = TryCast(HttpContext.Current.Session("ShoppingCart"), ShoppingCart)
			If cart Is Nothing Then
                cart = New ShoppingCart()
                HttpContext.Current.Session("ShoppingCart") = cart
			End If
			Return cart
		End Function
	End Class
End Namespace