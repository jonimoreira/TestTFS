using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsWCF
{
    [TestClass]
    public class TestesPlanilhaAba_SUL
    {
        [TestMethod]
        public void UGminAraucaria()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-UGminARAUC";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();
            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_UGminARAUC.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SUL[i].LDvalorplanilha_UgminAraucaria);
                }

            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(TestesBasicos.MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();

                    throw iEx;
                }
            }
        }

        [TestMethod]
        public void GeracaoMinimaAraucaria()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-GERminARAUC";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();
            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_GERminARAUC.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SUL[i].LDvalorplanilha_GeracaoMinimaAraucara);
                }

            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(TestesBasicos.MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();

                    throw iEx;
                }
            }
        }

        [TestMethod]
        public void LimiteGrbi1SuperiorImport()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_GARABI_ITASSA1-LimiteSUPGARABI1";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_SUL.Count; i++)
                {
                    Modulo_GARABI_ITASSA1_LimiteSUPGARABI1.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SUL[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SUL[i].LDvalorplanilha_LimGrbiISUPImport);
                }

            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(TestesBasicos.MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();

                    throw iEx;
                }
            }
        }

        [TestMethod]
        public void LimiteGrbi1InferiorExport()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_GARABI_ITASSA1-LimiteINFGARABI1";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_SUL.Count; i++)
                {
                    Modulo_GARABI_ITASSA1_LimiteINFGARABI1.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SUL[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SUL[i].LDvalorplanilha_LimGrbiIINFExport);
                }

            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(TestesBasicos.MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();

                    throw iEx;
                }
            }
        }

        [TestMethod]
        public void LimiteGrbi2SuperiorImport()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_GARABI_ITASSA1-LimiteSUPGARABI2";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_SUL.Count; i++)
                {
                    Modulo_GARABI_ITASSA1_LimiteSUPGARABI2.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SUL[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SUL[i].LDvalorplanilha_LimGrbiIISUPImport);
                }

            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(TestesBasicos.MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();

                    throw iEx;
                }
            }
        }

        [TestMethod]
        public void LimiteGrbi2InferiorExport()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_GARABI_ITASSA1-LimiteINFGARABI2";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_SUL.Count; i++)
                {
                    Modulo_GARABI_ITASSA1_LimiteINFGARABI2.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SUL[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SUL[i].LDvalorplanilha_LimGrbiIIINFExport);
                }

            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(TestesBasicos.MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();

                    throw iEx;
                }
            }
        }

        [TestMethod]
        public void PeriodoCargaSE_CO()
        {
            TestesPlanilhaAba_N_NE_SE testes = new TestesPlanilhaAba_N_NE_SE();
            testes.PeriodoCargaSE_CO();
        }

        [TestMethod]
        public void ValorReferenciaFRS_Usinas()
        {
            TestesPlanilhaAba_S_SE testes = new TestesPlanilhaAba_S_SE();
            testes.ValorReferenciaFRS_Usinas();
        }
    }
}
