using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ONS.MaquinaInequacoes.Service.DataContracts
{
    [DataContract]
    public class Variavel
    {
        [DataMember]
        public string Nome = string.Empty;
        [DataMember]
        public TipoDadoEnum TipoDado = TipoDadoEnum.Numerico;
        [DataMember]
        public object Valor = 0.0;
    }

    [DataContract(Name="TipoDado")]
    public enum TipoDadoEnum
    {
        [EnumMember]
        Numerico = 1,
        [EnumMember]
        String = 2,
        [EnumMember]
        Booleano = 3,
        [EnumMember]
        HoraMinutoSegundo = 4,
    }

}