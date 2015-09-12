using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using System.Collections.Generic;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_N_NE_SE_comECE_RNE_2009_ECE_ON_OFF
    {
        private string nomeFuncao = "Modulo_N_NE_SE_comECE_RNE_2009-ECE_ON_OFF";
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

            Variable estado_ece = maquinaInequacoes.CalculationMemory["estado_ece"];

            Assert.AreEqual(estado_ece.GetValue(), "DESLIGADO");
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
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_N_NE_SE[i]);
                maquinaInequacoes.Execute();

                Variable estado_ece = maquinaInequacoes.CalculationMemory["estado_ece"];

                Assert.AreEqual(estado_ece.GetValue(), mediador.linhas_N_NE_SE[i].LDvalorplanilha_ECETUCIPU);
            }
        }

        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="sheetRow_S_SE"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, SheetRow_N_NE_SE sheetRow_N_NE_SE)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xFNS", sheetRow_N_NE_SE.MC_FNS);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xpercarga", 0.0);
        }

        public static void AtualizarVariaveisDaMemoriaDeCalculo(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, SheetRow_N_NE_SE sheetRow_N_NE_SE)
        {
            Mediador.SetVariavelValor(memoriaCalculo, "xFNS", sheetRow_N_NE_SE.MC_FNS);
            Mediador.SetVariavelValor(memoriaCalculo, "xpercarga", 0.0);
        }

    }
}
