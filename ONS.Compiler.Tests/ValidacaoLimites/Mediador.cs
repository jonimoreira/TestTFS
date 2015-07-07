using ONS.Compiler.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.Tests.ValidacaoLimites
{
    public class Mediador
    {
        public Dictionary<int, SheetRow_S_SE> linhas_S_SE = new Dictionary<int,SheetRow_S_SE>();
        public Dictionary<int, SheetRow_SUL> linhas_SUL = new Dictionary<int, SheetRow_SUL>();
        public void CarregaDados_SheetRow_S_SE()
        {
            linhas_S_SE.Clear();

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
                    
                    SheetRow_S_SE sheetRow_S_SE = new SheetRow_S_SE();
                    sheetRow_S_SE.PK_HoraInicFim = new KeyValuePair<string, string>(valores[1].Trim(), valores[2].Trim());
                    sheetRow_S_SE.MC_FSE_Programado = double.Parse(valores[3]);
                    sheetRow_S_SE.MC_RSE_Eletrico = double.Parse(valores[4]);
                    sheetRow_S_SE.MC_RSUL = double.Parse(valores[5]);
                    sheetRow_S_SE.MC_FBAIN = double.Parse(valores[6]);
                    sheetRow_S_SE.MC_FINBA = double.Parse(valores[7]);
                    sheetRow_S_SE.MC_POT_ELO_CC = double.Parse(valores[8]);
                    sheetRow_S_SE.MC_FIV = double.Parse(valores[9]);
                    sheetRow_S_SE.MC_GIPU_60Hz = double.Parse(valores[10]);
                    sheetRow_S_SE.MC_Mq_60Hz = double.Parse(valores[11]);
                    sheetRow_S_SE.MC_CARGA_SIN = double.Parse(valores[12]);
                    sheetRow_S_SE.MC_CARGA_SUL = double.Parse(valores[13]);
                    sheetRow_S_SE.MC_LIM_ELO_CC = valores[23].Trim().ToLower();
                    sheetRow_S_SE.MC_Gera_Usinas = double.Parse(valores[25]);

                    sheetRow_S_SE.LDvalorplanilha_LIM_FBAIN = double.Parse(valores[14]);
                    sheetRow_S_SE.LDvalorplanilha_LIM_FINBA = double.Parse(valores[15]);
                    sheetRow_S_SE.LDvalorplanilha_LIM_FSE = double.Parse(valores[16]);
                    sheetRow_S_SE.LDvalorplanilha_LIM_RSE = double.Parse(valores[17]);
                    sheetRow_S_SE.LDvalorplanilha_LIM_RSUL_FSUL_SUP_RSUL = double.Parse(valores[18]);
                    sheetRow_S_SE.LDvalorplanilha_LIM_RSUL_FSUL_INF_FSUL = double.Parse(valores[19]);

                    sheetRow_S_SE.LDvalorplanilha_PERIODO_DE_CARGA = valores[24].Trim();

                    linhas_S_SE.Add(iLinhaIdx, sheetRow_S_SE);
                    iLinhaIdx++;
                }

            }

            // Atualiza retorno do periodo de carga (LDretorno_PERIODO_DE_CARGA)
            InequationEngine maquinaInequacoes = new InequationEngine();
            CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            CarregaListaDecisoes(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            maquinaInequacoes.Compile();

            foreach (int key in linhas_S_SE.Keys)
            {
                maquinaInequacoes.CalculationMemory.UpdateVariable("xhora", CustomFunctions.Hora(linhas_S_SE[key].PK_HoraInicFim.Key + ":00"));
                maquinaInequacoes.Execute();
                linhas_S_SE[key].LDretorno_PERIODO_DE_CARGA = maquinaInequacoes.CalculationMemory["PeriodoCarga_SE_CO"].GetValue().ToString();
            }
        }

        public void CarregaDados_SheetRow_SUL()
        {
            linhas_SUL.Clear();

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

                    SheetRow_SUL sheetRow_SUL = new SheetRow_SUL();
                    sheetRow_SUL.PK_HoraInicFim = new KeyValuePair<string, string>(valores[1].Trim(), valores[2].Trim());
                    sheetRow_SUL.MC_FRS = double.Parse(valores[3]);
                    sheetRow_SUL.MC_RSUL = double.Parse(valores[4]);
                    sheetRow_SUL.MC_Grbi_I = double.Parse(valores[5]);
                    sheetRow_SUL.MC_Grbi_II = double.Parse(valores[6]);
                    sheetRow_SUL.MC_CARGA_do_SUL = double.Parse(valores[7]);
                    sheetRow_SUL.MC_Gera_Araucara = double.Parse(valores[8]);

                    sheetRow_SUL.MC_UGs_Gerando_GBM = double.Parse(valores[16]);
                    sheetRow_SUL.MC_UGs_Gerando_GNB = double.Parse(valores[17]);
                    sheetRow_SUL.MC_UGs_Gerando_SSA = double.Parse(valores[18]);
                    sheetRow_SUL.MC_UGs_Gerando_Ita = double.Parse(valores[19]);
                    sheetRow_SUL.MC_UGs_Gerando_Mach = double.Parse(valores[20]);
                    sheetRow_SUL.MC_UGs_Gerando_BGrande = double.Parse(valores[21]);
                    sheetRow_SUL.MC_UGs_Gerando_CNO = double.Parse(valores[22]);
                    sheetRow_SUL.MC_UGs_Gerando_GPS = double.Parse(valores[23]);
                    sheetRow_SUL.MC_UGs_Gerando_S_Osorio = double.Parse(valores[24]);
                    sheetRow_SUL.MC_UGs_Gerando_Araucaria = double.Parse(valores[25]);

                    sheetRow_SUL.MC_C_Sincrono_GBM = double.Parse(valores[16]);
                    sheetRow_SUL.MC_C_Sincrono_GNB = double.Parse(valores[17]);
                    sheetRow_SUL.MC_C_Sincrono_SSA = double.Parse(valores[18]);
                    sheetRow_SUL.MC_C_Sincrono_Ita = double.Parse(valores[19]);
                    sheetRow_SUL.MC_C_Sincrono_Mach = double.Parse(valores[20]);
                    sheetRow_SUL.MC_C_Sincrono_B_Grande = double.Parse(valores[21]);
                    sheetRow_SUL.MC_C_Sincrono_CNO = double.Parse(valores[22]);
                    sheetRow_SUL.MC_C_Sincrono_GPS = double.Parse(valores[23]);
                    sheetRow_SUL.MC_C_Sincrono_S_Osorio = double.Parse(valores[24]);

                    sheetRow_SUL.MC_J_Lacerda_P = double.Parse(valores[25]);
                    sheetRow_SUL.MC_J_Lacerda_M = double.Parse(valores[26]);
                    sheetRow_SUL.MC_J_Lacerda_G = double.Parse(valores[27]);
                    sheetRow_SUL.MC_J_Lacerda_GG = double.Parse(valores[28]);
                    
                    sheetRow_SUL.MC_G1 = double.Parse(valores[39]);
                    sheetRow_SUL.MC_G2 = double.Parse(valores[40]);
                    sheetRow_SUL.MC_G3 = double.Parse(valores[41]);
                    sheetRow_SUL.MC_G4 = double.Parse(valores[42]);

                    sheetRow_SUL.LD_ValorReferenciaFRS_Usinas = double.Parse(valores[43]);

                    linhas_SUL.Add(iLinhaIdx, sheetRow_SUL);
                    iLinhaIdx++;
                }

            }
        }

        public void CarregaMemoriaDeCalculo(InequationEngine maquinaInequacoes, string funcao)
        {
            // Parse memória de cálculo no formato txt //Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\" + funcao + "-MC.txt";
            System.IO.StreamReader sr = new System.IO.StreamReader(File.OpenRead(fileName));
            
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();
                if (line != string.Empty && line.Substring(0, 2) != "//")
                {
                    string[] valores = line.Split('=');
                    string varName = valores[0]; 
                    object varValue;
                    VariableDataType varType = VariableDataType.Numeric;

                    if (valores.Length == 1)
                    {
                        varValue = 0.0;
                    }
                    else 
                    {
                        string valorVariavel = valores[1].Trim();
                        if (valorVariavel.StartsWith("\"")) // é string
                        {
                            string strTemp = string.Empty;
                            for (int i=1;i<valores.Length;i++)
                            {
                                strTemp += valores[i];
                            }
                            strTemp = strTemp.Trim();
                            if (!strTemp.EndsWith("\""))
                                throw new Exception("Erro ao carregar memória de cálculo do arquivo [" + fileName + "]. Formato de valor da string na definição de variável inválida em: " + line);
                            else
                            {
                                strTemp = strTemp.Remove(0,1); // remove " inicial
                                varValue = strTemp.Remove(strTemp.Length - 1,1); // remove " final (se tiver no meio, deixa)
                                varType = VariableDataType.String;
                            }
                        }
                        else
                        {
                            varValue = valores[1];
                            double testDouble = double.MinValue;
                            bool testBool = true;
                            DateTime testDateTime = DateTime.Now;
                            if (double.TryParse(varValue.ToString(), out testDouble))
                                varType = VariableDataType.Numeric;
                            else if (bool.TryParse(varValue.ToString(), out testBool))
                                varType = VariableDataType.Boolean;
                            else if (DateTime.TryParse(varValue.ToString().Replace("hora(", string.Empty).Replace(")", string.Empty), out testDateTime))
                            {
                                varType = VariableDataType.Time;
                                varValue = testDateTime;
                            }
                            else
                                throw new Exception("Erro ao carregar memória de cálculo do arquivo [" + fileName + "]. Formato de valor na definição de variável inválida em: " + line);

                        }
                    }
                    
                    Variable var = new Variable(varName, varType, varValue);
                    maquinaInequacoes.CalculationMemory.Add(var);

                }
            }

        }

        public void CarregaListaDecisoes(InequationEngine maquinaInequacoes, string funcao)
        {
            KeyValuePair<string, string> decisao = new KeyValuePair<string, string>();

            //Abre lista de decisões
            List<string> listaDecisioesOrdenada = new List<string>();
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\" + funcao + "-LD.txt";
            StreamReader sr = new StreamReader(File.OpenRead(fileName));
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();

                // separa linha
                string[] valores = line.Split(',');
                if (line.Trim() == string.Empty || (line.Length > 2 && line.Substring(0, 2) == "//"))
                {
                    // Linha vazia ou comentário
                }
                else if (valores.Length == 2)
                {
                    string inequacao = valores[0].Trim();
                    string[] atribuicoes = valores[1].Split(';');
                    if (atribuicoes.Length == 0)
                        throw new Exception("Erro ao carregar lista de decisões do arquivo. Formato de linha na definição de atribuições na decisão inválida em: " + valores[1]);

                    decisao = new KeyValuePair<string,string>(inequacao, valores[1].Trim());
                    AtualizaListaDeDecisoes(maquinaInequacoes, decisao);
                }
                else
                {
                    throw new Exception("Erro ao carregar lista de decisões do arquivo. Formato de linha na definição de decisão inválida em: " + line);                    
                }
            }
        }

        public void AtualizaListaDeDecisoes(InequationEngine maquinaInequacoes, KeyValuePair<string, string> decisaoLinha)
        {
            Inequation inequacao = new Inequation(decisaoLinha.Key);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(decisaoLinha.Value);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(string.Empty);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

        }

        public void AtualizaVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, string funcao)
        {
            switch (funcao)
            {
                case "Modulo_Interligacao_SSE-LIMITE_RSUL":
                    for (int i = 0; i < linhas_S_SE.Count; i++)
                    {
                        AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL(maquinaInequacoes, linhas_S_SE[i], linhas_SUL[i]);
                    }
                    break;
                case "Modulo_Interligacao_SSE-LimiteFBAIN":
                    for (int i = 0; i < linhas_S_SE.Count; i++) 
                    {
                        AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFBAIN(maquinaInequacoes, linhas_S_SE[i]);
                    }
                    break;
                case "Modulo_Interligacao_SSE-limiteFINBA":
                    for (int i = 0; i < linhas_S_SE.Count; i++)
                    {
                        AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_limiteFINBA(maquinaInequacoes, linhas_S_SE[i], linhas_SUL[i]);
                    }
                    break;
                case "Modulo_Interligacao_SSE-LimiteFSE":
                    for (int i = 0; i < linhas_S_SE.Count; i++)
                    {
                        AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFSE(maquinaInequacoes, linhas_S_SE[i]);
                    }
                    break;
                case "Modulo_Interligacao_SSE-Limite_RSE":
                    for (int i = 0; i < linhas_S_SE.Count; i++)
                    {
                        AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFSE(maquinaInequacoes, linhas_S_SE[i]);
                    }
                    break;
                case "Modulo_Interligacao_SSE-LIMITE_FSUL":
                    for (int i = 0; i < linhas_S_SE.Count; i++)
                    {
                        AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_FSUL(maquinaInequacoes, linhas_S_SE[i]);
                    }
                    break;
                default:
                    break;
            }
        }

        public void AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE, SheetRow_SUL sheetRow_SUL)
        {
            List<Variable> variablesList = new List<Variable>();
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xrsul", sheetRow_S_SE.MC_RSUL);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xcargasul", sheetRow_S_SE.MC_CARGA_SUL);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xugarauc", sheetRow_SUL.MC_UGs_Gerando_Araucaria);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xugg1", sheetRow_SUL.MC_G1);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xugg2", sheetRow_SUL.MC_G2);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xugg3", sheetRow_SUL.MC_G3);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xugg4", sheetRow_SUL.MC_G4);
        }

        public void AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFBAIN(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE)
        {
            List<Variable> variablesList = new List<Variable>();
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xNMaqIpu", sheetRow_S_SE.MC_Mq_60Hz);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xGerIPU", sheetRow_S_SE.MC_GIPU_60Hz);
            //maquinaInequacoes.CalculationMemory.UpdateVariable("xangra", sheetRow_SUL.MC_UGs_Gerando_Araucaria);

        }

        public void AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_limiteFINBA(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE, SheetRow_SUL sheetRow_SUL)
        {
            List<Variable> variablesList = new List<Variable>();
            maquinaInequacoes.CalculationMemory.UpdateVariable("xrsul", sheetRow_S_SE.MC_RSUL);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xcargasul", sheetRow_S_SE.MC_CARGA_SUL);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xugarauc", sheetRow_SUL.MC_UGs_Gerando_Araucaria);
            maquinaInequacoes.CalculationMemory.UpdateVariable("x_refFRS_Ger", sheetRow_SUL.LD_ValorReferenciaFRS_Usinas);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xFRS_GerUSs", sheetRow_SUL.MC_FRS - sheetRow_S_SE.MC_Gera_Usinas);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xJLP", sheetRow_SUL.MC_J_Lacerda_P);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xJLM", sheetRow_SUL.MC_J_Lacerda_M);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xJLG", sheetRow_SUL.MC_J_Lacerda_G);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xJLGG", sheetRow_SUL.MC_J_Lacerda_GG);

        }

        public void AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFSE(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE)
        {
            List<Variable> variablesList = new List<Variable>();
            //maquinaInequacoes.CalculationMemory.UpdateVariable("xangra", sheetRow_SUL.MC_UGs_Gerando_Araucaria);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xMaqIpu", sheetRow_S_SE.MC_Mq_60Hz);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xGerIPU", sheetRow_S_SE.MC_GIPU_60Hz);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA);
            // LimiteFSE($A$23,L6,K6,Y6)
            // LimiteFSE(xangra, xMaqIpu, xGerIPU, xpercarga)
        }

        public void AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_Limite_RSE(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE)
        {
            List<Variable> variablesList = new List<Variable>();
            maquinaInequacoes.CalculationMemory.UpdateVariable("xelo", sheetRow_S_SE.MC_POT_ELO_CC);
            //maquinaInequacoes.CalculationMemory.UpdateVariable("xangra", sheetRow_SUL.MC_UGs_Gerando_Araucaria);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xMaq", sheetRow_S_SE.MC_Mq_60Hz);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xGerIPU", sheetRow_S_SE.MC_GIPU_60Hz);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xrsul", sheetRow_S_SE.MC_RSUL);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA);
            // Limite_RSE(I6,$A$23, L6, K6, F6,Y6)
            // Limite_RSE(xelo, xangra, xMaq, xGerIPU, xrsul, xpercarga)
        }

        public void AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_FSUL(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE)
        {
            List<Variable> variablesList = new List<Variable>();
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA);
            
        }


        private string GetCaminhoBaseArquivosTeste()
        {
            string result = string.Empty;
            try
            { 
                result = ConfigurationManager.AppSettings["CaminhoBaseArquivosTeste"];
            }
            catch(Exception iEx)
            { 
                throw new Exception("Erro ao carregar chave 'CaminhoBaseArquivosTeste' do arquivo de configuração (app.config)", iEx);
            }

            return result;
        }

        private string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SUL()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SUL";
            //  @"\ValidacaoLimites\Dados\Spreadsheet_Example02_S_SE.csv";
            try
            {
                result = ConfigurationManager.AppSettings[key];
            }
            catch (Exception iEx)
            {
                throw new Exception("Erro ao carregar chave '" + key + "' do arquivo de configuração (app.config)", iEx);
            }

            return result;
        }

        private string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_S_SE()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_S_SE";
            //  @"\ValidacaoLimites\Dados\Spreadsheet_Example02_S_SE.csv";
            try
            {
                result = ConfigurationManager.AppSettings[key];
            }
            catch (Exception iEx)
            {
                throw new Exception("Erro ao carregar chave '" + key + "' do arquivo de configuração (app.config)", iEx);
            }

            return result;
        }

    }
}
