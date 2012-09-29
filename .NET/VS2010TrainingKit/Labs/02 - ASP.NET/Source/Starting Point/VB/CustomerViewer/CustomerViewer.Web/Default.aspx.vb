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

Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports CustomerService.Proxies

Namespace CustomerViewer.Web
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim proxy = New CustomerServiceClient()
			Try
				CustomersDropDownList.DataSource = proxy.GetCustomers()
				CustomersDropDownList.DataBind()
			Catch exp As Exception
				ShowAlert("Error fetching customers: " & exp.Message)
			End Try
		End Sub

		Private Sub ShowAlert(ByVal msg As String)
			Page.ClientScript.RegisterStartupScript(Me.GetType(), "ErrorScript", "<script type='text/javascript'>alert(""" & msg & """);</script>")
		End Sub
	End Class
End Namespace
