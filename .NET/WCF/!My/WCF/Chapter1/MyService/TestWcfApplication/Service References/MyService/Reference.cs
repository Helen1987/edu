﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestWcfApplication.MyService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="MyNamespace", ConfigurationName="MyService.IMyContract")]
    public interface IMyContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="MyNamespace/IMyContract/MyMethod", ReplyAction="MyNamespace/IMyContract/MyMethodResponse")]
        string MyMethod(string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyContractChannel : TestWcfApplication.MyService.IMyContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyContractClient : System.ServiceModel.ClientBase<TestWcfApplication.MyService.IMyContract>, TestWcfApplication.MyService.IMyContract {
        
        public MyContractClient() {
        }
        
        public MyContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string MyMethod(string text) {
            return base.Channel.MyMethod(text);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyService.IMyOtherContract")]
    public interface IMyOtherContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyOtherContract/SomeMethod", ReplyAction="http://tempuri.org/IMyOtherContract/SomeMethodResponse")]
        string SomeMethod(string text);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyOtherContractChannel : TestWcfApplication.MyService.IMyOtherContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyOtherContractClient : System.ServiceModel.ClientBase<TestWcfApplication.MyService.IMyOtherContract>, TestWcfApplication.MyService.IMyOtherContract {
        
        public MyOtherContractClient() {
        }
        
        public MyOtherContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyOtherContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyOtherContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyOtherContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SomeMethod(string text) {
            return base.Channel.SomeMethod(text);
        }
    }
}