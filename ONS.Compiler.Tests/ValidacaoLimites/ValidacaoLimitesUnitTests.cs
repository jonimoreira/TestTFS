﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using ONS.Compiler.Tests.ValidacaoLimites;
using System.Collections.Generic;
using Ciloci.Flee.Tests;

namespace ONS.Compiler.Tests.ValidacaoLimites
{
    [TestClass]
    public class ValidacaoLimitesUnitTests
    {
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

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                mediador.AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_RSUL(maquinaInequacoes, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_LIM_RSUL_FSUL_SUP_RSUL);
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
        public void TestaCarregaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFBAIN()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaListaDecisoes_Modulo_Interligacao_SSE_LimiteFBAIN()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaAtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFBAIN()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");
            mediador.AtualizaVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCompila_Modulo_Interligacao_SSE_LimiteFBAIN()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");

            maquinaInequacoes.Compile();

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaExecuta_Modulo_Interligacao_SSE_LimiteFBAIN()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), 1850.0);
        }

        [TestMethod]
        public void TestaExecutaComDados_Modulo_Interligacao_SSE_LimiteFBAIN()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();
            mediador.CarregaDados_SheetRow_SUL();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFBAIN");

            maquinaInequacoes.Compile();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                mediador.AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFBAIN(maquinaInequacoes, mediador.linhas_S_SE[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_LIM_FBAIN);
            }
        }

        [TestMethod]
        public void TestaCarregaMemoriaDeCalculo_Modulo_Interligacao_SSE_limiteFINBA()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaListaDecisoes_Modulo_Interligacao_SSE_limiteFINBA()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaAtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_limiteFINBA()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");
            mediador.AtualizaVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCompila_Modulo_Interligacao_SSE_limiteFINBA()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");

            maquinaInequacoes.Compile();

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaExecuta_Modulo_Interligacao_SSE_limiteFINBA()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), 1500.0);
        }

        [TestMethod]
        public void TestaExecutaComDados_Modulo_Interligacao_SSE_limiteFINBA()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();
            mediador.CarregaDados_SheetRow_SUL();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-limiteFINBA");

            maquinaInequacoes.Compile();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                mediador.AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_limiteFINBA(maquinaInequacoes, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_LIM_FINBA);
            }
        }

        [TestMethod]
        public void TestaCarregaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaListaDecisoes_Modulo_Interligacao_SSE_LimiteFSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaAtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");
            mediador.AtualizaVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCompila_Modulo_Interligacao_SSE_LimiteFSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");

            maquinaInequacoes.Compile();

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaExecuta_Modulo_Interligacao_SSE_LimiteFSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), 6100.0);
        }

        [TestMethod]
        public void TestaExecutaComDados_Modulo_Interligacao_SSE_LimiteFSE()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LimiteFSE");

            maquinaInequacoes.Compile();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                mediador.AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LimiteFSE(maquinaInequacoes, mediador.linhas_S_SE[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_LIM_FSE);
            }
        }

        [TestMethod]
        public void TestaCarregaMemoriaDeCalculo_Modulo_Interligacao_SSE_Limite_RSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaListaDecisoes_Modulo_Interligacao_SSE_Limite_RSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaAtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_Limite_RSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");
            mediador.AtualizaVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCompila_Modulo_Interligacao_SSE_Limite_RSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");

            maquinaInequacoes.Compile();

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaExecuta_Modulo_Interligacao_SSE_Limite_RSE()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), 9200.0);
        }

        [TestMethod]
        public void TestaExecutaComDados_Modulo_Interligacao_SSE_Limite_RSE()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-Limite_RSE");

            maquinaInequacoes.Compile();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                mediador.AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_Limite_RSE(maquinaInequacoes, mediador.linhas_S_SE[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_LIM_RSE);
            }
        }

        [TestMethod]
        public void TestaCarregaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_FSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCarregaListaDecisoes_Modulo_Interligacao_SSE_LIMITE_FSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaAtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_FSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");
            mediador.AtualizaVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void TestaCompila_Modulo_Interligacao_SSE_LIMITE_FSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");

            maquinaInequacoes.Compile();

            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestaExecuta_Modulo_Interligacao_SSE_LIMITE_FSUL()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");

            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), -5900.0);
        }

        [TestMethod]
        public void TestaExecutaComDados_Modulo_Interligacao_SSE_LIMITE_FSUL()
        {
            Mediador mediador = new Mediador();

            mediador.CarregaDados_SheetRow_S_SE();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregaMemoriaDeCalculo(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");
            mediador.CarregaListaDecisoes(maquinaInequacoes, "Modulo_Interligacao_SSE-LIMITE_FSUL");

            maquinaInequacoes.Compile();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                mediador.AtualizaVariaveisDaMemoriaDeCalculo_Modulo_Interligacao_SSE_LIMITE_FSUL(maquinaInequacoes, mediador.linhas_S_SE[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_LIM_RSUL_FSUL_INF_FSUL);
            }
        }

    }
}