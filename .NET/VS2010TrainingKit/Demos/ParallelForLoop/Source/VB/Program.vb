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

Imports Microsoft.VisualBasic
Imports System
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Diagnostics


Namespace ParallelDemo
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Console.WriteLine("MTID={0}", Thread.CurrentThread.ManagedThreadId)

            Dim sw As Stopwatch = Stopwatch.StartNew()
            ParallelMethod()
            ' NonParallelMethod()
			sw.Stop()

			Console.WriteLine("It Took {0} ms", sw.ElapsedMilliseconds)

			Console.WriteLine(Constants.vbLf & "Finished...")
			Console.ReadKey(True)
		End Sub

		Private Shared Sub NonParallelMethod()
			For i As Integer = 0 To 15
				Console.WriteLine("TID={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i)

				SimulateProcessing()
			Next i
		End Sub

		Private Shared Sub ParallelMethod()
			Parallel.For(0, 16, Sub(i)
				Console.WriteLine("TID={0}, i={1}", Thread.CurrentThread.ManagedThreadId, i)
				SimulateProcessing()
			End Sub)
		End Sub

		Private Shared Sub SimulateProcessing()
			Thread.SpinWait(80000000)
		End Sub
	End Class
End Namespace
