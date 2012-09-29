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
Imports System.Windows.Forms

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
Public Class RibbonX
    Implements Office.IRibbonExtensibility

    Private ribbon As Office.IRibbonUI

    Private m_pdfDocumentProperties = False
    Private m_xpsDocumentProperties = False
    Private m_pdfDocumentStructure = False
    Private m_xpsDocumentStructure = False

    Public Sub New()
    End Sub

#Region "IRibbonExtensibility Members"

    Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
        Return GetResourceText("PublishingAddIn.RibbonX.xml")
    End Function

#End Region

#Region "Ribbon Callbacks"
    'Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1.
    Public Sub Ribbon_Load(ByVal ribbonUI As Office.IRibbonUI)
        Me.ribbon = ribbonUI
    End Sub

    Public Function GetButtonImage(ByVal control As Office.IRibbonControl) As System.Drawing.Bitmap
        Select Case control.Id
            Case "btnRibbonXPS", "btnBackStageXPS"
                Return My.Resources.XPS
            Case "btnRibbonPDF", "btnBackStagePDF"
                Return My.Resources.PDF
            Case Else
                Return Nothing
        End Select
    End Function

    Public Sub Checked(ByVal control As Office.IRibbonControl, ByVal value As Boolean)
        Select Case control.Id
            Case "chkPDFDocProps"
                m_pdfDocumentProperties = value
            Case "chkPDFDocStructure"
                m_pdfDocumentStructure = value
            Case "chkXPSDocProps"
                m_xpsDocumentProperties = value
            Case "chkXPSDocStructure"
                m_xpsDocumentStructure = value
        End Select
    End Sub

    Public Function IsChecked(ByVal control As Office.IRibbonControl) As Boolean
        Select Case control.Id
            Case "chkPDFDocProps"
                Return m_pdfDocumentProperties
            Case "chkPDFDocStructure"
                Return m_pdfDocumentStructure
            Case "chkXPSDocProps"
                Return m_xpsDocumentProperties
            Case "chkXPSDocStructure"
                Return m_xpsDocumentStructure
            Case Else
                Return False
        End Select
    End Function

    Public Sub ExportDocument(ByVal control As Office.IRibbonControl)
        Select Case control.Id
            Case "btnRibbonXPS", "btnBackStageXPS"
                PerformExport(".xps", WdExportFormat.wdExportFormatXPS, m_xpsDocumentProperties, m_xpsDocumentStructure)
            Case "btnRibbonPDF", "btnBackStagePDF"
                PerformExport(".pdf", WdExportFormat.wdExportFormatPDF, m_pdfDocumentProperties, m_pdfDocumentStructure)
        End Select
    End Sub

    Private Sub PerformExport(ByVal extension As String, ByVal format As WdExportFormat, ByVal exportProperties As Boolean, ByVal exportStructure As Boolean)
        Dim fileName = Globals.ThisAddIn.Application.ActiveDocument.FullName.Replace(".docx", extension)

        Globals.ThisAddIn.Application.ActiveDocument.ExportAsFixedFormat(
            fileName,
            format,
            IncludeDocProps:=exportProperties,
            DocStructureTags:=exportStructure)

        MessageBox.Show("Export Complete")
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
