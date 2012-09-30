﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50215.44
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FileDataComponent;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=2.0.50215.44.
// 


/// <remarks/>
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="FileServiceSoap", Namespace="http://tempuri.org/")]
public partial class FileService : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback DownloadFileOperationCompleted;
    
    /// <remarks/>
    public FileService() {
        this.Url = "http://localhost/WebServices2/FileService.asmx";
    }
    
    /// <remarks/>
    public event DownloadFileCompletedEventHandler DownloadFileCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DownloadFile", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
    [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/")]
    public FileData DownloadFile([System.Xml.Serialization.XmlElementAttribute(Namespace="http://tempuri.org/")] string serverFileName) {
        object[] results = this.Invoke("DownloadFile", new object[] {
                    serverFileName});
        return ((FileData)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginDownloadFile(string serverFileName, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("DownloadFile", new object[] {
                    serverFileName}, callback, asyncState);
    }
    
    /// <remarks/>
    public FileData EndDownloadFile(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((FileData)(results[0]));
    }
    
    /// <remarks/>
    public void DownloadFileAsync(string serverFileName) {
        this.DownloadFileAsync(serverFileName, null);
    }
    
    /// <remarks/>
    public void DownloadFileAsync(string serverFileName, object userState) {
        if ((this.DownloadFileOperationCompleted == null)) {
            this.DownloadFileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadFileOperationCompleted);
        }
        this.InvokeAsync("DownloadFile", new object[] {
                    serverFileName}, this.DownloadFileOperationCompleted, userState);
    }
    
    private void OnDownloadFileOperationCompleted(object arg) {
        if ((this.DownloadFileCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.DownloadFileCompleted(this, new DownloadFileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
public delegate void DownloadFileCompletedEventHandler(object sender, DownloadFileCompletedEventArgs e);

/// <remarks/>
public partial class DownloadFileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal DownloadFileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public FileData Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((FileData)(this.results[0]));
        }
    }
}
