using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsWCF
{
    [TestClass]
    public class TestesPlanilhaAba_ACR_MT
    {
        [TestMethod]
        public void UGminAraucaria()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Acre_Rondonia_MT-limite_FMT";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_Acre_Rondonia_MT_limite_FMT.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_Limite_FMT);
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
        public void LimiteFACROSuperior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_RACRO-Limite_Sup_FACRO";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_RACRO_Limite_Sup_FACRO.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_Limite_FMT);
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
        public void LimiteFACROInferior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_RACRO-Limite_Inf_FACRO";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_RACRO_Limite_Inf_FACRO.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_Lim_FACROInf);
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
        public void LimiteSm_Aq()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_RACRO-Limite_Sam_Ariq";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_RACRO_Limite_Sam_Ariq.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_LimiteSm_Aq);
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
        public void LimiteF_BtB()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_RACRO-Limite_BtB";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_RACRO_Limite_BtB.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_LimiteFBtB);
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
        public void LimiteF_TRpr()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_RACRO-Limite_TRprov";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_RACRO_Limite_TRprov.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_LimiteFTRpr);
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
        public void LimitePOLO()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_RACRO-Limite_POLO";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_RACRO_Limite_POLO.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_LimitePOLO);
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
        public void LimiteSA_Jirau()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_RACRO-Limite_SA_JI";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_ACRO_MT();

            try
            {
                for (int i = 0; i < mediador.linhas_ACRO_MT.Count; i++)
                {
                    Modulo_RACRO_Limite_SA_JI.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_ACRO_MT[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_ACRO_MT[i].LDvalorplanilha_LimiteSAJirau);
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
    }
}
