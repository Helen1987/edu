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
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UsingWCFServices.WebServiceProxies
{
    public partial class SalesOrderHeader : IEditableObject
    {
        SalesOrderHeader _OriginalObject;
        bool _Editing;

        public void BeginEdit()
        {
            if (!_Editing)
            {
                _Editing = true;
                _OriginalObject = this.MemberwiseClone() as SalesOrderHeader;
            }
        }

        public void CancelEdit()
        {
            if (_Editing)
            {
                Comment = _OriginalObject.Comment;
                ShipDate = _OriginalObject.ShipDate;
                _Editing = false;
            }
        }

        public void EndEdit()
        {
            if (_Editing)
            {
                _Editing = false;
                _OriginalObject = null;
            }
        }

    }
}
