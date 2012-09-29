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

Imports System.ComponentModel.DataAnnotations

Public NotInheritable Class DateValidator
    Public Shared Function ValidateDate(ByVal dt As Date, ByVal context As  _
         ValidationContext) As ValidationResult
        If dt.Year <= Date.Now.Year Then
            Return ValidationResult.Success
        Else
            Return New ValidationResult("The date must be less than " + _
                    "or equal to the current year.")
        End If
    End Function

End Class

