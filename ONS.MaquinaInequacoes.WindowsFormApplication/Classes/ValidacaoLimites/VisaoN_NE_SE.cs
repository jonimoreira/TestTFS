using ONS.MaquinaInequacoes.WindowsFormApplication.MaquinaInequacoesServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ONS.MaquinaInequacoes.WindowsFormApplication.Classes.ValidacaoLimites
{
    public class VisaoN_NE_SE
    {
        public static void CarregarVariaveisComDados(Visao visao, List<Variavel> variaveis)
        {
            visao.Valores = new Dictionary<int, List<MaquinaInequacoesServiceReference.Variavel>>();
            visao.Variaveis = new List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>>();

            //Abre CSV como texto
            string fileName = GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_N_NE_SE();
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

                    InserirVariavelGlobal("EXP_N", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[3]), variaveisDaLinha);
                    InserirVariavelGlobal("RNE", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[4]), variaveisDaLinha);
                    InserirVariavelGlobal("FNE", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[5]), variaveisDaLinha);
                    InserirVariavelGlobal("EXP_SE", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[6]), variaveisDaLinha);
                    InserirVariavelGlobal("FMCCO", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[7]), variaveisDaLinha);
                    InserirVariavelGlobal("FSENE", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[8]), variaveisDaLinha);
                    InserirVariavelGlobal("FNS", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[9]), variaveisDaLinha);
                    InserirVariavelGlobal("FSM", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[10]), variaveisDaLinha);
                    InserirVariavelGlobal("SMGerando", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[11]), variaveisDaLinha);
                    InserirVariavelGlobal("Maqs_Laj", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[12]), variaveisDaLinha);
                    InserirVariavelGlobal("Maqs_Px", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[13]), variaveisDaLinha);
                    InserirVariavelGlobal("Maqs_SMCOp", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[14]), variaveisDaLinha);
                    InserirVariavelGlobal("CARGASIN", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[15]), variaveisDaLinha);
                    InserirVariavelGlobal("CargaNE", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[18]), variaveisDaLinha);
                    InserirVariavelGlobal("Xingo_Gera", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[19]), variaveisDaLinha);
                    InserirVariavelGlobal("Xingo_NumUgs", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[20]), variaveisDaLinha);
                    InserirVariavelGlobal("Gera_Porto_Pecem", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[21]), variaveisDaLinha);
                    
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

            // Adiciona o periodo de carga N/NE pois o resultado será usado nas outras funções 
            Funcao funcaoPeriodoCargaNNE = funcoes.Where(f => f.Nome == "Modulo_Horarios_RNE_2009-PeriodoCarga_N_NE").FirstOrDefault();
            // xHora As Date, xDiaSemana As String, xTipo As String, Hverao
            funcaoPeriodoCargaNNE.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "PeriodoCarga_N_NE".ToLower()).FirstOrDefault();
            KeyValuePair<Funcao, int> funcKVPNNE = new KeyValuePair<Funcao, int>(funcaoPeriodoCargaNNE, i);
            visao.Funcoes.Add(funcKVPNNE);

            // Adiciona o periodo de carga SE/CO pois o resultado será usado nas outras funções 
            Funcao funcaoPeriodoCarga = funcoes.Where(f => f.Nome == "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO").FirstOrDefault();
            // xHora As Date, xDiaSemana As String, xTipo As String, Hverao
            funcaoPeriodoCarga.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "PeriodoCarga_SE_CO".ToLower()).FirstOrDefault();
            i++;
            KeyValuePair<Funcao, int> funcKVP = new KeyValuePair<Funcao, int>(funcaoPeriodoCarga, i);
            visao.Funcoes.Add(funcKVP);

            // Adiciona função pois o resultado será usado nas outras funções 
            Funcao funcaoXingoMinMaqs = funcoes.Where(f => f.Nome == "Modulo_N_NE_SE_semECE_RNE_2009-min_Xingo").FirstOrDefault();
            Decisao decisaoXingo = new Decisao();
            List<Decisao> decisoesXingo = new List<Decisao>();
            decisaoXingo.Inequacao = string.Empty;
            decisaoXingo.BlocoDeAcao = "xRNE = vglobal_RNE; xger_xingo = vglobal_Xingo_Gera;";
            decisoesXingo.Add(decisaoXingo);
            foreach (Decisao dec in funcaoXingoMinMaqs.ListaDecisoes.Decisoes)
            {
                decisoesXingo.Add(dec);
            }
            funcaoXingoMinMaqs.ListaDecisoes.Decisoes = decisoesXingo.ToArray();
            funcaoXingoMinMaqs.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "maqs".ToLower()).FirstOrDefault();
            i++;
            KeyValuePair<Funcao, int> funcKVPXingo = new KeyValuePair<Funcao, int>(funcaoXingoMinMaqs, i);
            visao.Funcoes.Add(funcKVPXingo);

            foreach (Funcao funcao in funcoes)
            {
                Decisao decisao = new Decisao();
                List<Decisao> decisoes = new List<Decisao>();
                KeyValuePair<Funcao, int> func = new KeyValuePair<Funcao, int>();

                switch (funcao.Nome)
                {
                    case "Modulo_N_NE_SE_comECE_RNE_2009-ECE_ON_OFF":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xFNS = vglobal_FNS;";
                        decisoes.Add(decisao);
                        foreach (Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();

                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "estado_ece").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;
                        
                        break;

                    case "Modulo_N_NE_apoio-LimiteEXPN_N_EXP":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xpercarga = PeriodoCarga_SE_CO; xRNE = vglobal_RNE; xEXPN = vglobal_EXP_N; xFSENE = vglobal_FSENE;";
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
                    case "Modulo_N_NE_apoio-Limite_Inf_EXPN_IO_NNE":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xpercarga = PeriodoCarga_N_NE; xRNE = vglobal_RNE; xEXPN = vglobal_EXP_N; xEXPSE = vglobal_EXP_SE;";
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
                    case "Modulo_N_NE_apoio-LimiteRNE_Cenarios_N_NE_SE":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xEXPN = vglobal_EXP_N; xRNE = vglobal_RNE; xEXP_SE = vglobal_EXP_SE; xpercarga = PeriodoCarga_N_NE; x_cargaNE = vglobal_CargaNE; xugxingo = vglobal_Xingo_NumUgs; xlimugx = maqs; xFSENE = vglobal_FSENE;";
                        //xEXPN As Double, xRNE As Double, xEXP_SE As Double, xpercarga As String, x_cargaNE, xugxingo, xlimugx, xFSENE
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
                    case "Modulo_N_NE_apoio-LimiteEXP_SE_cenarios":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xpercarga = PeriodoCarga_N_NE; xRNE = vglobal_RNE; xEXP_SE = vglobal_EXP_SE; xPpecem = vglobal_Gera_Porto_Pecem; xFSENE = vglobal_FSENE;";
                        //xpercarga As String, xRNE As Double, xEXP_SE As Double, xPpecem, xFSENE
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
                    case "Modulo_N_NE_apoio-Limite_inf_EXP_SE_SE_EXP":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xpercarga = PeriodoCarga_N_NE; xRNE = vglobal_RNE; xEXPSE = vglobal_EXP_SE;";
                        //xpercarga As String, xRNE As Double, xEXPSE 
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
                    case "Modulo_N_NE_apoio-LimiteFSENE":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xpercarga = PeriodoCarga_N_NE; x_cargaNE = vglobal_CargaNE;";
                        //xpercarga As String, x_cargaNE
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
                    case "Modulo_Limites_MOPs-LimiteFNS_IO":
                        decisao.Inequacao = string.Empty;
                        // xMqIPU = vglobal_ [S_SE:U] // xECE_IPU_TUC // xMW_ug_ipu [S_SE!K6/S_SE!L6]
                        decisao.BlocoDeAcao = "xMqSM = vglobal_SMGerando; xSM_cs = vglobal_Maqs_SMCOp; xMqLJ = vglobal_Maqs_Laj; xMqPX = vglobal_Maqs_Px; xcarga_SIN = vglobal_CARGASIN; xpercarga = PeriodoCarga_N_NE; xFSM = vglobal_FSM; xFSENE = vglobal_FSENE;";
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
                    case "Modulo_Limites_MOPs-Lim_Inferior_FSM":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xEXPSE = vglobal_EXP_SE; xugSM = vglobal_SMGerando; xpercarga = PeriodoCarga_N_NE;";
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
                    case "Modulo_Limites_MOPs-Limite_Superior_FSM":
                        decisao.Inequacao = string.Empty;
                        // xMqIPU, xECE_IPU_TUC, xMW_ug_ipu
                        decisao.BlocoDeAcao = "xMqSM = vglobal_SMGerando; xSM_cs = vglobal_Maqs_SMCOp; xMqLJ = vglobal_Maqs_Laj; xMqPX = vglobal_Maqs_Px; xcarga_SIN = vglobal_CARGASIN; xpercarga = PeriodoCarga_N_NE; xEXPN = vglobal_EXP_N; xFNS = vglobal_FNS; xFSENE = vglobal_FSENE;";
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

        private static string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_N_NE_SE()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_N_NE_SE";
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
