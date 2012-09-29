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
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookFormRegion
{
    partial class BillableTaskRegion
    {
        #region Form Region Factory

        [Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Task)]
        [Microsoft.Office.Tools.Outlook.FormRegionName("OutlookFormRegion.BillableTaskRegion")]
        public partial class BillableTaskRegionFactory
        {
            // Occurs before the form region is initialized.
            // To prevent the form region from appearing, set e.Cancel to true.
            // Use e.OutlookItem to get a reference to the current Outlook item.
            private void BillableTaskRegionFactory_FormRegionInitializing(object sender, Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs e)
            {
            }
        }

        #endregion

        private Outlook.TaskItem m_taskItem;
        private Outlook.ItemProperty m_isBillable;
        private Outlook.ItemProperty m_customer;
        private Outlook.ItemProperty m_hours;
        private Outlook.ItemProperty m_details;


        // Occurs before the form region is displayed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void BillableTaskRegion_FormRegionShowing(object sender, System.EventArgs e)
        {
            m_taskItem = this.OutlookItem as Outlook.TaskItem;

            EnsureProperties();
            chkBillable.Checked = m_isBillable.Value;
            UpdateEnableState();

            lstCustomer.SelectedText = m_customer.Value;
            numHours.Value = (decimal)m_hours.Value;
            txtDetails.Text = m_details.Value;
        }

        // Occurs when the form region is closed.
        // Use this.OutlookItem to get a reference to the current Outlook item.
        // Use this.OutlookFormRegion to get a reference to the form region.
        private void BillableTaskRegion_FormRegionClosed(object sender, System.EventArgs e)
        {
        }

        private void chkBillable_CheckedChanged(object sender, EventArgs e)
        {
            m_isBillable.Value = chkBillable.Checked;
            UpdateEnableState();
        }

        private void lstCustomer_TextChanged(object sender, EventArgs e)
        {
            m_customer.Value = lstCustomer.Text;
        }

        private void numHours_ValueChanged(object sender, EventArgs e)
        {
            m_hours.Value = (double)numHours.Value;
        }

        private void txtDetails_TextChanged(object sender, EventArgs e)
        {
            m_details.Value = txtDetails.Text;
        }

        public void UpdateEnableState()
        {
            lstCustomer.Enabled = chkBillable.Checked;
            numHours.Enabled = chkBillable.Checked;
            txtDetails.Enabled = chkBillable.Checked;
        }

        private void EnsureProperties()
        {
            EnsureItemProperty(ref m_isBillable, "Billable", Outlook.OlUserPropertyType.olYesNo);
            EnsureItemProperty(ref m_customer, "Billable Customer", Outlook.OlUserPropertyType.olText);
            EnsureItemProperty(ref m_hours, "Billable Hours", Outlook.OlUserPropertyType.olNumber);
            EnsureItemProperty(ref m_details, "Billing Details", Outlook.OlUserPropertyType.olText);
        }

        private void EnsureItemProperty(ref Outlook.ItemProperty property, string name, Outlook.OlUserPropertyType propertyType)
        {
            if (property == null)
            {
                property = m_taskItem.ItemProperties[name];
                if (property == null)
                    property =
                        m_taskItem.ItemProperties.Add(name, propertyType);
            }
        }
    }
}
