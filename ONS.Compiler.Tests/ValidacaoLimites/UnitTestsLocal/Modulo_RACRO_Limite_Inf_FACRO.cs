using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using System.Collections.Generic;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal
{
    [TestClass]
    public class Modulo_RACRO_Limite_Inf_FACRO
    {
        private string nomeFuncao = "Modulo_RACRO-Limite_Inf_FACRO";
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

            Assert.AreEqual(limite.GetValue(), -200.0);
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
            
            mediador.CarregarDados_SheetRow_ACRO_MT();
            for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_ACRO_MT[i]);
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

            mediador.CarregarDados_SheetRow_ACRO_MT();

            for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
            {
                AtualizarVariaveisDaMemoriaDeCalculo(maquinaInequacoes, mediador.linhas_ACRO_MT[i]);
                maquinaInequacoes.Execute();

                Variable limite = maquinaInequacoes.CalculationMemory["lim"];

                Assert.AreEqual(Math.Round((double)limite.GetValue(),0), Math.Round((double)mediador.linhas_ACRO_MT[i].LDvalorplanilha_Lim_FACROInf,0));
            }
        }

        /// <summary>
        /// Atualiza as variáveis da memória de cálculo de acordo com os valores contidos nos parâmetros.
        /// </summary>
        /// <param name="maquinaInequacoes"></param>
        /// <param name="sheetRow_S_SE"></param>
        public void AtualizarVariaveisDaMemoriaDeCalculo(InequationEngine maquinaInequacoes, SheetRow_ACRO_MT sheetRow_ACRO_MT)
        {
            maquinaInequacoes.CalculationMemory.UpdateVariable("xFACRO", sheetRow_ACRO_MT.MC_FBtB);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xMaqSA", sheetRow_ACRO_MT.MC_UHESantoAntonioNumUGs);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xMaqJir", sheetRow_ACRO_MT.MC_UHJirauNumUgs);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xilha1", sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoIlha1);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xilha2", sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoIlha2);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xmesq", sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoMEsqrd);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xJirau", sheetRow_ACRO_MT.MC_UHJirauGer);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xTR_prov", sheetRow_ACRO_MT.MC_FTRpr);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xPOLO1", sheetRow_ACRO_MT.MC_POLO1);
            maquinaInequacoes.CalculationMemory.UpdateVariable("xBtB", sheetRow_ACRO_MT.MC_FBtB);
        }

        public static void AtualizarVariaveisDaMemoriaDeCalculo(MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo, SheetRow_ACRO_MT sheetRow_ACRO_MT)
        {
            Mediador.SetVariavelValor(memoriaCalculo, "xFACRO", sheetRow_ACRO_MT.MC_FBtB);
            Mediador.SetVariavelValor(memoriaCalculo, "xMaqSA", sheetRow_ACRO_MT.MC_UHESantoAntonioNumUGs);
            Mediador.SetVariavelValor(memoriaCalculo, "xMaqJir", sheetRow_ACRO_MT.MC_UHJirauNumUgs);
            Mediador.SetVariavelValor(memoriaCalculo, "xilha1", sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoIlha1);
            Mediador.SetVariavelValor(memoriaCalculo, "xilha2", sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoIlha2);
            Mediador.SetVariavelValor(memoriaCalculo, "xmesq", sheetRow_ACRO_MT.MC_UHESantoAntonioGeracaoMEsqrd);
            Mediador.SetVariavelValor(memoriaCalculo, "xJirau", sheetRow_ACRO_MT.MC_UHJirauGer);
            Mediador.SetVariavelValor(memoriaCalculo, "xTR_prov", sheetRow_ACRO_MT.MC_FTRpr);
            Mediador.SetVariavelValor(memoriaCalculo, "xPOLO1", sheetRow_ACRO_MT.MC_POLO1);
            Mediador.SetVariavelValor(memoriaCalculo, "xBtB", sheetRow_ACRO_MT.MC_FBtB);
        }

    }
}
