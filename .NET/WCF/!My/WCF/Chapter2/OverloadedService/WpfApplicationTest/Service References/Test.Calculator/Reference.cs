﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ServiceModel;
namespace WpfApplicationTest.Test.Calculator {
	
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
	[System.ServiceModel.ServiceContractAttribute(ConfigurationName="Test.Calculator.ICalculator")]
	public interface ICalculator {

		[System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/AddInt", ReplyAction="http://tempuri.org/ICalculator/AddIntResponse",
			Name="AddInt")]
		int Add(int arg1, int arg2);
		
		[System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICalculator/AddDouble", ReplyAction="http://tempuri.org/ICalculator/AddDoubleResponse",
			Name="AddDouble")]
		double Add(double arg1, double arg2);
	}
	
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
	public interface ICalculatorChannel : WpfApplicationTest.Test.Calculator.ICalculator, System.ServiceModel.IClientChannel {
	}
	
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
	public partial class CalculatorClient : System.ServiceModel.ClientBase<WpfApplicationTest.Test.Calculator.ICalculator>, WpfApplicationTest.Test.Calculator.ICalculator {
		
		public CalculatorClient() {
		}
		
		public CalculatorClient(string endpointConfigurationName) : 
				base(endpointConfigurationName) {
		}
		
		public CalculatorClient(string endpointConfigurationName, string remoteAddress) : 
				base(endpointConfigurationName, remoteAddress) {
		}
		
		public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
				base(endpointConfigurationName, remoteAddress) {
		}
		
		public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
				base(binding, remoteAddress) {
		}
		
		[OperationContract(Name="AddInt")]
		public int Add(int arg1, int arg2) {
			return base.Channel.Add(arg1, arg2);
		}
		
		[OperationContract(Name="AddDouble")]
		public double Add(double arg1, double arg2) {
			return base.Channel.Add(arg1, arg2);
		}
	}
}
