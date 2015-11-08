using ONS.MaquinaInequacoes.WindowsFormApplication.MaquinaInequacoesServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ONS.MaquinaInequacoes.WindowsFormApplication.Classes.ValidacaoLimites
{
    public class VisaoSEVERA_N3
    {
        public static void CarregarVariaveisComDados(Visao visao, List<Variavel> variaveis)
        {
            visao.Valores = new Dictionary<int, List<MaquinaInequacoesServiceReference.Variavel>>();
            visao.Variaveis = new List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>>();

            //Abre CSV como texto
            string fileName = GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SEVERA_N3();
            System.IO.StreamReader sr = new System.IO.StreamReader(File.OpenRead(fileName));

            int iLinhaIdx = 0;

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();

                // separa linha do CSV
                string[] valores = line.Split(',');
                double primeiraColunaComValor = 0.0;

                if (valores.Length > 3 && double.TryParse(valores[3], out primeiraColunaComValor))
                {

                    List<MaquinaInequacoesServiceReference.Variavel> variaveisDaLinha = new List<MaquinaInequacoesServiceReference.Variavel>();

                    InserirVariavelGlobal("HBO", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[9]), variaveisDaLinha);
                    InserirVariavelGlobal("MqsCanaBrava", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[11]), variaveisDaLinha);
                    
                    visao.Valores.Add(iLinhaIdx, variaveisDaLinha);

                    iLinhaIdx++;
                }

            }

            // Carrega variáveis globais na visão
            foreach (MaquinaInequacoesServiceReference.Variavel var in visao.Valores[0])
            {
                KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int> variavel = new KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>(var, 0);
                visao.Variaveis.Add(variavel);
                variaveis.Add(variavel.Key);
            }


        }

        /// <summary>
        /// Carrega funções na visão adicionando mapeamento valor da variável global para variável "interna" da função
        /// </summary>
        /// <param name="visao"></param>
        /// <param name="variaveis"></param>
        /// <param name="funcoes"></param>
        public static void CarregarFuncoes(Visao visao, List<Variavel> variaveis, List<Funcao> funcoes)
        {
            visao.Funcoes = new List<KeyValuePair<Funcao, int>>();
            int i = 0;

            // Adiciona primeiro o periodo de carga pois o resultado será usado nas outras funções (variável PeriodoCarga_SE_CO atualizada no Main.Executar()
            Funcao funcaoPeriodoCarga = funcoes.Where(f => f.Nome == "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO").FirstOrDefault();
            // xHora As Date, xDiaSemana As String, xTipo As String, Hverao
            funcaoPeriodoCarga.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "PeriodoCarga_SE_CO".ToLower()).FirstOrDefault();
            KeyValuePair<Funcao, int> funcKVP = new KeyValuePair<Funcao, int>(funcaoPeriodoCarga, i);
            visao.Funcoes.Add(funcKVP);
            
            foreach (Funcao funcao in funcoes)
            {
                Decisao decisao = new Decisao();
                List<Decisao> decisoes = new List<Decisao>();
                KeyValuePair<Funcao, int> func = new KeyValuePair<Funcao, int>();

                switch (funcao.Nome)
                {
                    case "Modulo_Limites_MOPs-Limite_GIPU_n3":
                        /*
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xlogica24";
                        decisoes.Add(decisao);
                        foreach (Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();
                        */
                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;
                        
                        break;
                    case "Modulo_Limites_MOPs-LIM_FSE_n3":
                        decisao.Inequacao = string.Empty;
                        // xcargaSIN, xelocc, , xlimite_fse
                        decisao.BlocoDeAcao = "xpercarga = PeriodoCarga_SE_CO; xhbo = vglobal_HBO;";
                        decisoes.Add(decisao);
                        foreach (Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();
                        
                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    case "Modulo_Limites_MOPs-LIM_RSE_n3":
                        decisao.Inequacao = string.Empty;
                        // xcargaSIN, xelocc, , xlimite_rse
                        decisao.BlocoDeAcao = "xpercarga = PeriodoCarga_SE_CO; xhbo = vglobal_HBO;";
                        decisoes.Add(decisao);
                        foreach (Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();

                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    case "Modulo_Limites_MOPs-LIM_FNS_n3":
                        decisao.Inequacao = string.Empty;
                        // xcargaSIN, xcbrava, xmq_sm = N_NE_SE!L6+N_NE_SE!O6
                        decisao.BlocoDeAcao = "xcbrava = vglobal_MqsCanaBrava; xhbo = vglobal_HBO; xpercarga = PeriodoCarga_SE_CO;";
                        decisoes.Add(decisao);
                        foreach (Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();

                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    case "Modulo_Limites_MOPs-LIM_FSM_n3":
                        decisao.Inequacao = string.Empty;
                        // xcargaSIN, , xmq_sm, 
                        decisao.BlocoDeAcao = "xcbrava = vglobal_MqsCanaBrava; xhbo = vglobal_HBO; xpercarga = PeriodoCarga_SE_CO;";
                        decisoes.Add(decisao);
                        foreach (Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();

                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    case "Modulo_Limites_MOPs-Limite_RSUL_n3":
                        // xcarga_SIN
                        
                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    
                    default:
                        break;
                }


            }

        }

        public static void InserirVariavelGlobal(string nomeVariavel, MaquinaInequacoesServiceReference.TipoDado tipoDado, object valor, List<MaquinaInequacoesServiceReference.Variavel> variaveisDaLinha)
        {
            MaquinaInequacoesServiceReference.Variavel variavel = new MaquinaInequacoesServiceReference.Variavel();
            variavel.Nome = "vglobal_" + nomeVariavel;
            variavel.TipoDado = tipoDado;
            variavel.Valor = valor;
            variaveisDaLinha.Add(variavel);

        }

        private static string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SEVERA_N3()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SEVERA_N3";
            //  @"\ValidacaoLimites\Dados\Spreadsheet_Example02_SEVERA_N3.csv";
            try
            {
                result = System.Configuration.ConfigurationSettings.AppSettings[key];
            }
            catch (Exception iEx)
            {
                throw new Exception("Erro ao carregar chave '" + key + "' do arquivo de configuração (app.config)", iEx);
            }

            return result;
        }

    }
}
