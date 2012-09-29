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

Imports Microsoft.Office.Interop.Word

'TODO:  Follow these steps to enable the Ribbon (XML) item:

'1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

'Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility
'    Return New Ribbon()
'End Function

'2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
'   actions, such as clicking a button. Note: if you have exported this Ribbon from the
'   Ribbon designer, move your code from the event handlers to the callback methods and
'   modify the code to work with the Ribbon extensibility (RibbonX) programming model.

'3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.

'For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.

<Runtime.InteropServices.ComVisible(True)> _
    Public Class Ribbon
    Implements Office.IRibbonExtensibility

    Private ribbon As Office.IRibbonUI

    Private m_properties = New ExportProperties()

    Public Sub New()
    End Sub

    Public Function GetButtonImage(ByVal control As Office.IRibbonControl) As System.Drawing.Bitmap
        Select Case control.Id
            Case "btnBackStageXPS", "btnRibbonXPS"
                Return My.Resources.XPS
            Case "btnBackStagePDF", "btnRibbonPDF"
                Return My.Resources.PDF
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function GetEnable(ByVal control As Office.IRibbonControl) As Boolean
        Select Case control.Id
            Case "btnBackStageXPS", "txtXPSPath", "btnRibbonXPS"
                Return m_properties.XpsEnabled
            Case "btnBackStagePDF", "txtPDFPath", "btnRibbonPDF"
                Return m_properties.PdfEnabled
            Case Else
                Return False
        End Select
    End Function

    Public Function IsEnableChecked(ByVal control As Office.IRibbonControl) As Boolean
        If control.Id = "chkEnableXPS" Then
            Return m_properties.XpsEnabled
        ElseIf control.Id = "chkEnablePDF" Then
            Return m_properties.PdfEnabled
        Else
            Return False
        End If
    End Function

    Public Sub EnableChecked(ByVal control As Office.IRibbonControl, ByVal value As Boolean)
        If control.Id = "chkEnableXPS" Then
            m_properties.XpsEnabled = value
            ribbon.InvalidateControl("btnRibbonXPS")
            ribbon.InvalidateControl("btnBackStageXPS")
            ribbon.InvalidateControl("txtXPSPath")
        ElseIf control.Id = "chkEnablePDF" Then
            m_properties.PdfEnabled = value
            ribbon.InvalidateControl("btnRibbonPDF")
            ribbon.InvalidateControl("btnBackStagePDF")
            ribbon.InvalidateControl("txtPDFPath")
        End If
    End Sub

    Public Function GetExportPath(ByVal control As Office.IRibbonControl) As String
        If control.Id = "txtXPSPath" Then
            Return m_properties.XpsExportPath
        ElseIf control.Id = "txtPDFPath" Then
            Return m_properties.PdfExportPath
        Else
            Return String.Empty
        End If
    End Function

    Public Sub SetExportPath(ByVal control As Office.IRibbonControl, ByVal value As String)
        If control.Id = "txtXPSPath" Then
            m_properties.XpsExportPath = value
        ElseIf control.Id = "txtPDFPath" Then
            m_properties.PdfExportPath = value
        End If
    End Sub

    Public Sub ExportDocument(ByVal control As Office.IRibbonControl)
        Select Case control.Id
            Case "btnRibbonXPS", "btnBackStageXPS"
                    Globals.ThisAddIn.Application.ActiveDocument.ExportAsFixedFormat(m_properties.XpsExportPath, WdExportFormat.wdExportFormatXPS)
                Exit Select
            Case "btnRibbonPDF", "btnBackStagePDF"
                    Globals.ThisAddIn.Application.ActiveDocument.ExportAsFixedFormat(m_properties.PdfExportPath, WdExportFormat.wdExportFormatPDF)
                Exit Select
        End Select
    End Sub

    Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
        Return GetResourceText("ExportAddIn.Ribbon.xml")
    End Function

#Region "Ribbon Callbacks"
    'Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1.
    Public Sub Ribbon_Load(ByVal ribbonUI As Office.IRibbonUI)
        Me.ribbon = ribbonUI
    End Sub



#End Region

#Region "Helpers"

    Private Shared Function GetResourceText(ByVal resourceName As String) As String
        Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        Dim resourceNames() As String = asm.GetManifestResourceNames()
        For i As Integer = 0 To resourceNames.Length - 1
            If String.Compare(resourceName, resourceNames(i), StringComparison.OrdinalIgnoreCase) = 0 Then
                Using resourceReader As IO.StreamReader = New IO.StreamReader(asm.GetManifestResourceStream(resourceNames(i)))
                    If resourceReader IsNot Nothing Then
                        Return resourceReader.ReadToEnd()
                    End If
                End Using
            End If
        Next
        Return Nothing
    End Function

#End Region

End Class
