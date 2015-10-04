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
    public partial class SimulacaoValidacaoLimitesVisoes : Form
    {

        private Visao visaoCorrente;

        public List<Visao> ListaVisoes
        {
            get
            {
                List<Visao> listaVisoes = (List<Visao>)dataGridView1.DataSource;
                return listaVisoes;
            }
        }

        public SimulacaoValidacaoLimitesVisoes()
        {
            InitializeComponent();
        }

        public void LoadDataGrid(List<Visao> visoes)
        {
            dataGridView1.DataSource = visoes;
        }

        private DataGridViewComboBoxColumn CreateComboBoxOrdem()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            List<int> list = new List<int>();
            for (int i = 0; i < 100;i++ )
            {
                list.Add(i);
            }
            combo.DataSource = list;
            combo.DataPropertyName = "Ordem";
            combo.Name = "Ordem";
            return combo;
        }

        public void LoadListaVariaveis(List<MaquinaInequacoesServiceReference.Variavel> variaveis)
        {
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.DataSource = variaveis;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "X";
            chk.Name = "chkVariaveis";
            dataGridView3.Columns.Add(chk);
            //dataGridView3.Columns.Add(CreateComboBoxOrdem());

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Nome";
            column.Name = "Variavel";
            dataGridView3.Columns.Add(column);

            /*
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Ordem";
            cmb.Name = "cmbOrdem";
            cmb.MaxDropDownItems = 100;
            for (int i = 0; i < 100; i++)
            {
                cmb.Items.Add(i);
            }
            dataGridView3.Columns.Add(cmb);
            
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                row.Cells[chk.Name].Value = false;
                //(row.Cells[cmb.Name] as DataGridViewComboBoxCell).Value = 0;
            }
            */
        }

        public void LoadListaFuncoes(List<Funcao> funcoes)
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = funcoes;

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "X";
            chk.Name = "chkVariaveis";
            dataGridView2.Columns.Add(chk);
            //dataGridView3.Columns.Add(CreateComboBoxOrdem());

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Nome";
            column.Name = "Funcao";
            dataGridView2.Columns.Add(column);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("Nome da visão");
                return;
            }

            foreach (Visao var in ListaVisoes)
            {
                if (var.Nome.Trim().ToLower() == textBox2.Text.Trim().ToLower())
                {
                    MessageBox.Show("Visão com mesmo nome já existe");
                    return;
                }
            }

            Visao visao = new Visao();
            visao.Nome = textBox2.Text;
            visao.NumValores = int.Parse(textBox1.Text);
            visao.NumValoresDiario30em30min = checkBox1.Checked;
            CarregaFuncoes(visao);
            CarregaVariaveis(visao);

            List<Visao> lista = (List<Visao>)dataGridView1.DataSource;
            lista.Add(visao);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = lista;
            //MessageBox.Show("Inserido");
        }

        private void CarregaFuncoes(Visao visao)
        {
            if (visao.Funcoes == null)
                visao.Funcoes = new List<KeyValuePair<Funcao, int>>();
            visao.Funcoes.Clear();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    Funcao funcao = (Funcao)row.DataBoundItem;
                    int ordem = 0;
                    //if (row.Cells[1].Value != null) int.TryParse(row.Cells[1].Value.ToString(), out ordem);
                    KeyValuePair<Funcao, int> funcOrdem = new KeyValuePair<Funcao, int>(funcao, ordem);
                    visao.Funcoes.Add(funcOrdem);
                }
            }

        }

        private void CarregaVariaveis(Visao visao)
        {
            if (visao.Variaveis == null)
                visao.Variaveis = new List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>>();
            visao.Variaveis.Clear();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    MaquinaInequacoesServiceReference.Variavel variavel = (MaquinaInequacoesServiceReference.Variavel)row.DataBoundItem;
                    int ordem = 0;
                    //int.TryParse(row.Cells[1].Value.ToString(), out ordem);
                    KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int> varOrdem = new KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>(variavel, ordem);
                    visao.Variaveis.Add(varOrdem);
                }
            }
        }

        private void dataGridView3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /*
            try
            {
                if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                {
                    object value = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dataGridView3.Columns[e.ColumnIndex]).Items.Contains(value))
                    {
                        ((DataGridViewComboBoxColumn)dataGridView3.Columns[e.ColumnIndex]).Items.Add(value);
                    }
                }

                throw e.Exception;
            }
            catch (Exception ex)
            {
                
                bool rethrow = ExceptionPolicy.HandleException(ex, "UI Policy");
                if (rethrow)
                {
                    MessageBox.Show(string.Format(@"Failed to bind ComboBox. "
                    + "Please contact support with this message:"
                    + "\n\n" + ex.Message));
                }
                
            }
             * */
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Text = "48";
                textBox1.Enabled = false;
            }
            else
                textBox1.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulaVisaoSelecionada();
        }

        private void PopulaVisaoSelecionada()
        {
            if (dataGridView1.CurrentRow.Selected)
            {
                visaoCorrente = (Visao)dataGridView1.CurrentRow.DataBoundItem;
                textBox2.Text = visaoCorrente.Nome;
                textBox1.Text = visaoCorrente.NumValores.ToString();
                checkBox1.Checked = visaoCorrente.NumValoresDiario30em30min;

            }

        }

        private void UncheckAll()
        {
            /*
            foreach(MaquinaInequacoesServiceReference.Variavel var in ((List<MaquinaInequacoesServiceReference.Variavel>)dataGridView3.DataSource))
            {

            }
            */
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
                List<Visao> lista = (List<Visao>)dataGridView1.DataSource;
                Visao visaoExlcuir = null;
                foreach (Visao visao in lista)
                {
                    if (visao.Nome.Trim().ToLower() == textBox2.Text.Trim().ToLower())
                    {
                        visaoExlcuir = visao;
                        break;
                    }
                }

                if (visaoExlcuir != null)
                {
                    lista.Remove(visaoExlcuir);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = lista;
                }

        }

    }
}
