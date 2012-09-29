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

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.208
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace Application
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://contoso.com/hr/", ConfigurationName:="Application.IApplicationService")>  _
    Public Interface IApplicationService
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://contoso.com/hr/IApplicationService/SubmitJobApplication", ReplyAction:="http://contoso.com/hr/IApplicationService/SubmitJobApplicationResponse")>  _
        Function SubmitJobApplication(ByVal request As Application.SubmitJobApplicationRequest) As Application.SubmitJobApplicationResponse
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://contoso.com/hr/IApplicationService/HumanScreeningCompleted", ReplyAction:="http://contoso.com/hr/IApplicationService/HumanScreeningCompletedResponse")>  _
        Function HumanScreeningCompleted(ByVal request As Application.HumanScreeningCompletedRequest) As Application.HumanScreeningCompletedResponse
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class SubmitJobApplicationRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="SubmitJobApplicationRequest", [Namespace]:="http://contoso.com/contracts/hr", Order:=0)>  _
        Public SubmitJobApplicationRequest1 As HRApplicationServices.Contracts.SubmitJobApplicationRequest
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal SubmitJobApplicationRequest1 As HRApplicationServices.Contracts.SubmitJobApplicationRequest)
            MyBase.New
            Me.SubmitJobApplicationRequest1 = SubmitJobApplicationRequest1
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class SubmitJobApplicationResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute(Name:="SubmitJobApplicationResponse", [Namespace]:="http://contoso.com/contracts/hr", Order:=0)>  _
        Public SubmitJobApplicationResponse1 As HRApplicationServices.Contracts.SubmitJobApplicationResponse
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal SubmitJobApplicationResponse1 As HRApplicationServices.Contracts.SubmitJobApplicationResponse)
            MyBase.New
            Me.SubmitJobApplicationResponse1 = SubmitJobApplicationResponse1
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class HumanScreeningCompletedRequest
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://contoso.com/contracts/hr", Order:=0)>  _
        Public HumanScreeningResult As HRApplicationServices.Contracts.HumanScreeningResult
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal HumanScreeningResult As HRApplicationServices.Contracts.HumanScreeningResult)
            MyBase.New
            Me.HumanScreeningResult = HumanScreeningResult
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class HumanScreeningCompletedResponse
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://schemas.microsoft.com/2003/10/Serialization/", Order:=0)>  _
        Public [boolean] As System.Nullable(Of Boolean)
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal [boolean] As System.Nullable(Of Boolean))
            MyBase.New
            Me.[boolean] = [boolean]
        End Sub
    End Class
End Namespace
