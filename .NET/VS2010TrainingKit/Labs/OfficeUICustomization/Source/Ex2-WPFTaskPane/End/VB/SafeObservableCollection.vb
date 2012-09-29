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
Imports System.Collections.Specialized
Imports System.Windows.Threading

Public Class SafeObservableCollection(Of T)
    Inherits ObservableCollection(Of T)

    Public Shadows Event CollectionChanged As NotifyCollectionChangedEventHandler

    Protected Overrides Sub OnCollectionChanged(ByVal e As NotifyCollectionChangedEventArgs)
        If CollectionChangedEvent IsNot Nothing Then
            Dim dispatcherObject = CollectionChangedEvent.GetInvocationList() _
                        .Select(Function(n) n.Target).OfType(Of DispatcherObject)().FirstOrDefault()

            If dispatcherObject.Dispatcher IsNot Nothing AndAlso dispatcherObject.Dispatcher.CheckAccess() = False Then
                dispatcherObject.Dispatcher.Invoke(DispatcherPriority.DataBind, CType(Sub() OnCollectionChanged(e), System.Action))
            Else
                RaiseEvent CollectionChanged(Me, e)
            End If
        End If
    End Sub
End Class
