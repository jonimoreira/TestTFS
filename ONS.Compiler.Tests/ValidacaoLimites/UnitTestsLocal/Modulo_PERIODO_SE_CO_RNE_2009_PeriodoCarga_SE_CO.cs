using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO
    {
        private string nomeFuncao = "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO";

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

            Variable PeriodoCarga_SE_CO = maquinaInequacoes.CalculationMemory["PeriodoCarga_SE_CO"];

            Assert.AreEqual(PeriodoCarga_SE_CO.GetValue(), "LEVE");
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
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, "Terça-Feira", "ÚTIL", "NORMAL");
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
                maquinaInequacoes.CalculationMemory.UpdateVariable("xhora", CustomFunctions.Hora(mediador.linhas_S_SE[i].PK_HoraInicFim.Key + ":00"));
                maquinaInequacoes.Execute();

                Variable PeriodoCarga_SE_CO = maquinaInequacoes.CalculationMemory["PeriodoCarga_SE_CO"];

                Assert.AreEqual(PeriodoCarga_SE_CO.GetValue(), mediador.linhas_S_SE[i].LDretorno_PERIODO_DE_CARGA);
            }
        }

        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="xDiaSemana"></param>
        /// <param name="xTipo"></param>
        /// <param name="Hverao"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, string xDiaSemana, string xTipo, string Hverao)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xDiaSemana", xDiaSemana);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xTipo", xTipo);
            maquinaInequacoes.CalculationMemory.UpdateVariable("Hverao", Hverao);
        }

    }
}
