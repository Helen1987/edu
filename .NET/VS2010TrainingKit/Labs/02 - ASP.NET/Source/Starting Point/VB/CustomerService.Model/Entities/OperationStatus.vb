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

Namespace CustomersService.Model.Entities
	<DebuggerDisplay("Status: {Status}")>
	Public Class OperationStatus
		Public Property Status() As Boolean
		Public Property RecordsAffected() As Integer
		Public Property Message() As String
		Public Property OperationID() As Object
		Public Property ExceptionMessage() As String
		Public Property ExceptionStackTrace() As String
		Public Property ExceptionInnerMessage() As String
		Public Property ExceptionInnerStackTrace() As String

		Public Shared Function CreateFromException(ByVal message As String, ByVal ex As Exception) As OperationStatus
			Dim opStatus As OperationStatus = New OperationStatus With {.Status = False, .Message = message, .OperationID = Nothing}

			If ex IsNot Nothing Then
				opStatus.ExceptionMessage = ex.Message
				opStatus.ExceptionStackTrace = ex.StackTrace
				opStatus.ExceptionInnerMessage = If(ex.InnerException Is Nothing, Nothing, ex.InnerException.Message)
				opStatus.ExceptionInnerStackTrace = If(ex.InnerException Is Nothing, Nothing, ex.InnerException.StackTrace)
			End If
			Return opStatus
		End Function
	End Class
End Namespace
