﻿using ONS.Compiler.Business;
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
        public Dictionary<int, SheetRow_N_NE_SE> linhas_N_NE_SE = new Dictionary<int, SheetRow_N_NE_SE>();
        public Dictionary<int, SheetRow_SEVERA_N3> linhas_SEVERA_N3 = new Dictionary<int, SheetRow_SEVERA_N3>();
        public Dictionary<int, SheetRow_ACRO_MT> linhas_ACRO_MT = new Dictionary<int, SheetRow_ACRO_MT>();
        
        public void CarregarDados_SheetRow_S_SE()
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
                    sheetRow_S_SE.LDvalorplanilha_Mqs_crt_IPU_max = double.Parse(valores[20]);
                    sheetRow_S_SE.LDvalorplanilha_Limite_GIPU_SUP = double.Parse(valores[21]);
                    sheetRow_S_SE.LDvalorplanilha_Limite_GIPU_INF = double.Parse(valores[22]);
                    sheetRow_S_SE.LDvalorplanilha_PERIODO_DE_CARGA = valores[24].Trim();
                    sheetRow_S_SE.LDvalorplanilha_Valor_referencia_FRS_Usinas = double.Parse(valores[26]);

                    linhas_S_SE.Add(iLinhaIdx, sheetRow_S_SE);
                    iLinhaIdx++;
                }

            }

            // Atualiza retorno do periodo de carga (LDretorno_PERIODO_DE_CARGA)
            // TODO: passar parametro bool se for para executar (cuidado com complexidade ciclomática)
            
            InequationEngine maquinaInequacoes = new InequationEngine();
            CarregarMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            CarregarListaDecisoes(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            maquinaInequacoes.Compile();

            foreach (int key in linhas_S_SE.Keys)
            {
                maquinaInequacoes.CalculationMemory.UpdateVariable("xhora", CustomFunctions.Hora(linhas_S_SE[key].PK_HoraInicFim.Key + ":00"));
                maquinaInequacoes.Execute();
                linhas_S_SE[key].LDretorno_PERIODO_DE_CARGA = maquinaInequacoes.CalculationMemory["PeriodoCarga_SE_CO"].GetValue().ToString();
            }
             
        }

        public void CarregarDados_SheetRow_SUL()
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

                    sheetRow_SUL.MC_C_Sincrono_GBM = double.Parse(valores[26]);
                    sheetRow_SUL.MC_C_Sincrono_GNB = double.Parse(valores[27]);
                    sheetRow_SUL.MC_C_Sincrono_SSA = double.Parse(valores[28]);
                    sheetRow_SUL.MC_C_Sincrono_Ita = double.Parse(valores[29]);
                    sheetRow_SUL.MC_C_Sincrono_Mach = double.Parse(valores[30]);
                    sheetRow_SUL.MC_C_Sincrono_B_Grande = double.Parse(valores[31]);
                    sheetRow_SUL.MC_C_Sincrono_CNO = double.Parse(valores[32]);
                    sheetRow_SUL.MC_C_Sincrono_GPS = double.Parse(valores[33]);
                    sheetRow_SUL.MC_C_Sincrono_S_Osorio = double.Parse(valores[34]);

                    sheetRow_SUL.MC_J_Lacerda_P = double.Parse(valores[35]);
                    sheetRow_SUL.MC_J_Lacerda_M = double.Parse(valores[36]);
                    sheetRow_SUL.MC_J_Lacerda_G = double.Parse(valores[37]);
                    sheetRow_SUL.MC_J_Lacerda_GG = double.Parse(valores[38]);
                    
                    sheetRow_SUL.MC_G1 = double.Parse(valores[39]);
                    sheetRow_SUL.MC_G2 = double.Parse(valores[40]);
                    sheetRow_SUL.MC_G3 = double.Parse(valores[41]);
                    sheetRow_SUL.MC_G4 = double.Parse(valores[42]);

                    sheetRow_SUL.LD_ValorReferenciaFRS_Usinas = double.Parse(valores[43]);

                    sheetRow_SUL.LDvalorplanilha_UgminAraucaria = double.Parse(valores[9]);
                    sheetRow_SUL.LDvalorplanilha_GeracaoMinimaAraucara = double.Parse(valores[10]);
                    sheetRow_SUL.LDvalorplanilha_LimGrbiISUPImport = double.Parse(valores[11]);
                    sheetRow_SUL.LDvalorplanilha_LimGrbiIINFExport = double.Parse(valores[12]);
                    sheetRow_SUL.LDvalorplanilha_LimGrbiIISUPImport = double.Parse(valores[13]);
                    sheetRow_SUL.LDvalorplanilha_LimGrbiIIINFExport = double.Parse(valores[14]);
                    
                    linhas_SUL.Add(iLinhaIdx, sheetRow_SUL);
                    iLinhaIdx++;
                }

            }
        }

        public void CarregarDados_SheetRow_ACRO_MT()
        {
            linhas_ACRO_MT.Clear();

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

                    SheetRow_ACRO_MT sheetRow_ACRO_MT = new SheetRow_ACRO_MT();
                    sheetRow_ACRO_MT.PK_HoraInicFim = new KeyValuePair<string, string>(valores[1].Trim(), valores[2].Trim());

                    sheetRow_ACRO_MT.LDvalorplanilha_Limite_FMT = double.Parse(valores[9]);
                    sheetRow_ACRO_MT.LDvalorplanilha_Lim_FACROSup = double.Parse(valores[10]);
                    sheetRow_ACRO_MT.LDvalorplanilha_Lim_FACROInf = double.Parse(valores[11]);
                    sheetRow_ACRO_MT.LDvalorplanilha_LimiteSm_Aq = double.Parse(valores[12]);
                    sheetRow_ACRO_MT.LDvalorplanilha_LimiteFBtB = double.Parse(valores[13]);
                    sheetRow_ACRO_MT.LDvalorplanilha_LimiteFTRpr = double.Parse(valores[14]);
                    sheetRow_ACRO_MT.LDvalorplanilha_LimitePOLO = double.Parse(valores[15]);
                    sheetRow_ACRO_MT.LDvalorplanilha_LimiteSAJirau = double.Parse(valores[16]);

                    sheetRow_ACRO_MT.MC_GeracaoItqPPdr = double.Parse(valores[22]);
                    sheetRow_ACRO_MT.MC_FACRO = double.Parse(valores[4]);
                    sheetRow_ACRO_MT.MC_FluxoSamAq = double.Parse(valores[5]);
                    sheetRow_ACRO_MT.MC_FBtB = double.Parse(valores[6]);
                    sheetRow_ACRO_MT.MC_FTRpr = double.Parse(valores[7]);
                    sheetRow_ACRO_MT.MC_POLO1 = double.Parse(valores[8]);
                    sheetRow_ACRO_MT.MC_UHESantoAntonioNumUGs = double.Parse(valores[23]);
                    sheetRow_ACRO_MT.MC_UHESantoAntonioGerTotal = double.Parse(valores[24]);
                    sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoIlha1 = double.Parse(valores[25]);
                    sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoIlha2 = double.Parse(valores[26]);
                    sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoMEsqrd = double.Parse(valores[27]);
                    sheetRow_ACRO_MT.MC_GerTNorteII = double.Parse(valores[28]);
                    sheetRow_ACRO_MT.MC_UHJirauGer = double.Parse(valores[29]);
                    sheetRow_ACRO_MT.MC_UHJirauNumUgs = double.Parse(valores[30]);

                    linhas_ACRO_MT.Add(iLinhaIdx, sheetRow_ACRO_MT);
                    iLinhaIdx++;
                }
            }

            if (linhas_ACRO_MT.Count == 0) throw new Exception("Lista de valores de linhas_ACRO_MT não foi carregada. Verificar arquivo: " + fileName);
        }

        public void CarregarDados_SheetRow_N_NE_SE()
        {
            linhas_SUL.Clear();

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

                    SheetRow_N_NE_SE sheetRow_N_NE_SE = new SheetRow_N_NE_SE();
                    sheetRow_N_NE_SE.PK_HoraInicFim = new KeyValuePair<string, string>(valores[1].Trim(), valores[2].Trim());
                    sheetRow_N_NE_SE.MC_EXP_N = double.Parse(valores[3]);
                    sheetRow_N_NE_SE.MC_RNE = double.Parse(valores[4]);
                    sheetRow_N_NE_SE.MC_FNE = double.Parse(valores[5]);
                    sheetRow_N_NE_SE.MC_EXP_SE = double.Parse(valores[6]);
                    sheetRow_N_NE_SE.MC_FMCCO = double.Parse(valores[7]);
                    sheetRow_N_NE_SE.MC_FSENE = double.Parse(valores[8]);
                    sheetRow_N_NE_SE.MC_FNS = double.Parse(valores[9]);
                    sheetRow_N_NE_SE.MC_FSM = double.Parse(valores[10]);
                    sheetRow_N_NE_SE.MC_SMGerando = double.Parse(valores[11]);
                    sheetRow_N_NE_SE.MC_Maqs_Laj = double.Parse(valores[12]);
                    sheetRow_N_NE_SE.MC_Maqs_Px = double.Parse(valores[13]);
                    sheetRow_N_NE_SE.MC_Maqs_SMCOp = double.Parse(valores[14]);
                    sheetRow_N_NE_SE.MC_CARGASIN = double.Parse(valores[15]);
                    sheetRow_N_NE_SE.MC_CargaNE = double.Parse(valores[18]);
                    sheetRow_N_NE_SE.MC_Xingo_Gera = double.Parse(valores[19]);
                    sheetRow_N_NE_SE.MC_Xingo_NumUgs = double.Parse(valores[20]);
                    sheetRow_N_NE_SE.MC_Gera_Porto_Pecem = double.Parse(valores[21]);

                    sheetRow_N_NE_SE.LDvalorplanilha_ECETUCIPU = valores[17].Trim();
                    sheetRow_N_NE_SE.LDvalorplanilha_LimiteEXPN_SUP = double.Parse(valores[22]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimiteEXPN_INF = double.Parse(valores[23]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimiteRNE = double.Parse(valores[24]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimiteEXP_SE_Sup = double.Parse(valores[26]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimiteEXP_SE_Inf = double.Parse(valores[27]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimiteFSENE = double.Parse(valores[29]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimFNS_N2 = double.Parse(valores[30]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimFSM_N2_Inf = double.Parse(valores[31]);
                    sheetRow_N_NE_SE.LDvalorplanilha_LimFSM_N2_Sup = double.Parse(valores[32]);
                    
                    sheetRow_N_NE_SE.LDvalorplanilha_Xingo_MinMaqs = double.Parse(valores[33]);
                    sheetRow_N_NE_SE.LDvalorplanilha_PerCargaNNE = valores[34].Trim();
                    
                    linhas_N_NE_SE.Add(iLinhaIdx, sheetRow_N_NE_SE);
                    iLinhaIdx++;
                }

            }
        }

        public void CarregarDados_SheetRow_SEVERA_N3()
        {
            linhas_SUL.Clear();

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

                    SheetRow_SEVERA_N3 sheetRow_SEVERA_N3 = new SheetRow_SEVERA_N3();
                    sheetRow_SEVERA_N3.PK_HoraInicFim = new KeyValuePair<string, string>(valores[1].Trim(), valores[2].Trim());
                    sheetRow_SEVERA_N3.MC_HBO = double.Parse(valores[9]);
                    sheetRow_SEVERA_N3.MC_MqsCanaBrava = double.Parse(valores[11]);

                    sheetRow_SEVERA_N3.LDvalorplanilha_LIMITGERIPU = double.Parse(valores[12]);
                    sheetRow_SEVERA_N3.LDvalorplanilha_LIM_FSE_n3 = double.Parse(valores[14]);
                    sheetRow_SEVERA_N3.LDvalorplanilha_LIM_RSE_n3 = double.Parse(valores[15]);

                    if (!double.TryParse(valores[16], out sheetRow_SEVERA_N3.LDvalorplanilha_LIMIT_FNS))
                        sheetRow_SEVERA_N3.LDvalorplanilha_LIMIT_FNS = double.MinValue;

                    sheetRow_SEVERA_N3.LDvalorplanilha_LIMIT_FSM = double.Parse(valores[17]);
                    sheetRow_SEVERA_N3.LDvalorplanilha_LIMIT_RSUL = double.Parse(valores[18]);
                    
                    linhas_SEVERA_N3.Add(iLinhaIdx, sheetRow_SEVERA_N3);
                    iLinhaIdx++;
                }

            }
        }


        /// <summary>
        /// Método para carregar a memória de cálculo de acordo com o arquivo txt seguindo a sintaxe básica para declaração de variáveis.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="funcao">Nome completo da função de acordo com o arquivo txt. Padrão: Modulo_{nomeModulo}_{nomeFuncao}</param>
        public void CarregarMemoriaDeCalculo(InequationEngine maquinaInequacoes, string funcao)
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

                    KeyValuePair<VariableDataType, object> varTypeValue = ParseTipoVariavelValor(line, valores, fileName);
                    VariableDataType varType = varTypeValue.Key;
                    object varValue = varTypeValue.Value;

                    Variable var = new Variable(varName, varType, varValue);
                    maquinaInequacoes.CalculationMemory.Add(var);

                }
            }

        }

        public void CarregarMemoriaDeCalculo(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, string funcao)
        {
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\" + funcao + "-MC.txt";
            System.IO.StreamReader sr = new System.IO.StreamReader(File.OpenRead(fileName));

            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();
                if (line != string.Empty && line.Substring(0, 2) != "//")
                {
                    string[] valores = line.Split('=');
                    string varName = valores[0];

                    KeyValuePair<VariableDataType, object> varTypeValue = ParseTipoVariavelValor(line, valores, fileName);
                    VariableDataType varType = varTypeValue.Key;
                    object varValue = varTypeValue.Value;

                    MaquinaInequacoesServiceReference.Variavel variavel = new MaquinaInequacoesServiceReference.Variavel();
                    variavel.Nome = varName;
                    switch(varType)
                    {
                        case VariableDataType.Boolean:
                            variavel.TipoDado = MaquinaInequacoesServiceReference.TipoDado.Booleano;
                            break;
                        case VariableDataType.Numeric:
                            variavel.TipoDado = MaquinaInequacoesServiceReference.TipoDado.Numerico;
                            break;
                        case VariableDataType.String:
                            variavel.TipoDado = MaquinaInequacoesServiceReference.TipoDado.String;
                            break;
                        case VariableDataType.Time:
                            variavel.TipoDado = MaquinaInequacoesServiceReference.TipoDado.HoraMinutoSegundo;
                            break;
                        default:
                            break;
                    }
                    variavel.Valor = varValue;

                    if (memoriaCalculo.Variaveis == null)
                        memoriaCalculo.Variaveis = new List<MaquinaInequacoesServiceReference.Variavel>();

                    memoriaCalculo.Variaveis.Add(variavel);

                }
            }

        }

        private KeyValuePair<VariableDataType, object> ParseTipoVariavelValor(string line, string[] valores, string fileName)
        {
            VariableDataType varType = VariableDataType.Numeric;
            object varValue;

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
                    for (int i = 1; i < valores.Length; i++)
                    {
                        strTemp += valores[i];
                    }
                    strTemp = strTemp.Trim();
                    if (!strTemp.EndsWith("\""))
                        throw new Exception("Erro ao carregar memória de cálculo do arquivo [" + fileName + "]. Formato de valor da string na definição de variável inválida em: " + line);
                    else
                    {
                        strTemp = strTemp.Remove(0, 1); // remove " inicial
                        varValue = strTemp.Remove(strTemp.Length - 1, 1); // remove " final (se tiver no meio, deixa)
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

            KeyValuePair<VariableDataType, object> result = new KeyValuePair<VariableDataType, object>(varType, varValue);

            return result;
        }

        /// <summary>
        /// Método para carregar a lista de decisões de acordo com o arquivo txt seguindo a sintaxe básica.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="funcao">Nome completo da função de acordo com o arquivo txt. Padrão: Modulo_{nomeModulo}_{nomeFuncao}</param>
        public void CarregarListaDecisoes(InequationEngine maquinaInequacoes, string funcao)
        {
            KeyValuePair<string, string> decisao = new KeyValuePair<string, string>();

            //Abre lista de decisões
            List<string> listaDecisioesOrdenada = new List<string>();
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\" + funcao + "-LD.txt";
            StreamReader sr = new StreamReader(File.OpenRead(fileName));
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();

                if (!line.StartsWith("//") && line != string.Empty)
                {
                    KeyValuePair<string, string> inequacaoBlocoAcao = ParseInequacaoBlocoAcao(line);
                    string inequacao = inequacaoBlocoAcao.Key;
                    string blocoAcao = inequacaoBlocoAcao.Value;

                    decisao = new KeyValuePair<string, string>(inequacao, blocoAcao);
                    AtualizarListaDeDecisoes(maquinaInequacoes, decisao);
                }
            }
        }

        public void CarregarListaDecisoes(MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes, string funcao)
        {
            //Abre lista de decisões
            List<string> listaDecisioesOrdenada = new List<string>();
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\MemoriaCalculo_ListasDecisoes\" + funcao + "-LD.txt";
            StreamReader sr = new StreamReader(File.OpenRead(fileName));
            while (sr.Peek() != -1)
            {
                string line = sr.ReadLine().Trim();

                if (!line.StartsWith("//") && line != string.Empty)
                {
                    KeyValuePair<string, string> inequacaoBlocoAcao = ParseInequacaoBlocoAcao(line);
                    string inequacao = inequacaoBlocoAcao.Key;
                    string blocoAcao = inequacaoBlocoAcao.Value;

                    MaquinaInequacoesServiceReference.Decisao decisao = new MaquinaInequacoesServiceReference.Decisao();
                    decisao.Inequacao = inequacao;
                    decisao.BlocoDeAcao = blocoAcao;

                    if (listaDecisoes.Decisoes == null)
                        listaDecisoes.Decisoes = new List<MaquinaInequacoesServiceReference.Decisao>();

                    listaDecisoes.Decisoes.Add(decisao);
                }
            }
        }

        public static MaquinaInequacoesServiceReference.Variavel GetVariavelPorNome(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, string nome)
        {
            foreach (MaquinaInequacoesServiceReference.Variavel variavel in memoriaCalculo.Variaveis)
            {
                if (nome.ToLower().Trim() == variavel.Nome.ToLower().Trim())
                    return variavel;
            }
            return null;
        }

        public static void SetVariavelValor(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, string nome, object varValue)
        {
            foreach (MaquinaInequacoesServiceReference.Variavel variavel in memoriaCalculo.Variaveis)
            {
                if (nome.ToLower().Trim() == variavel.Nome.ToLower().Trim())
                {
                    variavel.Valor = varValue;
                    return;
                }
            }
        }

        private KeyValuePair<string, string> ParseInequacaoBlocoAcao(string line)
        {
            // separa inequação e bloco de ação: <ineq>,<bloco ação>
            string inequacao = line.Substring(0, line.IndexOf(","));
            string blocoAcao = line.Substring(line.IndexOf(",") + 1);
            string[] atribuicoes = blocoAcao.Split(';');
            if (atribuicoes.Length == 0)
                throw new Exception("Erro ao carregar lista de decisões do arquivo. Formato de linha na definição de atribuições na decisão inválida em: " + blocoAcao);

            KeyValuePair<string, string> result = new KeyValuePair<string, string>(inequacao, blocoAcao);
            return result;
        }

        /// <summary>
        /// Método para popular a decisão com {inequação, bloco V}. Bloco F = vazio.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="decisaoLinha"></param>
        public void AtualizarListaDeDecisoes(InequationEngine maquinaInequacoes, KeyValuePair<string, string> decisaoLinha)
        {
            Inequation inequacao = new Inequation(decisaoLinha.Key);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(decisaoLinha.Value);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(string.Empty);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

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

        private string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_ACRO_MT()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_ACRO_MT";
            
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

        private string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_N_NE_SE()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_N_NE_SE";
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

        private string GetCaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SEVERA_N3()
        {
            string result = string.Empty;
            string key = "CaminhoCompletoArquivoTeste_ValidacaoLimites_Aba_SEVERA_N3";
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
