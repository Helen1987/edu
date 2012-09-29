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

Namespace BlendLab
    Public Class MainViewModel
        Implements INotifyPropertyChanged
        Public Sub New()
            ' Insert code required on object creation below this point.
        End Sub

        'INSTANT VB NOTE: The variable isMenuOpen was renamed since Visual Basic does not allow class members with the same name:
        Private isMenuOpen_Renamed As Boolean
        Public Property IsMenuOpen() As Boolean
            Get
                Return isMenuOpen_Renamed
            End Get
            Set(ByVal value As Boolean)
                isMenuOpen_Renamed = value
                NotifyPropertyChanged("IsMenuOpen")
            End Set
        End Property

        Public Sub OpenMenu()
            IsMenuOpen = True
        End Sub

        Public Sub CloseMenu()
            IsMenuOpen = False
        End Sub

#Region "INotifyPropertyChanged"
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub NotifyPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub
#End Region

    End Class
End Namespace