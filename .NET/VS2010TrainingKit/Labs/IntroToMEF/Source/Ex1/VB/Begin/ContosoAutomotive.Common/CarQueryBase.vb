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

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq


Public MustInherit Class CarQueryBase
    Implements ICarQuery, INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private _name As String
    Public Property Name As String
        Get
            Return Me._name
        End Get
        Set(ByVal value As String)
            Me._name = value
            Me.NotifyPropertyChanged("Name")
        End Set
    End Property

    Private _description As String
    Public Property Description As String
        Get
            Return Me._description
        End Get
        Set(ByVal value As String)
            Me._description = value
            Me.NotifyPropertyChanged("Description")
        End Set
    End Property

    Private _imagePath As String
    Public Property ImagePath As String
        Get
            Return Me._imagePath
        End Get
        Set(ByVal value As String)
            Me._imagePath = value
            Me.NotifyPropertyChanged("ImagePath")
        End Set
    End Property

    Private _results As List(Of Car)
    Public Property Results As List(Of Car) Implements ICarQuery.Results
        Get
            Return Me._results
        End Get
        Set(ByVal value As List(Of Car))
            Me._results = value
            Me.ResultsCount = Me._results.Count()
            Me.NotifyPropertyChanged("Results")
        End Set
    End Property

    Private _resultsCount As Integer
    Public Property ResultsCount As Integer Implements ICarQuery.ResultsCount
        Get
            Return Me._resultsCount
        End Get
        Set(ByVal value As Integer)
            Me._resultsCount = value
            Me.NotifyPropertyChanged("ResultsCount")
        End Set
    End Property

    Private Sub NotifyPropertyChanged(ByVal name As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
    End Sub

    Public Sub Run(ByVal cars As IEnumerable(Of Car), ByVal longRunning As Boolean) Implements ICarQuery.Run
        If longRunning Then
            System.Threading.Thread.SpinWait(80000000)
        End If

        Me.Results = RunQuery(cars).ToList()
    End Sub

    Protected MustOverride Function RunQuery(ByVal cars As IEnumerable(Of Car)) As IEnumerable(Of Car)
End Class