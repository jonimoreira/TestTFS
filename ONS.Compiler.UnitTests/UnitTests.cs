using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using ONS.Compiler.UnitTests.ValidacaoLimites;
using System.Collections.Generic;

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

            Assert.AreEqual(maquinaInequacoes.CalculationMemory["a"].Value, 0.0);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["b"].Value, -1.0);
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

            Assert.AreEqual(limite.Value, -1500.0);
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

                Assert.AreEqual(limite.Value, mediador.linhas_S_SE[i].LDretorno_LIM_RSUL_FSUL_SUP_RSUL);
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
