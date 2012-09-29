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
'     This code was generated from a template.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices

<DataContract(IsReference:=False)>
<KnownType(GetType(ProductCategory))>
<KnownType(GetType(ProductModel))>
<KnownType(GetType(SalesOrderDetail))>
Partial Public Class Product
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Primitive Properties"

    <DataMember()>
    Public Property ProductID() As Integer
        Get
            Return _productID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_productID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("The property 'ProductID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.")
                End If
                _productID = value
                OnPropertyChanged("ProductID")
            End If
        End Set
    End Property

    Private _productID As Integer

    <DataMember()>
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            If Not Equals(_name, value) Then
                _name = value
                OnPropertyChanged("Name")
            End If
        End Set
    End Property

    Private _name As String

    <DataMember()>
    Public Property ProductNumber() As String
        Get
            Return _productNumber
        End Get
        Set(ByVal value As String)
            If Not Equals(_productNumber, value) Then
                _productNumber = value
                OnPropertyChanged("ProductNumber")
            End If
        End Set
    End Property

    Private _productNumber As String

    <DataMember()>
    Public Property Color() As String
        Get
            Return _color
        End Get
        Set(ByVal value As String)
            If Not Equals(_color, value) Then
                _color = value
                OnPropertyChanged("Color")
            End If
        End Set
    End Property

    Private _color As String

    <DataMember()>
    Public Property StandardCost() As Decimal
        Get
            Return _standardCost
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_standardCost, value) Then
                _standardCost = value
                OnPropertyChanged("StandardCost")
            End If
        End Set
    End Property

    Private _standardCost As Decimal

    <DataMember()>
    Public Property ListPrice() As Decimal
        Get
            Return _listPrice
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_listPrice, value) Then
                _listPrice = value
                OnPropertyChanged("ListPrice")
            End If
        End Set
    End Property

    Private _listPrice As Decimal

    <DataMember()>
    Public Property Size() As String
        Get
            Return _size
        End Get
        Set(ByVal value As String)
            If Not Equals(_size, value) Then
                _size = value
                OnPropertyChanged("Size")
            End If
        End Set
    End Property

    Private _size As String

    <DataMember()>
    Public Property Weight() As Nullable(Of Decimal)
        Get
            Return _weight
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_weight, value) Then
                _weight = value
                OnPropertyChanged("Weight")
            End If
        End Set
    End Property

    Private _weight As Nullable(Of Decimal)

    <DataMember()>
    Public Property ProductCategoryID() As Nullable(Of Integer)
        Get
            Return _productCategoryID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_productCategoryID, value) Then
                ChangeTracker.RecordOriginalValue("ProductCategoryID", _productCategoryID)
                If Not IsDeserializing Then
                    If ProductCategory IsNot Nothing AndAlso Not Equals(ProductCategory.ProductCategoryID, value) Then
                        ProductCategory = Nothing
                    End If
                End If
                _productCategoryID = value
                OnPropertyChanged("ProductCategoryID")
            End If
        End Set
    End Property

    Private _productCategoryID As Nullable(Of Integer)

    <DataMember()>
    Public Property ProductModelID() As Nullable(Of Integer)
        Get
            Return _productModelID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_productModelID, value) Then
                ChangeTracker.RecordOriginalValue("ProductModelID", _productModelID)
                If Not IsDeserializing Then
                    If ProductModel IsNot Nothing AndAlso Not Equals(ProductModel.ProductModelID, value) Then
                        ProductModel = Nothing
                    End If
                End If
                _productModelID = value
                OnPropertyChanged("ProductModelID")
            End If
        End Set
    End Property

    Private _productModelID As Nullable(Of Integer)

    <DataMember()>
    Public Property SellStartDate() As Date
        Get
            Return _sellStartDate
        End Get
        Set(ByVal value As Date)
            If Not Equals(_sellStartDate, value) Then
                _sellStartDate = value
                OnPropertyChanged("SellStartDate")
            End If
        End Set
    End Property

    Private _sellStartDate As Date

    <DataMember()>
    Public Property SellEndDate() As Nullable(Of Date)
        Get
            Return _sellEndDate
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_sellEndDate, value) Then
                _sellEndDate = value
                OnPropertyChanged("SellEndDate")
            End If
        End Set
    End Property

    Private _sellEndDate As Nullable(Of Date)

    <DataMember()>
    Public Property DiscontinuedDate() As Nullable(Of Date)
        Get
            Return _discontinuedDate
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_discontinuedDate, value) Then
                _discontinuedDate = value
                OnPropertyChanged("DiscontinuedDate")
            End If
        End Set
    End Property

    Private _discontinuedDate As Nullable(Of Date)

    <DataMember()>
    Public Property ThumbNailPhoto() As Byte()
        Get
            Return _thumbNailPhoto
        End Get
        Set(ByVal value As Byte())
            If _thumbNailPhoto IsNot value Then
                _thumbNailPhoto = value
                OnPropertyChanged("ThumbNailPhoto")
            End If
        End Set
    End Property

    Private _thumbNailPhoto As Byte()

    <DataMember()>
    Public Property ThumbnailPhotoFileName() As String
        Get
            Return _thumbnailPhotoFileName
        End Get
        Set(ByVal value As String)
            If Not Equals(_thumbnailPhotoFileName, value) Then
                _thumbnailPhotoFileName = value
                OnPropertyChanged("ThumbnailPhotoFileName")
            End If
        End Set
    End Property

    Private _thumbnailPhotoFileName As String

    <DataMember()>
    Public Property rowguid() As System.Guid
        Get
            Return _rowguid
        End Get
        Set(ByVal value As System.Guid)
            If Not Equals(_rowguid, value) Then
                _rowguid = value
                OnPropertyChanged("rowguid")
            End If
        End Set
    End Property

    Private _rowguid As System.Guid

    <DataMember()>
    Public Property ModifiedDate() As Date
        Get
            Return _modifiedDate
        End Get
        Set(ByVal value As Date)
            If Not Equals(_modifiedDate, value) Then
                _modifiedDate = value
                OnPropertyChanged("ModifiedDate")
            End If
        End Set
    End Property

    Private _modifiedDate As Date

#End Region
#Region "Navigation Properties"

    <DataMember()>
    Public Property ProductCategory() As ProductCategory
        Get
            Return _productCategory
        End Get
        Set(ByVal value As ProductCategory)
            If _productCategory IsNot value Then
                Dim previousValue As ProductCategory = _productCategory
                _productCategory = value
                FixupProductCategory(previousValue)
                OnNavigationPropertyChanged("ProductCategory")
            End If
        End Set
    End Property

    Private _productCategory As ProductCategory


    <DataMember()>
    Public Property ProductModel() As ProductModel
        Get
            Return _productModel
        End Get
        Set(ByVal value As ProductModel)
            If _productModel IsNot value Then
                Dim previousValue As ProductModel = _productModel
                _productModel = value
                FixupProductModel(previousValue)
                OnNavigationPropertyChanged("ProductModel")
            End If
        End Set
    End Property

    Private _productModel As ProductModel


    <DataMember()>
    Public Property SalesOrderDetails() As TrackableCollection(Of SalesOrderDetail)
        Get
            If _salesOrderDetails Is Nothing Then
                _salesOrderDetails = New TrackableCollection(Of SalesOrderDetail)
                AddHandler _salesOrderDetails.CollectionChanged, AddressOf FixupSalesOrderDetails
            End If
            Return _salesOrderDetails
        End Get
        Set(ByVal value As TrackableCollection(Of SalesOrderDetail))
            If Not Object.ReferenceEquals(_salesOrderDetails, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled")
                End If
                If _salesOrderDetails IsNot Nothing Then
                    RemoveHandler _salesOrderDetails.CollectionChanged, AddressOf FixupSalesOrderDetails
                End If
                _salesOrderDetails = value
                If _salesOrderDetails IsNot Nothing Then
                    AddHandler _salesOrderDetails.CollectionChanged, AddressOf FixupSalesOrderDetails
                End If
                OnNavigationPropertyChanged("SalesOrderDetails")
            End If
        End Set
    End Property

    Private _salesOrderDetails As TrackableCollection(Of SalesOrderDetail)

#End Region
#Region "ChangeTracking"

    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        If ChangeTracker.State <> ObjectState.Added AndAlso ChangeTracker.State <> ObjectState.Deleted Then
            ChangeTracker.State = ObjectState.Modified
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Protected Overridable Sub OnNavigationPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _changeTracker As ObjectChangeTracker

    <DataMember()>
    Public Property ChangeTracker() As ObjectChangeTracker Implements IObjectWithChangeTracker.ChangeTracker
        Get
            If _changeTracker Is Nothing Then
                _changeTracker = New ObjectChangeTracker()
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            Return _changeTracker
        End Get
        Set(ByVal value As ObjectChangeTracker)
            If _changeTracker IsNot Nothing Then
                RemoveHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            _changeTracker = value
            If _changeTracker IsNot Nothing Then
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
        End Set
    End Property

    Private Sub HandleObjectStateChanging(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.ClearNavigationProperties()
        End If
    End Sub

    Private _isDeserializing As Boolean
    Protected Property IsDeserializing() As Boolean
        Get
            Return _isDeserializing
        End Get
        Private Set(ByVal value As Boolean)
            _isDeserializing = value
        End Set
    End Property

    <OnDeserializing()>
    Public Sub OnDeserializingMethod(ByVal context As StreamingContext)
        IsDeserializing = True
    End Sub

    <OnDeserialized()>
    Public Sub OnDeserializedMethod(ByVal context As StreamingContext)
        IsDeserializing = False
        ChangeTracker.ChangeTrackingEnabled = True
    End Sub

    Protected Overridable Sub ClearNavigationProperties()
        ProductCategory = Nothing
        ProductModel = Nothing
        SalesOrderDetails.Clear()
    End Sub

#End Region
#Region "Association Fixup"

    Private Sub FixupProductCategory(ByVal previousValue As ProductCategory, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Products.Contains(Me) Then
            previousValue.Products.Remove(Me)
        End If

        If ProductCategory IsNot Nothing Then
            If Not ProductCategory.Products.Contains(Me) Then
                ProductCategory.Products.Add(Me)
            End If

            ProductCategoryID = ProductCategory.ProductCategoryID
        ElseIf Not skipKeys Then
            ProductCategoryID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ProductCategory") AndAlso
                ChangeTracker.OriginalValues("ProductCategory") Is ProductCategory Then
                ChangeTracker.OriginalValues.Remove("ProductCategory")
            Else
                ChangeTracker.RecordOriginalValue("ProductCategory", previousValue)
            End If
            If ProductCategory IsNot Nothing AndAlso Not ProductCategory.ChangeTracker.ChangeTrackingEnabled Then
                ProductCategory.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupProductModel(ByVal previousValue As ProductModel, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Products.Contains(Me) Then
            previousValue.Products.Remove(Me)
        End If

        If ProductModel IsNot Nothing Then
            If Not ProductModel.Products.Contains(Me) Then
                ProductModel.Products.Add(Me)
            End If

            ProductModelID = ProductModel.ProductModelID
        ElseIf Not skipKeys Then
            ProductModelID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ProductModel") AndAlso
                ChangeTracker.OriginalValues("ProductModel") Is ProductModel Then
                ChangeTracker.OriginalValues.Remove("ProductModel")
            Else
                ChangeTracker.RecordOriginalValue("ProductModel", previousValue)
            End If
            If ProductModel IsNot Nothing AndAlso Not ProductModel.ChangeTracker.ChangeTrackingEnabled Then
                ProductModel.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupSalesOrderDetails(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As SalesOrderDetail In e.NewItems
                item.Product = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("SalesOrderDetails", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As SalesOrderDetail In e.OldItems
                If ReferenceEquals(item.Product, Me) Then
                    item.Product = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("SalesOrderDetails", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
