﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:2.0.50727.3053
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Der Quellcode wurde automatisch mit Microsoft.VSDesigner generiert. Version 2.0.50727.3053.
// 
#pragma warning disable 1591

namespace EpagesWebServices.TaxAreaServiceRef {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="bind_TaxArea_SOAP", Namespace="urn://epages.de/WebService/TaxAreaService/2006/07")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(TGetList_Return))]
    public partial class TaxAreaService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getListOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TaxAreaService() {
            this.Url = "http://localhost/epages/Store.soap";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event getListCompletedEventHandler getListCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn://epages.de/WebService/TaxAreaService/2006/07#getList", RequestNamespace="urn://epages.de/WebService/TaxAreaService/2006/07", ResponseNamespace="urn://epages.de/WebService/TaxAreaService/2006/07")]
        [return: System.Xml.Serialization.SoapElementAttribute("TaxAreas")]
        public TGetList_Return[] getList() {
            object[] results = this.Invoke("getList", new object[0]);
            return ((TGetList_Return[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetList(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getList", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public TGetList_Return[] EndgetList(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((TGetList_Return[])(results[0]));
        }
        
        /// <remarks/>
        public void getListAsync() {
            this.getListAsync(null);
        }
        
        /// <remarks/>
        public void getListAsync(object userState) {
            if ((this.getListOperationCompleted == null)) {
                this.getListOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetListOperationCompleted);
            }
            this.InvokeAsync("getList", new object[0], this.getListOperationCompleted, userState);
        }
        
        private void OngetListOperationCompleted(object arg) {
            if ((this.getListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getListCompleted(this, new getListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn://epages.de/WebService/TaxAreaTypes/2006/07")]
    public partial class TGetList_Return {
        
        private string pathField;
        
        /// <remarks/>
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void getListCompletedEventHandler(object sender, getListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TGetList_Return[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TGetList_Return[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591