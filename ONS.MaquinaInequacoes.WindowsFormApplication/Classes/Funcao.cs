using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.MaquinaInequacoes.WindowsFormApplication
{
    public class Funcao
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes;

        public MaquinaInequacoesServiceReference.ListaDecisoes ListaDecisoes
        {
            get { return listaDecisoes; }
            set { listaDecisoes = value; }
        }

        private MaquinaInequacoesServiceReference.Variavel variavelRetorno;

        public MaquinaInequacoesServiceReference.Variavel VariavelRetorno
        {
            get { return variavelRetorno; }
            set { variavelRetorno = value; }
        }
    }
}
