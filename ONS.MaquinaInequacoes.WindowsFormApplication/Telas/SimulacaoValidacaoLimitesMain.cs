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
            simulacaoValidacaoLimitesVisoes.LoadListaVariaveis(Variaveis);
            simulacaoValidacaoLimitesVisoes.LoadListaFuncoes(Funcoes);
            simulacaoValidacaoLimitesVisoes.ShowDialog();
            visoes = simulacaoValidacaoLimitesVisoes.ListaVisoes;
            AtualizaTabs();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MaquinaInequacoesServiceClient maquinaInequacoesServiceClient = new MaquinaInequacoesServiceClient();
            maquinaInequacoesServiceClient.ShowDialog();
        }

        private void AtualizaTabs()
        {
            tabControl1.TabPages.Clear();

            foreach (Visao visao in Visoes)
            {
                TabPage myTabPage = new TabPage(visao.Nome);
                myTabPage.AutoScroll = true;
                tabControl1.TabPages.Add(myTabPage);
                DataGridView dat = new DataGridView();
                dat.AutoSize = true;
                //dat.Width = 1260;
                //dat.Height = 330;
                //Comparison<int> comparison = new Comparison<int>(CompareLength);
                //Array.Sort(array, comparison);

                //visao.Variaveis.OrderBy()
                
                foreach(KeyValuePair<MaquinaInequacoesServiceReference.Variavel,int> variavel in visao.Variaveis.OrderBy(o=>o.Value))
                {
                    dat.Columns.Add("var_" + variavel.Key.Nome, variavel.Key.Nome);
                }

                foreach (KeyValuePair<Funcao, int> funcao in visao.Funcoes.OrderBy(o => o.Value))
                {
                    dat.Columns.Add("func_" + funcao.Key.Nome, funcao.Key.Nome);
                }

                // Valores iniciais
                for (int i = 0; i < visao.NumValores; i++)
                {
                    var index = dat.Rows.Add();
                    foreach (KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int> variavel in visao.Variaveis.OrderBy(o => o.Value))
                    {
                        dat.Rows[index].Cells["var_" + variavel.Key.Nome].Value = variavel.Key.Valor;
                    }
                    foreach (KeyValuePair<Funcao, int> funcao in visao.Funcoes.OrderBy(o => o.Value))
                    {
                        dat.Rows[index].Cells["func_" + funcao.Key.Nome].Value = "<<executar>>";//funcao.Key.;
                    }
                    
                }

                myTabPage.Controls.Add(dat);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient maquinaInequacoesServiceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();

            try
            {
                MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
                

            // Para cada linha no grid em cada visão
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    foreach (Control ctrl in tab.Controls)
                    {
                        if (ctrl is DataGridView)
                        {
                            DataGridView dat = (DataGridView)ctrl;
                            foreach (DataGridViewRow row in dat.Rows)
                            {
                                // Atualiza MC
                                foreach (MaquinaInequacoesServiceReference.Variavel variavel in Variaveis)
                                {
                                    try
                                    {
                                        if (row.Cells["var_" + variavel.Nome] != null)
                                        {
                                            variavel.Valor = row.Cells["var_" + variavel.Nome].Value;
                                        }
                                    }
                                    catch(Exception iex)
                                    { }
                                }
                                memoriaCalculo.Variaveis = Variaveis.ToArray();

                                // Executa para cada função na tab
                                foreach (Funcao funcao in Funcoes)
                                {
                                    if (row.Cells["func_" + funcao.Nome] != null)
                                    {
                                        MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = funcao.ListaDecisoes;

                                        MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculoResult = maquinaInequacoesServiceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);
                                        foreach (MaquinaInequacoesServiceReference.Variavel var in memoriaCalculoResult.Variaveis)
                                        {
                                            for (int i = 0; i < row.Cells.Count;i++ )
                                            {
                                                if (row.Cells[i].OwningColumn.Name == "var_" + var.Nome)
                                                {
                                                    row.Cells[i].Value = var.Valor;
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                            break;
                        }
                    }

                }


                MessageBox.Show("Execução efetuada com sucesso.");
            }
            catch (Exception iEx)
            {
                MessageBox.Show("Erro na execução:" + iEx.Message + "\n");
                
            }


        }

    }
}
