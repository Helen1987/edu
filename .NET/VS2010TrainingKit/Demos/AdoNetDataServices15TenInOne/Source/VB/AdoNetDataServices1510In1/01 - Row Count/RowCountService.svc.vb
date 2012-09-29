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

Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web
Imports AdoNetDataServices1510In1.RowCount

Public Class RowCountService
    Inherits DataService(Of RowCountContext)

    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2
        config.SetEntitySetAccessRule("Products", EntitySetRights.All)
        config.SetEntitySetPageSize("Products", 20)
    End Sub

End Class
