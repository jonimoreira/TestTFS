﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ONS.Compiler.Tests.MaquinaInequacoesServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MemoriaCalculo", Namespace="http://schemas.datacontract.org/2004/07/ONS.MaquinaInequacoes.Service.DataContrac" +
        "ts")]
    [System.SerializableAttribute()]
    public partial class MemoriaCalculo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.Variavel> VariaveisField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.Variavel> Variaveis {
            get {
                return this.VariaveisField;
            }
            set {
                if ((object.ReferenceEquals(this.VariaveisField, value) != true)) {
                    this.VariaveisField = value;
                    this.RaisePropertyChanged("Variaveis");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Variavel", Namespace="http://schemas.datacontract.org/2004/07/ONS.MaquinaInequacoes.Service.DataContrac" +
        "ts")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.TipoDado))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.List<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.Variavel>))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.Decisao))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Collections.Generic.List<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.Decisao>))]
    public partial class Variavel : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ONS.Compiler.Tests.MaquinaInequacoesServiceReference.TipoDado TipoDadoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ValorField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nome {
            get {
                return this.NomeField;
            }
            set {
                if ((object.ReferenceEquals(this.NomeField, value) != true)) {
                    this.NomeField = value;
                    this.RaisePropertyChanged("Nome");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ONS.Compiler.Tests.MaquinaInequacoesServiceReference.TipoDado TipoDado {
            get {
                return this.TipoDadoField;
            }
            set {
                if ((this.TipoDadoField.Equals(value) != true)) {
                    this.TipoDadoField = value;
                    this.RaisePropertyChanged("TipoDado");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Valor {
            get {
                return this.ValorField;
            }
            set {
                if ((object.ReferenceEquals(this.ValorField, value) != true)) {
                    this.ValorField = value;
                    this.RaisePropertyChanged("Valor");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoDado", Namespace="http://schemas.datacontract.org/2004/07/ONS.MaquinaInequacoes.Service.DataContrac" +
        "ts")]
    public enum TipoDado : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Numerico = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        String = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Booleano = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        HoraMinutoSegundo = 4,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Decisao", Namespace="http://schemas.datacontract.org/2004/07/ONS.MaquinaInequacoes.Service.DataContrac" +
        "ts")]
    [System.SerializableAttribute()]
    public partial class Decisao : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BlocoDeAcaoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InequacaoField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BlocoDeAcao {
            get {
                return this.BlocoDeAcaoField;
            }
            set {
                if ((object.ReferenceEquals(this.BlocoDeAcaoField, value) != true)) {
                    this.BlocoDeAcaoField = value;
                    this.RaisePropertyChanged("BlocoDeAcao");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Inequacao {
            get {
                return this.InequacaoField;
            }
            set {
                if ((object.ReferenceEquals(this.InequacaoField, value) != true)) {
                    this.InequacaoField = value;
                    this.RaisePropertyChanged("Inequacao");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ListaDecisoes", Namespace="http://schemas.datacontract.org/2004/07/ONS.MaquinaInequacoes.Service.DataContrac" +
        "ts")]
    [System.SerializableAttribute()]
    public partial class ListaDecisoes : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.Decisao> DecisoesField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.Decisao> Decisoes {
            get {
                return this.DecisoesField;
            }
            set {
                if ((object.ReferenceEquals(this.DecisoesField, value) != true)) {
                    this.DecisoesField = value;
                    this.RaisePropertyChanged("Decisoes");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MaquinaInequacoesServiceReference.IMaquinaInequacoesService")]
    public interface IMaquinaInequacoesService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomGPL", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomGPLResponse")]
        string ExecutarJSONcomGPL(string memoriaCalculo, string listaDecisoes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomGPL", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomGPLResponse")]
        System.Threading.Tasks.Task<string> ExecutarJSONcomGPLAsync(string memoriaCalculo, string listaDecisoes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomGPL", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomGPLResponse")]
        string ExecutarXMLcomGPL(string memoriaCalculo, string listaDecisoes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomGPL", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomGPLResponse")]
        System.Threading.Tasks.Task<string> ExecutarXMLcomGPLAsync(string memoriaCalculo, string listaDecisoes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomObjetos", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomObjetosResponse")]
        ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo ExecutarJSONcomObjetos(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomObjetos", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarJSONcomObjetosResponse")]
        System.Threading.Tasks.Task<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo> ExecutarJSONcomObjetosAsync(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomObjetos", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomObjetosResponse")]
        ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo ExecutarXMLcomObjetos(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomObjetos", ReplyAction="http://tempuri.org/IMaquinaInequacoesService/ExecutarXMLcomObjetosResponse")]
        System.Threading.Tasks.Task<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo> ExecutarXMLcomObjetosAsync(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMaquinaInequacoesServiceChannel : ONS.Compiler.Tests.MaquinaInequacoesServiceReference.IMaquinaInequacoesService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MaquinaInequacoesServiceClient : System.ServiceModel.ClientBase<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.IMaquinaInequacoesService>, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.IMaquinaInequacoesService {
        
        public MaquinaInequacoesServiceClient() {
        }
        
        public MaquinaInequacoesServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MaquinaInequacoesServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MaquinaInequacoesServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MaquinaInequacoesServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ExecutarJSONcomGPL(string memoriaCalculo, string listaDecisoes) {
            return base.Channel.ExecutarJSONcomGPL(memoriaCalculo, listaDecisoes);
        }
        
        public System.Threading.Tasks.Task<string> ExecutarJSONcomGPLAsync(string memoriaCalculo, string listaDecisoes) {
            return base.Channel.ExecutarJSONcomGPLAsync(memoriaCalculo, listaDecisoes);
        }
        
        public string ExecutarXMLcomGPL(string memoriaCalculo, string listaDecisoes) {
            return base.Channel.ExecutarXMLcomGPL(memoriaCalculo, listaDecisoes);
        }
        
        public System.Threading.Tasks.Task<string> ExecutarXMLcomGPLAsync(string memoriaCalculo, string listaDecisoes) {
            return base.Channel.ExecutarXMLcomGPLAsync(memoriaCalculo, listaDecisoes);
        }
        
        public ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo ExecutarJSONcomObjetos(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes) {
            return base.Channel.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);
        }
        
        public System.Threading.Tasks.Task<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo> ExecutarJSONcomObjetosAsync(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes) {
            return base.Channel.ExecutarJSONcomObjetosAsync(memoriaCalculo, listaDecisoes);
        }
        
        public ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo ExecutarXMLcomObjetos(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes) {
            return base.Channel.ExecutarXMLcomObjetos(memoriaCalculo, listaDecisoes);
        }
        
        public System.Threading.Tasks.Task<ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo> ExecutarXMLcomObjetosAsync(ONS.Compiler.Tests.MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, ONS.Compiler.Tests.MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes) {
            return base.Channel.ExecutarXMLcomObjetosAsync(memoriaCalculo, listaDecisoes);
        }
    }
}
