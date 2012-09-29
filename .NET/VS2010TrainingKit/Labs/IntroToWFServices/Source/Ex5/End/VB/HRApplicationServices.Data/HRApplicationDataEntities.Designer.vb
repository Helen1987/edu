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

<Assembly: EdmSchemaAttribute("44fb847d-8ace-461d-9ea9-98f6a8af33ec")>

#Region "Contexts"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
Public Partial Class HRApplicationDataEntities
    Inherits ObjectContext

    #Region "Constructors"

    ''' <summary>
    ''' Initializes a new HRApplicationDataEntities object using the connection string found in the 'HRApplicationDataEntities' section of the application configuration file.
    ''' </summary>
    Public Sub New()
        MyBase.New("name=HRApplicationDataEntities", "HRApplicationDataEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new HRApplicationDataEntities object.
    ''' </summary>
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString, "HRApplicationDataEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new HRApplicationDataEntities object.
    ''' </summary>
    Public Sub New(ByVal connection As EntityConnection)
        MyBase.New(connection, "HRApplicationDataEntities")
    MyBase.ContextOptions.LazyLoadingEnabled = true
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
    Public ReadOnly Property Applicants() As ObjectSet(Of Applicant)
        Get
            If (_Applicants Is Nothing) Then
                _Applicants = MyBase.CreateObjectSet(Of Applicant)("Applicants")
            End If
            Return _Applicants
        End Get
    End Property

    Private _Applicants As ObjectSet(Of Applicant)

    #End Region
    #Region "AddTo Methods"

    ''' <summary>
    ''' Deprecated Method for adding a new object to the Applicants EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
    ''' </summary>
    Public Sub AddToApplicants(ByVal applicant As Applicant)
        MyBase.AddObject("Applicants", applicant)
    End Sub

    #End Region
End Class

#End Region
#Region "Entities"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
<EdmEntityTypeAttribute(NamespaceName:="HRApplicationDataModel", Name:="Applicant")>
<Serializable()>
<DataContractAttribute(IsReference:=True)>
Public Partial Class Applicant
    Inherits EntityObject
    #Region "Factory Method"

    ''' <summary>
    ''' Create a new Applicant object.
    ''' </summary>
    ''' <param name="applicationID">Initial value of the ApplicationID property.</param>
    ''' <param name="requestID">Initial value of the RequestID property.</param>
    ''' <param name="applicantName">Initial value of the ApplicantName property.</param>
    ''' <param name="education">Initial value of the Education property.</param>
    ''' <param name="numberOfReferences">Initial value of the NumberOfReferences property.</param>
    Public Shared Function CreateApplicant(applicationID As Global.System.Int32, requestID As Global.System.Guid, applicantName As Global.System.String, education As Global.System.String, numberOfReferences As Global.System.Int32) As Applicant
        Dim applicant as Applicant = New Applicant
        applicant.ApplicationID = applicationID
        applicant.RequestID = requestID
        applicant.ApplicantName = applicantName
        applicant.Education = education
        applicant.NumberOfReferences = numberOfReferences
        Return applicant
    End Function

    #End Region
    #Region "Primitive Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property ApplicationID() As Global.System.Int32
        Get
            Return _ApplicationID
        End Get
        Set
            If (_ApplicationID <> Value) Then
                OnApplicationIDChanging(value)
                ReportPropertyChanging("ApplicationID")
                _ApplicationID = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("ApplicationID")
                OnApplicationIDChanged()
            End If
        End Set
    End Property

    Private _ApplicationID As Global.System.Int32
    Private Partial Sub OnApplicationIDChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnApplicationIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property RequestID() As Global.System.Guid
        Get
            Return _RequestID
        End Get
        Set
            OnRequestIDChanging(value)
            ReportPropertyChanging("RequestID")
            _RequestID = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("RequestID")
            OnRequestIDChanged()
        End Set
    End Property

    Private _RequestID As Global.System.Guid
    Private Partial Sub OnRequestIDChanging(value As Global.System.Guid)
    End Sub

    Private Partial Sub OnRequestIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property ApplicantName() As Global.System.String
        Get
            Return _ApplicantName
        End Get
        Set
            OnApplicantNameChanging(value)
            ReportPropertyChanging("ApplicantName")
            _ApplicantName = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("ApplicantName")
            OnApplicantNameChanged()
        End Set
    End Property

    Private _ApplicantName As Global.System.String
    Private Partial Sub OnApplicantNameChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnApplicantNameChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Education() As Global.System.String
        Get
            Return _Education
        End Get
        Set
            OnEducationChanging(value)
            ReportPropertyChanging("Education")
            _Education = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("Education")
            OnEducationChanged()
        End Set
    End Property

    Private _Education As Global.System.String
    Private Partial Sub OnEducationChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnEducationChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property NumberOfReferences() As Global.System.Int32
        Get
            Return _NumberOfReferences
        End Get
        Set
            OnNumberOfReferencesChanging(value)
            ReportPropertyChanging("NumberOfReferences")
            _NumberOfReferences = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("NumberOfReferences")
            OnNumberOfReferencesChanged()
        End Set
    End Property

    Private _NumberOfReferences As Global.System.Int32
    Private Partial Sub OnNumberOfReferencesChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnNumberOfReferencesChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=true)>
    <DataMemberAttribute()>
    Public Property HireApproved() As Nullable(Of Global.System.Boolean)
        Get
            Return _HireApproved
        End Get
        Set
            OnHireApprovedChanging(value)
            ReportPropertyChanging("HireApproved")
            _HireApproved = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("HireApproved")
            OnHireApprovedChanged()
        End Set
    End Property

    Private _HireApproved As Nullable(Of Global.System.Boolean)
    Private Partial Sub OnHireApprovedChanging(value As Nullable(Of Global.System.Boolean))
    End Sub

    Private Partial Sub OnHireApprovedChanged()
    End Sub

    #End Region
End Class

#End Region

