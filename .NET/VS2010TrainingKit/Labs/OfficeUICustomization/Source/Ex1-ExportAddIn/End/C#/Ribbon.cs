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
using Microsoft.Office.Interop.Word;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace ExportAddIn
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        private ExportProperties m_properties = new ExportProperties();

        public Ribbon()
        {
        }

        public System.Drawing.Bitmap GetButtonImage(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "btnRibbonXPS":
                case "btnBackStageXPS":
                    return Properties.Resources.XPS;
                case "btnRibbonPDF":
                case "btnBackStagePDF":
                    return Properties.Resources.PDF;
                default:
                    return null;
            }
        }

        public bool GetEnable(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "btnRibbonXPS":
                case "btnBackStageXPS":
                case "txtXPSPath":
                    return m_properties.XpsEnabled;
                case "btnRibbonPDF":
                case "btnBackStagePDF":
                case "txtPDFPath":
                    return m_properties.PdfEnabled;
                default:
                    return false;
            }
        }

        public bool IsEnableChecked(Office.IRibbonControl control)
        {
            if (control.Id == "chkEnableXPS")
                return m_properties.XpsEnabled;
            else if (control.Id == "chkEnablePDF")
                return m_properties.PdfEnabled;
            else
                return false;
        }

        public void EnableChecked(Office.IRibbonControl control, bool value)
        {
            if (control.Id == "chkEnableXPS")
            {
                m_properties.XpsEnabled = value;
                ribbon.InvalidateControl("btnRibbonXPS");
                ribbon.InvalidateControl("btnBackStageXPS");
                ribbon.InvalidateControl("txtXPSPath");
            }
            else if (control.Id == "chkEnablePDF")
            {
                m_properties.PdfEnabled = value;
                ribbon.InvalidateControl("btnRibbonPDF");
                ribbon.InvalidateControl("btnBackStagePDF");
                ribbon.InvalidateControl("txtPDFPath");
            }
        }

        public string GetExportPath(Office.IRibbonControl control)
        {
            if (control.Id == "txtXPSPath")
                return m_properties.XpsExportPath;
            else if (control.Id == "txtPDFPath")
                return m_properties.PdfExportPath;
            else
                return string.Empty;
        }

        public void SetExportPath(Office.IRibbonControl control, string value)
        {
            if (control.Id == "txtXPSPath")
                m_properties.XpsExportPath = value;
            else if (control.Id == "txtPDFPath")
                m_properties.PdfExportPath = value;
        }

        public void ExportDocument(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "btnRibbonXPS":
                case "btnBackStageXPS":
                    Globals.ThisAddIn.Application.ActiveDocument.
                        ExportAsFixedFormat(
                            m_properties.XpsExportPath,
                            WdExportFormat.wdExportFormatXPS);
                    break;
                case "btnRibbonPDF":
                case "btnBackStagePDF":
                    Globals.ThisAddIn.Application.ActiveDocument.
                        ExportAsFixedFormat(
                            m_properties.PdfExportPath,
                            WdExportFormat.wdExportFormatPDF);
                    break;
            }
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ExportAddIn.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

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

        #endregion
    }
}
