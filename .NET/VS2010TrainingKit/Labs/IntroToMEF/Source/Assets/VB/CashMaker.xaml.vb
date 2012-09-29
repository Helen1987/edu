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

Imports System.Collections.ObjectModel
Imports System.Threading
Imports ContosoAutomotive.Common
Imports System.ComponentModel.Composition

Partial Public Class CashMaker
    Inherits UserControl
    Implements IPartImportsSatisfiedNotification

    Private numberOfCarsToGenerate As Integer = 200000

    Private cars As List(Of Car) = New List(Of Car)()

    Private SearchEnabled As Boolean = False

    Public Sub New()
        InitializeComponent()
        Dim thread = New Thread(Sub() Me.GenerateCars())
        thread.Start()
    End Sub

    Private Sub GenerateCars()
        Dim generator = New CarGenerator()

        For i As Integer = 0 To Me.numberOfCarsToGenerate - 1
            Me.cars.Add(generator.Generate())

            If i Mod 10000 = 0 Then
                Dim progress As Integer = CInt(Fix(CDbl(i) / 2000000 * 100))
                Dispatcher.BeginInvoke(Sub() Me.progressBar.Value = progress)
            End If
        Next i

        Me.EnableSearch()
        Dispatcher.BeginInvoke(Sub() Me.progressBar.Visibility = Visibility.Collapsed)
    End Sub

    Private Sub DisableSearch()
        Me.SearchEnabled = False
    End Sub

    Private Sub EnableSearch()
        Me.SearchEnabled = True
    End Sub

    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Do something more interesting in the future
        MessageBox.Show("Buying Cars. We're going to be RICH")
    End Sub

    Private Sub commandList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs)
        If (Me.SearchEnabled) Then
            Me.DisableSearch()
            Dim thread = New Thread(Sub()
                                        If (e.AddedItems.Count > 0) Then
                                            Dim query = TryCast(e.AddedItems(0), Lazy(Of ICarQuery, IQueryMetadata))

                                            If (query IsNot Nothing) Then
                                                query.Value.Run(Me.cars, True)
                                            End If

                                            Dispatcher.BeginInvoke(Sub() Me.Results.ItemsSource = query.Value.Results)
                                        End If

                                        Me.EnableSearch()
                                    End Sub)

            thread.Start()
            thread.Join()
        End If
    End Sub

    Public Sub OnImportsSatisfied() Implements IPartImportsSatisfiedNotification.OnImportsSatisfied
        ' bind Car Queries
    End Sub
End Class
