using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.MaquinaInequacoes.WindowsFormApplication.Classes
{
    public class Visao
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private List<KeyValuePair<Funcao, int>> funcoes;

        public List<KeyValuePair<Funcao, int>> Funcoes
        {
            get { return funcoes; }
            set { funcoes = value; }
        }
        private List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>> variaveis;

        public List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>> Variaveis
        {
            get { return variaveis; }
            set { variaveis = value; }
        }

        private int numValores;

        public int NumValores
        {
            get { return numValores; }
            set { numValores = value; }
        }

    }
}
