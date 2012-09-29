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

<DataContract(IsReference:=True)>
<KnownType(GetType(Product))>
<KnownType(GetType(SalesOrderHeader))>
Partial Public Class SalesOrderDetail
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Primitive Properties"

    <DataMember()>
    Public Property SalesOrderID() As Integer
        Get
            Return _salesOrderID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_salesOrderID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("The property 'SalesOrderID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.")
                End If
                If Not IsDeserializing Then
                    If SalesOrderHeader IsNot Nothing AndAlso Not Equals(SalesOrderHeader.SalesOrderID, value) Then
                        SalesOrderHeader = Nothing
                    End If
                End If
                _salesOrderID = value
                OnPropertyChanged("SalesOrderID")
            End If
        End Set
    End Property

    Private _salesOrderID As Integer

    <DataMember()>
    Public Property SalesOrderDetailID() As Integer
        Get
            Return _salesOrderDetailID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_salesOrderDetailID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("The property 'SalesOrderDetailID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.")
                End If
                _salesOrderDetailID = value
                OnPropertyChanged("SalesOrderDetailID")
            End If
        End Set
    End Property

    Private _salesOrderDetailID As Integer

    <DataMember()>
    Public Property OrderQty() As Short
        Get
            Return _orderQty
        End Get
        Set(ByVal value As Short)
            If Not Equals(_orderQty, value) Then
                _orderQty = value
                OnPropertyChanged("OrderQty")
            End If
        End Set
    End Property

    Private _orderQty As Short

    <DataMember()>
    Public Property ProductID() As Integer
        Get
            Return _productID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_productID, value) Then
                ChangeTracker.RecordOriginalValue("ProductID", _productID)
                If Not IsDeserializing Then
                    If Product IsNot Nothing AndAlso Not Equals(Product.ProductID, value) Then
                        Product = Nothing
                    End If
                End If
                _productID = value
                OnPropertyChanged("ProductID")
            End If
        End Set
    End Property

    Private _productID As Integer

    <DataMember()>
    Public Property UnitPrice() As Decimal
        Get
            Return _unitPrice
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_unitPrice, value) Then
                _unitPrice = value
                OnPropertyChanged("UnitPrice")
            End If
        End Set
    End Property

    Private _unitPrice As Decimal

    <DataMember()>
    Public Property UnitPriceDiscount() As Decimal
        Get
            Return _unitPriceDiscount
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_unitPriceDiscount, value) Then
                _unitPriceDiscount = value
                OnPropertyChanged("UnitPriceDiscount")
            End If
        End Set
    End Property

    Private _unitPriceDiscount As Decimal

    <DataMember()>
    Public Property LineTotal() As Decimal
        Get
            Return _lineTotal
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_lineTotal, value) Then
                _lineTotal = value
                OnPropertyChanged("LineTotal")
            End If
        End Set
    End Property

    Private _lineTotal As Decimal

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
    Public Property Product() As Product
        Get
            Return _product
        End Get
        Set(ByVal value As Product)
            If _product IsNot value Then
                Dim previousValue As Product = _product
                _product = value
                FixupProduct(previousValue)
                OnNavigationPropertyChanged("Product")
            End If
        End Set
    End Property

    Private _product As Product


    <DataMember()>
    Public Property SalesOrderHeader() As SalesOrderHeader
        Get
            Return _salesOrderHeader
        End Get
        Set(ByVal value As SalesOrderHeader)
            If _salesOrderHeader IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' This the dependent end of an identifying relationship, so the principal end cannot be changed if it is already set,
                    ' otherwise it can only be set to an entity with a primary key that is the same value as the dependent's foreign key.
                    If Not Equals(SalesOrderID, value.SalesOrderID) Then
                        Throw New InvalidOperationException("The principal end of an identifying relationship can only be changed when the dependent end is in the Added state.")
                    End If
                End If
                Dim previousValue As SalesOrderHeader = _salesOrderHeader
                _salesOrderHeader = value
                FixupSalesOrderHeader(previousValue)
                OnNavigationPropertyChanged("SalesOrderHeader")
            End If
        End Set
    End Property

    Private _salesOrderHeader As SalesOrderHeader


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

    ' This entity type is the dependent end in at least one association that performs cascade deletes.
    ' This event handler will process notifications that occur when the principal end is deleted.
    Friend Sub HandleCascadeDelete(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.MarkAsDeleted()
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
        Product = Nothing
        SalesOrderHeader = Nothing
    End Sub

#End Region
#Region "Association Fixup"

    Private Sub FixupProduct(ByVal previousValue As Product)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.SalesOrderDetails.Contains(Me) Then
            previousValue.SalesOrderDetails.Remove(Me)
        End If

        If Product IsNot Nothing Then
            If Not Product.SalesOrderDetails.Contains(Me) Then
                Product.SalesOrderDetails.Add(Me)
            End If

            ProductID = Product.ProductID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Product") AndAlso
                ChangeTracker.OriginalValues("Product") Is Product Then
                ChangeTracker.OriginalValues.Remove("Product")
            Else
                ChangeTracker.RecordOriginalValue("Product", previousValue)
            End If
            If Product IsNot Nothing AndAlso Not Product.ChangeTracker.ChangeTrackingEnabled Then
                Product.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupSalesOrderHeader(ByVal previousValue As SalesOrderHeader)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.SalesOrderDetails.Contains(Me) Then
            previousValue.SalesOrderDetails.Remove(Me)
        End If

        If SalesOrderHeader IsNot Nothing Then
            If Not SalesOrderHeader.SalesOrderDetails.Contains(Me) Then
                SalesOrderHeader.SalesOrderDetails.Add(Me)
            End If

            SalesOrderID = SalesOrderHeader.SalesOrderID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("SalesOrderHeader") AndAlso
                ChangeTracker.OriginalValues("SalesOrderHeader") Is SalesOrderHeader Then
                ChangeTracker.OriginalValues.Remove("SalesOrderHeader")
            Else
                ChangeTracker.RecordOriginalValue("SalesOrderHeader", previousValue)
            End If
            If SalesOrderHeader IsNot Nothing AndAlso Not SalesOrderHeader.ChangeTracker.ChangeTrackingEnabled Then
                SalesOrderHeader.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
