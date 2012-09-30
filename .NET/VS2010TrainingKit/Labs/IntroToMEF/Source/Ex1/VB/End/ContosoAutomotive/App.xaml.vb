﻿' ----------------------------------------------------------------------------------
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

Imports System.Reflection
Imports System.Windows
Imports System.ComponentModel.Composition.Hosting

Class App
    ''' <summary>
    ''' Interaction logic for App.xaml
    ''' </summary>
    Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
        Dim catalog = New AggregateCatalog(New DirectoryCatalog("."),
                                   New AssemblyCatalog(Assembly.GetExecutingAssembly()))
        Dim container = New CompositionContainer(catalog)

        Dim window = container.GetExportedValue(Of CashMaker)()
        window.Show()
    End Sub
End Class