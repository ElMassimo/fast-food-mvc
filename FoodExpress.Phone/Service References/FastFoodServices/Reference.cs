﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace FoodExpress.Phone.FastFoodServices {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderHeader", Namespace="http://schemas.datacontract.org/2004/07/FastFood.Services")]
    public partial class OrderHeader : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int IdField;
        
        private string NameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDetail", Namespace="http://schemas.datacontract.org/2004/07/FastFood.Services")]
    public partial class OrderDetail : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string AddressField;
        
        private decimal CostField;
        
        private System.DateTime DateOrderedField;
        
        private string DescriptionField;
        
        private int IdField;
        
        private int StatusField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Cost {
            get {
                return this.CostField;
            }
            set {
                if ((this.CostField.Equals(value) != true)) {
                    this.CostField = value;
                    this.RaisePropertyChanged("Cost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOrdered {
            get {
                return this.DateOrderedField;
            }
            set {
                if ((this.DateOrderedField.Equals(value) != true)) {
                    this.DateOrderedField = value;
                    this.RaisePropertyChanged("DateOrdered");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FastFoodServices.IDeliveryServices")]
    public interface IDeliveryServices {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDeliveryServices/GetUndeliveredOrders", ReplyAction="http://tempuri.org/IDeliveryServices/GetUndeliveredOrdersResponse")]
        System.IAsyncResult BeginGetUndeliveredOrders(string nick, string password, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader> EndGetUndeliveredOrders(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDeliveryServices/GetOrderDetail", ReplyAction="http://tempuri.org/IDeliveryServices/GetOrderDetailResponse")]
        System.IAsyncResult BeginGetOrderDetail(int orderId, System.AsyncCallback callback, object asyncState);
        
        FoodExpress.Phone.FastFoodServices.OrderDetail EndGetOrderDetail(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IDeliveryServices/DeliverOrder", ReplyAction="http://tempuri.org/IDeliveryServices/DeliverOrderResponse")]
        System.IAsyncResult BeginDeliverOrder(string nick, string password, int orderId, int orderStatus, System.AsyncCallback callback, object asyncState);
        
        bool EndDeliverOrder(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeliveryServicesChannel : FoodExpress.Phone.FastFoodServices.IDeliveryServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetUndeliveredOrdersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUndeliveredOrdersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetOrderDetailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetOrderDetailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public FoodExpress.Phone.FastFoodServices.OrderDetail Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((FoodExpress.Phone.FastFoodServices.OrderDetail)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeliverOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DeliverOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeliveryServicesClient : System.ServiceModel.ClientBase<FoodExpress.Phone.FastFoodServices.IDeliveryServices>, FoodExpress.Phone.FastFoodServices.IDeliveryServices {
        
        private BeginOperationDelegate onBeginGetUndeliveredOrdersDelegate;
        
        private EndOperationDelegate onEndGetUndeliveredOrdersDelegate;
        
        private System.Threading.SendOrPostCallback onGetUndeliveredOrdersCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetOrderDetailDelegate;
        
        private EndOperationDelegate onEndGetOrderDetailDelegate;
        
        private System.Threading.SendOrPostCallback onGetOrderDetailCompletedDelegate;
        
        private BeginOperationDelegate onBeginDeliverOrderDelegate;
        
        private EndOperationDelegate onEndDeliverOrderDelegate;
        
        private System.Threading.SendOrPostCallback onDeliverOrderCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public DeliveryServicesClient() {
        }
        
        public DeliveryServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DeliveryServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeliveryServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DeliveryServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetUndeliveredOrdersCompletedEventArgs> GetUndeliveredOrdersCompleted;
        
        public event System.EventHandler<GetOrderDetailCompletedEventArgs> GetOrderDetailCompleted;
        
        public event System.EventHandler<DeliverOrderCompletedEventArgs> DeliverOrderCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult FoodExpress.Phone.FastFoodServices.IDeliveryServices.BeginGetUndeliveredOrders(string nick, string password, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUndeliveredOrders(nick, password, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader> FoodExpress.Phone.FastFoodServices.IDeliveryServices.EndGetUndeliveredOrders(System.IAsyncResult result) {
            return base.Channel.EndGetUndeliveredOrders(result);
        }
        
        private System.IAsyncResult OnBeginGetUndeliveredOrders(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string nick = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            return ((FoodExpress.Phone.FastFoodServices.IDeliveryServices)(this)).BeginGetUndeliveredOrders(nick, password, callback, asyncState);
        }
        
        private object[] OnEndGetUndeliveredOrders(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader> retVal = ((FoodExpress.Phone.FastFoodServices.IDeliveryServices)(this)).EndGetUndeliveredOrders(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUndeliveredOrdersCompleted(object state) {
            if ((this.GetUndeliveredOrdersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUndeliveredOrdersCompleted(this, new GetUndeliveredOrdersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUndeliveredOrdersAsync(string nick, string password) {
            this.GetUndeliveredOrdersAsync(nick, password, null);
        }
        
        public void GetUndeliveredOrdersAsync(string nick, string password, object userState) {
            if ((this.onBeginGetUndeliveredOrdersDelegate == null)) {
                this.onBeginGetUndeliveredOrdersDelegate = new BeginOperationDelegate(this.OnBeginGetUndeliveredOrders);
            }
            if ((this.onEndGetUndeliveredOrdersDelegate == null)) {
                this.onEndGetUndeliveredOrdersDelegate = new EndOperationDelegate(this.OnEndGetUndeliveredOrders);
            }
            if ((this.onGetUndeliveredOrdersCompletedDelegate == null)) {
                this.onGetUndeliveredOrdersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUndeliveredOrdersCompleted);
            }
            base.InvokeAsync(this.onBeginGetUndeliveredOrdersDelegate, new object[] {
                        nick,
                        password}, this.onEndGetUndeliveredOrdersDelegate, this.onGetUndeliveredOrdersCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult FoodExpress.Phone.FastFoodServices.IDeliveryServices.BeginGetOrderDetail(int orderId, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetOrderDetail(orderId, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        FoodExpress.Phone.FastFoodServices.OrderDetail FoodExpress.Phone.FastFoodServices.IDeliveryServices.EndGetOrderDetail(System.IAsyncResult result) {
            return base.Channel.EndGetOrderDetail(result);
        }
        
        private System.IAsyncResult OnBeginGetOrderDetail(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int orderId = ((int)(inValues[0]));
            return ((FoodExpress.Phone.FastFoodServices.IDeliveryServices)(this)).BeginGetOrderDetail(orderId, callback, asyncState);
        }
        
        private object[] OnEndGetOrderDetail(System.IAsyncResult result) {
            FoodExpress.Phone.FastFoodServices.OrderDetail retVal = ((FoodExpress.Phone.FastFoodServices.IDeliveryServices)(this)).EndGetOrderDetail(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetOrderDetailCompleted(object state) {
            if ((this.GetOrderDetailCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetOrderDetailCompleted(this, new GetOrderDetailCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetOrderDetailAsync(int orderId) {
            this.GetOrderDetailAsync(orderId, null);
        }
        
        public void GetOrderDetailAsync(int orderId, object userState) {
            if ((this.onBeginGetOrderDetailDelegate == null)) {
                this.onBeginGetOrderDetailDelegate = new BeginOperationDelegate(this.OnBeginGetOrderDetail);
            }
            if ((this.onEndGetOrderDetailDelegate == null)) {
                this.onEndGetOrderDetailDelegate = new EndOperationDelegate(this.OnEndGetOrderDetail);
            }
            if ((this.onGetOrderDetailCompletedDelegate == null)) {
                this.onGetOrderDetailCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetOrderDetailCompleted);
            }
            base.InvokeAsync(this.onBeginGetOrderDetailDelegate, new object[] {
                        orderId}, this.onEndGetOrderDetailDelegate, this.onGetOrderDetailCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult FoodExpress.Phone.FastFoodServices.IDeliveryServices.BeginDeliverOrder(string nick, string password, int orderId, int orderStatus, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDeliverOrder(nick, password, orderId, orderStatus, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool FoodExpress.Phone.FastFoodServices.IDeliveryServices.EndDeliverOrder(System.IAsyncResult result) {
            return base.Channel.EndDeliverOrder(result);
        }
        
        private System.IAsyncResult OnBeginDeliverOrder(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string nick = ((string)(inValues[0]));
            string password = ((string)(inValues[1]));
            int orderId = ((int)(inValues[2]));
            int orderStatus = ((int)(inValues[3]));
            return ((FoodExpress.Phone.FastFoodServices.IDeliveryServices)(this)).BeginDeliverOrder(nick, password, orderId, orderStatus, callback, asyncState);
        }
        
        private object[] OnEndDeliverOrder(System.IAsyncResult result) {
            bool retVal = ((FoodExpress.Phone.FastFoodServices.IDeliveryServices)(this)).EndDeliverOrder(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDeliverOrderCompleted(object state) {
            if ((this.DeliverOrderCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DeliverOrderCompleted(this, new DeliverOrderCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DeliverOrderAsync(string nick, string password, int orderId, int orderStatus) {
            this.DeliverOrderAsync(nick, password, orderId, orderStatus, null);
        }
        
        public void DeliverOrderAsync(string nick, string password, int orderId, int orderStatus, object userState) {
            if ((this.onBeginDeliverOrderDelegate == null)) {
                this.onBeginDeliverOrderDelegate = new BeginOperationDelegate(this.OnBeginDeliverOrder);
            }
            if ((this.onEndDeliverOrderDelegate == null)) {
                this.onEndDeliverOrderDelegate = new EndOperationDelegate(this.OnEndDeliverOrder);
            }
            if ((this.onDeliverOrderCompletedDelegate == null)) {
                this.onDeliverOrderCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDeliverOrderCompleted);
            }
            base.InvokeAsync(this.onBeginDeliverOrderDelegate, new object[] {
                        nick,
                        password,
                        orderId,
                        orderStatus}, this.onEndDeliverOrderDelegate, this.onDeliverOrderCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override FoodExpress.Phone.FastFoodServices.IDeliveryServices CreateChannel() {
            return new DeliveryServicesClientChannel(this);
        }
        
        private class DeliveryServicesClientChannel : ChannelBase<FoodExpress.Phone.FastFoodServices.IDeliveryServices>, FoodExpress.Phone.FastFoodServices.IDeliveryServices {
            
            public DeliveryServicesClientChannel(System.ServiceModel.ClientBase<FoodExpress.Phone.FastFoodServices.IDeliveryServices> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetUndeliveredOrders(string nick, string password, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = nick;
                _args[1] = password;
                System.IAsyncResult _result = base.BeginInvoke("GetUndeliveredOrders", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader> EndGetUndeliveredOrders(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader> _result = ((System.Collections.ObjectModel.ObservableCollection<FoodExpress.Phone.FastFoodServices.OrderHeader>)(base.EndInvoke("GetUndeliveredOrders", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetOrderDetail(int orderId, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = orderId;
                System.IAsyncResult _result = base.BeginInvoke("GetOrderDetail", _args, callback, asyncState);
                return _result;
            }
            
            public FoodExpress.Phone.FastFoodServices.OrderDetail EndGetOrderDetail(System.IAsyncResult result) {
                object[] _args = new object[0];
                FoodExpress.Phone.FastFoodServices.OrderDetail _result = ((FoodExpress.Phone.FastFoodServices.OrderDetail)(base.EndInvoke("GetOrderDetail", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginDeliverOrder(string nick, string password, int orderId, int orderStatus, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[4];
                _args[0] = nick;
                _args[1] = password;
                _args[2] = orderId;
                _args[3] = orderStatus;
                System.IAsyncResult _result = base.BeginInvoke("DeliverOrder", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndDeliverOrder(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("DeliverOrder", _args, result)));
                return _result;
            }
        }
    }
}