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

Public Module Helpers
    <System.Runtime.CompilerServices.Extension()>
    Public Function AsSelectList(ByVal list As IEnumerable(Of KeyValuePair(Of String, String))) As IEnumerable(Of SelectListItem)
        Return From item In list
               Select New SelectListItem() With {.Value = item.Key, .Text = item.Value}
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function AsSelectList(ByVal list As IEnumerable(Of Factor)) As IEnumerable(Of SelectListItem)
        Return From item In list
               Select New SelectListItem() With {.Value = item.Id, .Text = item.Name}
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function AsSelectList(ByVal list As IEnumerable(Of Integer)) As IEnumerable(Of SelectListItem)
        Return From item In list
               Select New SelectListItem() With {.Value = item.ToString(), .Text = item.ToString()}
    End Function
End Module