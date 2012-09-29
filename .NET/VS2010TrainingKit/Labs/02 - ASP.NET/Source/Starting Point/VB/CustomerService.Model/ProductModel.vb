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
<KnownType(GetType(Product))>
<KnownType(GetType(ProductModelProductDescription))>
Partial Public Class ProductModel
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Primitive Properties"

    <DataMember()>
    Public Property ProductModelID() As Integer
        Get
            Return _productModelID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_productModelID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("The property 'ProductModelID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.")
                End If
                _productModelID = value
                OnPropertyChanged("ProductModelID")
            End If
        End Set
    End Property

    Private _productModelID As Integer

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
    Public Property CatalogDescription() As String
        Get
            Return _catalogDescription
        End Get
        Set(ByVal value As String)
            If Not Equals(_catalogDescription, value) Then
                _catalogDescription = value
                OnPropertyChanged("CatalogDescription")
            End If
        End Set
    End Property

    Private _catalogDescription As String

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
    Public Property Products() As TrackableCollection(Of Product)
        Get
            If _products Is Nothing Then
                _products = New TrackableCollection(Of Product)
                AddHandler _products.CollectionChanged, AddressOf FixupProducts
            End If
            Return _products
        End Get
        Set(ByVal value As TrackableCollection(Of Product))
            If Not Object.ReferenceEquals(_products, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled")
                End If
                If _products IsNot Nothing Then
                    RemoveHandler _products.CollectionChanged, AddressOf FixupProducts
                End If
                _products = value
                If _products IsNot Nothing Then
                    AddHandler _products.CollectionChanged, AddressOf FixupProducts
                End If
                OnNavigationPropertyChanged("Products")
            End If
        End Set
    End Property

    Private _products As TrackableCollection(Of Product)

    <DataMember()>
    Public Property ProductModelProductDescriptions() As TrackableCollection(Of ProductModelProductDescription)
        Get
            If _productModelProductDescriptions Is Nothing Then
                _productModelProductDescriptions = New TrackableCollection(Of ProductModelProductDescription)
                AddHandler _productModelProductDescriptions.CollectionChanged, AddressOf FixupProductModelProductDescriptions
            End If
            Return _productModelProductDescriptions
        End Get
        Set(ByVal value As TrackableCollection(Of ProductModelProductDescription))
            If Not Object.ReferenceEquals(_productModelProductDescriptions, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled")
                End If
                If _productModelProductDescriptions IsNot Nothing Then
                    RemoveHandler _productModelProductDescriptions.CollectionChanged, AddressOf FixupProductModelProductDescriptions
                    ' This is the principal end in an association that performs cascade deletes.
                    ' Remove the cascade delete event handler for any entities in the current collection.
                    For Each item As ProductModelProductDescription In _productModelProductDescriptions
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _productModelProductDescriptions = value
                If _productModelProductDescriptions IsNot Nothing Then
                    AddHandler _productModelProductDescriptions.CollectionChanged, AddressOf FixupProductModelProductDescriptions
                    ' This is the principal end in an association that performs cascade deletes.
                    ' Add the cascade delete event handler for any entities that are already in the new collection.
                    For Each item As ProductModelProductDescription In _productModelProductDescriptions
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("ProductModelProductDescriptions")
            End If
        End Set
    End Property

    Private _productModelProductDescriptions As TrackableCollection(Of ProductModelProductDescription)

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
        Products.Clear()
        ProductModelProductDescriptions.Clear()
    End Sub

#End Region
#Region "Association Fixup"

    Private Sub FixupProducts(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Product In e.NewItems
                item.ProductModel = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Products", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Product In e.OldItems
                If ReferenceEquals(item.ProductModel, Me) Then
                    item.ProductModel = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Products", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupProductModelProductDescriptions(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ProductModelProductDescription In e.NewItems
                item.ProductModel = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ProductModelProductDescriptions", item)
                End If
                ' This is the principal end in an association that performs cascade deletes.
                ' Update the event listener to refer to the new dependent.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ProductModelProductDescription In e.OldItems
                If ReferenceEquals(item.ProductModel, Me) Then
                    item.ProductModel = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ProductModelProductDescriptions", item)
                    ' Delete the dependent end of this identifying association. If the current state is Added,
                    ' allow the relationship to be changed without causing the dependent to be deleted.
                    If item.ChangeTracker.State <> ObjectState.Added Then
                        item.MarkAsDeleted()
                    End If
                End If
                ' This is the principal end in an association that performs cascade deletes.
                ' Remove the previous dependent from the event listener.
                RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If
    End Sub

#End Region
End Class
