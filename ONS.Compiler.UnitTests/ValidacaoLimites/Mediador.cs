using ONS.Compiler.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ONS.Compiler.UnitTests.ValidacaoLimites
{
    public class Mediador
    {
        public Dictionary<int, SheetRow_S_SE> linhas_S_SE = new Dictionary<int,SheetRow_S_SE>();
        public Dictionary<int, SheetRow_SUL> linhas_SUL = new Dictionary<int, SheetRow_SUL>();
        public void CarregaDados_SheetRow_S_SE()
        {
            linhas_S_SE.Clear();

            //Abre CSV como texto
            string fileName = GetCaminhoCompletoArquivoTeste();
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
                    
                    sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA = valores[24].Trim();
                    sheetRow_S_SE.LDretorno_LIM_RSUL_FSUL_SUP_RSUL = double.Parse(valores[18]);
                    linhas_S_SE.Add(iLinhaIdx, sheetRow_S_SE);
                    iLinhaIdx++;
                }

            }
        }

        public void CarregaDados_SheetRow_SUL()
        {
            linhas_SUL.Clear();

            //Abre CSV como texto
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\Dados\Spreadsheet_Example02_SUL.csv";
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
                    
                    sheetRow_SUL.MC_G1 = double.Parse(valores[39]);
                    sheetRow_SUL.MC_G2 = double.Parse(valores[40]);
                    sheetRow_SUL.MC_G3 = double.Parse(valores[41]);
                    sheetRow_SUL.MC_G4 = double.Parse(valores[42]);

                    linhas_SUL.Add(iLinhaIdx, sheetRow_SUL);
                    iLinhaIdx++;
                }

            }
        }

        public void CarregaMemoriaDeCalculo(InequationEngine maquinaInequacoes, string funcao)
        {
            // Parse memória de cálculo no formato txt
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\ListasDecisoes\Modulo_Interligacao_SSE-LIMITE_RSUL-MC.txt";
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
                            if (double.TryParse(varValue.ToString(), out testDouble))
                                varType = VariableDataType.Numeric;
                            else if (bool.TryParse(varValue.ToString(), out testBool))
                                varType = VariableDataType.Boolean;
                            else
                                throw new Exception("Erro ao carregar memória de cálculo do arquivo [" + fileName + "]. Formato de valor na definição de variável inválida em: " + line);

                        }
                    }
                    
                    Variable var = new Variable(varName, varType, varValue);
                    maquinaInequacoes.CalculationMemory.Add(var);

                }
            }

        }

        /// <summary>
        /// Carrega a lista de decisões pelo nome da função (arquivo)
        /// </summary>
        /// <param name="funcao"></param>
        /// <returns></returns>
        public void CarregaListaDecisoes(InequationEngine maquinaInequacoes, string funcao)
        {
            KeyValuePair<string, string> decisao = new KeyValuePair<string, string>();

            //Abre lista de decisões
            List<string> listaDecisioesOrdenada = new List<string>();
            string fileName = GetCaminhoBaseArquivosTeste() + @"\ValidacaoLimites\ListasDecisoes\" + funcao + "-LD.txt";
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
                    for (int i = 0; i < linhas_S_SE.Count; i++) //TODO: sem sentido
                    {
                        AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL(maquinaInequacoes, linhas_S_SE[i], linhas_SUL[i]);
                    }
                    break;
                default:
                    break;
            }
        }

        public void AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE, SheetRow_SUL sheetRow_SUL)
        {
            List<Variable> variablesList = new List<Variable>();
            // Mapeamento da MC: variáveis definidos no Modulo_Interligacao_SSE-LIMITE_RSUL-MC com objetos sheetRow_S_SE
            foreach (string varName in maquinaInequacoes.CalculationMemory.Keys)
            {
                Variable var = maquinaInequacoes.CalculationMemory[varName];
                switch (var.Mnemonic)
                {
                    case "xpercarga":
                        var.Value = sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA;
                        break;
                    case "xrsul":
                        var.Value = sheetRow_S_SE.MC_RSUL;
                        break;
                    case "xcargasul":
                        var.Value = sheetRow_S_SE.MC_CARGA_SUL;
                        break;
                    case "xugarauc":
                        var.Value = sheetRow_SUL.MC_UGs_Gerando_Araucaria;
                        break;
                    case "xugg1":
                        var.Value = sheetRow_SUL.MC_G1;
                        break;
                    case "xugg2":
                        var.Value = sheetRow_SUL.MC_G2;
                        break;
                    case "xugg3":
                        var.Value = sheetRow_SUL.MC_G3;
                        break;
                    case "xugg4":
                        var.Value = sheetRow_SUL.MC_G4;
                        break;
                    default:
                        break;
                }
                variablesList.Add(var);
            }
            maquinaInequacoes.CalculationMemory.UpdateVariables(variablesList);
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

        private string GetCaminhoCompletoArquivoTeste()
        {
            string result = string.Empty;
            //  @"\ValidacaoLimites\Dados\Spreadsheet_Example02_S_SE.csv";
            try
            {
                result = ConfigurationManager.AppSettings["CaminhoCompletoArquivoTeste"];
            }
            catch (Exception iEx)
            {
                throw new Exception("Erro ao carregar chave 'CaminhoCompletoArquivoTeste' do arquivo de configuração (app.config)", iEx);
            }

            return result;
        }

    }
}
