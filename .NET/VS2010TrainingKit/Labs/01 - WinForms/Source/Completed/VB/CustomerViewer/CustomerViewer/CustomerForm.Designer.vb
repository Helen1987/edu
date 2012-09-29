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

Namespace CustomerViewer
	Partial Public Class CustomerForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label1 = New Label()
			Me.CustomersComboBox = New ComboBox()
			Me.label2 = New Label()
			Me.CustomerDetailsGroupBox = New GroupBox()
			Me.DeleteButton = New Button()
			Me.UpdateButton = New Button()
			Me.CustomerIDLabel = New Label()
			Me.label8 = New Label()
			Me.PhoneTextBox = New TextBox()
			Me.EmailTextBox = New TextBox()
			Me.CompanyNameTextBox = New TextBox()
			Me.LastNameTextBox = New TextBox()
			Me.FirstNameTextBox = New TextBox()
			Me.label7 = New Label()
			Me.label6 = New Label()
			Me.label5 = New Label()
			Me.label4 = New Label()
			Me.label3 = New Label()
			Me.CustomerDetailsGroupBox.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New Font("Microsoft Sans Serif", 20F, FontStyle.Bold, GraphicsUnit.Point, (CByte(0)))
			Me.label1.Location = New Point(13, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New Size(155, 31)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Customers"
			' 
			' CustomersComboBox
			' 
			Me.CustomersComboBox.DisplayMember = "FullName"
			Me.CustomersComboBox.DropDownStyle = ComboBoxStyle.DropDownList
			Me.CustomersComboBox.FormattingEnabled = True
			Me.CustomersComboBox.Location = New Point(121, 77)
			Me.CustomersComboBox.Name = "CustomersComboBox"
			Me.CustomersComboBox.Size = New Size(121, 21)
			Me.CustomersComboBox.TabIndex = 1
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New Point(19, 80)
			Me.label2.Name = "label2"
			Me.label2.Size = New Size(96, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Select a Customer:"
			' 
			' CustomerDetailsGroupBox
			' 
			Me.CustomerDetailsGroupBox.Controls.Add(Me.DeleteButton)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.UpdateButton)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.CustomerIDLabel)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.label8)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.PhoneTextBox)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.EmailTextBox)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.CompanyNameTextBox)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.LastNameTextBox)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.FirstNameTextBox)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.label7)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.label6)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.label5)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.label4)
			Me.CustomerDetailsGroupBox.Controls.Add(Me.label3)
			Me.CustomerDetailsGroupBox.Location = New Point(22, 136)
			Me.CustomerDetailsGroupBox.Name = "CustomerDetailsGroupBox"
			Me.CustomerDetailsGroupBox.Size = New Size(479, 339)
			Me.CustomerDetailsGroupBox.TabIndex = 3
			Me.CustomerDetailsGroupBox.TabStop = False
			Me.CustomerDetailsGroupBox.Text = "Customer Details"
			Me.CustomerDetailsGroupBox.Visible = False
			' 
			' DeleteButton
			' 
			Me.DeleteButton.Location = New Point(123, 291)
			Me.DeleteButton.Name = "DeleteButton"
			Me.DeleteButton.Size = New Size(75, 23)
			Me.DeleteButton.TabIndex = 17
			Me.DeleteButton.Text = "Delete"
			Me.DeleteButton.UseVisualStyleBackColor = True
'			Me.DeleteButton.Click += New System.EventHandler(Me.DeleteButton_Click)
			' 
			' UpdateButton
			' 
			Me.UpdateButton.Location = New Point(24, 291)
			Me.UpdateButton.Name = "UpdateButton"
			Me.UpdateButton.Size = New Size(75, 23)
			Me.UpdateButton.TabIndex = 16
			Me.UpdateButton.Text = "Update"
			Me.UpdateButton.UseVisualStyleBackColor = True
'			Me.UpdateButton.Click += New System.EventHandler(Me.UpdateButton_Click)
			' 
			' CustomerIDLabel
			' 
			Me.CustomerIDLabel.AutoSize = True
			Me.CustomerIDLabel.Location = New Point(120, 28)
			Me.CustomerIDLabel.Name = "CustomerIDLabel"
			Me.CustomerIDLabel.Size = New Size(0, 13)
			Me.CustomerIDLabel.TabIndex = 15
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New Point(21, 29)
			Me.label8.Name = "label8"
			Me.label8.Size = New Size(65, 13)
			Me.label8.TabIndex = 14
			Me.label8.Text = "Customer ID"
			' 
			' PhoneTextBox
			' 
			Me.PhoneTextBox.Location = New Point(120, 243)
			Me.PhoneTextBox.Name = "PhoneTextBox"
			Me.PhoneTextBox.Size = New Size(163, 20)
			Me.PhoneTextBox.TabIndex = 13
			' 
			' EmailTextBox
			' 
			Me.EmailTextBox.Location = New Point(120, 195)
			Me.EmailTextBox.Name = "EmailTextBox"
			Me.EmailTextBox.Size = New Size(163, 20)
			Me.EmailTextBox.TabIndex = 12
			' 
			' CompanyNameTextBox
			' 
			Me.CompanyNameTextBox.Location = New Point(120, 153)
			Me.CompanyNameTextBox.Name = "CompanyNameTextBox"
			Me.CompanyNameTextBox.Size = New Size(163, 20)
			Me.CompanyNameTextBox.TabIndex = 11
			' 
			' LastNameTextBox
			' 
			Me.LastNameTextBox.Location = New Point(120, 109)
			Me.LastNameTextBox.Name = "LastNameTextBox"
			Me.LastNameTextBox.Size = New Size(163, 20)
			Me.LastNameTextBox.TabIndex = 10
			' 
			' FirstNameTextBox
			' 
			Me.FirstNameTextBox.Location = New Point(120, 67)
			Me.FirstNameTextBox.Name = "FirstNameTextBox"
			Me.FirstNameTextBox.Size = New Size(163, 20)
			Me.FirstNameTextBox.TabIndex = 9
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New Point(21, 243)
			Me.label7.Name = "label7"
			Me.label7.Size = New Size(38, 13)
			Me.label7.TabIndex = 8
			Me.label7.Text = "Phone"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New Point(21, 198)
			Me.label6.Name = "label6"
			Me.label6.Size = New Size(32, 13)
			Me.label6.TabIndex = 7
			Me.label6.Text = "Email"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New Point(21, 156)
			Me.label5.Name = "label5"
			Me.label5.Size = New Size(82, 13)
			Me.label5.TabIndex = 6
			Me.label5.Text = "Company Name"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New Point(21, 112)
			Me.label4.Name = "label4"
			Me.label4.Size = New Size(58, 13)
			Me.label4.TabIndex = 5
			Me.label4.Text = "Last Name"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New Point(21, 70)
			Me.label3.Name = "label3"
			Me.label3.Size = New Size(57, 13)
			Me.label3.TabIndex = 4
			Me.label3.Text = "First Name"
			' 
			' CustomerForm
			' 
			Me.AutoScaleDimensions = New SizeF(6F, 13F)
			Me.AutoScaleMode = AutoScaleMode.Font
			Me.ClientSize = New Size(528, 511)
			Me.Controls.Add(Me.CustomerDetailsGroupBox)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.CustomersComboBox)
			Me.Controls.Add(Me.label1)
			Me.Name = "CustomerForm"
			Me.Text = "Customer Viewer"
'			Me.Load += New System.EventHandler(Me.CustomerForm_Load)
			Me.CustomerDetailsGroupBox.ResumeLayout(False)
			Me.CustomerDetailsGroupBox.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As Label
		Private CustomersComboBox As ComboBox
		Private label2 As Label
		Private CustomerDetailsGroupBox As GroupBox
		Private label5 As Label
		Private label4 As Label
		Private label3 As Label
		Private label7 As Label
		Private label6 As Label
		Private CustomerIDLabel As Label
		Private label8 As Label
		Private PhoneTextBox As TextBox
		Private EmailTextBox As TextBox
		Private CompanyNameTextBox As TextBox
		Private LastNameTextBox As TextBox
		Private FirstNameTextBox As TextBox
		Private WithEvents DeleteButton As Button
		Private WithEvents UpdateButton As Button
	End Class
End Namespace

