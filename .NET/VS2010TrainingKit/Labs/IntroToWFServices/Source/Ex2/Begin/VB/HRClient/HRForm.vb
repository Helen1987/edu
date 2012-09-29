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

Imports HRClient.SubmitApp
Imports System.ServiceModel

Public Class HRForm
    Private proxy As HRClient.SubmitApp.ApplicationServiceClient
    Delegate Sub SetTextCallback(ByVal text As String)

    Sub New()
        Me.InitializeComponent()
        SetFieldDefaults()
    End Sub

    Public Sub SetConfirmationText(ByVal text As String)
        Me.Invoke(New MethodInvoker(Sub()
                                        Me.confirmationTitle.Text = text
                                        Debug.WriteLine("*** Setting confirmation text = " & text)
                                        Me.confirmationPanel.Visible = True
                                        Me.confirmationPanel.Update()
                                    End Sub))
    End Sub

    Private Function CreateApplicationRequest() As SubmitJobApplicationRequest
        Return New SubmitJobApplicationRequest With {
                    .Resume = New ApplicantResume With {
                        .Name = Me.txtName.Text,
                        .Email = Me.txtEmail.Text,
                        .Education = Me.comboBoxEducation.Text,
                        .NumReferences = IIf(String.IsNullOrEmpty(txtRefs.Text), 0, Integer.Parse(Me.txtRefs.Text.Trim()))
                        },
                    .RequestID = Guid.NewGuid()
                    }
    End Function

    Private Sub SubmitJobApplication()
        ShowConfirmationPanel()
        proxy = New HRClient.SubmitApp.ApplicationServiceClient()
        proxy.BeginSubmitJobApplication(CreateApplicationRequest(), AddressOf OnStartCompleted, Nothing)
    End Sub

    Private Sub OnStartCompleted(ByVal asr As IAsyncResult)
        Try
            Dim result As SubmitJobApplicationResponse = DirectCast(proxy.EndSubmitJobApplication(asr), SubmitJobApplicationResponse)
            SetConfirmationText(result.ResponseText)
            ShowStartAgainButton()
            proxy.Close()
        Catch generatedExceptionName As CommunicationException
            ShowExceptionText(My.Resources.CommException)
            proxy.Abort()
        Catch generatedExceptionName As TimeoutException
            ShowExceptionText(My.Resources.TimeoutText)
            proxy.Abort()
        Catch generatedExceptionName As Exception
            proxy.Abort()
            Throw
        End Try
    End Sub

    Private Sub ShowExceptionText(ByVal text As String)
        SetConfirmationText(text)
        ShowStartAgainButton()
    End Sub

    Private Sub ShowStartAgainButton()
        Me.Invoke(New MethodInvoker(Sub()
                                        Me.buttonStartAgain.Visible = True
                                    End Sub))
    End Sub

    Private Sub ShowConfirmationPanel()
        Me.confirmationPanel.Visible = True
        Me.buttonStartAgain.Visible = False
        Me.confirmationTitle.Text = My.Resources.SubmitText
        Me.Update()
    End Sub

    Private Sub submitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submitButton.Click
        SubmitJobApplication()
    End Sub

    Private Sub buttonStartAgain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStartAgain.Click
        SetFieldDefaults()
        Me.confirmationPanel.Visible = False
    End Sub

    Private Sub SetFieldDefaults()
        Dim r As New Random()

        If r.[Next]() Mod 2 = 0 Then
            Me.txtName.Text = "John Smith"
        Else
            Me.txtName.Text = "Jane Smith"
        End If
        Me.txtRefs.Text = "5"
        Me.txtEmail.Text = "jsmith@example.com"
        Me.comboBoxEducation.Text = If(r.[Next]() Mod 2 = 0, "Bachelors", "Masters")
    End Sub
End Class
