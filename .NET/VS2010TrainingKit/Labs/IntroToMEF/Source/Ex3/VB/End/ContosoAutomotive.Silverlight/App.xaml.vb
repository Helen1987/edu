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

Imports System.ComponentModel.Composition.Hosting

Partial Public Class App
    Inherits Application

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Application_Startup(ByVal o As Object, ByVal e As StartupEventArgs) Handles Me.Startup
        Dim xapCatalog = New DeploymentCatalog("/ClientBin/ContosoAutomotive.Woodgrove.SL.xap")
        AddHandler xapCatalog.DownloadCompleted, AddressOf xapCatalog_DownloadCompleted
        xapCatalog.DownloadAsync()
        Dim catalog = New AggregateCatalog(New DeploymentCatalog(), xapCatalog)
        Dim container = New CompositionContainer(catalog)

        Me.RootVisual = container.GetExportedValue(Of CashMaker)()
    End Sub

    Private Sub xapCatalog_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        System.Threading.Thread.Sleep(2000)
    End Sub

    Private Sub Application_Exit(ByVal o As Object, ByVal e As EventArgs) Handles Me.Exit

    End Sub

    Private Sub Application_UnhandledException(ByVal sender As Object, ByVal e As ApplicationUnhandledExceptionEventArgs) Handles Me.UnhandledException

        ' If the app is running outside of the debugger then report the exception using
        ' the browser's exception mechanism. On IE this will display it a yellow alert 
        ' icon in the status bar and Firefox will display a script error.
        If Not System.Diagnostics.Debugger.IsAttached Then

            ' NOTE: This will allow the application to continue running after an exception has been thrown
            ' but not handled. 
            ' For production applications this error handling should be replaced with something that will 
            ' report the error to the website and stop the application.
            e.Handled = True
            Deployment.Current.Dispatcher.BeginInvoke(New Action(Of ApplicationUnhandledExceptionEventArgs)(AddressOf ReportErrorToDOM), e)
        End If
    End Sub

    Private Sub ReportErrorToDOM(ByVal e As ApplicationUnhandledExceptionEventArgs)

        Try
            Dim errorMsg As String = e.ExceptionObject.Message + e.ExceptionObject.StackTrace
            errorMsg = errorMsg.Replace(""""c, "'"c).Replace(ChrW(13) & ChrW(10), "\n")

            System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(""Unhandled Error in Silverlight Application " + errorMsg + """);")
        Catch

        End Try
    End Sub

End Class
