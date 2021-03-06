﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using System.Collections.Generic;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_Limites_MOPs_LIM_FSE_n3
    {
        private string nomeFuncao = "Modulo_Limites_MOPs-LIM_FSE_n3";
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

            Assert.AreEqual(limite.GetValue(), 0.0);
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

            mediador.CarregarDados_SheetRow_SEVERA_N3();
            mediador.CarregarDados_SheetRow_S_SE();

            for (int i = 0; i < mediador.linhas_SEVERA_N3.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_SEVERA_N3[i], mediador.linhas_S_SE[i]);
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

            mediador.CarregarDados_SheetRow_SEVERA_N3();
            mediador.CarregarDados_SheetRow_S_SE();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_SEVERA_N3[i], mediador.linhas_S_SE[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_SEVERA_N3[i].LDvalorplanilha_LIM_FSE_n3);
            }
        }

        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>    
        /// <param name="sheetRow_S_SE"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, SheetRow_SEVERA_N3 sheetRow_SEVERA_N3, SheetRow_S_SE sheetRow_S_SE)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", sheetRow_S_SE.LDvalorplanilha_PERIODO_DE_CARGA);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xcargaSIN", sheetRow_S_SE.MC_CARGA_SIN);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xelocc", sheetRow_S_SE.MC_POT_ELO_CC);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xhbo", sheetRow_SEVERA_N3.MC_HBO);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xlimite_fse", sheetRow_S_SE.LDvalorplanilha_LIM_FSE);

        }

        public static void AtualizarVariaveisDaMemoriaDeCalculo(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, SheetRow_SEVERA_N3 sheetRow_SEVERA_N3, SheetRow_S_SE sheetRow_S_SE)
        {
            Mediador.SetVariavelValor(memoriaCalculo, "xpercarga", sheetRow_S_SE.LDvalorplanilha_PERIODO_DE_CARGA);
            Mediador.SetVariavelValor(memoriaCalculo, "xcargaSIN", sheetRow_S_SE.MC_CARGA_SIN);
            Mediador.SetVariavelValor(memoriaCalculo, "xelocc", sheetRow_S_SE.MC_POT_ELO_CC);
            Mediador.SetVariavelValor(memoriaCalculo, "xhbo", sheetRow_SEVERA_N3.MC_HBO);
            Mediador.SetVariavelValor(memoriaCalculo, "xlimite_fse", sheetRow_S_SE.LDvalorplanilha_LIM_FSE);
            
        }

    }
}
