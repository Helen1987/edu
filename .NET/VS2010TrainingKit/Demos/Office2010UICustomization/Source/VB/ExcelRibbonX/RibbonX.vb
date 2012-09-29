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

Imports System.Globalization

'TODO:  Follow these steps to enable the Ribbon (XML) item:

'1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

'Protected Overrides Function CreateRibbonExtensibilityObject() As Microsoft.Office.Core.IRibbonExtensibility
'    Return New RibbonX()
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

    Private ExcelApplication As Microsoft.Office.Interop.Excel.Application  ' Excel
    Private StartColumn As String = "C" ' Start column of the contextual data
    Private StartRow As String = "5" ' Start row of the contextual data
    Private EndColumn As String = "G" ' End column of the contextual data
    Private EndRow As String = "8" ' End row of the contextual data
    Private InsideData As Boolean = False ' Is selection inside data?
    Private PlaceShown As Boolean = True ' Is the place shown?
    Private CurrentSpecStage As Integer = 1 ' What stage is the spec at right now?
    Private ReadyToExitDesignPhase As Boolean = False ' Can the design phase be exited?
    Private Today As DateTime = System.DateTime.Today.Date ' Today's date
    Private CurrentDesignDate As DateTime = System.DateTime.Today.Date.AddDays(-2) ' Design due date as a date
    Private ProductionDate As DateTime = DateTime.Parse("May 14, 2009", CultureInfo.InvariantCulture) ' Production due date as date
    Private OpenDesignIssues As Boolean = True ' Are there any open design issues

    Public Sub New()
    End Sub
#Region "IRibbonExtensibility Members"
    Public Function GetCustomUI(ByVal ribbonID As String) As String Implements Office.IRibbonExtensibility.GetCustomUI
        Return GetResourceText("ExcelRibbonX.RibbonX.xml")
    End Function
#End Region

#Region "Ribbon Callbacks"
    'Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1.
    Public Sub Ribbon_Load(ByVal ribbonUI As Office.IRibbonUI)
        Me.ribbon = ribbonUI
        ExcelApplication = CType(Globals.ThisAddIn.Application, Microsoft.Office.Interop.Excel.Application)
        AddHandler ExcelApplication.SheetSelectionChange, AddressOf excelApplication_SheetSelectionChange
    End Sub

    ' GetVisible callback for the Process tab and appropriate context menu items
    Public Function GetProcessToolsVisibility(ByVal control As Office.IRibbonControl) As Boolean
        Return InsideData
    End Function

    ' Negated GetVisible callback for the Process tab and appropriate context menu items
    Public Function GetNegatedProcessToolsVisibility(ByVal control As Office.IRibbonControl) As Boolean
        Return Not InsideData
    End Function

    ' GetPressed callback for Harmonic toggle button
    Public Function GetHarmonicPressedState(ByVal control As Office.IRibbonControl) As Boolean
        Return True
    End Function

    ' GetText callback for Shaft Radius text-box
    Public Function GetShaftRadiusText(ByVal control As Office.IRibbonControl) As String
        Return "2.33"
    End Function

    ' GetText callback for Shaft Stress text-box
    Public Function GetShaftStressText(ByVal control As Office.IRibbonControl) As String
        Return "925.45"
    End Function

    ' GetText callback for Shaft Angle text-box
    Public Function GetShaftAngleText(ByVal control As Office.IRibbonControl) As String
        Return "48"
    End Function

    ' GetText callback for Wheel Radius text-box
    Public Function GetWheelRadiusText(ByVal control As Office.IRibbonControl) As String
        Return "12.80"
    End Function

    ' GetText callback for Wheel Horizontal text-box
    Public Function GetWheelHorizontalText(ByVal control As Office.IRibbonControl) As String
        Return "2.44"
    End Function

    ' GetText callback for Wheel Vertical text-box
    Public Function GetWheelVerticalText(ByVal control As Office.IRibbonControl) As String
        Return "2.44"
    End Function

    ' Get ID callback for Type drop-down
    Public Function GetTypeID(ByVal control As Office.IRibbonControl) As String
        Return "ItemHelical"
    End Function

    ' Get ID callback for Pitch drop-down
    Public Function GetPitchID(ByVal control As Office.IRibbonControl) As String
        Return "ItemDiametral"
    End Function

    ' Get ID callback for Material drop-down
    Public Function GetMaterialID(ByVal control As Office.IRibbonControl) As String
        Return "ItemSteel"
    End Function

    ' Return Risk gallery item count
    Public Function GetRiskItemCount(ByVal control As Office.IRibbonControl) As Long
        Return 6
    End Function

    ' GetImage callback for the Risk gallery
    Public Function GetRiskImage(ByVal control As Office.IRibbonControl) As System.Drawing.Bitmap
        Return My.Resources.risksIcon
    End Function

    ' Return appropriate Risk gallery images
    Public Function GetRiskItemImage(ByVal control As Office.IRibbonControl, ByVal index As Integer) As System.Drawing.Bitmap
        If index = 0 Then
            Return My.Resources.riskNone
        ElseIf index = 1 Then
            Return My.Resources.riskLow
        ElseIf index = 2 Then
            Return My.Resources.riskLowToMed
        ElseIf index = 3 Then
            Return My.Resources.riskMed
        ElseIf index = 4 Then
            Return My.Resources.riskMedToHigh
        Else
            Return My.Resources.riskHigh
        End If
    End Function

    Public Function OverrideInfoLabel(ByVal control As Office.IRibbonControl) As String
        Return "HELP"
    End Function

    ' GetVisible callback for the OutSpace place
    Public Function GetPlaceVisibility(ByVal control As Office.IRibbonControl) As Boolean
        Return PlaceShown
    End Function

    ' Get the title for the top-most slab
    Public Function GetSpecBasicsLabel(ByVal control As Office.IRibbonControl) As String
        If CurrentSpecStage = 1 Then
            Return ("Contoso Specification Details - Design Phase")
        Else
            Return ("Contoso Specification Details - Legal Review Phase")
        End If
    End Function

    ' Get the label text for the hero button in the top-most slab
    Public Function GetExitPhaseButtonLabel(ByVal control As Office.IRibbonControl) As String
        If CurrentSpecStage = 1 Then
            Return ("Exit Design Phase")
        Else
            Return ("Exit Legal Review")
        End If
    End Function

    ' Get the icon for the hero button in the top-most slab
    Public Function GetExitPhaseButtonImage(ByVal control As Office.IRibbonControl) As String
        If CurrentSpecStage = 1 Then
            Return ("FileCompatibilityChecker")
        Else
            Return ("CitationInsert")
        End If
    End Function

    ' Switch the spec phase and invalidate
    Public Sub SwitchPhase(ByVal control As Office.IRibbonControl)
        ' Advance to the 2nd stage
        If CurrentSpecStage = 1 Then
            CurrentSpecStage = 2
            ' Or, reset the add-in
        Else
            CurrentSpecStage = 1
            ReadyToExitDesignPhase = False
            CurrentDesignDate = Today.AddDays(-2)
            CurrentDesignDate = CurrentDesignDate
            OpenDesignIssues = True
            System.Windows.Forms.MessageBox.Show("You have finished legal review!", "Exit Legal Review")
        End If

        ribbon.Invalidate()
    End Sub

    ' Get the enalbed state for the hero button in the top-most slab
    Public Function GetExitPhaseButtonEnabledState(ByVal contro As Office.IRibbonControl) As Boolean
        Return (ReadyToExitDesignPhase AndAlso (Not IsDesignDateOverdue()))
    End Function

    ' Get visibility of the Schedule For Design Review slab
    Public Function GetScheduleForDesignPhaseVisibitliy(ByVal control As Office.IRibbonControl) As Boolean
        If CurrentSpecStage = 1 Then
            Return (True)
        Else
            Return (False)
        End If
    End Function

    ' Get the loudness of the Schedule For Design Review slab
    Public Function GetScheduleForDesignPhaseLoudness(ByVal control As Office.IRibbonControl) As Office.BackstageGroupStyle
        If IsDesignDateOverdue() Then
            Return Office.BackstageGroupStyle.BackstageGroupStyleError
        Else
            Return Office.BackstageGroupStyle.BackstageGroupStyleNormal
        End If
    End Function

    ' Get the helper text for the Schedule For Design Review slab
    Public Function GetScheduleForDesignPhaseHelperText(ByVal contol As Office.IRibbonControl) As String
        If IsDesignDateOverdue() Then
            Return ("This document is marked as in the design phase even though the Design Due date has passed.")
        Else
            Return ("The Design Due date is in " & (CurrentDesignDate.Subtract(Today)).Days & " days.")
        End If
    End Function

    ' Extend design due date
    Public Sub ExtendDesignDueDate(ByVal control As Office.IRibbonControl)
        CurrentDesignDate = CurrentDesignDate.AddDays(7)
        ribbon.Invalidate()
    End Sub

    ' Get the design due date
    Public Function GetDesignDueDate(ByVal control As Office.IRibbonControl) As String
        Return CurrentDesignDate.ToShortDateString()
    End Function

    ' Get the icon for the desgin due date
    Public Function GetDesignDateImage(ByVal control As Office.IRibbonControl) As String
        If IsDesignDateOverdue() = True Then
            Return ("XDMoreDetailsAlert")
        Else
            Return ("NewAppointment")
        End If
    End Function

    ' Is the design date overdue?
    Public Function IsDesignDateOverdue() As Boolean
        If CurrentDesignDate.CompareTo(Today) < 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    ' Get the prodcution due date
    Public Function GetProductionDateDue(ByVal control As Office.IRibbonControl) As String
        Return ProductionDate.ToShortDateString()
    End Function

    ' Update design date
    Public Sub UpdateDesignDate(ByVal control As Office.IRibbonControl, ByVal value As String)
        Try
            CurrentDesignDate = DateTime.Parse(value, CultureInfo.InvariantCulture)
            ribbon.Invalidate()
        Catch
            System.Windows.Forms.MessageBox.Show("The date you entered is invalid.  Please use M/D/YYYY format.", "Invalid Date Entered")
            ribbon.Invalidate()
        End Try
    End Sub

    ' Get visibility for the Open Design Issues slab
    Public Function GetOpenDesignIssuesVisibility(ByVal control As Office.IRibbonControl) As Boolean
        If CurrentSpecStage = 1 Then
            Return (True)
        Else
            Return (False)
        End If
    End Function

    ' Get loudness for the Open Design Issues slab
    Public Function GetOpenDesignIssuesLoudness(ByVal control As Office.IRibbonControl) As Office.BackstageGroupStyle
        If GetOpenDesignIssues() Then
            Return Office.BackstageGroupStyle.BackstageGroupStyleError
        Else
            Return Office.BackstageGroupStyle.BackstageGroupStyleNormal
        End If
    End Function

    ' Get visibility info for controls that keep track of whether there are any existing issues
    Public Function GetVisibleIssues(ByVal control As Office.IRibbonControl) As Integer
        If GetOpenDesignIssues() Then
            Return 2
        Else
            Return 0
        End If
    End Function

    ' Are there any open design issues?
    Public Function GetOpenDesignIssues() As Boolean
        Return OpenDesignIssues
    End Function

    ' Get the helper text for the Open Design Issues slab
    Public Function GetOpenDesignIssuesHelperText(ByVal control As Office.IRibbonControl) As String
        If GetOpenDesignIssues() Then
            Return ("All of the open issues must be resolved before moving the specification to the Legal Review phase.")
        Else
            Return ("There are no open design issues.")
        End If
    End Function

    ' Resolve open issues
    Public Sub ResolveOpenIssues(ByVal control As Office.IRibbonControl)
        OpenDesignIssues = False
        ReadyToExitDesignPhase = True
        ribbon.Invalidate()
    End Sub

    ' Execute the built-in "Protect Sheet" button
    Public Sub ExecuteSheetProtect(ByVal control As Office.IRibbonControl)
        ExcelApplication.CommandBars.ExecuteMso("SheetProtect")
    End Sub

    ' Get visibility info for the Schedule For Legal Review slab
    Public Function GetScheduleForLegalReviewVisibitliy(ByVal control As Office.IRibbonControl) As Boolean
        If CurrentSpecStage = 2 Then
            Return (True)
        Else
            Return (False)
        End If
    End Function

    ' Get visibility info for the Accessibility slab
    Public Function GetAccessibilityIssuesVisibility(ByVal control As Office.IRibbonControl) As Boolean
        If CurrentSpecStage = 2 Then
            Return (True)
        Else
            Return (False)
        End If
    End Function

    ' Get visibility info for the Worldwide Readiness slab
    Public Function GetWorldwideVisibility(ByVal control As Office.IRibbonControl) As Boolean
        If CurrentSpecStage = 2 Then
            Return (True)
        Else
            Return (False)
        End If
    End Function

    ' Get visibility info for the Patent Documentation slab
    Public Function GetPatentsVisibility(ByVal control As Office.IRibbonControl) As Boolean
        If CurrentSpecStage = 2 Then
            Return (True)
        Else
            Return (False)
        End If
    End Function

    ' Return appropriate TeamSpecs Image, based on the current spec stage
    Public Function GetTeamSpecsImage(ByVal control As Office.IRibbonControl) As System.Drawing.Bitmap
        If CurrentSpecStage = 1 Then
            Return My.Resources.teamSpecStatus1
        Else
            Return My.Resources.teamSpecStatus2
        End If
    End Function

    ' Return the stretcher image for the 1st column
    Public Function GetStretcherImage(ByVal control As Office.IRibbonControl) As System.Drawing.Bitmap
        Return My.Resources.stretcher
    End Function

#End Region

#Region "Helpers"
    ' Switch tabs based on user context
    Private Sub excelApplication_SheetSelectionChange(ByVal Sheet As Object, ByVal Target As Microsoft.Office.Interop.Excel.Range)
        Dim CurrentSheet As Microsoft.Office.Interop.Excel.Worksheet = CType(Sheet, Microsoft.Office.Interop.Excel.Worksheet)
        Dim CurrentCell As Microsoft.Office.Interop.Excel.Range = CType(CurrentSheet.Application.ActiveWindow.RangeSelection, Microsoft.Office.Interop.Excel.Range)
        Dim SelectedRange As String = CurrentCell.Address(False, False, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, False, CurrentCell)
        Dim SelectedColumn As String = SelectedRange.Substring(0, 1)
        Dim SelectedRow As String = SelectedRange.Substring(1, 1)
        If SelectedRange.Length.CompareTo(2) > 0 Then
            If InsideData = True Then
                InsideData = False
                ribbon.Invalidate()
                ribbon.ActivateTabMso("TabHome")
            End If
        Else
            If ((SelectedColumn.CompareTo(StartColumn) < 0) OrElse (SelectedColumn.CompareTo(EndColumn) > 0) OrElse (SelectedRow.CompareTo(StartRow) < 0) OrElse (SelectedRow.CompareTo(EndRow) > 0)) Then
                If InsideData = True Then
                    InsideData = False
                    ribbon.Invalidate()
                    ribbon.ActivateTabMso("TabHome")
                End If
            Else
                If InsideData = False Then
                    InsideData = True
                    ribbon.Invalidate()
                    ribbon.ActivateTab("TabParts")
                End If
            End If
        End If
    End Sub

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

    Public Function GetStaticText(ByVal control As Office.IRibbonControl) As String
        Select Case control.Id
            Case "TitleEditBox"
                Return "Flexible Bracket"
            Case "DesignerEditBox"
                Return "Clay Satterfield"
            Case "EngineerEditBox"
                Return "Mirko Mandic"
            Case "TeamEditBox"
                Return "Design"
            Case "CostEditBox"
                Return "$14,300"
            Case "ReviewEditBox"
                Return "11/23/2008"
            Case "CourtDateEditBox"
                Return "11/30/2008"
            Case "ProductionLegalEditBox"
                Return "12/04/2008"
            Case Else
                Return "DefaultData"
        End Select
    End Function
#End Region

End Class
