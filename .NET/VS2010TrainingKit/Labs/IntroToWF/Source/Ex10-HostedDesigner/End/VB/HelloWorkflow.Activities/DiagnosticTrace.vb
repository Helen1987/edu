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

Imports System.Activities
Imports System.Activities.Tracking
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows.Markup

<Designer(GetType(DiagnosticTraceDesigner))>
Public NotInheritable Class DiagnosticTrace
    Inherits CodeActivity
    Const DefaultRecordName As String = "Diagnostic Trace"

    Public Sub New()
        Level = TraceLevel.Off
        Category = DefaultRecordName
    End Sub

    ''' <summary>
    ''' The Text to display in the trace
    ''' </summary>
    ''' <remarks>
    ''' The Text property is an InArgument because we want to 
    ''' allow it to evaluate the content of trace data at runtime
    ''' The category and level are Design time properties - they cannot
    ''' be changed at runtime/>
    ''' </remarks>
    <DefaultValue(CStr(Nothing))>
    Public Property Text() As InArgument(Of String)
        Get
            Return mText
        End Get
        Set(ByVal value As InArgument(Of String))
            mText = value
        End Set
    End Property
    Private mText As InArgument(Of String)

    ''' <summary>
    ''' The category of the trace
    ''' </summary>
    ''' <remarks>
    ''' The category name is also used as the record name for 
    ''' the CustomTrackingRecord
    ''' </remarks>
    <DependsOn("Text")>
    <DefaultValue(CStr(Nothing))>
    Public Property Category() As String
        Get
            Return mCategory
        End Get
        Set(ByVal value As String)
            mCategory = value
        End Set
    End Property
    Private mCategory As String

    ''' <summary>
    ''' The trace level for this message
    ''' </summary>
    <DependsOn("Category")>
    <DefaultValue("Off")>
    Public Property Level() As TraceLevel
        Get
            Return mLevel
        End Get
        Set(ByVal value As TraceLevel)
            mLevel = value
        End Set
    End Property
    Private mLevel As TraceLevel

    Protected Overrides Sub Execute(ByVal context As CodeActivityContext)
        Dim text As String = context.GetValue(Me.Text)

        Select Case Level
            Case System.Diagnostics.TraceLevel.[Error]
                Trace.TraceError(text)
                Exit Select
            Case System.Diagnostics.TraceLevel.Info
                Trace.TraceInformation(text)
                Exit Select
            Case System.Diagnostics.TraceLevel.Verbose
                Trace.WriteLine(text, Category)
                Exit Select
            Case System.Diagnostics.TraceLevel.Warning
                Trace.TraceWarning(text)
                Exit Select
        End Select

        If Level <> System.Diagnostics.TraceLevel.Off Then
            Dim trackRecord = New CustomTrackingRecord(Category, Level)
            trackRecord.Data.Add("Text", text)
            trackRecord.Data.Add("Category", Category)

            context.Track(trackRecord)
        End If
    End Sub

    Protected Overrides Sub CacheMetadata(ByVal metadata As CodeActivityMetadata)
        Dim textArg = New RuntimeArgument("Text", GetType(String), ArgumentDirection.[In], True)
        metadata.AddArgument(textArg)

        If String.IsNullOrEmpty(Category) Then
            metadata.AddValidationError("Category must not be empty")
        End If
    End Sub
End Class
