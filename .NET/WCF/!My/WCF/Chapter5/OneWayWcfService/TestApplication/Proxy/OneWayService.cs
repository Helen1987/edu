﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IOneWayService")]
public interface IOneWayService
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IOneWayService/MyMethodWithError")]
    void MyMethodWithError();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOneWayService/MyMethodWithoutError", ReplyAction="http://tempuri.org/IOneWayService/MyMethodWithoutErrorResponse")]
    void MyMethodWithoutError();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IOneWayServiceChannel : IOneWayService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class OneWayServiceClient : System.ServiceModel.ClientBase<IOneWayService>, IOneWayService
{
    
    public OneWayServiceClient()
    {
    }
    
    public OneWayServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public OneWayServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public OneWayServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public OneWayServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void MyMethodWithError()
    {
        base.Channel.MyMethodWithError();
    }
    
    public void MyMethodWithoutError()
    {
        base.Channel.MyMethodWithoutError();
    }
}