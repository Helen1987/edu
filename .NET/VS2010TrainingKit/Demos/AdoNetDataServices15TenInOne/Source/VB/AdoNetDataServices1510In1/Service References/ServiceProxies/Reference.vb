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

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.21006.1
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On


'Original file name:
'Generation date: 09/12/2009 04:38:07 p.m.
Namespace ServiceProxies
    '''<summary>
    '''There are no comments for RowCountContext in the schema.
    '''</summary>
    Partial Public Class RowCountContext
        Inherits Global.System.Data.Services.Client.DataServiceContext
        '''<summary>
        '''Initialize a new RowCountContext object.
        '''</summary>
        Public Sub New(ByVal serviceRoot As Global.System.Uri)
            MyBase.New(serviceRoot)
            Me.ResolveName = AddressOf Me.ResolveNameFromType
            Me.ResolveType = AddressOf Me.ResolveTypeFromName
            Me.OnContextCreated
        End Sub
        Partial Private Sub OnContextCreated()
        End Sub
        Private Shared ROOTNAMESPACE As String = GetType(ServiceProxies.RowCountContext).Namespace.Remove(GetType(ServiceProxies.RowCountContext).Namespace.LastIndexOf("ServiceProxies"))
        '''<summary>
        '''Since the namespace configured for this service reference
        '''in Visual Studio is different from the one indicated in the
        '''server schema, use type-mappers to map between the two.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.EntityModel.Emitters.EntityContainerEmitter", "1.0.0")>  _
        Protected Function ResolveTypeFromName(ByVal typeName As String) As Global.System.Type
            If typeName.StartsWith("AdoNetDataServices1510In1.RowCount", Global.System.StringComparison.OrdinalIgnoreCase) Then
                Return Me.GetType.Assembly.GetType(String.Concat(String.Concat(ROOTNAMESPACE, "ServiceProxies"), typeName.Substring(34)), false)
            End If
            Return Nothing
        End Function
        '''<summary>
        '''Since the namespace configured for this service reference
        '''in Visual Studio is different from the one indicated in the
        '''server schema, use type-mappers to map between the two.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.EntityModel.Emitters.EntityContainerEmitter", "1.0.0")>  _
        Protected Function ResolveNameFromType(ByVal clientType As Global.System.Type) As String
            If clientType.Namespace.Equals(String.Concat(ROOTNAMESPACE, "ServiceProxies"), Global.System.StringComparison.OrdinalIgnoreCase) Then
                Return String.Concat("AdoNetDataServices1510In1.RowCount.", clientType.Name)
            End If
            Return Nothing
        End Function
        '''<summary>
        '''There are no comments for Products in the schema.
        '''</summary>
        Public ReadOnly Property Products() As Global.System.Data.Services.Client.DataServiceQuery(Of Product)
            Get
                If (Me._Products Is Nothing) Then
                    Me._Products = MyBase.CreateQuery(Of Product)("Products")
                End If
                Return Me._Products
            End Get
        End Property
        Private _Products As Global.System.Data.Services.Client.DataServiceQuery(Of Product)
        '''<summary>
        '''There are no comments for Products in the schema.
        '''</summary>
        Public Sub AddToProducts(ByVal product As Product)
            MyBase.AddObject("Products", product)
        End Sub
    End Class
    '''<summary>
    '''There are no comments for AdoNetDataServices1510In1.RowCount.Product in the schema.
    '''</summary>
    '''<KeyProperties>
    '''ProductID
    '''</KeyProperties>
    <Global.System.Data.Services.Common.DataServiceKeyAttribute("ProductID")>  _
    Partial Public Class Product
        '''<summary>
        '''Create a new Product object.
        '''</summary>
        '''<param name="productID">Initial value of ProductID.</param>
        '''<param name="name">Initial value of Name.</param>
        '''<param name="productNumber">Initial value of ProductNumber.</param>
        '''<param name="standardCost">Initial value of StandardCost.</param>
        '''<param name="listPrice">Initial value of ListPrice.</param>
        '''<param name="sellStartDate">Initial value of SellStartDate.</param>
        '''<param name="rowguid">Initial value of rowguid.</param>
        '''<param name="modifiedDate">Initial value of ModifiedDate.</param>
        Public Shared Function CreateProduct(ByVal productID As Integer, ByVal name As String, ByVal productNumber As String, ByVal standardCost As Decimal, ByVal listPrice As Decimal, ByVal sellStartDate As Date, ByVal rowguid As Global.System.Guid, ByVal modifiedDate As Date) As Product
            Dim product As Product = New Product()
            product.ProductID = productID
            product.Name = name
            product.ProductNumber = productNumber
            product.StandardCost = standardCost
            product.ListPrice = listPrice
            product.SellStartDate = sellStartDate
            product.rowguid = rowguid
            product.ModifiedDate = modifiedDate
            Return product
        End Function
        '''<summary>
        '''There are no comments for Property ProductID in the schema.
        '''</summary>
        Public Property ProductID() As Integer
            Get
                Return Me._ProductID
            End Get
            Set
                Me.OnProductIDChanging(value)
                Me._ProductID = value
                Me.OnProductIDChanged
            End Set
        End Property
        Private _ProductID As Integer
        Partial Private Sub OnProductIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnProductIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Name in the schema.
        '''</summary>
        Public Property Name() As String
            Get
                Return Me._Name
            End Get
            Set
                Me.OnNameChanging(value)
                Me._Name = value
                Me.OnNameChanged
            End Set
        End Property
        Private _Name As String
        Partial Private Sub OnNameChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnNameChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ProductNumber in the schema.
        '''</summary>
        Public Property ProductNumber() As String
            Get
                Return Me._ProductNumber
            End Get
            Set
                Me.OnProductNumberChanging(value)
                Me._ProductNumber = value
                Me.OnProductNumberChanged
            End Set
        End Property
        Private _ProductNumber As String
        Partial Private Sub OnProductNumberChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnProductNumberChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Color in the schema.
        '''</summary>
        Public Property Color() As String
            Get
                Return Me._Color
            End Get
            Set
                Me.OnColorChanging(value)
                Me._Color = value
                Me.OnColorChanged
            End Set
        End Property
        Private _Color As String
        Partial Private Sub OnColorChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnColorChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property StandardCost in the schema.
        '''</summary>
        Public Property StandardCost() As Decimal
            Get
                Return Me._StandardCost
            End Get
            Set
                Me.OnStandardCostChanging(value)
                Me._StandardCost = value
                Me.OnStandardCostChanged
            End Set
        End Property
        Private _StandardCost As Decimal
        Partial Private Sub OnStandardCostChanging(ByVal value As Decimal)
        End Sub
        Partial Private Sub OnStandardCostChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ListPrice in the schema.
        '''</summary>
        Public Property ListPrice() As Decimal
            Get
                Return Me._ListPrice
            End Get
            Set
                Me.OnListPriceChanging(value)
                Me._ListPrice = value
                Me.OnListPriceChanged
            End Set
        End Property
        Private _ListPrice As Decimal
        Partial Private Sub OnListPriceChanging(ByVal value As Decimal)
        End Sub
        Partial Private Sub OnListPriceChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Size in the schema.
        '''</summary>
        Public Property Size() As String
            Get
                Return Me._Size
            End Get
            Set
                Me.OnSizeChanging(value)
                Me._Size = value
                Me.OnSizeChanged
            End Set
        End Property
        Private _Size As String
        Partial Private Sub OnSizeChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnSizeChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Weight in the schema.
        '''</summary>
        Public Property Weight() As Global.System.Nullable(Of Decimal)
            Get
                Return Me._Weight
            End Get
            Set
                Me.OnWeightChanging(value)
                Me._Weight = value
                Me.OnWeightChanged
            End Set
        End Property
        Private _Weight As Global.System.Nullable(Of Decimal)
        Partial Private Sub OnWeightChanging(ByVal value As Global.System.Nullable(Of Decimal))
        End Sub
        Partial Private Sub OnWeightChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ProductCategoryID in the schema.
        '''</summary>
        Public Property ProductCategoryID() As Global.System.Nullable(Of Integer)
            Get
                Return Me._ProductCategoryID
            End Get
            Set
                Me.OnProductCategoryIDChanging(value)
                Me._ProductCategoryID = value
                Me.OnProductCategoryIDChanged
            End Set
        End Property
        Private _ProductCategoryID As Global.System.Nullable(Of Integer)
        Partial Private Sub OnProductCategoryIDChanging(ByVal value As Global.System.Nullable(Of Integer))
        End Sub
        Partial Private Sub OnProductCategoryIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ProductModelID in the schema.
        '''</summary>
        Public Property ProductModelID() As Global.System.Nullable(Of Integer)
            Get
                Return Me._ProductModelID
            End Get
            Set
                Me.OnProductModelIDChanging(value)
                Me._ProductModelID = value
                Me.OnProductModelIDChanged
            End Set
        End Property
        Private _ProductModelID As Global.System.Nullable(Of Integer)
        Partial Private Sub OnProductModelIDChanging(ByVal value As Global.System.Nullable(Of Integer))
        End Sub
        Partial Private Sub OnProductModelIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property SellStartDate in the schema.
        '''</summary>
        Public Property SellStartDate() As Date
            Get
                Return Me._SellStartDate
            End Get
            Set
                Me.OnSellStartDateChanging(value)
                Me._SellStartDate = value
                Me.OnSellStartDateChanged
            End Set
        End Property
        Private _SellStartDate As Date
        Partial Private Sub OnSellStartDateChanging(ByVal value As Date)
        End Sub
        Partial Private Sub OnSellStartDateChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property SellEndDate in the schema.
        '''</summary>
        Public Property SellEndDate() As Global.System.Nullable(Of Date)
            Get
                Return Me._SellEndDate
            End Get
            Set
                Me.OnSellEndDateChanging(value)
                Me._SellEndDate = value
                Me.OnSellEndDateChanged
            End Set
        End Property
        Private _SellEndDate As Global.System.Nullable(Of Date)
        Partial Private Sub OnSellEndDateChanging(ByVal value As Global.System.Nullable(Of Date))
        End Sub
        Partial Private Sub OnSellEndDateChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property DiscontinuedDate in the schema.
        '''</summary>
        Public Property DiscontinuedDate() As Global.System.Nullable(Of Date)
            Get
                Return Me._DiscontinuedDate
            End Get
            Set
                Me.OnDiscontinuedDateChanging(value)
                Me._DiscontinuedDate = value
                Me.OnDiscontinuedDateChanged
            End Set
        End Property
        Private _DiscontinuedDate As Global.System.Nullable(Of Date)
        Partial Private Sub OnDiscontinuedDateChanging(ByVal value As Global.System.Nullable(Of Date))
        End Sub
        Partial Private Sub OnDiscontinuedDateChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ThumbNailPhoto in the schema.
        '''</summary>
        Public Property ThumbNailPhoto() As Byte()
            Get
                If (Not (Me._ThumbNailPhoto) Is Nothing) Then
                    Return CType(Me._ThumbNailPhoto.Clone,Byte())
                Else
                    Return Nothing
                End If
            End Get
            Set
                Me.OnThumbNailPhotoChanging(value)
                Me._ThumbNailPhoto = value
                Me.OnThumbNailPhotoChanged
            End Set
        End Property
        Private _ThumbNailPhoto() As Byte
        Partial Private Sub OnThumbNailPhotoChanging(ByVal value() As Byte)
        End Sub
        Partial Private Sub OnThumbNailPhotoChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ThumbnailPhotoFileName in the schema.
        '''</summary>
        Public Property ThumbnailPhotoFileName() As String
            Get
                Return Me._ThumbnailPhotoFileName
            End Get
            Set
                Me.OnThumbnailPhotoFileNameChanging(value)
                Me._ThumbnailPhotoFileName = value
                Me.OnThumbnailPhotoFileNameChanged
            End Set
        End Property
        Private _ThumbnailPhotoFileName As String
        Partial Private Sub OnThumbnailPhotoFileNameChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnThumbnailPhotoFileNameChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property rowguid in the schema.
        '''</summary>
        Public Property rowguid() As Global.System.Guid
            Get
                Return Me._rowguid
            End Get
            Set
                Me.OnrowguidChanging(value)
                Me._rowguid = value
                Me.OnrowguidChanged
            End Set
        End Property
        Private _rowguid As Global.System.Guid
        Partial Private Sub OnrowguidChanging(ByVal value As Global.System.Guid)
        End Sub
        Partial Private Sub OnrowguidChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ModifiedDate in the schema.
        '''</summary>
        Public Property ModifiedDate() As Date
            Get
                Return Me._ModifiedDate
            End Get
            Set
                Me.OnModifiedDateChanging(value)
                Me._ModifiedDate = value
                Me.OnModifiedDateChanged
            End Set
        End Property
        Private _ModifiedDate As Date
        Partial Private Sub OnModifiedDateChanging(ByVal value As Date)
        End Sub
        Partial Private Sub OnModifiedDateChanged()
        End Sub
    End Class
End Namespace
