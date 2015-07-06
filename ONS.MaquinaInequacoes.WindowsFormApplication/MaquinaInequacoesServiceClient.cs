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
    public partial class MaquinaInequacoesServiceClient : Form
    {
        public MaquinaInequacoesServiceClient()
        {
            InitializeComponent();
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            txtBoxMemoriaCalculoSaida.Clear();
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient maquinaInequacoesServiceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            try
            {
                txtBoxMemoriaCalculoSaida.Text = maquinaInequacoesServiceClient.ExecutarJSON(txtBoxMemoriaCalculoEntrada.Text, txtBoxListaDecisoes.Text);
                MessageBox.Show("Execução efetuada com sucesso.");
            }
            catch (Exception iEx)
            {
                MessageBox.Show("Erro na execução:" + iEx.Message + "\n");
                //Adicionar log no tratamento de erro.
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtBoxMemoriaCalculoSaida.Clear();
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient maquinaInequacoesServiceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            try
            {
                MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
                MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

                MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculoResult = maquinaInequacoesServiceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);
                txtBoxMemoriaCalculoSaida.Text = memoriaCalculoResult.ToString();
                MessageBox.Show("Execução efetuada com sucesso.");
            }
            catch (Exception iEx)
            {
                MessageBox.Show("Erro na execução:" + iEx.Message + "\n");
                //Adicionar log no tratamento de erro.
            }
        }
    }
}
