﻿// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.208
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRClient.SubmitApp {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubmitJobApplicationRequest", Namespace="http://contoso.com/contracts/hr")]
    [System.SerializableAttribute()]
    public partial class SubmitJobApplicationRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Guid RequestIDField;
        
        private HRClient.SubmitApp.ApplicantResume ResumeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Guid RequestID {
            get {
                return this.RequestIDField;
            }
            set {
                if ((this.RequestIDField.Equals(value) != true)) {
                    this.RequestIDField = value;
                    this.RaisePropertyChanged("RequestID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public HRClient.SubmitApp.ApplicantResume Resume {
            get {
                return this.ResumeField;
            }
            set {
                if ((object.ReferenceEquals(this.ResumeField, value) != true)) {
                    this.ResumeField = value;
                    this.RaisePropertyChanged("Resume");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ApplicantResume", Namespace="http://contoso.com/contracts/hr")]
    [System.SerializableAttribute()]
    public partial class ApplicantResume : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string EducationField;
        
        private string EmailField;
        
        private string NameField;
        
        private int NumReferencesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Education {
            get {
                return this.EducationField;
            }
            set {
                if ((object.ReferenceEquals(this.EducationField, value) != true)) {
                    this.EducationField = value;
                    this.RaisePropertyChanged("Education");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int NumReferences {
            get {
                return this.NumReferencesField;
            }
            set {
                if ((this.NumReferencesField.Equals(value) != true)) {
                    this.NumReferencesField = value;
                    this.RaisePropertyChanged("NumReferences");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SubmitJobApplicationResponse", Namespace="http://contoso.com/contracts/hr")]
    [System.SerializableAttribute()]
    public partial class SubmitJobApplicationResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string ApplicantNameField;
        
        private int ApplicationIDField;
        
        private string ResponseTextField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ApplicantName {
            get {
                return this.ApplicantNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ApplicantNameField, value) != true)) {
                    this.ApplicantNameField = value;
                    this.RaisePropertyChanged("ApplicantName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int ApplicationID {
            get {
                return this.ApplicationIDField;
            }
            set {
                if ((this.ApplicationIDField.Equals(value) != true)) {
                    this.ApplicationIDField = value;
                    this.RaisePropertyChanged("ApplicationID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ResponseText {
            get {
                return this.ResponseTextField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseTextField, value) != true)) {
                    this.ResponseTextField = value;
                    this.RaisePropertyChanged("ResponseText");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://contoso.com/hr/", ConfigurationName="SubmitApp.IApplicationService")]
    public interface IApplicationService {
        
        // CODEGEN: Generating message contract since the operation SubmitJobApplication is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="http://contoso.com/hr/IApplicationService/SubmitJobApplication", ReplyAction="http://contoso.com/hr/IApplicationService/SubmitJobApplicationResponse")]
        HRClient.SubmitApp.SubmitJobApplicationResponse1 SubmitJobApplication(HRClient.SubmitApp.SubmitJobApplicationRequest1 request);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://contoso.com/hr/IApplicationService/SubmitJobApplication", ReplyAction="http://contoso.com/hr/IApplicationService/SubmitJobApplicationResponse")]
        System.IAsyncResult BeginSubmitJobApplication(HRClient.SubmitApp.SubmitJobApplicationRequest1 request, System.AsyncCallback callback, object asyncState);
        
        HRClient.SubmitApp.SubmitJobApplicationResponse1 EndSubmitJobApplication(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SubmitJobApplicationRequest1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://contoso.com/contracts/hr", Order=0)]
        public HRClient.SubmitApp.SubmitJobApplicationRequest SubmitJobApplicationRequest;
        
        public SubmitJobApplicationRequest1() {
        }
        
        public SubmitJobApplicationRequest1(HRClient.SubmitApp.SubmitJobApplicationRequest SubmitJobApplicationRequest) {
            this.SubmitJobApplicationRequest = SubmitJobApplicationRequest;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SubmitJobApplicationResponse1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://contoso.com/contracts/hr", Order=0)]
        public HRClient.SubmitApp.SubmitJobApplicationResponse SubmitJobApplicationResponse;
        
        public SubmitJobApplicationResponse1() {
        }
        
        public SubmitJobApplicationResponse1(HRClient.SubmitApp.SubmitJobApplicationResponse SubmitJobApplicationResponse) {
            this.SubmitJobApplicationResponse = SubmitJobApplicationResponse;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IApplicationServiceChannel : HRClient.SubmitApp.IApplicationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SubmitJobApplicationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public SubmitJobApplicationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public HRClient.SubmitApp.SubmitJobApplicationResponse Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((HRClient.SubmitApp.SubmitJobApplicationResponse)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ApplicationServiceClient : System.ServiceModel.ClientBase<HRClient.SubmitApp.IApplicationService>, HRClient.SubmitApp.IApplicationService {
        
        private BeginOperationDelegate onBeginSubmitJobApplicationDelegate;
        
        private EndOperationDelegate onEndSubmitJobApplicationDelegate;
        
        private System.Threading.SendOrPostCallback onSubmitJobApplicationCompletedDelegate;
        
        public ApplicationServiceClient() {
        }
        
        public ApplicationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ApplicationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ApplicationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ApplicationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<SubmitJobApplicationCompletedEventArgs> SubmitJobApplicationCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HRClient.SubmitApp.SubmitJobApplicationResponse1 HRClient.SubmitApp.IApplicationService.SubmitJobApplication(HRClient.SubmitApp.SubmitJobApplicationRequest1 request) {
            return base.Channel.SubmitJobApplication(request);
        }
        
        public HRClient.SubmitApp.SubmitJobApplicationResponse SubmitJobApplication(HRClient.SubmitApp.SubmitJobApplicationRequest SubmitJobApplicationRequest) {
            HRClient.SubmitApp.SubmitJobApplicationRequest1 inValue = new HRClient.SubmitApp.SubmitJobApplicationRequest1();
            inValue.SubmitJobApplicationRequest = SubmitJobApplicationRequest;
            HRClient.SubmitApp.SubmitJobApplicationResponse1 retVal = ((HRClient.SubmitApp.IApplicationService)(this)).SubmitJobApplication(inValue);
            return retVal.SubmitJobApplicationResponse;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult HRClient.SubmitApp.IApplicationService.BeginSubmitJobApplication(HRClient.SubmitApp.SubmitJobApplicationRequest1 request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSubmitJobApplication(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSubmitJobApplication(HRClient.SubmitApp.SubmitJobApplicationRequest SubmitJobApplicationRequest, System.AsyncCallback callback, object asyncState) {
            HRClient.SubmitApp.SubmitJobApplicationRequest1 inValue = new HRClient.SubmitApp.SubmitJobApplicationRequest1();
            inValue.SubmitJobApplicationRequest = SubmitJobApplicationRequest;
            return ((HRClient.SubmitApp.IApplicationService)(this)).BeginSubmitJobApplication(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        HRClient.SubmitApp.SubmitJobApplicationResponse1 HRClient.SubmitApp.IApplicationService.EndSubmitJobApplication(System.IAsyncResult result) {
            return base.Channel.EndSubmitJobApplication(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public HRClient.SubmitApp.SubmitJobApplicationResponse EndSubmitJobApplication(System.IAsyncResult result) {
            HRClient.SubmitApp.SubmitJobApplicationResponse1 retVal = ((HRClient.SubmitApp.IApplicationService)(this)).EndSubmitJobApplication(result);
            return retVal.SubmitJobApplicationResponse;
        }
        
        private System.IAsyncResult OnBeginSubmitJobApplication(object[] inValues, System.AsyncCallback callback, object asyncState) {
            HRClient.SubmitApp.SubmitJobApplicationRequest SubmitJobApplicationRequest = ((HRClient.SubmitApp.SubmitJobApplicationRequest)(inValues[0]));
            return this.BeginSubmitJobApplication(SubmitJobApplicationRequest, callback, asyncState);
        }
        
        private object[] OnEndSubmitJobApplication(System.IAsyncResult result) {
            HRClient.SubmitApp.SubmitJobApplicationResponse retVal = this.EndSubmitJobApplication(result);
            return new object[] {
                    retVal};
        }
        
        private void OnSubmitJobApplicationCompleted(object state) {
            if ((this.SubmitJobApplicationCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SubmitJobApplicationCompleted(this, new SubmitJobApplicationCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SubmitJobApplicationAsync(HRClient.SubmitApp.SubmitJobApplicationRequest SubmitJobApplicationRequest) {
            this.SubmitJobApplicationAsync(SubmitJobApplicationRequest, null);
        }
        
        public void SubmitJobApplicationAsync(HRClient.SubmitApp.SubmitJobApplicationRequest SubmitJobApplicationRequest, object userState) {
            if ((this.onBeginSubmitJobApplicationDelegate == null)) {
                this.onBeginSubmitJobApplicationDelegate = new BeginOperationDelegate(this.OnBeginSubmitJobApplication);
            }
            if ((this.onEndSubmitJobApplicationDelegate == null)) {
                this.onEndSubmitJobApplicationDelegate = new EndOperationDelegate(this.OnEndSubmitJobApplication);
            }
            if ((this.onSubmitJobApplicationCompletedDelegate == null)) {
                this.onSubmitJobApplicationCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSubmitJobApplicationCompleted);
            }
            base.InvokeAsync(this.onBeginSubmitJobApplicationDelegate, new object[] {
                        SubmitJobApplicationRequest}, this.onEndSubmitJobApplicationDelegate, this.onSubmitJobApplicationCompletedDelegate, userState);
        }
    }
}
