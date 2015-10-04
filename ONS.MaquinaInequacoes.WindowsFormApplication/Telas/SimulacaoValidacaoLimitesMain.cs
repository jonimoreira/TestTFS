using ONS.MaquinaInequacoes.WindowsFormApplication.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                myTabPage.Name = visao.Nome;
                myTabPage.AutoScroll = true;
                tabControl1.TabPages.Add(myTabPage);
                DataGridView dat = new DataGridView();
                dat.AutoSize = true;
                //dat.Width = 1260;
                //dat.Height = 330;
                //Comparison<int> comparison = new Comparison<int>(CompareLength);
                //Array.Sort(array, comparison);

                //visao.Variaveis.OrderBy()
                DateTime horario30em30 = new DateTime(2015, 01, 01, 0, 0, 0);
                if (visao.NumValoresDiario30em30min)
                {
                    dat.Columns.Add("Horario", "Horario (ini-fim)");
                }
                
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

                    if (visao.NumValoresDiario30em30min)
                    {
                        DateTime horario30em30sup = horario30em30.AddMinutes(30.0);
                        dat.Rows[index].Cells["Horario"].Value = horario30em30.ToString("HH:mm") + " - " + horario30em30sup.ToString("HH:mm");
                        horario30em30 = horario30em30sup;
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
                    // Carrega visao referente a TabPage
                    Visao visao = Visoes.Where(v => v.Nome == tab.Name).FirstOrDefault();
                    if (visao == null)
                        break;

                    foreach (Control ctrl in tab.Controls)
                    {
                        if (ctrl is DataGridView)
                        {
                            DataGridView dat = (DataGridView)ctrl;

                            foreach (DataGridViewRow row in dat.Rows)
                            {
                                // Sai do for ao chegar no final (por algum motivo há uma linha a mais com valores nulos no final)
                                if (row.Cells[0].Value == null)
                                    break;

                                // Atualiza MC pelos valores na linha do DataGridView
                                for (int i = 0; i < row.Cells.Count; i++)
                                {
                                    MaquinaInequacoesServiceReference.Variavel variavel = Variaveis.Where(v => "var_" + v.Nome == row.Cells[i].OwningColumn.Name).FirstOrDefault();
                                    if (variavel != null)
                                    {
                                        variavel.Valor = row.Cells[i].Value;
                                    }
                                }

                                memoriaCalculo.Variaveis = Variaveis.ToArray();

                                // Executa para cada função na visão
                                foreach (KeyValuePair<Funcao,int> funcaoKVP in visao.Funcoes)
                                {
                                    Funcao funcao = funcaoKVP.Key;

                                    MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = funcao.ListaDecisoes;

                                        try
                                        {
                                            // Chama o serviço
                                            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculoResult = maquinaInequacoesServiceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                                            // Atualiza variáveis na grid com valores
                                            for (int i = 0; i < row.Cells.Count; i++)
                                            {
                                                MaquinaInequacoesServiceReference.Variavel var = memoriaCalculoResult.Variaveis.Where(v => "var_" + v.Nome == row.Cells[i].OwningColumn.Name).FirstOrDefault();
                                                if (var != null)
                                                {
                                                    row.Cells[i].Value = var.Valor;
                                                }
                                            }

                                            MaquinaInequacoesServiceReference.Variavel varRetornoFuncao = memoriaCalculoResult.Variaveis.Where(v => v.Nome == funcao.VariavelRetorno.Nome).FirstOrDefault();
                                            if (varRetornoFuncao != null) funcao.VariavelRetorno = varRetornoFuncao;

                                            // Atualiza valor da função na grid com valor da variável de retorno
                                            for (int i = 0; i < row.Cells.Count; i++)
                                            {
                                                if (row.Cells[i].OwningColumn.Name == "func_" + funcao.Nome)
                                                {
                                                    row.Cells[i].Value = funcao.VariavelRetorno.Valor;
                                                    break;
                                                }
                                            }
                                        }
                                        catch(Exception iEx)
                                        {
                                            MessageBox.Show("Erro na chamada ao serviço:" + iEx.Message + "\n" + iEx.StackTrace);
                                        }
                                        
                                }

                            }
                            break;
                        }
                    }

                }

                maquinaInequacoesServiceClient.Close();
                MessageBox.Show("Execução efetuada com sucesso.");
            }
            catch (Exception iEx)
            {
                MessageBox.Show("Erro na execução:" + iEx.Message + "\n");
                if (maquinaInequacoesServiceClient != null && maquinaInequacoesServiceClient.State == System.ServiceModel.CommunicationState.Opened)
                    maquinaInequacoesServiceClient.Close();
                maquinaInequacoesServiceClient = null;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            CarregarMemoriaDeCalculoDeTodasFuncoesValidacaoLimites();
            CarregarListaDecisoesDeTodasFuncoesValidacaoLimites();
        }

        private string GetCaminhoBaseArquivosTeste()
        {
            string result = string.Empty;
            try
            {
                result = System.Configuration.ConfigurationSettings.AppSettings["CaminhoBaseArquivosTeste"];
            }
            catch (Exception iEx)
            {
                throw new Exception("Erro ao carregar chave 'CaminhoBaseArquivosTeste' do arquivo de configuração (app.config)", iEx);
            }

            return result;
        }

        
        public void CarregarMemoriaDeCalculoDeTodasFuncoesValidacaoLimites()
        {
            string filepath = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\";
            DirectoryInfo d = new DirectoryInfo(filepath);

            Variaveis.Clear();
            foreach (var file in d.GetFiles("*.txt"))
            {
                if (file.FullName.Contains("-MC.txt"))
                    CarregarMemoriaDeCalculoDoArquivo(file.FullName);
                //Directory.Move(file.FullName, filepath + "\\TextFiles\\" + file.Name);
            }

            MessageBox.Show("Todas variáveis das funções na Validação de Limites foram carregadas.");
            
        }

        public void CarregarMemoriaDeCalculoDoArquivo(string fileName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(File.OpenRead(fileName));
            MaquinaInequacoesServiceClient telaFuncaoParse = new MaquinaInequacoesServiceClient();

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();
                if (line != string.Empty && line.Substring(0, 2) != "//")
                {
                    string[] valores = line.Split('=');
                    string varName = valores[0];

                    MaquinaInequacoesServiceReference.Variavel varRepetida = variaveis.Where(v => v.Nome == varName).FirstOrDefault();
                    if (varRepetida == null)
                    {
                        KeyValuePair<MaquinaInequacoesServiceReference.TipoDado, object> varTypeValue = telaFuncaoParse.ParseTipoVariavelValor(line, valores);
                        MaquinaInequacoesServiceReference.Variavel variavel = new MaquinaInequacoesServiceReference.Variavel();
                        variavel.Nome = varName;
                        variavel.TipoDado = varTypeValue.Key;
                        variavel.Valor = varTypeValue.Value;
                        variaveis.Add(variavel);
                    }
                }
            }

        }

        public void CarregarListaDecisoesDeTodasFuncoesValidacaoLimites()
        {
            string filepath = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\";
            DirectoryInfo d = new DirectoryInfo(filepath);

            Funcoes.Clear();
            foreach (var file in d.GetFiles("*.txt"))
            {
                if (file.FullName.Contains("-LD.txt"))
                    CarregarListaDecisoesDoArquivo(file.FullName);

            }

            MessageBox.Show("Todas funções na Validação de Limites foram carregadas.");

        }

        public void CarregarListaDecisoesDoArquivo(string fileName)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(File.OpenRead(fileName));
            MaquinaInequacoesServiceClient telaFuncaoParse = new MaquinaInequacoesServiceClient();

            Funcao funcao = new Funcao();
            funcao.Nome = fileName.Replace(GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\", string.Empty).Replace("-LD.txt", string.Empty);
            
            List<MaquinaInequacoesServiceReference.Decisao> decisoes = new List<MaquinaInequacoesServiceReference.Decisao>();
            
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();
                if (line != string.Empty && line.Substring(0, 2) != "//")
                {
                    KeyValuePair<string, string> inequacaoBlocoAcao = ParseInequacaoBlocoAcao(line);
                    string inequacao = inequacaoBlocoAcao.Key;
                    string blocoAcao = inequacaoBlocoAcao.Value;

                    MaquinaInequacoesServiceReference.Decisao decisao = new MaquinaInequacoesServiceReference.Decisao();
                    decisao.Inequacao = inequacao;
                    decisao.BlocoDeAcao = blocoAcao;
                    decisoes.Add(decisao);
                }
            }

            if (funcao.ListaDecisoes == null)
                funcao.ListaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            funcao.ListaDecisoes.Decisoes = decisoes.ToArray();
            //funcao.VariavelRetorno = varRetorno;
            Funcoes.Add(funcao);

        }

        private KeyValuePair<string, string> ParseInequacaoBlocoAcao(string line)
        {
            // separa inequação e bloco de ação: <ineq>,<bloco ação>
            string inequacao = line.Substring(0, line.IndexOf(","));
            string blocoAcao = line.Substring(line.IndexOf(",") + 1);
            string[] atribuicoes = blocoAcao.Split(';');
            if (atribuicoes.Length == 0)
                throw new Exception("Erro ao carregar lista de decisões. Formato de linha na definição de atribuições na decisão inválida em: " + blocoAcao);

            KeyValuePair<string, string> result = new KeyValuePair<string, string>(inequacao, blocoAcao);
            return result;
        }

    }
}
