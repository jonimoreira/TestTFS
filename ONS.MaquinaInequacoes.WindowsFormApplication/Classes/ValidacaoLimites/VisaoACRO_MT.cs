using ONS.MaquinaInequacoes.WindowsFormApplication.MaquinaInequacoesServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ONS.MaquinaInequacoes.WindowsFormApplication.Classes.ValidacaoLimites
{
    public class VisaoACRO_MT
    {
        public static void CarregarVariaveisComDados(Visao visao, List<Variavel> variaveis)
        {
            visao.Valores = new Dictionary<int, List<MaquinaInequacoesServiceReference.Variavel>>();
            visao.Variaveis = new List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>>();

            //Abre CSV como texto
            string fileName = GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_ACRO_MT();
            System.IO.StreamReader sr = new System.IO.StreamReader(File.OpenRead(fileName));

            int iLinhaIdx = 0;

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine();

                // separa linha do CSV
                string[] valores = line.Split(',');
                double primeiraColunaComValor = 0.0;

                if (valores.Length > 3 && double.TryParse(valores[4], out primeiraColunaComValor))
                {

                    List<MaquinaInequacoesServiceReference.Variavel> variaveisDaLinha = new List<MaquinaInequacoesServiceReference.Variavel>();

                    InserirVariavelGlobal("FACRO", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[4]), variaveisDaLinha);
                    InserirVariavelGlobal("FluxoSamAq", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[5]), variaveisDaLinha);
                    InserirVariavelGlobal("FBtB", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[6]), variaveisDaLinha);
                    InserirVariavelGlobal("FTRpr", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[7]), variaveisDaLinha);
                    InserirVariavelGlobal("POLO1", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[8]), variaveisDaLinha);
                    InserirVariavelGlobal("GeracaoItqPPdr", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[22]), variaveisDaLinha);
                    InserirVariavelGlobal("UHESantoAntonioNumUGs", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[23]), variaveisDaLinha);
                    InserirVariavelGlobal("UHESantoAntonioGerTotal", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[24]), variaveisDaLinha);
                    InserirVariavelGlobal("UHESantoAntonioGeracaoIlha1", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[25]), variaveisDaLinha);
                    InserirVariavelGlobal("UHESantoAntonioGeracaoIlha2", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[26]), variaveisDaLinha);
                    InserirVariavelGlobal("UHESantoAntonioGeracaoMEsqrd", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[27]), variaveisDaLinha);
                    InserirVariavelGlobal("GerTNorteII", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[28]), variaveisDaLinha);
                    InserirVariavelGlobal("UHJirauGer", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[29]), variaveisDaLinha);
                    InserirVariavelGlobal("UHJirauNumUgs", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[30]), variaveisDaLinha);
                    
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
            /*
            // Adiciona primeiro o periodo de carga pois o resultado será usado nas outras funções (variável PeriodoCarga_SE_CO atualizada no Main.Executar()
            Funcao funcaoPeriodoCarga = funcoes.Where(f => f.Nome == "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO").FirstOrDefault();
            // xHora As Date, xDiaSemana As String, xTipo As String, Hverao
            funcaoPeriodoCarga.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "PeriodoCarga_SE_CO".ToLower()).FirstOrDefault();
            KeyValuePair<Funcao, int> funcKVP = new KeyValuePair<Funcao, int>(funcaoPeriodoCarga, i);
            visao.Funcoes.Add(funcKVP);
            */
            foreach (Funcao funcao in funcoes)
            {
                Decisao decisao = new Decisao();
                List<Decisao> decisoes = new List<Decisao>();
                KeyValuePair<Funcao, int> func = new KeyValuePair<Funcao, int>();

                switch (funcao.Nome)
                {
                    case "Modulo_Acre_Rondonia_MT-limite_FMT":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "ger_Itq_PPdr = vglobal_GeracaoItqPPdr;";
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
                        
                    case "Modulo_RACRO-Limite_Sup_FACRO":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xBtB  = vglobal_FBtB; xTR_prov = vglobal_FTRpr; t_nort = vglobal_GerTNorteII; xPOLO1 = vglobal_POLO1";
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

                    case "Modulo_RACRO-Limite_Inf_FACRO":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xFACRO = vglobal_FACRO; xMaqSA = vglobal_UHESantoAntonioNumUGs; xMaqJir = vglobal_UHJirauNumUgs; xilha1 = vglobal_UHESantoAntonioGeracaoIlha1; xilha2 = vglobal_UHESantoAntonioGeracaoIlha1; xmesq = vglobal_UHESantoAntonioGeracaoMEsqrd; xJirau = vglobal_UHJirauGer; xTR_prov = vglobal_FTRpr; xBtB  = vglobal_FBtB; xPOLO1 = vglobal_POLO1";
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


                    case "Modulo_RACRO-Limite_Sam_Ariq":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xTN2 = vglobal_GerTNorteII;";
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

                    case "Modulo_RACRO-Limite_BtB":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xPOLO1 = vglobal_POLO1; xMaqSA = vglobal_UHESantoAntonioNumUGs; xMaqJir = vglobal_UHJirauNumUgs; xTR_prov = vglobal_FTRpr; Facro = vglobal_FACRO;"; 
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
                    case "Modulo_RACRO-Limite_TRprov":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xFACRO = vglobal_FACRO; xPOLO1 = vglobal_POLO1; xMaqSA = vglobal_UHESantoAntonioNumUGs; xMaqJir = vglobal_UHJirauNumUgs; xBtB = vglobal_FBtB;";
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
                    case "Modulo_RACRO-Limite_POLO":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xPolo = vglobal_POLO1; BtB = vglobal_FBtB; xMaqSA = vglobal_UHESantoAntonioNumUGs; xMaqJir = vglobal_UHJirauNumUgs;";
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
                    case "Modulo_RACRO-Limite_SA_JI":
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xPolo = vglobal_POLO1; xTR_prov = vglobal_FTRpr; xBtB = vglobal_FBtB; xGerSA = vglobal_UHESantoAntonioGerTotal; xGerJir = vglobal_UHJirauGer;";
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

        private static string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_ACRO_MT()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_ACRO_MT";
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
