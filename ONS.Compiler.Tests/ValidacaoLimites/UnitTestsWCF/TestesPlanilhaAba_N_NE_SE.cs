using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsWCF
{
    [TestClass]
    public class TestesPlanilhaAba_N_NE_SE
    {
        [TestMethod]
        public void ECE_TUC_IPU()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_SE_comECE_RNE_2009-ECE_ON_OFF";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_SE_comECE_RNE_2009_ECE_ON_OFF.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "estado_ece").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_ECETUCIPU);
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
        public void LimiteEXPNSuperior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_apoio-LimiteEXPN_N_EXP";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_apoio_LimiteEXPN_N_EXP.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimiteEXPN_SUP);
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
        public void LimiteEXPNInferior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_apoio-Limite_Inf_EXPN_IO_NNE";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_apoio_Limite_Inf_EXPN_IO_NNE.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimiteEXPN_INF);
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
        public void LimiteRNE()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_apoio-LimiteRNE_Cenarios_N_NE_SE";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_apoio_LimiteRNE_Cenarios_N_NE_SE.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimiteRNE);
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
        public void LimiteEXP_SESuperior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_apoio-LimiteEXP_SE_cenarios";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_apoio_LimiteEXP_SE_cenarios.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimiteEXP_SE_Sup);
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
        public void LimiteEXP_SEInferior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_apoio-Limite_inf_EXP_SE_SE_EXP";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_apoio_Limite_inf_EXP_SE_SE_EXP.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimiteEXP_SE_Inf);
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
        public void LimiteFSENE()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_apoio-LimiteFSENE";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_apoio_LimiteFSENE.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimiteFSENE);
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
        public void LimiteFNS_N2()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Limites_MOPs-LimiteFNS_IO";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();
            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_LimiteFNS_IO.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i], mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimFNS_N2);
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
        public void LimiteFSM_N2Inferior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Limites_MOPs-Lim_Inferior_FSM";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();
            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_Lim_Inferior_FSM.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i], mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimFSM_N2_Inf);
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
        public void LimiteFSM_N2Superior()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Limites_MOPs-Limite_Superior_FSM";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();
            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_Limite_Superior_FSM.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i], mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_LimFSM_N2_Sup);
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
        public void XingoMinimoMaquinas()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_N_NE_SE_semECE_RNE_2009-min_Xingo";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_N_NE_SE_semECE_RNE_2009_min_Xingo.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "maqs").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_Xingo_MinMaqs);
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
        public void PeriodoCargaN_NE()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Horarios_RNE_2009-PeriodoCarga_N_NE";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Horarios_RNE_2009_PeriodoCarga_N_NE.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i], "Terça-Feira", "ÚTIL", "NORMAL");
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "PeriodoCarga_N_NE").Valor, mediador.linhas_N_NE_SE[i].LDvalorplanilha_PerCargaNNE);
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
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_PERIODO_SE_CO_RNE_2009-PeriodoCarga_SE_CO";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_PERIODO_SE_CO_RNE_2009_PeriodoCarga_SE_CO.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i], "Terça-Feira", "ÚTIL", "NORMAL");
                    memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "PeriodoCarga_SE_CO").Valor, mediador.linhas_S_SE[i].LDretorno_PERIODO_DE_CARGA);
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
