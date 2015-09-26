using ONS.MaquinaInequacoes.WindowsFormApplication.Classes;
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

        private List<Visao> visoes;
        public List<Visao> Visoes
        {
            get
            {
                if (visoes == null)
                    visoes = new List<Visao>();
                return visoes;
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
            /*
            MaquinaInequacoesServiceReference.Variavel var1 = new MaquinaInequacoesServiceReference.Variavel();
            var1.Nome="limite";
            var1.TipoDado = MaquinaInequacoesServiceReference.TipoDado.Numerico;
            var1.Valor = 0.0;
            Variaveis.Add(var1);

            Funcao func1 = new Funcao();
            func1.Nome = "testeLimiteFRSUL";
            //func1.ListaDecisoes.Decisoes.i
            Funcoes.Add(func1);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimulacaoValidacaoLimitesFuncoes simulacaoValidacaoLimitesFuncoes = new SimulacaoValidacaoLimitesFuncoes();
            simulacaoValidacaoLimitesFuncoes.LoadDataGrid(Funcoes);
            simulacaoValidacaoLimitesFuncoes.LoadDataGridVariaveis(Variaveis);
            simulacaoValidacaoLimitesFuncoes.ShowDialog();
            funcoes = simulacaoValidacaoLimitesFuncoes.ListaFuncoes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SimulacaoValidacaoLimitesVisoes simulacaoValidacaoLimitesVisoes = new SimulacaoValidacaoLimitesVisoes();
            simulacaoValidacaoLimitesVisoes.LoadDataGrid(Visoes);
            simulacaoValidacaoLimitesVisoes.LoadCheckBoxListVariaveis(Variaveis);
            simulacaoValidacaoLimitesVisoes.LoadCheckBoxListFuncoes(Funcoes);
            simulacaoValidacaoLimitesVisoes.ShowDialog();
            visoes = simulacaoValidacaoLimitesVisoes.ListaVisoes;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MaquinaInequacoesServiceClient maquinaInequacoesServiceClient = new MaquinaInequacoesServiceClient();
            maquinaInequacoesServiceClient.ShowDialog();
        }
    }
}
