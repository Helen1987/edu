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
using System.Linq;
using System.Text;

using Microsoft.Office.Core;

namespace ExportAddIn
{
    public class ExportProperties
    {       
        public bool XpsEnabled
        {
            get
            {                
                return GetProperty<bool>("XpsEnabled");
            }
            set
            {
                SetProperty("XpsEnabled", MsoDocProperties.msoPropertyTypeBoolean, value);
            }
        }

        public string XpsExportPath
        {
            get
            {
                return GetProperty<string>("XpsExportPath");
            }
            set
            {
                SetProperty("XpsExportPath", MsoDocProperties.msoPropertyTypeString, value);
            }
        }

        public bool PdfEnabled
        {
            get
            {
                return GetProperty<bool>("PdfEnabled");
            }
            set
            {
                SetProperty("PdfEnabled", MsoDocProperties.msoPropertyTypeBoolean, value);
            }
        }

        public string PdfExportPath
        {
            get
            {
                return GetProperty<string>("PdfExportPath");
            }
            set
            {
                SetProperty("PdfExportPath", MsoDocProperties.msoPropertyTypeString, value);
            }
        }

        private T GetProperty<T>(string propertyName)
        {
            DocumentProperty property = FindProperty(propertyName);
            if (property == null)
                return default(T);
            else
                return (T)property.Value;
        }

        private void SetProperty(string propertyName, MsoDocProperties propertyType, object value)
        {
            DocumentProperty property = FindProperty(propertyName);
            if (property == null)
                AddProperty(propertyName, propertyType, value);
            else
                property.Value = value;
        }

        private DocumentProperty FindProperty(string propertyName)
        {
            DocumentProperties properties =
                Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties;
            return properties.Cast<DocumentProperty>().FirstOrDefault(n => n.Name == propertyName);
        }

        private void AddProperty(string propertyName, MsoDocProperties propertyType, object value)
        {   
            DocumentProperties properties =
                Globals.ThisAddIn.Application.ActiveDocument.CustomDocumentProperties;
            properties.Add(propertyName, false, propertyType, value);
        }

    }
}
