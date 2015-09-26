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
    public partial class SimulacaoValidacaoLimitesFuncoes : Form
    {

        private Funcao funcaoCorrente;
        public List<Funcao> ListaFuncoes
        {
            get
            {
                List<Funcao> listaFuncoes = (List<Funcao>)dataGridView1.DataSource;
                return listaFuncoes;
            }
        }

        public SimulacaoValidacaoLimitesFuncoes()
        {
            InitializeComponent();
        }
        public void LoadDataGrid(List<Funcao> funcoes)
        {
            dataGridView1.DataSource = funcoes;
        }

        public void LoadDataGridVariaveis(List<MaquinaInequacoesServiceReference.Variavel> variaveis)
        {
            dataGridView2.DataSource = variaveis;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Nome da variável");
                return;
            }

            foreach (Funcao func in ListaFuncoes)
            {
                if (func.Nome.Trim().ToLower() == textBox2.Text.Trim().ToLower())
                {
                    MessageBox.Show("Função com mesmo nome já existe");
                    return;
                }
            }

            Funcao funcao = new Funcao();
            funcao.Nome = textBox2.Text;
            funcao.ListaDecisoes = CarregaListaDecisoes();

            List<Funcao> lista = (List<Funcao>)dataGridView1.DataSource;
            lista.Add(funcao);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            //MessageBox.Show("Inserido");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulaFuncao();
        }

        public void PopulaFuncao()
        {
            if (dataGridView1.CurrentRow.Selected)
            {
                funcaoCorrente = (Funcao)dataGridView1.CurrentRow.DataBoundItem;
                textBox2.Text = funcaoCorrente.Nome;
                textBox3.Text = string.Empty;
                foreach (MaquinaInequacoesServiceReference.Decisao decisao in funcaoCorrente.ListaDecisoes.Decisoes)
                {
                    textBox3.Text += decisao.Inequacao + ", " + decisao.BlocoDeAcao  + Environment.NewLine;
                }
            }

        }

        public MaquinaInequacoesServiceReference.ListaDecisoes CarregaListaDecisoes()
        {
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();
            List<MaquinaInequacoesServiceReference.Decisao> decisoes = new List<MaquinaInequacoesServiceReference.Decisao>();
            foreach (string line in textBox3.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                if (!line.StartsWith("//") && line != string.Empty)
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

            listaDecisoes.Decisoes = decisoes.ToArray();
            return listaDecisoes;
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

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            List<Funcao> lista = (List<Funcao>)dataGridView1.DataSource;
            Funcao funcaoExlcuir = null;
            foreach (Funcao func in lista)
            {
                if (func.Nome.Trim().ToLower() == textBox2.Text.Trim().ToLower())
                {
                    funcaoExlcuir = func;
                    break;
                }
            }

            if (funcaoExlcuir != null)
            {
                lista.Remove(funcaoExlcuir);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;

            }
        }

    }
}
