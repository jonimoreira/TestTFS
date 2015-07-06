using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ONS.MaquinaInequacoes.Service.DataContracts
{
    [DataContract]
    public class ListaDecisoes
    {
        private List<Decisao> _decisoes;

        [DataMember]
        public List<Decisao> Decisoes
        {
            get 
            {
                if (_decisoes == null)
                    _decisoes = new List<Decisao>();
                return _decisoes; 
            }
            set { _decisoes = value; }
        }
    }
}