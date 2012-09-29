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

Imports System.Net
Imports System.ServiceModel
Imports System.ServiceModel.Discovery

Module Module1
    Private Function HostDiscoveryEndpoint(ByVal hostName As String) As ServiceHost
        ' Create a new ServiceHost with a singleton ChatDiscovery Proxy
        Dim myProxyHost As New ServiceHost(New ChatDiscoveryProxy())

        Dim proxyAddress As String = "net.tcp://" & hostName & ":8001/discoveryproxy"

        ' Create the discovery endpoint
        Dim discoveryEndpoint As New DiscoveryEndpoint(New NetTcpBinding(), New EndpointAddress(proxyAddress))

        discoveryEndpoint.IsSystemEndpoint = False

        ' Add UDP Annoucement endpoint
        myProxyHost.AddServiceEndpoint(New UdpAnnouncementEndpoint())

        ' Add the discovery endpoint
        myProxyHost.AddServiceEndpoint(discoveryEndpoint)

        myProxyHost.Open()
        Console.WriteLine("Discovery Proxy {0}", proxyAddress)

        Return myProxyHost
    End Function

    Sub Main()
        Console.Title = "ChatProxy Service"
        Console.WriteLine("ChatProxy Console Host")
        Dim hostName As String = Dns.GetHostName()

        Using proxyHost As ServiceHost = HostDiscoveryEndpoint(hostName)
            Console.WriteLine("Press <Enter> to exit")
            Console.ReadLine()
            proxyHost.Close()
        End Using
    End Sub
End Module
