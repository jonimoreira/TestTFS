using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsWCF
{
    [TestClass]
    public class TestesPlanilhaAba_S_SE
    {
        [TestMethod]
        public void LimiteFBAIN()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-LimiteFBAIN";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_LimiteFBAIN.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_LIM_FBAIN);
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
        public void LimiteFINBA()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-limiteFINBA";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();
            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_limiteFINBA.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_LIM_FINBA);
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
        public void LimiteFSE()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-limiteFSE";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_LimiteFSE.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_LIM_FSE);
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
        public void LimiteRSE()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-Limite_RSE";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_Limite_RSE.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_LIM_RSE);
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
        public void LimiteRSUL_Superior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-LIMITE_RSUL";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();
            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_LIMITE_RSUL.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_LIM_RSUL_FSUL_SUP_RSUL);
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
        public void LimiteFSUL_Inferior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-LIMITE_FSUL";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_LIMITE_FSUL.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_LIM_RSUL_FSUL_INF_FSUL);
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
        public void MaquinasCorteIPUmax()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-Mqs_CORTE_FIPU_FSE";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_Mqs_CORTE_FIPU_FSE.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "corte").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_Mqs_crt_IPU_max);
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
        public void LimiteGIPUSuperior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-LimGIPU";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_LimGIPU.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_Limite_GIPU_SUP);
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
        public void LimiteGIPUInferior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-GIPU_minimo";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_GIPU_minimo.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_Limite_GIPU_INF);
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
            TestesPlanilhaAba_N_NE_SE teste = new TestesPlanilhaAba_N_NE_SE();
            teste.PeriodoCargaSE_CO();
        }



        [TestMethod]
        public void ValorReferenciaFRS_Usinas()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Interligacao_SSE-refFRS_Ger";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();
            mediador.CarregarDados_SheetRow_SUL();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Interligacao_SSE_refFRS_Ger.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i], mediador.linhas_SUL[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_S_SE[i].LDvalorplanilha_Valor_referencia_FRS_Usinas);
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

    }
}
