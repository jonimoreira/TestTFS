using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using System.Collections.Generic;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_Interligacao_SSE_refFRS_Ger
    {
        private string nomeFuncao = "Modulo_Interligacao_SSE-refFRS_Ger";

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
            maquinaInequacoes.Execute();

            Variable limite = maquinaInequacoes.CalculationMemory["lim"];

            Assert.AreEqual(limite.GetValue(), 3000.0);
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
            mediador.CarregarDados_SheetRow_SUL();
            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
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
            mediador.CarregarDados_SheetRow_SUL();

            for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(limite.GetValue(), mediador.linhas_S_SE[i].LDvalorplanilha_Valor_referencia_FRS_Usinas);
            }
        }

        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="sheetRow_S_SE"></param>
        /// <param name="sheetRow_SUL"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, SheetRow_S_SE sheetRow_S_SE, SheetRow_SUL sheetRow_SUL)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xcargasul", sheetRow_S_SE.MC_CARGA_SUL);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xUGarauc", sheetRow_SUL.MC_Gera_Araucara);
        }

        public static void AtualizarVariaveisDaMemoriaDeCalculo(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, SheetRow_S_SE sheetRow_S_SE, SheetRow_SUL sheetRow_SUL)
        {
            Mediador.SetVariavelValor(memoriaCalculo, "xcargasul", sheetRow_S_SE.MC_CARGA_SUL);
            Mediador.SetVariavelValor(memoriaCalculo, "xUGarauc", sheetRow_SUL.MC_Gera_Araucara);
        }

    }
}
