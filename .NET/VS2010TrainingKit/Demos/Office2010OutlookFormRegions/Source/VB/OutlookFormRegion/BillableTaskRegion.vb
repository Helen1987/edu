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

Public Class BillableTaskRegion

    Private m_taskItem As Outlook.TaskItem
    Private m_isBillable As Outlook.ItemProperty
    Private m_customer As Outlook.ItemProperty
    Private m_hours As Outlook.ItemProperty
    Private m_details As Outlook.ItemProperty

    Private Sub EnsureItemProperty(ByRef prop As Outlook.ItemProperty, ByVal name As String, ByVal propertyType As Outlook.OlUserPropertyType)
        If prop Is Nothing Then
            prop = m_taskItem.ItemProperties(name)
            If prop Is Nothing Then
                prop = m_taskItem.ItemProperties.Add(name, propertyType)
            End If
        End If
    End Sub

    Private Sub EnsureProperties()
        EnsureItemProperty(m_isBillable, "Billable", Outlook.OlUserPropertyType.olYesNo)
        EnsureItemProperty(m_customer, "Billable Customer", Outlook.OlUserPropertyType.olText)
        EnsureItemProperty(m_hours, "Billable Hours", Outlook.OlUserPropertyType.olNumber)
        EnsureItemProperty(m_details, "Billing Details", Outlook.OlUserPropertyType.olText)
    End Sub

    Public Sub UpdateEnableState()
        lstCustomer.Enabled = chkBillable.Checked
        numHours.Enabled = chkBillable.Checked
        txtDetails.Enabled = chkBillable.Checked
    End Sub

    Private Sub chkBillable_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkBillable.CheckedChanged
        EnsureProperties()
        m_isBillable.Value = chkBillable.Checked
        UpdateEnableState()
    End Sub

    Private Sub lstCustomer_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstCustomer.TextChanged
        EnsureProperties()
        m_customer.Value = lstCustomer.Text
    End Sub

    Private Sub numHours_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numHours.ValueChanged
        EnsureProperties()
        m_hours.Value = CDec(numHours.Value)
    End Sub


    Private Sub txtDetails_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtDetails.TextChanged
        EnsureProperties()
        m_details.Value = txtDetails.Text
    End Sub

#Region "Form Region Factory"

    <Microsoft.Office.Tools.Outlook.FormRegionMessageClass(Microsoft.Office.Tools.Outlook.FormRegionMessageClassAttribute.Task)> _
    <Microsoft.Office.Tools.Outlook.FormRegionName("OutlookFormRegion.BillableTaskRegion")> _
    Partial Public Class BillableTaskRegionFactory

        ' Occurs before the form region is initialized.
        ' To prevent the form region from appearing, set e.Cancel to true.
        ' Use e.OutlookItem to get a reference to the current Outlook item.
        Private Sub BillableTaskRegionFactory_FormRegionInitializing(ByVal sender As Object, ByVal e As Microsoft.Office.Tools.Outlook.FormRegionInitializingEventArgs) Handles Me.FormRegionInitializing

        End Sub

    End Class

#End Region

    'Occurs before the form region is displayed. 
    'Use Me.OutlookItem to get a reference to the current Outlook item.
    'Use Me.OutlookFormRegion to get a reference to the form region.
    Private Sub BillableTaskRegion_FormRegionShowing(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionShowing
        m_taskItem = TryCast(Me.OutlookItem, Outlook.TaskItem)

        EnsureProperties()
        chkBillable.Checked = m_isBillable.Value
        UpdateEnableState()

        lstCustomer.SelectedText = m_customer.Value
        numHours.Value = CDec(m_hours.Value)
        txtDetails.Text = m_details.Value

    End Sub

    'Occurs when the form region is closed.   
    'Use Me.OutlookItem to get a reference to the current Outlook item.
    'Use Me.OutlookFormRegion to get a reference to the form region.
    Private Sub BillableTaskRegion_FormRegionClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormRegionClosed

    End Sub
End Class
