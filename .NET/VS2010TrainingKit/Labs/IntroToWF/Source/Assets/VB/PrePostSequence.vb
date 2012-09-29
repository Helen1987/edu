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
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows.Markup


''' <summary>
''' An activity that executes child activities in order and supports a pre/post activity
''' </summary>
<ContentProperty("Activities")>
Public NotInheritable Class PrePostSequence
    Inherits NativeActivity
#Region "Private Members"

    Private m_activities As Collection(Of Activity)
    Private m_variables As Collection(Of Variable)

    Private preCompleted As New Variable(Of Boolean)()
    Private bodyCompleted As New Variable(Of Boolean)()
    Private lastIndexHint As New Variable(Of Integer)()

    Private m_onChildCompleted As CompletionCallback
    Private m_onPreCompleted As CompletionCallback

#End Region

    ''' <summary>
    ''' Contains the variables scoped to this activity
    ''' </summary>
    Public ReadOnly Property Variables() As Collection(Of Variable)
        Get
            If m_variables Is Nothing Then
                m_variables = New Collection(Of Variable)()
            End If
            Return m_variables
        End Get
    End Property

    ''' <summary>
    ''' The Pre-Sequence activity
    ''' </summary>
    ''' <remarks>
    ''' Use the DependsOn to control the order of serialization in XAML
    ''' This will come after the variables
    ''' </remarks>
    Private _Pre As Activity
    <DependsOn("Variables")> _
    Public Property Pre() As Activity
        Get
            Return _Pre
        End Get
        Set(ByVal value As Activity)
            _Pre = value
        End Set
    End Property

    ''' <summary>
    ''' The Activities in the body of the sequence
    ''' </summary>
    ''' <remarks>
    ''' Use the DependsOn to control the order of serialization in XAML
    ''' This will come after Pre activity
    ''' </remarks>
    <DependsOn("Pre")> _
    Public ReadOnly Property Activities() As Collection(Of Activity)
        Get
            If m_activities Is Nothing Then
                m_activities = New Collection(Of Activity)()
            End If
            Return m_activities
        End Get
    End Property

    ''' <summary>
    ''' The Post-Sequence Activity
    ''' </summary>
    ''' <remarks>
    ''' Use the DependsOn to control the order of serialization in XAML
    ''' This will come after the Activities
    ''' </remarks>
    Private _Post As Activity
    <DependsOn("Activities")> _
    Public Property Post() As Activity
        Get
            Return _Post
        End Get
        Set(ByVal value As Activity)
            _Post = value
        End Set
    End Property

    ''' <summary>
    ''' The callback for when the Pre activity is completed
    ''' </summary>
    Private ReadOnly Property OnPreCompletedCallback() As CompletionCallback
        Get
            If m_onPreCompleted Is Nothing Then
                m_onPreCompleted = New CompletionCallback(AddressOf OnPreCompleted)
            End If
            Return m_onPreCompleted
        End Get
    End Property

    ''' <summary>
    ''' The callback for when child activities are completed
    ''' </summary>
    ''' <remarks>
    ''' Creating and caching the callback using this pattern
    ''' results in improved performance because the callback
    ''' is created only once even though there may be 
    ''' many child activities
    ''' </remarks>
    Private ReadOnly Property OnChildCompletedCallback() As CompletionCallback
        Get
            If m_onChildCompleted Is Nothing Then
                m_onChildCompleted = New CompletionCallback(AddressOf OnChildCompleted)
            End If
            Return m_onChildCompleted
        End Get
    End Property

    ''' <summary>
    ''' Informs the runtime about our activity and the data
    ''' </summary>
    ''' <param name="metadata">The metadata</param>
    ''' <remarks>
    ''' The base class implementation
    ''' will discover variables and child activities using reflection. By overriding 
    ''' CacheMetadata we avoid this and get improved performance.
    ''' </remarks>
    Protected Overloads Overrides Sub CacheMetadata(ByVal metadata As NativeActivityMetadata)
        '' implementation variables are variables that are 
        '' private to our workflow.
        metadata.AddImplementationVariable(lastIndexHint)
        metadata.AddImplementationVariable(preCompleted)
        metadata.AddImplementationVariable(bodyCompleted)

        metadata.SetVariablesCollection(Variables)

        metadata.AddChild(Pre)
        metadata.AddChild(Post)

        ' Cannot use metadata.SetActivitiesCollection because of Pre/Post
        For Each activity As Activity In Activities
            metadata.AddChild(activity)
        Next
    End Sub

    ''' <summary>
    ''' Implementation of the activity
    ''' </summary>
    ''' <param name="context">The context used to schedule</param>
    Protected Overloads Overrides Sub Execute(ByVal context As NativeActivityContext)
        ScheduleChildActivities(context)
    End Sub

    ''' <summary>
    ''' Schedules the child activities
    ''' </summary>
    ''' <param name="context">The context used to schedule</param>
    ''' <remarks>
    ''' The PrePostSequence can have the following combinations
    ''' Pre Only
    ''' Post Only
    ''' Pre and Post with empty Activities collection
    ''' Pre and Post and Activities
    ''' </remarks>
    Private Sub ScheduleChildActivities(ByVal context As NativeActivityContext)
        If PreActivityExists() AndAlso PreHasNotCompleted(context) Then
            ' Schedule the Pre activity
            context.ScheduleActivity(Pre, OnPreCompletedCallback)
        ElseIf ActivitiesCollectionIsNotEmpty() AndAlso ActivitiesHaveNotCompleted(context) Then
            ' Schedule the first child
            ' the OnChildCompletedCallback will schedule
            ' the other child activities
            context.ScheduleActivity(Activities.First(), OnChildCompletedCallback)
        ElseIf PostIsNotEmpty() Then
            ' No CompletionCallback is required for Post because
            ' the activity is done when Post is completed
            context.ScheduleActivity(Post)
        End If
    End Sub

    ''' <summary>
    ''' Called when the Pre activity is completed
    ''' </summary>
    ''' <param name="context"></param>
    ''' <param name="completedInstance"></param>
    Private Sub OnPreCompleted(ByVal context As NativeActivityContext, ByVal completedInstance As ActivityInstance)
        preCompleted.[Set](context, True)
        ScheduleChildActivities(context)
    End Sub

    ''' <summary>
    ''' Called when one of the child activities is completed
    ''' </summary>
    ''' <param name="context"></param>
    ''' <param name="completedInstance"></param>
    Private Sub OnChildCompleted(ByVal context As NativeActivityContext, ByVal completedInstance As ActivityInstance)
        ' get the index of the completed activity and increment it
        Dim completedInstanceIndex As Integer = lastIndexHint.[Get](context)
        Dim nextChildIndex As Integer = completedInstanceIndex + 1

        ' if the sequence is not done, schedule the next child
        If nextChildIndex < Activities.Count Then
            lastIndexHint.[Set](context, nextChildIndex)
            Dim nextChild As Activity = Activities(nextChildIndex)
            context.ScheduleActivity(nextChild, OnChildCompletedCallback)
        Else
            ' Completed body
            bodyCompleted.[Set](context, True)
            ScheduleChildActivities(context)
        End If
    End Sub

    Private Function PostIsNotEmpty() As Boolean
        Return Post IsNot Nothing
    End Function

    Private Function ActivitiesHaveNotCompleted(ByVal context As NativeActivityContext) As Boolean
        Return bodyCompleted.[Get](context) = False
    End Function

    Private Function ActivitiesCollectionIsNotEmpty() As Boolean
        Return Activities.Count > 0
    End Function

    Private Function PreHasNotCompleted(ByVal context As NativeActivityContext) As Boolean
        Return preCompleted.[Get](context) = False
    End Function

    Private Function PreActivityExists() As Boolean
        Return Pre IsNot Nothing
    End Function
End Class
