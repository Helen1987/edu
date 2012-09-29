// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using System.Globalization;
using ExcelRibbonX.Properties;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new RibbonX();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace ExcelRibbonX
{
    [ComVisible(true)]
    public class RibbonX : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private Microsoft.Office.Interop.Excel.Application ExcelApplication; // Excel
        private string StartColumn = "C"; // Start column of the contextual data
        private string StartRow = "5"; // Start row of the contextual data
        private string EndColumn = "G"; // End column of the contextual data
        private string EndRow = "8"; // End row of the contextual data
        private bool InsideData = false; // Is selection inside data?
        private bool PlaceShown = true; // Is the place shown?
        private int CurrentSpecStage = 1; // What stage is the spec at right now?
        private bool ReadyToExitDesignPhase = false; // Can the design phase be exited?
        private DateTime Today = System.DateTime.Today.Date; // Today's date
        private DateTime CurrentDesignDate = System.DateTime.Today.Date.AddDays(-2); // Design due date as a date
        private DateTime ProductionDate = DateTime.Parse("May 14, 2009", CultureInfo.InvariantCulture); // Production due date as date
        private bool OpenDesignIssues = true; // Are there any open design issues

        public RibbonX()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ExcelRibbonX.RibbonX.xml");
        }

        #endregion

        #region Ribbon Callbacks

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
            ExcelApplication = (Microsoft.Office.Interop.Excel.Application)Globals.ThisAddIn.Application;
            ExcelApplication.SheetSelectionChange += new Microsoft.Office.Interop.Excel.AppEvents_SheetSelectionChangeEventHandler(excelApplication_SheetSelectionChange);
        }

        // GetVisible callback for the Process tab and appropriate context menu items
        public bool GetProcessToolsVisibility(Office.IRibbonControl control)
        {
            return InsideData;
        }

        // Negated GetVisible callback for the Process tab and appropriate context menu items
        public bool GetNegatedProcessToolsVisibility(Office.IRibbonControl control)
        { return (!InsideData); }

        // GetPressed callback for Harmonic toggle button
        public bool GetHarmonicPressedState(Office.IRibbonControl control)
        { return true; }

        // GetText callback for Shaft Radius text-box
        public String GetShaftRadiusText(Office.IRibbonControl control)
        { return "2.33"; }

        // GetText callback for Shaft Stress text-box
        public String GetShaftStressText(Office.IRibbonControl control)
        { return "925.45"; }

        // GetText callback for Shaft Angle text-box
        public String GetShaftAngleText(Office.IRibbonControl control)
        { return "48"; }

        // GetText callback for Wheel Radius text-box
        public String GetWheelRadiusText(Office.IRibbonControl control)
        { return "12.80"; }

        // GetText callback for Wheel Horizontal text-box
        public String GetWheelHorizontalText(Office.IRibbonControl control)
        { return "2.44"; }

        // GetText callback for Wheel Vertical text-box
        public String GetWheelVerticalText(Office.IRibbonControl control)
        { return "2.44"; }

        // Get ID callback for Type drop-down
        public string GetTypeID(Office.IRibbonControl control)
        { return "ItemHelical"; }

        // Get ID callback for Pitch drop-down
        public string GetPitchID(Office.IRibbonControl control)
        { return "ItemDiametral"; }

        // Get ID callback for Material drop-down
        public string GetMaterialID(Office.IRibbonControl control)
        { return "ItemSteel"; }

        // Return Risk gallery item count
        public long GetRiskItemCount(Office.IRibbonControl control)
        { return 6; }

        // GetImage callback for the Risk gallery
        public System.Drawing.Bitmap GetRiskImage(Office.IRibbonControl control)
        { return Resources.risksIcon; }

        // Return appropriate Risk gallery images
        public System.Drawing.Bitmap GetRiskItemImage(Office.IRibbonControl control, int index)
        {
            if (index == 0) { return Resources.riskNone; }
            else if (index == 1) { return Resources.riskLow; }
            else if (index == 2) { return Resources.riskLowToMed; }
            else if (index == 3) { return Resources.riskMed; }
            else if (index == 4) { return Resources.riskMedToHigh; }
            else { return Resources.riskHigh; }
        }

        public String OverrideInfoLabel(Office.IRibbonControl control) { return "HELP"; }

        // GetVisible callback for the OutSpace place
        public bool GetPlaceVisibility(Office.IRibbonControl control) { return PlaceShown; }

        // Get the title for the top-most slab
        public String GetSpecBasicsLabel(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 1)
            { return ("Contoso Specification Details - Design Phase"); }
            else
            { return ("Contoso Specification Details - Legal Review Phase"); }
        }

        // Get the label text for the hero button in the top-most slab
        public String GetExitPhaseButtonLabel(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 1)
            { return ("Exit Design Phase"); }
            else
            { return ("Exit Legal Review"); }
        }

        // Get the icon for the hero button in the top-most slab
        public String GetExitPhaseButtonImage(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 1)
            { return ("FileCompatibilityChecker"); }
            else
            { return ("CitationInsert"); }
        }

        // Switch the spec phase and invalidate
        public void SwitchPhase(Office.IRibbonControl control)
        {
            // Advance to the 2nd stage
            if (CurrentSpecStage == 1)
            {
                CurrentSpecStage = 2;
            }
            // Or, reset the add-in
            else
            {
                CurrentSpecStage = 1;
                ReadyToExitDesignPhase = false;
                CurrentDesignDate = CurrentDesignDate = Today.AddDays(-2);
                OpenDesignIssues = true;
                System.Windows.Forms.MessageBox.Show("You have finished legal review!", "Exit Legal Review");
            }
            ribbon.Invalidate();
        }

        // Get the enalbed state for the hero button in the top-most slab
        public bool GetExitPhaseButtonEnabledState(Office.IRibbonControl contro)
        {
            return (ReadyToExitDesignPhase && !IsDesignDateOverdue());
        }

        // Get visibility of the Schedule For Design Review slab
        public bool GetScheduleForDesignPhaseVisibitliy(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 1)
            { return (true); }
            else
            { return (false); }
        }

        // Get the loudness of the Schedule For Design Review slab
        public Office.BackstageGroupStyle GetScheduleForDesignPhaseLoudness(Office.IRibbonControl control)
        {
            if (IsDesignDateOverdue()) { return Office.BackstageGroupStyle.BackstageGroupStyleError; }
            else { return Office.BackstageGroupStyle.BackstageGroupStyleNormal; }
        }

        // Get the helper text for the Schedule For Design Review slab
        public String GetScheduleForDesignPhaseHelperText(Office.IRibbonControl contol)
        {
            if (IsDesignDateOverdue())
            {
                return ("This document is marked as in the design phase even though the Design Due date has passed.");
            }
            else
            {
                return ("The Design Due date is in " + (CurrentDesignDate.Subtract(Today)).Days + " days.");
            }
        }

        // Extend design due date
        public void ExtendDesignDueDate(Office.IRibbonControl control)
        {
            CurrentDesignDate = CurrentDesignDate.AddDays(7);
            ribbon.Invalidate();
        }

        // Get the design due date
        public String GetDesignDueDate(Office.IRibbonControl control)
        {
            return CurrentDesignDate.ToShortDateString();
        }

        // Get the icon for the desgin due date
        public String GetDesignDateImage(Office.IRibbonControl control)
        {
            if (IsDesignDateOverdue() == true)
            {
                return ("XDMoreDetailsAlert");
            }
            else
            {
                return ("NewAppointment");
            }
        }

        // Is the design date overdue?
        public bool IsDesignDateOverdue()
        {
            if (CurrentDesignDate.CompareTo(Today) < 0)
            { return true; }
            else { return false; }
        }


        // Get the prodcution due date
        public String GetProductionDateDue(Office.IRibbonControl control)
        {
            return ProductionDate.ToShortDateString();
        }

        // Update design date
        public void UpdateDesignDate(Office.IRibbonControl control, String value)
        {
            try
            {
                CurrentDesignDate = DateTime.Parse(value, CultureInfo.InvariantCulture);
                ribbon.Invalidate();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("The date you entered is invalid.  Please use M/D/YYYY format.", "Invalid Date Entered");
                ribbon.Invalidate();
            }
        }

        // Get visibility for the Open Design Issues slab
        public bool GetOpenDesignIssuesVisibility(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 1)
            { return (true); }
            else
            { return (false); }
        }

        // Get loudness for the Open Design Issues slab
        public Office.BackstageGroupStyle GetOpenDesignIssuesLoudness(Office.IRibbonControl control)
        {
            if (GetOpenDesignIssues()) { return Office.BackstageGroupStyle.BackstageGroupStyleError; }
            else { return Office.BackstageGroupStyle.BackstageGroupStyleNormal; }
        }

        // Get visibility info for controls that keep track of whether there are any existing issues
        public int GetVisibleIssues(Office.IRibbonControl control)
        {
            if (GetOpenDesignIssues()) { return 2; }
            else { return 0; }
        }

        // Are there any open design issues?
        public bool GetOpenDesignIssues()
        {
            return OpenDesignIssues;
        }

        // Get the helper text for the Open Design Issues slab
        public String GetOpenDesignIssuesHelperText(Office.IRibbonControl control)
        {
            if (GetOpenDesignIssues())
            {
                return ("All of the open issues must be resolved before moving the specification to the Legal Review phase.");
            }
            else
            {
                return ("There are no open design issues.");
            }
        }

        // Resolve open issues
        public void ResolveOpenIssues(Office.IRibbonControl control)
        {
            OpenDesignIssues = false;
            ReadyToExitDesignPhase = true;
            ribbon.Invalidate();
        }

        // Execute the built-in "Protect Sheet" button
        public void ExecuteSheetProtect(Office.IRibbonControl control) { ExcelApplication.CommandBars.ExecuteMso("SheetProtect"); }

        // Get visibility info for the Schedule For Legal Review slab
        public bool GetScheduleForLegalReviewVisibitliy(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 2)
            { return (true); }
            else
            { return (false); }
        }

        // Get visibility info for the Accessibility slab
        public bool GetAccessibilityIssuesVisibility(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 2)
            { return (true); }
            else
            { return (false); }
        }

        // Get visibility info for the Worldwide Readiness slab
        public bool GetWorldwideVisibility(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 2)
            { return (true); }
            else
            { return (false); }
        }

        // Get visibility info for the Patent Documentation slab
        public bool GetPatentsVisibility(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 2)
            { return (true); }
            else
            { return (false); }
        }

        // Return appropriate TeamSpecs Image, based on the current spec stage
        public System.Drawing.Bitmap GetTeamSpecsImage(Office.IRibbonControl control)
        {
            if (CurrentSpecStage == 1)
            {
                return Resources.teamSpecStatus1;
            }
            else
            {
                return Resources.teamSpecStatus2;
            }
        }

        // Return the stretcher image for the 1st column
        public System.Drawing.Bitmap GetStretcherImage(Office.IRibbonControl control)
        {
            return Resources.stretcher;
        }


        #endregion

        #region Helpers
        // Switch tabs based on user context
        void excelApplication_SheetSelectionChange(object Sheet, Microsoft.Office.Interop.Excel.Range Target)
        {
            Microsoft.Office.Interop.Excel.Worksheet CurrentSheet = (Microsoft.Office.Interop.Excel.Worksheet)Sheet;
            Microsoft.Office.Interop.Excel.Range CurrentCell = (Microsoft.Office.Interop.Excel.Range)CurrentSheet.Application.ActiveWindow.RangeSelection;
            String SelectedRange = CurrentCell.get_Address(false, false, Microsoft.Office.Interop.Excel.XlReferenceStyle.xlA1, false, CurrentCell);
            String SelectedColumn = SelectedRange.Substring(0, 1);
            String SelectedRow = SelectedRange.Substring(1, 1);
            if (SelectedRange.Length.CompareTo(2) > 0)
            {
                if (InsideData == true)
                {
                    InsideData = false;
                    ribbon.Invalidate();
                    ribbon.ActivateTabMso("TabHome");
                }
            }
            else
            {
                if (((SelectedColumn.CompareTo(StartColumn) < 0) || (SelectedColumn.CompareTo(EndColumn) > 0) || (SelectedRow.CompareTo(StartRow) < 0) || (SelectedRow.CompareTo(EndRow) > 0)))
                {
                    if (InsideData == true)
                    {
                        InsideData = false;
                        ribbon.Invalidate();
                        ribbon.ActivateTabMso("TabHome");
                    }
                }
                else
                {
                    if (InsideData == false)
                    {
                        InsideData = true;
                        ribbon.Invalidate();
                        ribbon.ActivateTab("TabParts");
                    }
                }
            }
        }

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        public string GetStaticText(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "TitleEditBox":
                    return "Flexible Bracket";
                case "DesignerEditBox":
                    return "Clay Satterfield";
                case "EngineerEditBox":
                    return "Mirko Mandic";
                case "TeamEditBox":
                    return "Design";
                case "CostEditBox":
                    return "$14,300";

                case "ReviewEditBox":
                    return "11/23/2008";
                case "CourtDateEditBox":
                    return "11/30/2008";
                case "ProductionLegalEditBox":
                    return "12/04/2008";
                default:
                    return "DefaultData";


            }
        }

        #endregion
    }
}
