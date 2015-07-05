using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using ONS.Compiler.UnitTests.ValidacaoLimites;
using System.Collections.Generic;
using Ciloci.Flee.Tests;

namespace ONS.Compiler.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestDuplicateVariable()
        {
            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.String));
            try
            {
                maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.String));
            }
            catch (InequationEngineException iInEngEx)
            {
                Assert.AreEqual(iInEngEx.ExceptionType.ToString(), ExceptionType.ExistingVariableInCalcMemory.ToString());
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void TestExpressionExecution()
        {
            int a=1, b=2;
            string expressao = "(a+b)>0";
            string blocoAcaoTrue = "a=0;b=-1";
            string blocoAcaoFalse = "a=-1;b=0";

            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.Numeric, a));
            maquinaInequacoes.CalculationMemory.Add(new Variable("b", VariableDataType.Numeric, b));

            Inequation inequacao = new Inequation(expressao);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(blocoAcaoTrue);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(blocoAcaoFalse);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

            maquinaInequacoes.Compile();
            
            maquinaInequacoes.Execute();

            Assert.AreEqual(maquinaInequacoes.CalculationMemory["a"].GetValue(), 0.0);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["b"].GetValue(), -1.0);
        }

        [TestMethod]
        public void TestaCarregaDados_SheetRow_S_SE()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();

            Assert.AreEqual(true, true);

        }


        [TestMethod]
        public void TestaCarregaDados_SheetRow_SUL()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_SUL();

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaListaDecisoes_Modulo_Interligacao_SSE_LIMITE_RSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaAtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");
            mediador.AtualizaVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCompila_Modulo_Interligacao_SSE_LIMITE_RSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");

            maquinaInequacoes.Compile();
            
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaExecuta_Modulo_Interligacao_SSE_LIMITE_RSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), -1500.0);
        }

        [TestMethod]
        public void TestaExecutaComDados_Modulo_Interligacao_SSE_LIMITE_RSUL()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();
            mediador.CarregaDados_SheetRow_SUL();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");

            maquinaInequacoes.Compile();

            for(int i=0; i<mediador.linhas_S_SE.Count;i++)
            {
                mediador.AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL(maquinaInequacoes, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
                maquinaInequacoes.Execute();
                
                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDretorno_LIM_RSUL_FSUL_SUP_RSUL);
            }
        }

        [TestMethod]
        public void TestaCarregaMemoriaDeCalculo_Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaListaDecisoes_Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaAtualizaVariaveisDaMemoriaDeCalculo_Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            mediador.AtualizaVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaOperacaoComparacaoSimplesHora()
        {
            string pattern = "HH:mm:ss";
            string horaA = "00:00:00";
            string horaB = "23:59:00";
            DateTime a = DateTime.Now;
            DateTime b = DateTime.Now;
            double result = double.MinValue;
            DateTime horaConvertidaFlee = DateTime.Now;
            
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }

            string expressao = "(a>b or a<b or a=b or a<>b or a>=b or a<=b)";
            string blocoAcaoTrue = "result=100;";
            //string blocoAcaoTrue = "result=100;horaConvertidaFlee=cast(" + horaA + ");";
            string blocoAcaoFalse = "result=0;";

            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.Time, a));
            maquinaInequacoes.CalculationMemory.Add(new Variable("b", VariableDataType.Time, b));
            maquinaInequacoes.CalculationMemory.Add(new Variable("result", VariableDataType.Numeric, result));
            maquinaInequacoes.CalculationMemory.Add(new Variable("horaA", VariableDataType.String, horaA));

            Inequation inequacao = new Inequation(expressao);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(blocoAcaoTrue);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(blocoAcaoFalse);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

            maquinaInequacoes.Compile();

            maquinaInequacoes.Execute();

            Assert.AreEqual(maquinaInequacoes.CalculationMemory["a"].GetValue(), a);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["b"].GetValue(), b);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);
        }

        [TestMethod]
        public void TestaOperacaoComparacaoHora()
        {
            string pattern = "HH:mm:ss";
            string horaA = "20:27:31";
            string horaB = "20:09:50";
            DateTime a = DateTime.Now;
            DateTime b = DateTime.Now;
            double result = double.MinValue;
            DateTime horaConvertidaFlee = DateTime.Now;

            // Testa a maior que b 
            string expressao = "(a>b)";
            string blocoAcaoTrue = "result=100;";
            string blocoAcaoFalse = "result=0;";
            
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }

            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.Time, a));
            maquinaInequacoes.CalculationMemory.Add(new Variable("b", VariableDataType.Time, b));
            maquinaInequacoes.CalculationMemory.Add(new Variable("result", VariableDataType.Numeric, result));
            maquinaInequacoes.CalculationMemory.Add(new Variable("horaA", VariableDataType.String, horaA));

            Inequation inequacao = new Inequation(expressao);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(blocoAcaoTrue);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(blocoAcaoFalse);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

            maquinaInequacoes.Compile();

            maquinaInequacoes.Execute();

            Assert.AreEqual(maquinaInequacoes.CalculationMemory["a"].GetValue(), a);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["b"].GetValue(), b);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a >= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a<b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a <= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a = b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            horaA = "15:17:31";
            horaB = "15:27:31";
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }
            maquinaInequacoes.CalculationMemory.UpdateVariable("a", a);
            maquinaInequacoes.CalculationMemory.UpdateVariable("b", b);

            expressao = "(a > b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);
            
            expressao = "(a < b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a >= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a <= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a = b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            horaA = "11:00:22";
            horaB = "11:00:22";
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }
            maquinaInequacoes.CalculationMemory.UpdateVariable("a", a);
            maquinaInequacoes.CalculationMemory.UpdateVariable("b", b);

            expressao = "(a > b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a < b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a >= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a <= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a = b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

        }
        
        [TestMethod]
        public void TestaCompila_Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");

            maquinaInequacoes.Compile();

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaExecuta_Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();

            Variable PeriodoCarga_SE_CO = maquinaInequacoes.CalculationMemory["PeriodoCarga_SE_CO"];

            Assert.AreEqual(PeriodoCarga_SE_CO.GetValue(), "LEVE");
        }

        [TestMethod]
        public void TestaExecutaComDados_Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();
            
            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO");

            maquinaInequacoes.Compile();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                maquinaInequacoes.CalculationMemory.UpdateVariable("xhora", CustomFunctions.Hora(mediador.linhas_S_SE[i].PK_HoraInicFim.Key + ":00"));
                maquinaInequacoes.Execute();

                Variable PeriodoCarga_SE_CO = maquinaInequacoes.CalculationMemory["PeriodoCarga_SE_CO"];

                Assert.AreEqual(PeriodoCarga_SE_CO.GetValue(), mediador.linhas_S_SE[i].LDretorno_PERIODO_DE_CARGA);
            }
        }

        [TestMethod]
        public void TestesInternosFlee()
        {
            var bulkTests = new BulkTests();

            bulkTests.TestInvalidExpressions();
            bulkTests.TestValidExpressions();

            var benches = new Benchmarks();
            benches.TestSimpleCalcEngine();

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaMaquinaInequacaoValidacaoLimites()
        {
            /*
            InequationEngine maquinaInequacoes = new InequationEngine();
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");
            mediador.AtualizaListaDeDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_RSUL");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
           */
            Assert.AreEqual(true, true);
        }


    }
}
