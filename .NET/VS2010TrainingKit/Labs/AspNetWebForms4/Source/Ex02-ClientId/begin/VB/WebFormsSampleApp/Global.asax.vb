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

Namespace WebFormsSampleApp
	Public Class [Global]
		Inherits System.Web.HttpApplication

		Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs on application startup

		End Sub

		Private Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
			'  Code that runs on application shutdown

		End Sub

		Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs when an unhandled error occurs

		End Sub

		Private Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs when a new session is started

		End Sub

		Private Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
			' Code that runs when a session ends. 
			' Note: The Session_End event is raised only when the sessionstate mode
			' is set to InProc in the Web.config file. If session mode is set to StateServer 
			' or SQLServer, the event is not raised.

		End Sub

	End Class
End Namespace
