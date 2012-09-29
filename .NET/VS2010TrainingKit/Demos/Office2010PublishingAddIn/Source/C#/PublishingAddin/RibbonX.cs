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
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

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


namespace PublishingAddin
{
    [ComVisible(true)]
    public class RibbonX : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        private bool m_pdfDocumentProperties = false;
        private bool m_xpsDocumentProperties = false;
        private bool m_pdfDocumentStructure = false;
        private bool m_xpsDocumentStructure = false;

        public RibbonX()
        {

        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("PublishingAddin.RibbonX.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, select the Ribbon XML item in Solution Explorer and then press F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
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
        
        public void Checked(Office.IRibbonControl control, bool value)
        {
            switch (control.Id)
            {
                case "chkPDFDocProps":
                    m_pdfDocumentProperties = value;
                    break;
                case "chkPDFDocStructure":
                    m_pdfDocumentStructure = value;
                    break;
                case "chkXPSDocProps":
                    m_xpsDocumentProperties = value;
                    break;
                case "chkXPSDocStructure":
                    m_xpsDocumentStructure = value;
                    break;
            }
        }

        public bool IsChecked(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "chkPDFDocProps":
                    return m_pdfDocumentProperties;
                case "chkPDFDocStructure":
                    return m_pdfDocumentStructure;
                case "chkXPSDocProps":
                    return m_xpsDocumentProperties;
                case "chkXPSDocStructure":
                    return m_xpsDocumentStructure;
                default:
                    return false;
            }
        }
        
        public void ExportDocument(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "btnRibbonXPS":
                case "btnBackStageXPS":
                    PerformExport(".xps", WdExportFormat.wdExportFormatXPS, m_xpsDocumentProperties, m_xpsDocumentStructure);
                    break;
                case "btnRibbonPDF":
                case "btnBackStagePDF":
                    PerformExport(".pdf", WdExportFormat.wdExportFormatPDF, m_pdfDocumentProperties, m_pdfDocumentStructure);
                    break;
            }
        }

        private void PerformExport(string extension, Word.WdExportFormat format, bool exportProperties, bool exportStructure)
        {
            string fileName = Globals.ThisAddIn.Application.ActiveDocument.FullName.Replace(".docx", extension);

            Globals.ThisAddIn.Application.ActiveDocument.ExportAsFixedFormat(
                fileName,
                format,
                IncludeDocProps: exportProperties,
                DocStructureTags: exportStructure);

            MessageBox.Show("Export Complete");
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
