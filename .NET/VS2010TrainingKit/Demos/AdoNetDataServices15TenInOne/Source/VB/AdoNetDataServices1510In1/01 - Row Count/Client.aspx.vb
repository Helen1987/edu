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

Imports System.Data.Services.Client

Public Class Client
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Context = New ServiceProxies.RowCountContext(New Uri("http://localhost:50000/01%20-%20Row%20Count/RowCountService.svc"))

        '' This query requests all products as well as the total count
        '' of products (included inline). This is equivalent to:
        '' RowCountService.svc/Products?$inlinecount=allpages
        Dim productsWithCount = From prod In Context.Products.IncludeTotalCount() Order By prod.Name Select prod

        Dim queryResponse = TryCast(productsWithCount, DataServiceQuery).Execute()
        Dim queryOperationResponse = TryCast(queryResponse, QueryOperationResponse)
        Dim inlineCount = queryOperationResponse.TotalCount

        '' This query requests only the count of all products
        '' on the server. This is equivalent to: 
        '' RowCountService.svc/Products/$count
        Dim productCount = Context.Products.Count()
        rowCountLabel.Text = productCount.ToString()
    End Sub

End Class