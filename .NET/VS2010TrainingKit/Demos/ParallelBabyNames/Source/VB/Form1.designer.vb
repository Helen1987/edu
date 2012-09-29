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
Namespace PlinqMvpDemo
	Partial Public Class Form1
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
			Me.RunLinqButton = New System.Windows.Forms.Button()
			Me.RunPlinqButton = New System.Windows.Forms.Button()
			Me.NameTextBox = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.StateTextBox = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.InputSize1MB = New System.Windows.Forms.RadioButton()
			Me.InputSize5MB = New System.Windows.Forms.RadioButton()
			Me.InputSize10MB = New System.Windows.Forms.RadioButton()
			Me.InputSize50MB = New System.Windows.Forms.RadioButton()
			Me.InputSize100MB = New System.Windows.Forms.RadioButton()
			Me.InputSize250MB = New System.Windows.Forms.RadioButton()
			Me.InputSize500MB = New System.Windows.Forms.RadioButton()
			Me.LinqPicture = New System.Windows.Forms.PictureBox()
			Me.PlinqPicture = New System.Windows.Forms.PictureBox()
			Me.LinqTimeLabel = New System.Windows.Forms.Label()
			Me.PlinqTimeLabel = New System.Windows.Forms.Label()
			Me.SpeedupLabel = New System.Windows.Forms.Label()
			Me.LinqYearStartLabel = New System.Windows.Forms.Label()
			Me.PlinqYearStartLabel = New System.Windows.Forms.Label()
			Me.LinqYearEndLabel = New System.Windows.Forms.Label()
			Me.PlinqYearEndLabel = New System.Windows.Forms.Label()
			Me.LinqValueStartLabel = New System.Windows.Forms.Label()
			Me.PlinqValueStartLabel = New System.Windows.Forms.Label()
			Me.PlinqValueEndLabel = New System.Windows.Forms.Label()
			Me.LinqValueEndLabel = New System.Windows.Forms.Label()
			Me.InputSize1GB = New System.Windows.Forms.RadioButton()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.LineRadioButton = New System.Windows.Forms.RadioButton()
			Me.HistogramRadioButton = New System.Windows.Forms.RadioButton()
			Me.label4 = New System.Windows.Forms.Label()
			Me.ProcessorsToUse = New System.Windows.Forms.TrackBar()
			CType(Me.LinqPicture, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PlinqPicture, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.groupBox1.SuspendLayout()
			CType(Me.ProcessorsToUse, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' RunLinqButton
			' 
			Me.RunLinqButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11F)
			Me.RunLinqButton.Location = New System.Drawing.Point(89, 384)
			Me.RunLinqButton.Name = "RunLinqButton"
			Me.RunLinqButton.Size = New System.Drawing.Size(198, 57)
			Me.RunLinqButton.TabIndex = 0
			Me.RunLinqButton.Text = "LINQ"
			Me.RunLinqButton.UseVisualStyleBackColor = True
'			Me.RunLinqButton.Click += New System.EventHandler(Me.RunLinqButton_Click);
			' 
			' RunPlinqButton
			' 
			Me.RunPlinqButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11F)
			Me.RunPlinqButton.Location = New System.Drawing.Point(600, 384)
			Me.RunPlinqButton.Name = "RunPlinqButton"
			Me.RunPlinqButton.Size = New System.Drawing.Size(198, 57)
			Me.RunPlinqButton.TabIndex = 1
			Me.RunPlinqButton.Text = "PLINQ"
			Me.RunPlinqButton.UseVisualStyleBackColor = True
'			Me.RunPlinqButton.Click += New System.EventHandler(Me.RunPlinqButton_Click);
			' 
			' NameTextBox
			' 
			Me.NameTextBox.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.NameTextBox.Location = New System.Drawing.Point(386, 418)
			Me.NameTextBox.Name = "NameTextBox"
			Me.NameTextBox.Size = New System.Drawing.Size(146, 23)
			Me.NameTextBox.TabIndex = 4
			Me.NameTextBox.Text = "Robert"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label1.Location = New System.Drawing.Point(343, 418)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(41, 15)
			Me.label1.TabIndex = 5
			Me.label1.Text = "Name:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label2.Location = New System.Drawing.Point(343, 444)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(37, 15)
			Me.label2.TabIndex = 7
			Me.label2.Text = "State:"
			' 
			' StateTextBox
			' 
			Me.StateTextBox.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.StateTextBox.Location = New System.Drawing.Point(386, 444)
			Me.StateTextBox.Name = "StateTextBox"
			Me.StateTextBox.Size = New System.Drawing.Size(146, 23)
			Me.StateTextBox.TabIndex = 6
			Me.StateTextBox.Text = "WA"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label3.Location = New System.Drawing.Point(317, 492)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(63, 15)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Input size:"
			' 
			' InputSize1MB
			' 
			Me.InputSize1MB.AutoSize = True
			Me.InputSize1MB.Location = New System.Drawing.Point(386, 496)
			Me.InputSize1MB.Name = "InputSize1MB"
			Me.InputSize1MB.Size = New System.Drawing.Size(47, 17)
			Me.InputSize1MB.TabIndex = 12
			Me.InputSize1MB.Tag = "1"
			Me.InputSize1MB.Text = "1MB"
			Me.InputSize1MB.UseVisualStyleBackColor = True
'			Me.InputSize1MB.CheckedChanged += New System.EventHandler(Me.InputSize1MB_CheckedChanged);
			' 
			' InputSize5MB
			' 
			Me.InputSize5MB.AutoSize = True
			Me.InputSize5MB.Location = New System.Drawing.Point(451, 496)
			Me.InputSize5MB.Name = "InputSize5MB"
			Me.InputSize5MB.Size = New System.Drawing.Size(47, 17)
			Me.InputSize5MB.TabIndex = 13
			Me.InputSize5MB.Tag = "5"
			Me.InputSize5MB.Text = "5MB"
			Me.InputSize5MB.UseVisualStyleBackColor = True
'			Me.InputSize5MB.CheckedChanged += New System.EventHandler(Me.InputSize5MB_CheckedChanged);
			' 
			' InputSize10MB
			' 
			Me.InputSize10MB.AutoSize = True
			Me.InputSize10MB.Location = New System.Drawing.Point(516, 496)
			Me.InputSize10MB.Name = "InputSize10MB"
			Me.InputSize10MB.Size = New System.Drawing.Size(53, 17)
			Me.InputSize10MB.TabIndex = 14
			Me.InputSize10MB.Tag = "10"
			Me.InputSize10MB.Text = "10MB"
			Me.InputSize10MB.UseVisualStyleBackColor = True
'			Me.InputSize10MB.CheckedChanged += New System.EventHandler(Me.InputSize10MB_CheckedChanged);
			' 
			' InputSize50MB
			' 
			Me.InputSize50MB.AutoSize = True
			Me.InputSize50MB.Location = New System.Drawing.Point(580, 496)
			Me.InputSize50MB.Name = "InputSize50MB"
			Me.InputSize50MB.Size = New System.Drawing.Size(53, 17)
			Me.InputSize50MB.TabIndex = 15
			Me.InputSize50MB.Tag = "50"
			Me.InputSize50MB.Text = "50MB"
			Me.InputSize50MB.UseVisualStyleBackColor = True
'			Me.InputSize50MB.CheckedChanged += New System.EventHandler(Me.InputSize50MB_CheckedChanged);
			' 
			' InputSize100MB
			' 
			Me.InputSize100MB.AutoSize = True
			Me.InputSize100MB.Location = New System.Drawing.Point(386, 519)
			Me.InputSize100MB.Name = "InputSize100MB"
			Me.InputSize100MB.Size = New System.Drawing.Size(59, 17)
			Me.InputSize100MB.TabIndex = 16
			Me.InputSize100MB.Tag = "100"
			Me.InputSize100MB.Text = "100MB"
			Me.InputSize100MB.UseVisualStyleBackColor = True
'			Me.InputSize100MB.CheckedChanged += New System.EventHandler(Me.InputSize100MB_CheckedChanged);
			' 
			' InputSize250MB
			' 
			Me.InputSize250MB.AutoSize = True
			Me.InputSize250MB.Checked = True
			Me.InputSize250MB.Location = New System.Drawing.Point(451, 519)
			Me.InputSize250MB.Name = "InputSize250MB"
			Me.InputSize250MB.Size = New System.Drawing.Size(59, 17)
			Me.InputSize250MB.TabIndex = 17
			Me.InputSize250MB.TabStop = True
			Me.InputSize250MB.Tag = "250"
			Me.InputSize250MB.Text = "250MB"
			Me.InputSize250MB.UseVisualStyleBackColor = True
'			Me.InputSize250MB.CheckedChanged += New System.EventHandler(Me.InputSize250MB_CheckedChanged);
			' 
			' InputSize500MB
			' 
			Me.InputSize500MB.AutoSize = True
			Me.InputSize500MB.Location = New System.Drawing.Point(516, 519)
			Me.InputSize500MB.Name = "InputSize500MB"
			Me.InputSize500MB.Size = New System.Drawing.Size(59, 17)
			Me.InputSize500MB.TabIndex = 18
			Me.InputSize500MB.TabStop = True
			Me.InputSize500MB.Tag = "500"
			Me.InputSize500MB.Text = "500MB"
			Me.InputSize500MB.UseVisualStyleBackColor = True
'			Me.InputSize500MB.CheckedChanged += New System.EventHandler(Me.InputSize500MB_CheckedChanged);
			' 
			' LinqPicture
			' 
			Me.LinqPicture.Location = New System.Drawing.Point(35, 26)
			Me.LinqPicture.Name = "LinqPicture"
			Me.LinqPicture.Size = New System.Drawing.Size(404, 326)
			Me.LinqPicture.TabIndex = 19
			Me.LinqPicture.TabStop = False
			' 
			' PlinqPicture
			' 
			Me.PlinqPicture.Location = New System.Drawing.Point(485, 26)
			Me.PlinqPicture.Name = "PlinqPicture"
			Me.PlinqPicture.Size = New System.Drawing.Size(404, 326)
			Me.PlinqPicture.TabIndex = 20
			Me.PlinqPicture.TabStop = False
			' 
			' LinqTimeLabel
			' 
			Me.LinqTimeLabel.AutoSize = True
			Me.LinqTimeLabel.Font = New System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.LinqTimeLabel.ForeColor = System.Drawing.Color.Red
			Me.LinqTimeLabel.Location = New System.Drawing.Point(93, 454)
			Me.LinqTimeLabel.Name = "LinqTimeLabel"
			Me.LinqTimeLabel.Size = New System.Drawing.Size(112, 26)
			Me.LinqTimeLabel.TabIndex = 22
			Me.LinqTimeLabel.Text = "0.0 seconds"
			Me.LinqTimeLabel.Visible = False
			' 
			' PlinqTimeLabel
			' 
			Me.PlinqTimeLabel.AutoSize = True
			Me.PlinqTimeLabel.Font = New System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.PlinqTimeLabel.ForeColor = System.Drawing.Color.Red
			Me.PlinqTimeLabel.Location = New System.Drawing.Point(686, 454)
			Me.PlinqTimeLabel.Name = "PlinqTimeLabel"
			Me.PlinqTimeLabel.Size = New System.Drawing.Size(112, 26)
			Me.PlinqTimeLabel.TabIndex = 23
			Me.PlinqTimeLabel.Text = "0.0 seconds"
			Me.PlinqTimeLabel.Visible = False
			' 
			' SpeedupLabel
			' 
			Me.SpeedupLabel.AutoSize = True
			Me.SpeedupLabel.Font = New System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.SpeedupLabel.ForeColor = System.Drawing.Color.Red
			Me.SpeedupLabel.Location = New System.Drawing.Point(340, 365)
			Me.SpeedupLabel.Name = "SpeedupLabel"
			Me.SpeedupLabel.Size = New System.Drawing.Size(188, 36)
			Me.SpeedupLabel.TabIndex = 24
			Me.SpeedupLabel.Text = "1.03X speedup"
			Me.SpeedupLabel.Visible = False
			' 
			' LinqYearStartLabel
			' 
			Me.LinqYearStartLabel.AutoSize = True
			Me.LinqYearStartLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.LinqYearStartLabel.Location = New System.Drawing.Point(32, 355)
			Me.LinqYearStartLabel.Name = "LinqYearStartLabel"
			Me.LinqYearStartLabel.Size = New System.Drawing.Size(31, 13)
			Me.LinqYearStartLabel.TabIndex = 25
			Me.LinqYearStartLabel.Text = "1970"
			' 
			' PlinqYearStartLabel
			' 
			Me.PlinqYearStartLabel.AutoSize = True
			Me.PlinqYearStartLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.PlinqYearStartLabel.Location = New System.Drawing.Point(482, 355)
			Me.PlinqYearStartLabel.Name = "PlinqYearStartLabel"
			Me.PlinqYearStartLabel.Size = New System.Drawing.Size(31, 13)
			Me.PlinqYearStartLabel.TabIndex = 26
			Me.PlinqYearStartLabel.Text = "1970"
			' 
			' LinqYearEndLabel
			' 
			Me.LinqYearEndLabel.AutoSize = True
			Me.LinqYearEndLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.LinqYearEndLabel.Location = New System.Drawing.Point(409, 355)
			Me.LinqYearEndLabel.Name = "LinqYearEndLabel"
			Me.LinqYearEndLabel.Size = New System.Drawing.Size(31, 13)
			Me.LinqYearEndLabel.TabIndex = 27
			Me.LinqYearEndLabel.Text = "1970"
			' 
			' PlinqYearEndLabel
			' 
			Me.PlinqYearEndLabel.AutoSize = True
			Me.PlinqYearEndLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.PlinqYearEndLabel.Location = New System.Drawing.Point(858, 355)
			Me.PlinqYearEndLabel.Name = "PlinqYearEndLabel"
			Me.PlinqYearEndLabel.Size = New System.Drawing.Size(31, 13)
			Me.PlinqYearEndLabel.TabIndex = 28
			Me.PlinqYearEndLabel.Text = "1970"
			' 
			' LinqValueStartLabel
			' 
			Me.LinqValueStartLabel.AutoSize = True
			Me.LinqValueStartLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.LinqValueStartLabel.Location = New System.Drawing.Point(16, 339)
			Me.LinqValueStartLabel.Name = "LinqValueStartLabel"
			Me.LinqValueStartLabel.Size = New System.Drawing.Size(13, 13)
			Me.LinqValueStartLabel.TabIndex = 29
			Me.LinqValueStartLabel.Text = "0"
			Me.LinqValueStartLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
			' 
			' PlinqValueStartLabel
			' 
			Me.PlinqValueStartLabel.AutoSize = True
			Me.PlinqValueStartLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.PlinqValueStartLabel.Location = New System.Drawing.Point(466, 339)
			Me.PlinqValueStartLabel.Name = "PlinqValueStartLabel"
			Me.PlinqValueStartLabel.Size = New System.Drawing.Size(13, 13)
			Me.PlinqValueStartLabel.TabIndex = 30
			Me.PlinqValueStartLabel.Text = "0"
			Me.PlinqValueStartLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
			' 
			' PlinqValueEndLabel
			' 
			Me.PlinqValueEndLabel.AutoSize = True
			Me.PlinqValueEndLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.PlinqValueEndLabel.Location = New System.Drawing.Point(448, 26)
			Me.PlinqValueEndLabel.Name = "PlinqValueEndLabel"
			Me.PlinqValueEndLabel.Size = New System.Drawing.Size(31, 13)
			Me.PlinqValueEndLabel.TabIndex = 31
			Me.PlinqValueEndLabel.Text = "1000"
			Me.PlinqValueEndLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
			' 
			' LinqValueEndLabel
			' 
			Me.LinqValueEndLabel.AutoSize = True
			Me.LinqValueEndLabel.Font = New System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.LinqValueEndLabel.Location = New System.Drawing.Point(-2, 26)
			Me.LinqValueEndLabel.Name = "LinqValueEndLabel"
			Me.LinqValueEndLabel.Size = New System.Drawing.Size(31, 13)
			Me.LinqValueEndLabel.TabIndex = 32
			Me.LinqValueEndLabel.Text = "1000"
			Me.LinqValueEndLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
			' 
			' InputSize1GB
			' 
			Me.InputSize1GB.AutoSize = True
			Me.InputSize1GB.Location = New System.Drawing.Point(580, 519)
			Me.InputSize1GB.Name = "InputSize1GB"
			Me.InputSize1GB.Size = New System.Drawing.Size(46, 17)
			Me.InputSize1GB.TabIndex = 33
			Me.InputSize1GB.Tag = "500"
			Me.InputSize1GB.Text = "1GB"
			Me.InputSize1GB.UseVisualStyleBackColor = True
'			Me.InputSize1GB.CheckedChanged += New System.EventHandler(Me.InputSize1GB_CheckedChanged);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.LineRadioButton)
			Me.groupBox1.Controls.Add(Me.HistogramRadioButton)
			Me.groupBox1.Location = New System.Drawing.Point(11, 483)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(262, 53)
			Me.groupBox1.TabIndex = 34
			Me.groupBox1.TabStop = False
			' 
			' LineRadioButton
			' 
			Me.LineRadioButton.AutoSize = True
			Me.LineRadioButton.Location = New System.Drawing.Point(163, 21)
			Me.LineRadioButton.Name = "LineRadioButton"
			Me.LineRadioButton.Size = New System.Drawing.Size(77, 17)
			Me.LineRadioButton.TabIndex = 1
			Me.LineRadioButton.Text = "Line Graph"
			Me.LineRadioButton.UseVisualStyleBackColor = True
			' 
			' HistogramRadioButton
			' 
			Me.HistogramRadioButton.AutoSize = True
			Me.HistogramRadioButton.Checked = True
			Me.HistogramRadioButton.Location = New System.Drawing.Point(14, 21)
			Me.HistogramRadioButton.Name = "HistogramRadioButton"
			Me.HistogramRadioButton.Size = New System.Drawing.Size(125, 17)
			Me.HistogramRadioButton.TabIndex = 0
			Me.HistogramRadioButton.TabStop = True
			Me.HistogramRadioButton.Text = "Histogram/Bar Graph"
			Me.HistogramRadioButton.UseVisualStyleBackColor = True
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Font = New System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.label4.Location = New System.Drawing.Point(665, 496)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(71, 15)
			Me.label4.TabIndex = 35
			Me.label4.Text = "Processors:"
			' 
			' ProcessorsToUse
			' 
			Me.ProcessorsToUse.Location = New System.Drawing.Point(742, 496)
			Me.ProcessorsToUse.Name = "ProcessorsToUse"
			Me.ProcessorsToUse.Size = New System.Drawing.Size(147, 45)
			Me.ProcessorsToUse.TabIndex = 36
'			Me.ProcessorsToUse.Scroll += New System.EventHandler(Me.ProcessorsToUse_Scroll);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(926, 562)
			Me.Controls.Add(Me.ProcessorsToUse)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.InputSize1GB)
			Me.Controls.Add(Me.LinqValueEndLabel)
			Me.Controls.Add(Me.PlinqValueEndLabel)
			Me.Controls.Add(Me.PlinqValueStartLabel)
			Me.Controls.Add(Me.LinqValueStartLabel)
			Me.Controls.Add(Me.PlinqYearEndLabel)
			Me.Controls.Add(Me.LinqYearEndLabel)
			Me.Controls.Add(Me.PlinqYearStartLabel)
			Me.Controls.Add(Me.LinqYearStartLabel)
			Me.Controls.Add(Me.SpeedupLabel)
			Me.Controls.Add(Me.PlinqTimeLabel)
			Me.Controls.Add(Me.LinqTimeLabel)
			Me.Controls.Add(Me.PlinqPicture)
			Me.Controls.Add(Me.LinqPicture)
			Me.Controls.Add(Me.InputSize500MB)
			Me.Controls.Add(Me.InputSize250MB)
			Me.Controls.Add(Me.InputSize100MB)
			Me.Controls.Add(Me.InputSize50MB)
			Me.Controls.Add(Me.InputSize10MB)
			Me.Controls.Add(Me.InputSize5MB)
			Me.Controls.Add(Me.InputSize1MB)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.StateTextBox)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.NameTextBox)
			Me.Controls.Add(Me.RunPlinqButton)
			Me.Controls.Add(Me.RunLinqButton)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Form1"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.Text = "PLINQ Demo"
			CType(Me.LinqPicture, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PlinqPicture, System.ComponentModel.ISupportInitialize).EndInit()
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			CType(Me.ProcessorsToUse, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents RunLinqButton As System.Windows.Forms.Button
		Private WithEvents RunPlinqButton As System.Windows.Forms.Button
		Private NameTextBox As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private StateTextBox As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents InputSize1MB As System.Windows.Forms.RadioButton
		Private WithEvents InputSize5MB As System.Windows.Forms.RadioButton
		Private WithEvents InputSize10MB As System.Windows.Forms.RadioButton
		Private WithEvents InputSize50MB As System.Windows.Forms.RadioButton
		Private WithEvents InputSize100MB As System.Windows.Forms.RadioButton
		Private WithEvents InputSize250MB As System.Windows.Forms.RadioButton
		Private WithEvents InputSize500MB As System.Windows.Forms.RadioButton
		Private LinqPicture As System.Windows.Forms.PictureBox
		Private PlinqPicture As System.Windows.Forms.PictureBox
		Private LinqTimeLabel As System.Windows.Forms.Label
		Private PlinqTimeLabel As System.Windows.Forms.Label
		Private SpeedupLabel As System.Windows.Forms.Label
		Private LinqYearStartLabel As System.Windows.Forms.Label
		Private PlinqYearStartLabel As System.Windows.Forms.Label
		Private LinqYearEndLabel As System.Windows.Forms.Label
		Private PlinqYearEndLabel As System.Windows.Forms.Label
		Private LinqValueStartLabel As System.Windows.Forms.Label
		Private PlinqValueStartLabel As System.Windows.Forms.Label
		Private PlinqValueEndLabel As System.Windows.Forms.Label
		Private LinqValueEndLabel As System.Windows.Forms.Label
		Private WithEvents InputSize1GB As System.Windows.Forms.RadioButton
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private LineRadioButton As System.Windows.Forms.RadioButton
		Private HistogramRadioButton As System.Windows.Forms.RadioButton
		Private label4 As System.Windows.Forms.Label
		Private WithEvents ProcessorsToUse As System.Windows.Forms.TrackBar
	End Class
End Namespace

