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

Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports CalculatorClient.CalculatorServiceReference

	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			Dim r As New Random()
			textValue1.Text = (r.NextDouble() * 10).ToString()
			textValue2.Text = (r.NextDouble() * 10).ToString()
		End Sub

    Private Sub btnInvokeService_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        CalculateResults()
    End Sub

    Private Sub CalculateResults()
        Dim proxy As CalculatorServiceClient = Nothing
        Try
            Dim value1 As Double = Convert.ToDouble(textValue1.Text)
            Dim value2 As Double = Convert.ToDouble(textValue2.Text)

            Dim endpointName As String
            If ComboBoxServiceConnection.SelectedIndex = 0 Then
                endpointName = "CalculatorService"
            Else
                endpointName = "RouterService"
            End If
            proxy = New CalculatorServiceClient(endpointName)

            Using scope As New OperationContextScope(proxy.InnerChannel)
                Me.AddOptionalRoundingHeader(proxy)

                labelAddResult.Text = proxy.Add(value1, value2).ToString()
                labelSubResult.Text = proxy.Subtract(value1, value2).ToString()
                labelMultResult.Text = proxy.Multiply(value1, value2).ToString()

                If value2 <> 0.0 Then
                    labelDivResult.Text = proxy.Divide(value1, value2).ToString()
                Else
                    labelDivResult.Text = "Divide by 0"
                End If
            End Using

        Catch e1 As FormatException
            MessageBox.Show("Invalid numeric value, cannot calculate", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        Catch e2 As TimeoutException
            If proxy IsNot Nothing Then
                proxy.Abort()
            End If
            MessageBox.Show("Timeout - cannot connect to service", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        Catch e3 As CommunicationException
            If proxy IsNot Nothing Then
                proxy.Abort()
            End If
            MessageBox.Show("Unable to communicate with the service", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
        Finally
            If proxy IsNot Nothing Then
                proxy.Close()
            End If
        End Try
    End Sub

    Private Sub AddOptionalRoundingHeader(ByVal proxy As CalculatorServiceClient)
        ' TODO: Implement this method
    End Sub
End Class