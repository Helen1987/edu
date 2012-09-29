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
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Data.EntityClient
Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Runtime.Serialization

<Assembly: EdmSchemaAttribute("6c80a35b-c353-40dd-aa08-f373285525ac")>

Namespace RowCount
#Region "Contexts"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    Partial Public Class RowCountContext
        Inherits ObjectContext

#Region "Constructors"

        ''' <summary>
        ''' Initializes a new RowCountContext object using the connection string found in the 'RowCountContext' section of the application configuration file.
        ''' </summary>
        Public Sub New()
            MyBase.New("name=RowCountContext", "RowCountContext")
            MyBase.ContextOptions.LazyLoadingEnabled = True
            OnContextCreated()
        End Sub

        ''' <summary>
        ''' Initialize a new RowCountContext object.
        ''' </summary>
        Public Sub New(ByVal connectionString As String)
            MyBase.New(connectionString, "RowCountContext")
            MyBase.ContextOptions.LazyLoadingEnabled = True
            OnContextCreated()
        End Sub

        ''' <summary>
        ''' Initialize a new RowCountContext object.
        ''' </summary>
        Public Sub New(ByVal connection As EntityConnection)
            MyBase.New(connection, "RowCountContext")
            MyBase.ContextOptions.LazyLoadingEnabled = True
            OnContextCreated()
        End Sub

#End Region

#Region "Partial Methods"

        Partial Private Sub OnContextCreated()
        End Sub

#End Region

#Region "ObjectSet Properties"

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        Public ReadOnly Property Products() As ObjectSet(Of Product)
            Get
                If (_Products Is Nothing) Then
                    _Products = MyBase.CreateObjectSet(Of Product)("Products")
                End If
                Return _Products
            End Get
        End Property

        Private _Products As ObjectSet(Of Product)

#End Region
#Region "AddTo Methods"

        ''' <summary>
        ''' Deprecated Method for adding a new object to the Products EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
        ''' </summary>
        Public Sub AddToProducts(ByVal product As Product)
            MyBase.AddObject("Products", product)
        End Sub

#End Region
    End Class

#End Region
#Region "Entities"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmEntityTypeAttribute(NamespaceName:="AdoNetDataServices1510In1.RowCount", Name:="Product")>
    <Serializable()>
    <DataContractAttribute(IsReference:=True)>
    Partial Public Class Product
        Inherits EntityObject
#Region "Factory Method"

        ''' <summary>
        ''' Create a new Product object.
        ''' </summary>
        ''' <param name="productID">Initial value of the ProductID property.</param>
        ''' <param name="name">Initial value of the Name property.</param>
        ''' <param name="productNumber">Initial value of the ProductNumber property.</param>
        ''' <param name="standardCost">Initial value of the StandardCost property.</param>
        ''' <param name="listPrice">Initial value of the ListPrice property.</param>
        ''' <param name="sellStartDate">Initial value of the SellStartDate property.</param>
        ''' <param name="rowguid">Initial value of the rowguid property.</param>
        ''' <param name="modifiedDate">Initial value of the ModifiedDate property.</param>
        Public Shared Function CreateProduct(ByVal productID As Global.System.Int32, ByVal name As Global.System.String, ByVal productNumber As Global.System.String, ByVal standardCost As Global.System.Decimal, ByVal listPrice As Global.System.Decimal, ByVal sellStartDate As Global.System.DateTime, ByVal rowguid As Global.System.Guid, ByVal modifiedDate As Global.System.DateTime) As Product
            Dim product As Product = New Product
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

#End Region
#Region "Primitive Properties"

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=True, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property ProductID() As Global.System.Int32
            Get
                Return _ProductID
            End Get
            Set(ByVal value As Global.System.Int32)
                If (_ProductID <> value) Then
                    OnProductIDChanging(value)
                    ReportPropertyChanging("ProductID")
                    _ProductID = StructuralObject.SetValidValue(value)
                    ReportPropertyChanged("ProductID")
                    OnProductIDChanged()
                End If
            End Set
        End Property

        Private _ProductID As Global.System.Int32
        Partial Private Sub OnProductIDChanging(ByVal value As Global.System.Int32)
        End Sub

        Partial Private Sub OnProductIDChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property Name() As Global.System.String
            Get
                Return _Name
            End Get
            Set(ByVal value As Global.System.String)
                OnNameChanging(value)
                ReportPropertyChanging("Name")
                _Name = StructuralObject.SetValidValue(value, False)
                ReportPropertyChanged("Name")
                OnNameChanged()
            End Set
        End Property

        Private _Name As Global.System.String
        Partial Private Sub OnNameChanging(ByVal value As Global.System.String)
        End Sub

        Partial Private Sub OnNameChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property ProductNumber() As Global.System.String
            Get
                Return _ProductNumber
            End Get
            Set(ByVal value As Global.System.String)
                OnProductNumberChanging(value)
                ReportPropertyChanging("ProductNumber")
                _ProductNumber = StructuralObject.SetValidValue(value, False)
                ReportPropertyChanged("ProductNumber")
                OnProductNumberChanged()
            End Set
        End Property

        Private _ProductNumber As Global.System.String
        Partial Private Sub OnProductNumberChanging(ByVal value As Global.System.String)
        End Sub

        Partial Private Sub OnProductNumberChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property Color() As Global.System.String
            Get
                Return _Color
            End Get
            Set(ByVal value As Global.System.String)
                OnColorChanging(value)
                ReportPropertyChanging("Color")
                _Color = StructuralObject.SetValidValue(value, True)
                ReportPropertyChanged("Color")
                OnColorChanged()
            End Set
        End Property

        Private _Color As Global.System.String
        Partial Private Sub OnColorChanging(ByVal value As Global.System.String)
        End Sub

        Partial Private Sub OnColorChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property StandardCost() As Global.System.Decimal
            Get
                Return _StandardCost
            End Get
            Set(ByVal value As Global.System.Decimal)
                OnStandardCostChanging(value)
                ReportPropertyChanging("StandardCost")
                _StandardCost = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("StandardCost")
                OnStandardCostChanged()
            End Set
        End Property

        Private _StandardCost As Global.System.Decimal
        Partial Private Sub OnStandardCostChanging(ByVal value As Global.System.Decimal)
        End Sub

        Partial Private Sub OnStandardCostChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property ListPrice() As Global.System.Decimal
            Get
                Return _ListPrice
            End Get
            Set(ByVal value As Global.System.Decimal)
                OnListPriceChanging(value)
                ReportPropertyChanging("ListPrice")
                _ListPrice = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("ListPrice")
                OnListPriceChanged()
            End Set
        End Property

        Private _ListPrice As Global.System.Decimal
        Partial Private Sub OnListPriceChanging(ByVal value As Global.System.Decimal)
        End Sub

        Partial Private Sub OnListPriceChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property Size() As Global.System.String
            Get
                Return _Size
            End Get
            Set(ByVal value As Global.System.String)
                OnSizeChanging(value)
                ReportPropertyChanging("Size")
                _Size = StructuralObject.SetValidValue(value, True)
                ReportPropertyChanged("Size")
                OnSizeChanged()
            End Set
        End Property

        Private _Size As Global.System.String
        Partial Private Sub OnSizeChanging(ByVal value As Global.System.String)
        End Sub

        Partial Private Sub OnSizeChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property Weight() As Nullable(Of Global.System.Decimal)
            Get
                Return _Weight
            End Get
            Set(ByVal value As Nullable(Of Global.System.Decimal))
                OnWeightChanging(value)
                ReportPropertyChanging("Weight")
                _Weight = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("Weight")
                OnWeightChanged()
            End Set
        End Property

        Private _Weight As Nullable(Of Global.System.Decimal)
        Partial Private Sub OnWeightChanging(ByVal value As Nullable(Of Global.System.Decimal))
        End Sub

        Partial Private Sub OnWeightChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property ProductCategoryID() As Nullable(Of Global.System.Int32)
            Get
                Return _ProductCategoryID
            End Get
            Set(ByVal value As Nullable(Of Global.System.Int32))
                OnProductCategoryIDChanging(value)
                ReportPropertyChanging("ProductCategoryID")
                _ProductCategoryID = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("ProductCategoryID")
                OnProductCategoryIDChanged()
            End Set
        End Property

        Private _ProductCategoryID As Nullable(Of Global.System.Int32)
        Partial Private Sub OnProductCategoryIDChanging(ByVal value As Nullable(Of Global.System.Int32))
        End Sub

        Partial Private Sub OnProductCategoryIDChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property ProductModelID() As Nullable(Of Global.System.Int32)
            Get
                Return _ProductModelID
            End Get
            Set(ByVal value As Nullable(Of Global.System.Int32))
                OnProductModelIDChanging(value)
                ReportPropertyChanging("ProductModelID")
                _ProductModelID = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("ProductModelID")
                OnProductModelIDChanged()
            End Set
        End Property

        Private _ProductModelID As Nullable(Of Global.System.Int32)
        Partial Private Sub OnProductModelIDChanging(ByVal value As Nullable(Of Global.System.Int32))
        End Sub

        Partial Private Sub OnProductModelIDChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property SellStartDate() As Global.System.DateTime
            Get
                Return _SellStartDate
            End Get
            Set(ByVal value As Global.System.DateTime)
                OnSellStartDateChanging(value)
                ReportPropertyChanging("SellStartDate")
                _SellStartDate = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("SellStartDate")
                OnSellStartDateChanged()
            End Set
        End Property

        Private _SellStartDate As Global.System.DateTime
        Partial Private Sub OnSellStartDateChanging(ByVal value As Global.System.DateTime)
        End Sub

        Partial Private Sub OnSellStartDateChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property SellEndDate() As Nullable(Of Global.System.DateTime)
            Get
                Return _SellEndDate
            End Get
            Set(ByVal value As Nullable(Of Global.System.DateTime))
                OnSellEndDateChanging(value)
                ReportPropertyChanging("SellEndDate")
                _SellEndDate = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("SellEndDate")
                OnSellEndDateChanged()
            End Set
        End Property

        Private _SellEndDate As Nullable(Of Global.System.DateTime)
        Partial Private Sub OnSellEndDateChanging(ByVal value As Nullable(Of Global.System.DateTime))
        End Sub

        Partial Private Sub OnSellEndDateChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property DiscontinuedDate() As Nullable(Of Global.System.DateTime)
            Get
                Return _DiscontinuedDate
            End Get
            Set(ByVal value As Nullable(Of Global.System.DateTime))
                OnDiscontinuedDateChanging(value)
                ReportPropertyChanging("DiscontinuedDate")
                _DiscontinuedDate = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("DiscontinuedDate")
                OnDiscontinuedDateChanged()
            End Set
        End Property

        Private _DiscontinuedDate As Nullable(Of Global.System.DateTime)
        Partial Private Sub OnDiscontinuedDateChanging(ByVal value As Nullable(Of Global.System.DateTime))
        End Sub

        Partial Private Sub OnDiscontinuedDateChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property ThumbNailPhoto() As Global.System.Byte()
            Get
                Return StructuralObject.GetValidValue(_ThumbNailPhoto)
            End Get
            Set(ByVal value As Global.System.Byte())
                OnThumbNailPhotoChanging(value)
                ReportPropertyChanging("ThumbNailPhoto")
                _ThumbNailPhoto = StructuralObject.SetValidValue(value, True)
                ReportPropertyChanged("ThumbNailPhoto")
                OnThumbNailPhotoChanged()
            End Set
        End Property

        Private _ThumbNailPhoto As Global.System.Byte()
        Partial Private Sub OnThumbNailPhotoChanging(ByVal value As Global.System.Byte())
        End Sub

        Partial Private Sub OnThumbNailPhotoChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True)>
        <DataMemberAttribute()>
        Public Property ThumbnailPhotoFileName() As Global.System.String
            Get
                Return _ThumbnailPhotoFileName
            End Get
            Set(ByVal value As Global.System.String)
                OnThumbnailPhotoFileNameChanging(value)
                ReportPropertyChanging("ThumbnailPhotoFileName")
                _ThumbnailPhotoFileName = StructuralObject.SetValidValue(value, True)
                ReportPropertyChanged("ThumbnailPhotoFileName")
                OnThumbnailPhotoFileNameChanged()
            End Set
        End Property

        Private _ThumbnailPhotoFileName As Global.System.String
        Partial Private Sub OnThumbnailPhotoFileNameChanging(ByVal value As Global.System.String)
        End Sub

        Partial Private Sub OnThumbnailPhotoFileNameChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property rowguid() As Global.System.Guid
            Get
                Return _rowguid
            End Get
            Set(ByVal value As Global.System.Guid)
                OnrowguidChanging(value)
                ReportPropertyChanging("rowguid")
                _rowguid = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("rowguid")
                OnrowguidChanged()
            End Set
        End Property

        Private _rowguid As Global.System.Guid
        Partial Private Sub OnrowguidChanging(ByVal value As Global.System.Guid)
        End Sub

        Partial Private Sub OnrowguidChanged()
        End Sub

        ''' <summary>
        ''' No Metadata Documentation available.
        ''' </summary>
        <EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=False)>
        <DataMemberAttribute()>
        Public Property ModifiedDate() As Global.System.DateTime
            Get
                Return _ModifiedDate
            End Get
            Set(ByVal value As Global.System.DateTime)
                OnModifiedDateChanging(value)
                ReportPropertyChanging("ModifiedDate")
                _ModifiedDate = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("ModifiedDate")
                OnModifiedDateChanged()
            End Set
        End Property

        Private _ModifiedDate As Global.System.DateTime
        Partial Private Sub OnModifiedDateChanging(ByVal value As Global.System.DateTime)
        End Sub

        Partial Private Sub OnModifiedDateChanged()
        End Sub

#End Region
    End Class

#End Region

End Namespace