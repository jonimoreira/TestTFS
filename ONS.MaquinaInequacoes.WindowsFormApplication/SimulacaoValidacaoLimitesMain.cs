using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONS.MaquinaInequacoes.WindowsFormApplication
{
    public partial class SimulacaoValidacaoLimitesMain : Form
    {
        private List<MaquinaInequacoesServiceReference.Variavel> variaveis;
        public List<MaquinaInequacoesServiceReference.Variavel> Variaveis
        {
            get 
            {
                if (variaveis == null)
                    variaveis = new List<MaquinaInequacoesServiceReference.Variavel>();
                return variaveis;
            }
        }

        private List<Funcao> funcoes;
        public List<Funcao> Funcoes
        {
            get
            {
                if (funcoes == null)
                    funcoes = new List<Funcao>();
                return funcoes;
            }
        }


        public SimulacaoValidacaoLimitesMain()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            SimulacaoValidacaoLimitesVariaveis simulacaoValidacaoLimitesVariaveis = new SimulacaoValidacaoLimitesVariaveis();
            simulacaoValidacaoLimitesVariaveis.LoadDataGrid(Variaveis);
            simulacaoValidacaoLimitesVariaveis.ShowDialog();
            variaveis = simulacaoValidacaoLimitesVariaveis.ListaVariaveis;
        }

        private void SimulacaoValidacaoLimitesMain_Load(object sender, EventArgs e)
        {
            MaquinaInequacoesServiceReference.Variavel var1 = new MaquinaInequacoesServiceReference.Variavel();
            var1.Nome="limite";
            var1.TipoDado = MaquinaInequacoesServiceReference.TipoDado.Numerico;
            var1.Valor = 0.0;
            Variaveis.Add(var1);
        }
    }
}
