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

Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Linq.Expressions

Public Class AdventureWorks
    Inherits DataService(Of AdventureWorksLTEntities)

    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        config.SetEntitySetAccessRule("*", EntitySetRights.All)
        config.SetServiceOperationAccessRule("GetProducts", ServiceOperationRights.All)
        config.DataServiceBehavior.MaxProtocolVersion = System.Data.Services.Common.DataServiceProtocolVersion.V2
    End Sub

    <WebGet()> _
    Public Function GetProducts(ByVal productName As String, ByVal productCategoryId As Integer) As IQueryable(Of Product)
        Return From p In Me.CurrentDataSource.Product _
            Where p.ProductCategory.ProductCategoryID = productCategoryId AndAlso (p.Name = productName OrElse [String].IsNullOrEmpty(productName)) _
            Select p
    End Function

    <ChangeInterceptor("Product")> _
    Public Sub OnChangeProduct(ByVal product As Product, ByVal action As UpdateOperations)
        If action = UpdateOperations.Add OrElse action = UpdateOperations.Change Then

            If String.IsNullOrEmpty(product.Color) Then
                Throw New DataServiceException("Product must have a color specified")
            End If
            Dim fakeToday = New DateTime(2009, 3, 26)
            product.ModifiedDate = fakeToday
        End If
        If action = UpdateOperations.Add Then
            product.rowguid = Guid.NewGuid()
        End If
    End Sub

    <QueryInterceptor("ProductCategory")> _
    Public Function OnQueryProductCategory() As Expression(Of Func(Of ProductCategory, Boolean))
        Return (Function(pc) pc.Name.StartsWith("B"))
    End Function
End Class
