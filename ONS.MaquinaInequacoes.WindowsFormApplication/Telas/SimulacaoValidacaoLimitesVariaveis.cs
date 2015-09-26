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
    public partial class SimulacaoValidacaoLimitesVariaveis : Form
    {
        private MaquinaInequacoesServiceReference.Variavel variavelCorrente;

        public List<MaquinaInequacoesServiceReference.Variavel> ListaVariaveis
        {
            get
            {
                List<MaquinaInequacoesServiceReference.Variavel> listaVariaveis = (List<MaquinaInequacoesServiceReference.Variavel>)dataGridView1.DataSource;
                return listaVariaveis;
            }
        }

        public SimulacaoValidacaoLimitesVariaveis()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulaVariavel();
        }

        public void PopulaVariavel()
        {
            if (dataGridView1.CurrentRow.Selected)
            {
                variavelCorrente = (MaquinaInequacoesServiceReference.Variavel)dataGridView1.CurrentRow.DataBoundItem;
                textBox2.Text = variavelCorrente.Nome;
                textBox1.Text = variavelCorrente.Valor.ToString();
                //comboBox1.SelectedValue = variavelCorrente.TipoDado;
                comboBox1.SelectedIndex = comboBox1.FindString(variavelCorrente.TipoDado.ToString());
            }
        }

        private void SimulacaoValidacaoLimitesVariaveis_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }

        private void BindComboBox()
        {
            comboBox1.Items.Add(MaquinaInequacoesServiceReference.TipoDado.Booleano);
            comboBox1.Items.Add(MaquinaInequacoesServiceReference.TipoDado.Numerico);
            comboBox1.Items.Add(MaquinaInequacoesServiceReference.TipoDado.String);
            comboBox1.Items.Add(MaquinaInequacoesServiceReference.TipoDado.HoraMinutoSegundo);
            comboBox1.SelectionStart = 0;
        }

        public void LoadDataGrid(List<MaquinaInequacoesServiceReference.Variavel> variaveis)
        {
            dataGridView1.DataSource = variaveis;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Nome da variável");
                return;
            }

            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Tipo da variável");
                return;
            }

            foreach(MaquinaInequacoesServiceReference.Variavel var in ListaVariaveis)
            {
                if (var.Nome.Trim().ToLower() == textBox2.Text.Trim().ToLower())
                {
                    MessageBox.Show("Variável com mesmo nome já existe");
                    return;
                }
            }

            MaquinaInequacoesServiceReference.Variavel variavel = new MaquinaInequacoesServiceReference.Variavel();
            variavel.Nome = textBox2.Text;
            variavel.TipoDado = (MaquinaInequacoesServiceReference.TipoDado)comboBox1.SelectedItem;
            variavel.Valor = textBox1.Text;

            //((List<MaquinaInequacoesServiceReference.Variavel>)dataGridView1.DataSource).Add(variavel);
            List<MaquinaInequacoesServiceReference.Variavel> lista = (List<MaquinaInequacoesServiceReference.Variavel>)dataGridView1.DataSource;
            lista.Add(variavel);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            //MessageBox.Show("Inserido");
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            List<MaquinaInequacoesServiceReference.Variavel> lista = (List<MaquinaInequacoesServiceReference.Variavel>)dataGridView1.DataSource;
            MaquinaInequacoesServiceReference.Variavel variavelExlcuir = null;
            foreach (MaquinaInequacoesServiceReference.Variavel var in lista)
            {
                if (var.Nome.Trim().ToLower() == textBox2.Text.Trim().ToLower())
                {
                    variavelExlcuir = var;
                    break;
                }
            }

            if (variavelExlcuir != null)
            {
                lista.Remove(variavelExlcuir);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = lista;
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("Escreva a lista de váriaveis no campo ao lado seguindo o padrão por linha: <nome_variavel>[,<valor_inicial>[,<tipo>]]");
                return;
            }
            CarregaMemoriaCalculo();
        }

        public void CarregaMemoriaCalculo()
        {
            List<MaquinaInequacoesServiceReference.Variavel> variaveis = new List<MaquinaInequacoesServiceReference.Variavel>();
            MaquinaInequacoesServiceClient telaFuncaoParse = new MaquinaInequacoesServiceClient();
            foreach (string line in textBox3.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                if (line != string.Empty && line.Substring(0, 2) != "//")
                {
                    string[] valores = line.Split('=');
                    string varName = valores[0];

                    KeyValuePair<MaquinaInequacoesServiceReference.TipoDado, object> varTypeValue = telaFuncaoParse.ParseTipoVariavelValor(line, valores);
                    MaquinaInequacoesServiceReference.Variavel variavel = new MaquinaInequacoesServiceReference.Variavel();
                    variavel.Nome = varName;
                    variavel.TipoDado = varTypeValue.Key;
                    variavel.Valor = varTypeValue.Value;
                    variaveis.Add(variavel);
                }
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = variaveis;

        }
    }
}
