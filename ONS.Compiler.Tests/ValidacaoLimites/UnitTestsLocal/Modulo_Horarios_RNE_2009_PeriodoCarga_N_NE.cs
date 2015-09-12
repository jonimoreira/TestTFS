using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_Horarios_RNE_2009_PeriodoCarga_N_NE
    {
        private string nomeFuncao = "Modulo_Horarios_RNE_2009-PeriodoCarga_N_NE";

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

            Variable PeriodoCarga_N_NE = maquinaInequacoes.CalculationMemory["PeriodoCarga_N_NE"];

            Assert.AreEqual(PeriodoCarga_N_NE.GetValue(), "MEDIA");
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
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_N_NE_SE[i], "Terça-Feira", "ÚTIL", "NORMAL");
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

            mediador.CarregarDados_SheetRow_N_NE_SE();

            for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_N_NE_SE[i], "Terça-Feira", "ÚTIL", "NORMAL");
                maquinaInequacoes.Execute();

                Variable PeriodoCarga_N_NE = maquinaInequacoes.CalculationMemory["PeriodoCarga_N_NE"];

                Assert.AreEqual(PeriodoCarga_N_NE.GetValue(), mediador.linhas_N_NE_SE[i].LDvalorplanilha_PerCargaNNE);
            }
        }

        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="xDiaSemana"></param>
        /// <param name="xTipo"></param>
        /// <param name="Hverao"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, SheetRow_N_NE_SE sheetRow_N_NE_SE, string xDiaSemana, string xTipo, string Hverao)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xhora", CustomFunctions.Hora(sheetRow_N_NE_SE.PK_HoraInicFim.Key + ":00"));
            //maquinaInequacoes.CalculationMemory.UpdateVariable("xDiaSemana", xDiaSemana);
            //maquinaInequacoes.CalculationMemory.UpdateVariable("xTipo", xTipo);
            //maquinaInequacoes.CalculationMemory.UpdateVariable("Hverao", Hverao);
        }

        public static void AtualizarVariaveisDaMemoriaDeCalculo(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, SheetRow_N_NE_SE sheetRow_N_NE_SE, string xDiaSemana, string xTipo, string Hverao)
        {
            Mediador.SetVariavelValor(memoriaCalculo, "xhora", CustomFunctions.Hora(sheetRow_N_NE_SE.PK_HoraInicFim.Key + ":00"));
        }

    }
}
