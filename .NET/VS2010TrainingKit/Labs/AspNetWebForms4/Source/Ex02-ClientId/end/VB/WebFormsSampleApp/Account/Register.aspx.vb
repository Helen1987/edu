﻿' ----------------------------------------------------------------------------------
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
Imports System.Web.Security

Namespace WebFormsSampleApp.Account
	Partial Public Class Register
		Inherits System.Web.UI.Page

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			RegisterUser.ContinueDestinationPageUrl = Request.QueryString("ReturnUrl")
		End Sub

		Protected Sub RegisterUser_CreatedUser(ByVal sender As Object, ByVal e As EventArgs)
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, False)

			Dim continueUrl As String = RegisterUser.ContinueDestinationPageUrl
			If String.IsNullOrEmpty(continueUrl) Then
				continueUrl = "~/"
			End If
			Response.Redirect(continueUrl)
		End Sub

	End Class
End Namespace
