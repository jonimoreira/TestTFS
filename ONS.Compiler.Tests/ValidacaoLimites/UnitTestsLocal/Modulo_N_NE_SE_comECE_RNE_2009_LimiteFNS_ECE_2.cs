﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using System.Collections.Generic;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_N_NE_SE_comECE_RNE_2009_LimiteFNS_ECE_2
    {
        private string nomeFuncao = "Modulo_N_NE_SE_comECE_RNE_2009-LimiteFNS_ECE_2";
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

            Assert.AreEqual(limite.GetValue(), 2500.0);
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
            
            mediador.CarregarDados_SheetRow_N_NE_SE();
            for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_N_NE_SE[i]);
            }

            Assert.AreEqual(true, true);

        }
                
        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="sheetRow_S_SE"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, SheetRow_N_NE_SE sheetRow_N_NE_SE)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xSM_CSin", sheetRow_N_NE_SE.MC_Maqs_SMCOp);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xcarga_SIN", sheetRow_N_NE_SE.MC_CARGASIN);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xMqSM", sheetRow_N_NE_SE.MC_SMGerando);
        }

    }
}
