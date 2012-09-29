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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace ContosoWebParts.ListInspector
{
    public partial class ListInspectorUserControl : UserControl
    {
        protected Guid selectedListId = Guid.Empty;
        protected bool updateListProperties = false;

        protected void lslLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedListId = new Guid(lstLists.SelectedValue);
            updateListProperties = true;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if ((lstLists.SelectedIndex > -1) && (!updateListProperties))
            {
                selectedListId = new Guid(lstLists.SelectedValue);
            }

            lstLists.Items.Clear();
            SPWeb site = SPContext.Current.Web;
            foreach (SPList list in site.Lists)
            {
                ListItem listItem = new ListItem(list.Title, list.ID.ToString());
                lstLists.Items.Add(listItem);
            }

            if (selectedListId != Guid.Empty)
            {
                lstLists.Items.FindByValue(selectedListId.ToString()).Selected = true;
            }

            if (updateListProperties)
            {
                SPList list = SPContext.Current.Web.Lists[selectedListId];
                lblListTitle.Text = list.Title;
                lblListID.Text = list.ID.ToString().ToUpper();
                lblListIsDocumentLibrary.Text = (list is SPDocumentLibrary).ToString();
                lblListIsHidden.Text = list.Hidden.ToString();
                lblListItemCount.Text = list.ItemCount.ToString();
                lnkListUrl.Text = list.DefaultViewUrl;
                lnkListUrl.NavigateUrl = list.DefaultViewUrl;
            }
        }
    }
}
