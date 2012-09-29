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

Imports Microsoft.Office.Interop
Imports System.Runtime.CompilerServices

Module Module1

    Sub Main()
        Dim checkAccounts = CreateAccountList()

        checkAccounts.DisplayInExcel(Sub(account, cell)
                                         cell.Value2 = account.ID
                                         cell.Offset(0, 1).Value2 = account.Balance
                                         cell.Offset(0, 2).Value2 = account.AccountHolder
                                         If account.Balance < 0 Then
                                             cell.Interior.Color = RGB(255, 0, 0)
                                             cell.Offset(0, 1).Interior.Color = RGB(255, 0, 0)
                                             cell.Offset(0, 2).Interior.Color = RGB(255, 0, 0)
                                         End If
                                     End Sub)

        EmbedInWordDocument()
    End Sub

    Private Function CreateAccountList() As List(Of Account)
        Dim checkAccounts As New List(Of Account) From {
            New Account With {
                .ID = 1,
                .Balance = 285.93,
                .AccountHolder = "John Doe"
            },
            New Account With {
                .ID = 2,
                .Balance = 2349.23,
                .AccountHolder = "Richard Roe"
            },
            New Account With {
                .ID = 3,
                .Balance = -39.46,
                .AccountHolder = "I Dunoe"
            }
        }

        Return checkAccounts
    End Function

    <Extension()>
    Sub DisplayInExcel(ByVal accounts As IEnumerable(Of Account), ByVal DisplayFunc As Action(Of Account, Excel.Range))
        With New Excel.Application
            .Workbooks.Add()
            .Visible = True
            .Range("A1").Value = "ID"
            .Range("B1").Value = "Balance"
            .Range("C1").Value = "Account Holder"
            .Range("A2").Select()

            For Each ac In accounts
                DisplayFunc(ac, .ActiveCell)
                .ActiveCell.Offset(1, 0).Select()
            Next

            .Columns(1).AutoFit()
            .Columns(2).AutoFit()
            .Columns(3).AutoFit()
            .Range("A1:C4").Copy()
        End With
    End Sub

    Private Sub EmbedInWordDocument()
        Dim word As New Word.Application
        word.Visible = True
        word.Documents.Add()
        word.Selection.PasteSpecial(Link:=True, DisplayAsIcon:=False)
    End Sub
End Module
