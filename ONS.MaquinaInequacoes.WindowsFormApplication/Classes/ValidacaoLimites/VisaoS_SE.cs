using ONS.MaquinaInequacoes.WindowsFormApplication.MaquinaInequacoesServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ONS.MaquinaInequacoes.WindowsFormApplication.Classes.ValidacaoLimites
{
    public class VisaoS_SE
    {
        public static void CarregarVariaveisComDados(Visao visao, List<Variavel> variaveis)
        {
            visao.Valores = new Dictionary<int, List<MaquinaInequacoesServiceReference.Variavel>>();
            visao.Variaveis = new List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>>();

            //Abre CSV como texto
            string fileName = GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_S_SE();
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

                    InserirVariavelGlobal("FSE_Programado", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[3]), variaveisDaLinha);
                    InserirVariavelGlobal("RSE_Eletrico", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[4]), variaveisDaLinha);
                    //Carregado na VisaoSUL: InserirVariavelGlobal("RSUL", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[5]), variaveisDaLinha);
                    InserirVariavelGlobal("FBAIN", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[6]), variaveisDaLinha);
                    InserirVariavelGlobal("FINBA", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[7]), variaveisDaLinha);
                    InserirVariavelGlobal("POT_ELO_CC", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[8]), variaveisDaLinha);
                    InserirVariavelGlobal("FIV", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[16]), variaveisDaLinha);
                    InserirVariavelGlobal("GIPU_60Hz", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[17]), variaveisDaLinha);
                    InserirVariavelGlobal("Mq_60Hz", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[18]), variaveisDaLinha);
                    InserirVariavelGlobal("CARGA_SIN", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[19]), variaveisDaLinha);
                    InserirVariavelGlobal("CARGA_SUL", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[20]), variaveisDaLinha);
                    InserirVariavelGlobal("LIM_ELO_CC", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[21]), variaveisDaLinha);
                    InserirVariavelGlobal("Gera_Usinas", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[22]), variaveisDaLinha);
                    
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
                    case "Modulo_Interligacao_SSE-LimiteFBAIN":
                        //-> dependencia pro xpercarga = PeriodoCarga_SE_CO(...): executado no SUL (melhoria: não executar novamente)
                        
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xNMaqIpu = vglobal_Mq_60Hz; xGerIPU = vglobal_GIPU_60Hz; xpercarga = PeriodoCarga_SE_CO;"; // xangra = vglobal_GIPU_60Hz";
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
                    case "Modulo_Interligacao_SSE-limiteFINBA":
                        // dependência da VisaoSUL: xUGarauc, x_refFRS_Ger, xFRS_GerUSs, xJLP, xJLM, xJLG, xJLGG
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xrsul = vglobal_RSUL; xcargasul = vglobal_CARGA_SUL;";
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
                    case "Modulo_Interligacao_SSE-LimiteFSE":
                        // xpercarga <- PeriodoCarga_SE_CO
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xMaqIpu = vglobal_Mq_60Hz; xGerIPU = vglobal_GIPU_60Hz; xpercarga = PeriodoCarga_SE_CO;";
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
                    case "Modulo_Interligacao_SSE-Limite_RSE":
                        // xpercarga <- PeriodoCarga_SE_CO
                        // xangra
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xelo = vglobal_POT_ELO_CC; xMaq = vglobal_Mq_60Hz; xGerIPU = vglobal_GIPU_60Hz; xrsul = vglobal_RSUL; xpercarga = PeriodoCarga_SE_CO;";
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
                    case "Modulo_Interligacao_SSE-LIMITE_RSUL":
                        // xpercarga <- PeriodoCarga_SE_CO
                        // VisaoSUL: xUGarauc, xugG1, xugG2, xugG3, xugG4
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xrsul = vglobal_RSUL; xcargasul = vglobal_CARGA_SUL; xelo = vglobal_POT_ELO_CC; xMaq = vglobal_Mq_60Hz; xGerIPU = vglobal_GIPU_60Hz; xpercarga = PeriodoCarga_SE_CO;";
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
                    case "Modulo_Interligacao_SSE-LIMITE_FSUL":
                        // xpercarga <- PeriodoCarga_SE_CO
                        /*
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = " ";
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
                    case "Modulo_Interligacao_SSE-Mqs_CORTE_FIPU_FSE":
                        
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = " xFIV = vglobal_FIV; xFSE = vglobal_FSE_Programado; xMqs = vglobal_Mq_60Hz;";
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
                    case "Modulo_Interligacao_SSE-LimGIPU":
                        
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xmaq60 = vglobal_Mq_60Hz;";
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
                    case "Modulo_Interligacao_SSE-GIPU_minimo":
                        
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xrsul = vglobal_RSUL; xcargasul = vglobal_CARGA_SUL;";
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
                    case "Modulo_Interligacao_SSE-refFRS_Ger":
                        // VisaoSUL: xUGarauc
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xcargasul = vglobal_CARGA_SUL;";
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

        private static string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_S_SE()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_S_SE";
            //  @"\ValidacaoLimites\Dados\Spreadsheet_Example02_S_SE.csv";
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
