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

Imports System.ComponentModel
Imports System.Reflection

Namespace SilverlightWebBrowser.Data
	''' <summary>
	''' Provides an implementation of the INotifyPropertyChanged interface.
	''' </summary>
	Public MustInherit Class ObservableObject
		Implements INotifyPropertyChanged
		#Region "Events"

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		#End Region

		#Region "Methods"

		Protected Overridable Sub OnPropertyChanged(ParamArray ByVal properties() As String)
			If properties Is Nothing OrElse properties.Length = 0 Then
				Throw New ArgumentNullException("properties")
			End If

			For Each propertyName In properties
				VerifyProperty(propertyName)

                'Dim propertyChangedHandler As PropertyChangedEventHandler = PropertyChanged

                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))

                'If Not PropertyChanged Is Nothing Then
                '    RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
                'End If
			Next propertyName

		End Sub

		<Conditional("DEBUG")>
		Private Sub VerifyProperty(ByVal propertyName As String)
			Dim [property] As PropertyInfo = Me.GetType().GetProperty(propertyName)

			If [property] Is Nothing Then
				Dim message As String = String.Format("Invalid property: {0}", propertyName)
				Throw New Exception(message)
			End If
		End Sub

		#End Region
	End Class
End Namespace