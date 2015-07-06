using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ONS.MaquinaInequacoes.Service.DataContracts
{
    [DataContract]
    public class Decisao
    {
        [DataMember]
        public string Inequacao = string.Empty;
        [DataMember]
        public string BlocoDeAcao = string.Empty;
    }
}