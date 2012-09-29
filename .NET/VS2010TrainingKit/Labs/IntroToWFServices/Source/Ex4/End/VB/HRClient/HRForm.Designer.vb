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

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HRForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.confirmationPanel = New System.Windows.Forms.Panel()
        Me.buttonStartAgain = New System.Windows.Forms.Button()
        Me.offerPanel = New System.Windows.Forms.Panel()
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.confirmationTitle = New System.Windows.Forms.Label()
        Me.candidateConfirmationNumber = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtRefs = New System.Windows.Forms.TextBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.submitButton = New System.Windows.Forms.Button()
        Me.comboBoxEducation = New System.Windows.Forms.ComboBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.confirmationPanel.SuspendLayout()
        Me.flowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'confirmationPanel
        '
        Me.confirmationPanel.Controls.Add(Me.buttonStartAgain)
        Me.confirmationPanel.Controls.Add(Me.offerPanel)
        Me.confirmationPanel.Controls.Add(Me.flowLayoutPanel1)
        Me.confirmationPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.confirmationPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirmationPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.confirmationPanel.Location = New System.Drawing.Point(25, 77)
        Me.confirmationPanel.Name = "confirmationPanel"
        Me.confirmationPanel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.confirmationPanel.Size = New System.Drawing.Size(344, 147)
        Me.confirmationPanel.TabIndex = 24
        Me.confirmationPanel.Visible = False
        '
        'buttonStartAgain
        '
        Me.buttonStartAgain.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.buttonStartAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonStartAgain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonStartAgain.ForeColor = System.Drawing.Color.White
        Me.buttonStartAgain.Location = New System.Drawing.Point(115, 92)
        Me.buttonStartAgain.Name = "buttonStartAgain"
        Me.buttonStartAgain.Size = New System.Drawing.Size(75, 23)
        Me.buttonStartAgain.TabIndex = 11
        Me.buttonStartAgain.Text = "Start Again"
        Me.buttonStartAgain.UseVisualStyleBackColor = False
        '
        'offerPanel
        '
        Me.offerPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.offerPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.offerPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.offerPanel.Location = New System.Drawing.Point(14, 10)
        Me.offerPanel.Name = "offerPanel"
        Me.offerPanel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.offerPanel.Size = New System.Drawing.Size(316, 112)
        Me.offerPanel.TabIndex = 10
        Me.offerPanel.Visible = False
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flowLayoutPanel1.AutoSize = True
        Me.flowLayoutPanel1.Controls.Add(Me.confirmationTitle)
        Me.flowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.flowLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.flowLayoutPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(14, 17)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(301, 44)
        Me.flowLayoutPanel1.TabIndex = 9
        '
        'confirmationTitle
        '
        Me.confirmationTitle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.confirmationTitle.AutoSize = True
        Me.confirmationTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.confirmationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.confirmationTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.confirmationTitle.Location = New System.Drawing.Point(3, 0)
        Me.confirmationTitle.Name = "confirmationTitle"
        Me.confirmationTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.confirmationTitle.Size = New System.Drawing.Size(34, 17)
        Me.confirmationTitle.TabIndex = 0
        Me.confirmationTitle.Text = "text"
        Me.confirmationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'candidateConfirmationNumber
        '
        Me.candidateConfirmationNumber.AutoSize = True
        Me.candidateConfirmationNumber.BackColor = System.Drawing.SystemColors.Window
        Me.candidateConfirmationNumber.Cursor = System.Windows.Forms.Cursors.Default
        Me.candidateConfirmationNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.candidateConfirmationNumber.Location = New System.Drawing.Point(62, 217)
        Me.candidateConfirmationNumber.Name = "candidateConfirmationNumber"
        Me.candidateConfirmationNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.candidateConfirmationNumber.Size = New System.Drawing.Size(0, 13)
        Me.candidateConfirmationNumber.TabIndex = 23
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.label1.Location = New System.Drawing.Point(36, 84)
        Me.label1.Name = "label1"
        Me.label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label1.Size = New System.Drawing.Size(162, 13)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Candidate Information Form"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label5.Location = New System.Drawing.Point(49, 135)
        Me.label5.Name = "label5"
        Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label5.Size = New System.Drawing.Size(35, 13)
        Me.label5.TabIndex = 19
        Me.label5.Text = "Email:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(49, 108)
        Me.label2.Name = "label2"
        Me.label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label2.Size = New System.Drawing.Size(38, 13)
        Me.label2.TabIndex = 20
        Me.label2.Text = "Name:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(29, 163)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label3.Size = New System.Drawing.Size(58, 13)
        Me.label3.TabIndex = 26
        Me.label3.Text = "Education:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(22, 190)
        Me.label4.Name = "label4"
        Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label4.Size = New System.Drawing.Size(65, 13)
        Me.label4.TabIndex = 27
        Me.label4.Text = "References:"
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtName.Location = New System.Drawing.Point(89, 105)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtName.Size = New System.Drawing.Size(214, 20)
        Me.txtName.TabIndex = 18
        '
        'txtRefs
        '
        Me.txtRefs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefs.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRefs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefs.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtRefs.Location = New System.Drawing.Point(89, 187)
        Me.txtRefs.MaxLength = 50
        Me.txtRefs.Name = "txtRefs"
        Me.txtRefs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtRefs.Size = New System.Drawing.Size(45, 20)
        Me.txtRefs.TabIndex = 21
        '
        'pictureBox1
        '
        Me.pictureBox1.Image = Global.HRClient.My.Resources.Resources.logo1
        Me.pictureBox1.Location = New System.Drawing.Point(8, 3)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(200, 68)
        Me.pictureBox1.TabIndex = 25
        Me.pictureBox1.TabStop = False
        '
        'submitButton
        '
        Me.submitButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.submitButton.Cursor = System.Windows.Forms.Cursors.Default
        Me.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.submitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.submitButton.ForeColor = System.Drawing.Color.White
        Me.submitButton.Location = New System.Drawing.Point(228, 188)
        Me.submitButton.Name = "submitButton"
        Me.submitButton.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.submitButton.Size = New System.Drawing.Size(75, 23)
        Me.submitButton.TabIndex = 22
        Me.submitButton.Text = "Submit"
        Me.submitButton.UseVisualStyleBackColor = False
        '
        'comboBoxEducation
        '
        Me.comboBoxEducation.FormattingEnabled = True
        Me.comboBoxEducation.Items.AddRange(New Object() {"None", "Bachelors", "Masters", "Doctorate"})
        Me.comboBoxEducation.Location = New System.Drawing.Point(89, 159)
        Me.comboBoxEducation.Margin = New System.Windows.Forms.Padding(2)
        Me.comboBoxEducation.Name = "comboBoxEducation"
        Me.comboBoxEducation.Size = New System.Drawing.Size(212, 21)
        Me.comboBoxEducation.TabIndex = 28
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(89, 132)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(214, 20)
        Me.txtEmail.TabIndex = 29
        '
        'HRForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(376, 232)
        Me.Controls.Add(Me.confirmationPanel)
        Me.Controls.Add(Me.candidateConfirmationNumber)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtRefs)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.submitButton)
        Me.Controls.Add(Me.comboBoxEducation)
        Me.Controls.Add(Me.txtEmail)
        Me.Name = "HRForm"
        Me.Text = "Contoso HR Tool"
        Me.confirmationPanel.ResumeLayout(False)
        Me.confirmationPanel.PerformLayout()
        Me.flowLayoutPanel1.ResumeLayout(False)
        Me.flowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents confirmationPanel As System.Windows.Forms.Panel
    Private WithEvents buttonStartAgain As System.Windows.Forms.Button
    Private WithEvents offerPanel As System.Windows.Forms.Panel
    Private WithEvents flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents confirmationTitle As System.Windows.Forms.Label
    Private WithEvents candidateConfirmationNumber As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents txtRefs As System.Windows.Forms.TextBox
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents submitButton As System.Windows.Forms.Button
    Private WithEvents comboBoxEducation As System.Windows.Forms.ComboBox
    Private WithEvents txtEmail As System.Windows.Forms.TextBox

End Class
