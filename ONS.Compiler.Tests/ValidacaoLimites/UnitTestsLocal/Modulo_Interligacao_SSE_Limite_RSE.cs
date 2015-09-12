﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_Interligacao_SSE_Limite_RSE
    {
        private string nomeFuncao = "Modulo_Interligacao_SSE-Limite_RSE";

        /// <summary>
        /// Testa o carregamento da memória de cálculo (MC) a partir do arquivo txt.
        /// </summary>
        [TestMethod]
        public void CarregarMemoriaDeCalculo()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregarMemoriaDeCalculo(maquinaInequacoes, nomeFuncao);

            Assert.AreEqual(true, true);

        }

        /// <summary>
        /// Testa o carregamento da lista de decisões (LD) a partir do arquivo txt.
        /// </summary>
        [TestMethod]
        public void CarregarListaDecisoes()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregarMemoriaDeCalculo(maquinaInequacoes, nomeFuncao);
            mediador.CarregarListaDecisoes(maquinaInequacoes, nomeFuncao);

            Assert.AreEqual(true, true);

        }

        /// <summary>
        /// Testa a compilação da lista de decisões com base nas variáveis da memória de cálculo
        /// </summary>
        [TestMethod]
        public void Compilar()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregarMemoriaDeCalculo(maquinaInequacoes, nomeFuncao);
            mediador.CarregarListaDecisoes(maquinaInequacoes, nomeFuncao);

            maquinaInequacoes.Compile();

            Assert.AreEqual(true, true);
        }

        /// <summary>
        /// Testa a execução da lista de decisões com base nas variáveis (e seus valores iniciais) da memória de cálculo
        /// </summary>
        [TestMethod]
        public void Executar()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregarMemoriaDeCalculo(maquinaInequacoes, nomeFuncao);
            mediador.CarregarListaDecisoes(maquinaInequacoes, nomeFuncao);

            maquinaInequacoes.Compile();
            //TODO: medir tempo compilação vc execução
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), 9200.0);
        }

        /// <summary>
        /// Testa atualização das variáveis na memória de cálculo de acordo com os dados provenientes da planilha
        /// </summary>
        [TestMethod]
        public void AtualizarVariaveisDaMemoriaDeCalculo()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregarMemoriaDeCalculo(maquinaInequacoes, nomeFuncao);
            mediador.CarregarListaDecisoes(maquinaInequacoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();
            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_S_SE[i]);
            }

            Assert.AreEqual(true, true);

        }

        /// <summary>
        /// Testa a execução da lista de decisões com base nas variáveis da memória de cálculo e seus valores provenientes da planilha
        /// </summary>
        [TestMethod]
        public void ExecutarComDados()
        {
            Mediador mediador = new Mediador();

            InequationEngine maquinaInequacoes = new InequationEngine();
            mediador.CarregarMemoriaDeCalculo(maquinaInequacoes, nomeFuncao);
            mediador.CarregarListaDecisoes(maquinaInequacoes, nomeFuncao);

            maquinaInequacoes.Compile();

            mediador.CarregarDados_SheetRow_S_SE();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_S_SE[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_LIM_RSE);
            }
        }

        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="sheetRow_S_SE"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xelo", sheetRow_S_SE.MC_POT_ELO_CC);
            //maquinaInequacoes.CalculationMemory.UpdateVariable("xangra", sheetRow_SUL.MC_UGs_Gerando_Araucaria);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xMaq", sheetRow_S_SE.MC_Mq_60Hz);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xGerIPU", sheetRow_S_SE.MC_GIPU_60Hz);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xrsul", sheetRow_S_SE.MC_RSUL);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA);
            
        }

        public static void AtualizarVariaveisDaMemoriaDeCalculo(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, SheetRow_S_SE sheetRow_S_SE)
        {
            Mediador.SetVariavelValor(memoriaCalculo, "xelo", sheetRow_S_SE.MC_POT_ELO_CC);
            //Mediador.SetVariavelValor(memoriaCalculo, "xangra", sheetRow_SUL.MC_UGs_Gerando_Araucaria);
            Mediador.SetVariavelValor(memoriaCalculo, "xMaq", sheetRow_S_SE.MC_Mq_60Hz);
            Mediador.SetVariavelValor(memoriaCalculo, "xGerIPU", sheetRow_S_SE.MC_GIPU_60Hz);
            Mediador.SetVariavelValor(memoriaCalculo, "xrsul", sheetRow_S_SE.MC_RSUL);
            Mediador.SetVariavelValor(memoriaCalculo, "xpercarga", sheetRow_S_SE.LDretorno_PERIODO_DE_CARGA);
            
        }

    }
}
