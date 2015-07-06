using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ONS.MaquinaInequacoes.Service.DataContracts
{
    [DataContract]
    public class MemoriaCalculo
    {
        private List<Variavel> _variaveis;

        [DataMember]
        public List<Variavel> Variaveis
        {
            get 
            {
                if (_variaveis == null)
                    _variaveis = new List<Variavel>();
                return _variaveis; 
            }
            set { _variaveis = value; }
        }
    }
}