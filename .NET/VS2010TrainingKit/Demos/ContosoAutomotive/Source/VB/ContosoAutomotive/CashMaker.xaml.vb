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
Imports System.Collections.ObjectModel
Imports System.ComponentModel.Composition
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows
Imports ContosoAutomotive.Common

<Export()>
Class CashMaker
    Inherits Window

    Dim numberOfCarsToGenerate As Integer = 2000000

    Dim cars As List(Of Car) = New List(Of Car)()
    Dim stopwatch As Stopwatch = New Stopwatch()
    Dim searchOperation As CancellationTokenSource = New CancellationTokenSource()

    <ImportMany(GetType(ICarQuery), AllowRecomposition:=True)>
    Public Property CarQueries() As ObservableCollection(Of ICarQuery)

    Public Sub New()
        Me.InitializeComponent()

        Me.CarQueries = New ObservableCollection(Of ICarQuery)()
        Me.commandGrid.DataContext = Me.CarQueries

        Task.Factory.StartNew(AddressOf Me.GenerateCars)
    End Sub

    Private Sub searchButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.searchOperation = New CancellationTokenSource()
        Me.RunQueries()
    End Sub

    Private Sub parallelSearchButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.searchOperation = New CancellationTokenSource()
        Me.RunQueriesInParallel()
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        Me.searchOperation.Cancel()
    End Sub

    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Do something more interesting in the future
        MessageBox.Show("Buying Cars. We're going to be RICH")
    End Sub

    Private Sub RunQueries()
        Me.DisableSearch()
        Task.Factory.StartNew(Sub()
                                  Me.BeginTiming()
                                  For Each query In Me.CarQueries
                                      If Me.searchOperation.Token.IsCancellationRequested Then
                                          Return
                                      End If

                                      query.Run(Me.cars, True)
                                  Next
                                  Me.EndSequentialTiming()
                              End Sub, Me.searchOperation.Token).ContinueWith(AddressOf Me.EnableSearch)
    End Sub

    Private Sub RunQueriesInParallel()
        Me.DisableSearch()
        Task.Factory.StartNew(Sub()
                                  Try
                                      Me.BeginTiming()
                                      Dim options = New ParallelOptions() With {.CancellationToken = Me.searchOperation.Token}
                                      Parallel.ForEach(Me.CarQueries, options, Sub(query) query.Run(Me.cars, True))
                                      Me.EndParallelTiming()
                                  Catch e1 As OperationCanceledException
                                  End Try
                              End Sub, Me.searchOperation.Token).ContinueWith(AddressOf Me.EnableSearch)
    End Sub

    Private Sub CalculateImprovement()
        If Me.runtimeLabel.Content IsNot Nothing AndAlso Me.parallelRuntimeLabel.Content IsNot Nothing Then
            Dim improvement As Double = (CDbl(Me.runtimeLabel.Content)) / (CDbl(Me.parallelRuntimeLabel.Content))
            Me.runtimeImprovementLabel.Content = String.Format("{0}x", Math.Round(improvement, 2))
        End If
    End Sub

    Private Sub GenerateCars()
        Dim generator = New CarGenerator()

        For i As Integer = 0 To Me.numberOfCarsToGenerate - 1
            Me.cars.Add(generator.Generate())

            If i Mod 10000 = 0 Then
                Dim progress As Integer = CInt(Fix(CDbl(i) / 2000000 * 100))
                Dispatcher.Invoke(New Action(Sub() Me.progressBar.Value = progress))
            End If

            If i Mod 200000 = 0 Then
                Dim currentCars = Me.cars.ToArray()
                Task.Factory.StartNew(Sub()
                                          Parallel.ForEach(Me.CarQueries, Sub(query) query.Run(currentCars, False))
                                      End Sub)
            End If
        Next i

        Me.EnableSearch()
        Dispatcher.Invoke(New Action(Sub() Me.progressBar.Visibility = Visibility.Collapsed))
    End Sub

    Private Sub BeginTiming()
        Me.stopwatch.Reset()
        Me.stopwatch.Start()
    End Sub

    Private Sub EndSequentialTiming()
        Me.stopwatch.Stop()

        Dispatcher.Invoke(New Action(Sub()
                                         Me.runtimeLabel.Content = Math.Round(Me.stopwatch.Elapsed.TotalSeconds, 4)
                                         Me.CalculateImprovement()
                                     End Sub))
    End Sub

    Private Sub EndParallelTiming()
        Me.stopwatch.Stop()

        Dispatcher.Invoke(New Action(Sub()
                                         Me.parallelRuntimeLabel.Content = Math.Round(Me.stopwatch.Elapsed.TotalSeconds, 4)
                                         Me.CalculateImprovement()
                                     End Sub))
    End Sub

    Private Sub DisableSearch()
        Dispatcher.Invoke(New Action(Sub()
                                         Me.searchButton.Opacity = 0.25
                                         Me.searchButton.IsEnabled = False
                                         Me.parallelSearchButton.Opacity = 0.25
                                         Me.parallelSearchButton.IsEnabled = False
                                         Me.cancelButton.Opacity = 1
                                         Me.cancelButton.IsEnabled = True
                                     End Sub))
    End Sub

    Private Sub EnableSearch()
        Dispatcher.Invoke(New Action(Sub()
                                         Me.searchButton.Opacity = 1
                                         Me.searchButton.IsEnabled = True
                                         Me.parallelSearchButton.Opacity = 1
                                         Me.parallelSearchButton.IsEnabled = True
                                         Me.cancelButton.Opacity = 0.25
                                         Me.cancelButton.IsEnabled = False
                                     End Sub))
    End Sub
End Class
