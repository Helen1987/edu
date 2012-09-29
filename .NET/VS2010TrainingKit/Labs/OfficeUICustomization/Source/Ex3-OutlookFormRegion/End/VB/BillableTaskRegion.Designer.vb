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

<System.ComponentModel.ToolboxItemAttribute(False)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BillableTaskRegion
    Inherits Microsoft.Office.Tools.Outlook.FormRegionBase

    Public Sub New(ByVal formRegion As Microsoft.Office.Interop.Outlook.FormRegion)
        MyBase.New(Globals.Factory, formRegion)
        Me.InitializeComponent()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.numHours = New System.Windows.Forms.NumericUpDown()
        Me.txtDetails = New System.Windows.Forms.TextBox()
        Me.lstCustomer = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.chkBillable = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'numHours
        '
        Me.numHours.Location = New System.Drawing.Point(386, 4)
        Me.numHours.Name = "numHours"
        Me.numHours.Size = New System.Drawing.Size(95, 20)
        Me.numHours.TabIndex = 11
        '
        'txtDetails
        '
        Me.txtDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDetails.Location = New System.Drawing.Point(5, 31)
        Me.txtDetails.Multiline = True
        Me.txtDetails.Name = "txtDetails"
        Me.txtDetails.Size = New System.Drawing.Size(476, 116)
        Me.txtDetails.TabIndex = 10
        '
        'lstCustomer
        '
        Me.lstCustomer.FormattingEnabled = True
        Me.lstCustomer.Items.AddRange(New Object() {"Fabrikam Inc.", "Adventure Works"})
        Me.lstCustomer.Location = New System.Drawing.Point(143, 4)
        Me.lstCustomer.Name = "lstCustomer"
        Me.lstCustomer.Size = New System.Drawing.Size(167, 21)
        Me.lstCustomer.TabIndex = 9
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(347, 7)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 13)
        Me.label2.TabIndex = 8
        Me.label2.Text = "Hours"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(87, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Customer"
        '
        'chkBillable
        '
        Me.chkBillable.AutoSize = True
        Me.chkBillable.Location = New System.Drawing.Point(6, 6)
        Me.chkBillable.Name = "chkBillable"
        Me.chkBillable.Size = New System.Drawing.Size(59, 17)
        Me.chkBillable.TabIndex = 6
        Me.chkBillable.Text = "Billable"
        Me.chkBillable.UseVisualStyleBackColor = True
        '
        'BillableTaskRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.numHours)
        Me.Controls.Add(Me.txtDetails)
        Me.Controls.Add(Me.lstCustomer)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.chkBillable)
        Me.Name = "BillableTaskRegion"
        Me.Size = New System.Drawing.Size(486, 150)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    'NOTE: The following procedure is required by the Form Regions Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Shared Sub InitializeManifest(ByVal manifest As Microsoft.Office.Tools.Outlook.FormRegionManifest, ByVal factory As Microsoft.Office.Tools.Outlook.Factory)
        manifest.FormRegionName = "Billable Task"
        manifest.FormRegionType = Microsoft.Office.Tools.Outlook.FormRegionType.Adjoining

    End Sub
    Private WithEvents numHours As System.Windows.Forms.NumericUpDown
    Private WithEvents txtDetails As System.Windows.Forms.TextBox
    Private WithEvents lstCustomer As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents chkBillable As System.Windows.Forms.CheckBox

    Partial Public Class BillableTaskRegionFactory
        Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory

        Public Event FormRegionInitializing As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventHandler

        Private _Manifest As Microsoft.Office.Tools.Outlook.FormRegionManifest


        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Public Sub New()
            Me._Manifest = Globals.Factory.CreateFormRegionManifest()            
            BillableTaskRegion.InitializeManifest(Me._Manifest, Globals.Factory)
        End Sub

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        ReadOnly Property Manifest() As Microsoft.Office.Tools.Outlook.FormRegionManifest Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.Manifest
            Get
                Return Me._Manifest
            End Get
        End Property

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function CreateFormRegion(ByVal formRegion As Microsoft.Office.Interop.Outlook.FormRegion) As Microsoft.Office.Tools.Outlook.IFormRegion Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.CreateFormRegion
            Dim form as BillableTaskRegion = New BillableTaskRegion(formRegion)
            form.Factory = Me
            Return form
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function GetFormRegionStorage(ByVal outlookItem As Object, ByVal formRegionMode As Microsoft.Office.Interop.Outlook.OlFormRegionMode, ByVal formRegionSize As Microsoft.Office.Interop.Outlook.OlFormRegionSize) As Byte() Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.GetFormRegionStorage
            Throw New System.NotSupportedException()
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
        Function IsDisplayedForItem(ByVal outlookItem As Object, ByVal formRegionMode As Microsoft.Office.Interop.Outlook.OlFormRegionMode, ByVal formRegionSize As Microsoft.Office.Interop.Outlook.OlFormRegionSize) As Boolean Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.IsDisplayedForItem
            Dim cancelArgs As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs = Globals.Factory.CreateFormRegionInitializingEventArgs(outlookItem, formRegionMode, formRegionSize, False)
            cancelArgs.Cancel = False
            RaiseEvent FormRegionInitializing(Me, cancelArgs)
            Return Not cancelArgs.Cancel
        End Function

        <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
       ReadOnly Property Kind() As Microsoft.Office.Tools.Outlook.FormRegionKindConstants Implements Microsoft.Office.Tools.Outlook.IFormRegionFactory.Kind
            Get
                Return Microsoft.Office.Tools.Outlook.FormRegionKindConstants.WindowsForms
            End Get
        End Property
    End Class
End Class

Partial Class WindowFormRegionCollection

    Friend ReadOnly Property BillableTaskRegion() As BillableTaskRegion
        Get
            For Each Item As Object In Me
                If (TypeOf (Item) Is BillableTaskRegion) Then
                    Return Item
                End If
            Next
            Return Nothing
        End Get
    End Property
End Class