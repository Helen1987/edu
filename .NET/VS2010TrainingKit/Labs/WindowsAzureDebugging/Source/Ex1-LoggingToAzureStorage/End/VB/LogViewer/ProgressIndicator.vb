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

Imports System.Threading

Friend Class ProgressIndicator
    Private ReadOnly _RenamedprogressIndicator() As Char = {"-"c, "\"c, "|"c, "/"c, "-"c}
    Private progressState As Integer
    Private timer As Timer

    Public Sub New()
        Console.CursorVisible = False

        Me.timer = New Timer(Sub(state)
                                 Console.Write(Constants.vbCr & " ")
                                 Console.Write(_RenamedprogressIndicator(progressState))
                                 progressState = (progressState + 1) Mod _RenamedprogressIndicator.Length
                             End Sub, Nothing, Timeout.Infinite, 2000)
    End Sub

    Public Sub Enable()
        Me.timer.Change(0, 1000)
    End Sub

    Public Sub Disable()
        Me.timer.Change(Timeout.Infinite, 0)
        Console.Write(Constants.vbCr & "  " & Constants.vbCr)
    End Sub
End Class