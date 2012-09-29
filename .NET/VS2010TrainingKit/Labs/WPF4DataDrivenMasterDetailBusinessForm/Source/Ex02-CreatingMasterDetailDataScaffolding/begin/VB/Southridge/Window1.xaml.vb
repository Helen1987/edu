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

    Public Class Window1
        Inherits Window

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded

        Dim SouthridgeDataSet As Southridge.SouthridgeDataSet = CType(Me.FindResource("SouthridgeDataSet"), Southridge.SouthridgeDataSet)
        'Load data into the table Listings. You can modify this code as needed.
        Dim SouthridgeDataSetListingsTableAdapter As Southridge.SouthridgeDataSetTableAdapters.ListingsTableAdapter = New Southridge.SouthridgeDataSetTableAdapters.ListingsTableAdapter()
        SouthridgeDataSetListingsTableAdapter.Fill(SouthridgeDataSet.Listings)
        Dim ListingsViewSource As System.Windows.Data.CollectionViewSource = CType(Me.FindResource("ListingsViewSource"), System.Windows.Data.CollectionViewSource)
        ListingsViewSource.View.MoveCurrentToFirst()
    End Sub
End Class
