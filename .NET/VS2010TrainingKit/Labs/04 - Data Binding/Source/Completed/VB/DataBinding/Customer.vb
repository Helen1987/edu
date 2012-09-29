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

Namespace DataBinding
	Public Class Customer
		Implements INotifyPropertyChanged
		Private _Name As String
		Private _City As String
		Private _State As String
		Private _ImageUrl As String
		Private _IsGold As Boolean
		Private _Birthday As Date

		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
                If _Name IsNot value Then
                    _Name = value
                    OnPropertyChanged("Name")
                End If
			End Set
		End Property

		Public Property IsGold() As Boolean
			Get
				Return _IsGold
			End Get

			Set(ByVal value As Boolean)
                If _IsGold <> value Then
                    _IsGold = value
                    OnPropertyChanged("IsGold")
                End If
			End Set
		End Property

		Public Property Birthday() As Date
			Get
				Return _Birthday
			End Get

			Set(ByVal value As Date)
                If _Birthday <> value Then
                    _Birthday = value
                    OnPropertyChanged("Birthday")
                End If
			End Set
		End Property

		Public Property City() As String
			Get
				Return _City
			End Get
			Set(ByVal value As String)
				If _City <> value Then
					_City = value
					OnPropertyChanged("City")
				End If
			End Set
		End Property
		Public Property State() As String
			Get
				Return _State
			End Get
			Set(ByVal value As String)
				If _State <> value Then
					_State = value
					OnPropertyChanged("State")
				End If
			End Set
		End Property

		Public Property ImageUrl() As String
			Get
				Return _ImageUrl
			End Get
			Set(ByVal value As String)
				If _ImageUrl <> value Then
					_ImageUrl = value
					OnPropertyChanged("ImageUrl")
				End If
			End Set
		End Property

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Protected Sub OnPropertyChanged(ByVal propName As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
		End Sub
	End Class
End Namespace
