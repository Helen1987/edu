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
Imports System.Web
Imports System.Web.Services
Imports WebFormsSampleApp.Models

Namespace WebFormsSampleApp
	''' <summary>
	''' Summary description for GetProductImage
	''' </summary>
	<WebService(Namespace := "http://tempuri.org/"), WebServiceBinding(ConformsTo := WsiProfiles.BasicProfile1_1)> _
	Public Class GetProductImage
		Implements IHttpHandler

		Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
			Dim productId As Integer = Convert.ToInt32(context.Request("pid"))
			Dim repository As New AdventureWorksRepository()
			Dim imageData() As Byte = repository.GetProductImage(productId)

			context.Response.ContentType = "Image/gif"
			context.Response.OutputStream.Write(imageData, 0, imageData.Length)
		End Sub

		Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
			Get
				Return False
			End Get
		End Property
	End Class
End Namespace