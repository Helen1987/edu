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

Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq.Expressions
Imports UsingWCFServices.Models

Namespace CustomersService.Repository
	Public Class RepositoryBase(Of C As {ObjectContext, New})
		Implements IDisposable
		Private _DataContext As C

		Public Overridable ReadOnly Property DataContext() As C
			Get
				If _DataContext Is Nothing Then
					_DataContext = New C()
				End If
				Return _DataContext
			End Get
		End Property

		Public Overridable Function [Get](Of T As Class)(ByVal predicate As Expression(Of Func(Of T, Boolean))) As T
			If predicate IsNot Nothing Then
				Using DataContext
					Return DataContext.CreateObjectSet(Of T)().Where(predicate).SingleOrDefault()
				End Using
			Else
				Throw New ApplicationException("Predicate value must be passed to Get<T>.")
			End If
		End Function

		Public Overridable Function GetList(Of T As Class)(ByVal predicate As Expression(Of Func(Of T, Boolean))) As IQueryable(Of T)
			Try
					Return DataContext.CreateObjectSet(Of T)().Where(predicate)
			Catch ex As Exception
				'Log error
			End Try
			Return Nothing
		End Function

		Public Overridable Function GetList(Of T As Class, TKey)(ByVal orderBy As Expression(Of Func(Of T, TKey))) As IQueryable(Of T)
			Try
				Return GetList(Of T)().OrderBy(orderBy)
			Catch ex As Exception
				'Log error
			End Try
			Return Nothing
		End Function

		Public Overridable Function GetList(Of T As Class)() As IQueryable(Of T)
			Try
				Return DataContext.CreateObjectSet(Of T)()
			Catch ex As Exception
				'Log error
			End Try
			Return Nothing
		End Function

		Public Overridable Function Update(Of T As Class)(ByVal entity As T, ParamArray ByVal propsToUpdate() As String) As OperationStatus
			Dim opStatus As OperationStatus = New OperationStatus With {.Status = True}

			Try
				DataContext.CreateObjectSet(Of T)().Attach(entity)
				Dim entry = DataContext.ObjectStateManager.GetObjectStateEntry(entity)
				For Each propName In propsToUpdate
					entry.SetModifiedProperty(propName)
				Next propName
				opStatus.Status = DataContext.SaveChanges() > 0
			Catch exp As Exception
                opStatus = OperationStatus.CreateFromException("Error updating " & GetType(T).ToString() & ".", exp)
			End Try

			Return opStatus
		End Function

		Public Function ExecuteStoreCommand(ByVal cmdText As String, ParamArray ByVal parameters() As Object) As OperationStatus
			Dim opStatus = New OperationStatus With {.Status = True}

			Try
				opStatus.RecordsAffected = DataContext.ExecuteStoreCommand(cmdText, parameters)
			Catch exp As Exception
				OperationStatus.CreateFromException("Error executing store command: ", exp)
			End Try
			Return opStatus
		End Function

		Public Sub Dispose() Implements IDisposable.Dispose
			If DataContext IsNot Nothing Then
				DataContext.Dispose()
			End If
		End Sub
	End Class
End Namespace