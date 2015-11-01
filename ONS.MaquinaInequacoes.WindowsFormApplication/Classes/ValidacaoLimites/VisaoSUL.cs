using ONS.MaquinaInequacoes.WindowsFormApplication.MaquinaInequacoesServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONS.MaquinaInequacoes.WindowsFormApplication.Classes.ValidacaoLimites
{
    public class VisaoSUL
    {
        
        public static void CarregarVariaveisComDados(Visao visao, List<Variavel> variaveis)
        {
            visao.Valores = new Dictionary<int, List<MaquinaInequacoesServiceReference.Variavel>>();
            visao.Variaveis = new List<KeyValuePair<MaquinaInequacoesServiceReference.Variavel, int>>();
            
            //Abre CSV como texto
            string fileName = GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SUL();
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

                    InserirVariavelGlobal("FRS", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[3]), variaveisDaLinha);
                    InserirVariavelGlobal("RSUL", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[4]), variaveisDaLinha);
                    InserirVariavelGlobal("Grbi_I", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[5]), variaveisDaLinha);
                    InserirVariavelGlobal("Grbi_II", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[6]), variaveisDaLinha);
                    InserirVariavelGlobal("CARGA_do_SUL", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[7]), variaveisDaLinha);
                    InserirVariavelGlobal("Gera_Araucara", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[8]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_GBM", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[16]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_GNB", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[17]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_SSA", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[18]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_Ita", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[19]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_Mach", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[20]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_BGrande", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[21]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_CNO", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[22]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_GPS", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[23]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_S_Osorio", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[24]), variaveisDaLinha);
                    InserirVariavelGlobal("UGs_Gerando_Araucaria", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[25]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_GBM", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[26]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_GNB", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[27]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_SSA", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[28]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_Ita", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[29]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_Mach", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[30]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_B_Grande", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[31]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_CNO", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[32]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_GPS", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[33]), variaveisDaLinha);
                    InserirVariavelGlobal("C_Sincrono_S_Osorio", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[34]), variaveisDaLinha);
                    InserirVariavelGlobal("J_Lacerda_P", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[35]), variaveisDaLinha);
                    InserirVariavelGlobal("J_Lacerda_M", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[36]), variaveisDaLinha);
                    InserirVariavelGlobal("J_Lacerda_G", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[37]), variaveisDaLinha);
                    InserirVariavelGlobal("J_Lacerda_GG", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[38]), variaveisDaLinha);
                    InserirVariavelGlobal("G1", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[39]), variaveisDaLinha);
                    InserirVariavelGlobal("G2", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[40]), variaveisDaLinha);
                    InserirVariavelGlobal("G3", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[41]), variaveisDaLinha);
                    InserirVariavelGlobal("G4", MaquinaInequacoesServiceReference.TipoDado.Numerico, double.Parse(valores[42]), variaveisDaLinha);
                    
                    visao.Valores.Add(iLinhaIdx, variaveisDaLinha);

                    iLinhaIdx++;
                }

            }

            // Carrega variáveis globais na visão
            foreach(MaquinaInequacoesServiceReference.Variavel var in visao.Valores[0])
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
            foreach(Funcao funcao in funcoes)
            {
                Decisao decisao = new Decisao();
                List<Decisao> decisoes = new List<Decisao>();
                KeyValuePair<Funcao, int> func = new KeyValuePair<Funcao, int>();

                switch(funcao.Nome)
                {
                    case "Modulo_Interligacao_SSE-UGminARAUC":
                        
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xcargasul = vglobal_CARGA_do_SUL; xrsul = vglobal_RSUL";
                        decisoes.Add(decisao);
                        foreach(Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();
                        
                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;
                        
                        break;
                    case "Modulo_Interligacao_SSE-GERminARAUC":
                        
                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xcargasul = vglobal_CARGA_do_SUL; xrsul = vglobal_RSUL";
                        decisoes.Add(decisao);
                        foreach(Decisao dec in funcao.ListaDecisoes.Decisoes)
                        {
                            decisoes.Add(dec);
                        }
                        funcao.ListaDecisoes.Decisoes = decisoes.ToArray();
                        
                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;
                        
                        break;
                    case "Modulo_GARABI_ITASSA1-LimiteSUPGARABI1":

                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    case "Modulo_GARABI_ITASSA1-LimiteINFGARABI1":

                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xGarabi1 = vglobal_Grbi_I; xGarabi2 = vglobal_Grbi_II;";
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
                    case "Modulo_GARABI_ITASSA1-LimiteSUPGARABI2":

                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xGarabi1 = vglobal_Grbi_I; xGarabi2 = vglobal_Grbi_II;";
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
                    case "Modulo_GARABI_ITASSA1-LimiteINFGARABI2":

                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "lim").FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    case "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO":
                        // xHora As Date, xDiaSemana As String, xTipo As String, Hverao
                        funcao.VariavelRetorno = variaveis.Where(v => v.Nome.Trim().ToLower() == "PeriodoCarga_SE_CO".ToLower()).FirstOrDefault();
                        func = new KeyValuePair<Funcao, int>(funcao, i);
                        visao.Funcoes.Add(func);
                        i++;

                        break;
                    case "Modulo_Interligacao_SSE-refFRS_Ger":

                        decisao.Inequacao = string.Empty;
                        decisao.BlocoDeAcao = "xcargasul = vglobal_CARGA_do_SUL; xUGarauc = vglobal_Gera_Araucara";
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

        public static string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SUL()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SUL";
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
