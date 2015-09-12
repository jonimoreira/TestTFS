using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Tests.ValidacaoLimites.UnitTestsLocal;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsWCF
{
    [TestClass]
    public class TestesPlanilhaAba_SEVERAN3
    {
        [TestMethod]
        public void LimiteGeracaoIPU()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Limites_MOPs-Limite_GIPU_n3";
            Mediador mediador = new Mediador();
            
            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_N_NE_SE();
            mediador.CarregarDados_SheetRow_SEVERA_N3();

            try
            {   
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_Limite_GIPU_n3.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SEVERA_N3[i].LDvalorplanilha_LIMITGERIPU);
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

            string nomeFuncao = "Modulo_Limites_MOPs-LIM_FSE_n3";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SEVERA_N3();
            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_LIM_FSE_n3.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SEVERA_N3[i], mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SEVERA_N3[i].LDvalorplanilha_LIMITGERIPU);
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

            string nomeFuncao = "Modulo_Limites_MOPs-LIM_RSE_n3";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SEVERA_N3();
            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_LIM_RSE_n3.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SEVERA_N3[i], mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SEVERA_N3[i].LDvalorplanilha_LIM_FSE_n3);
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
        public void LimiteFNS()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Limites_MOPs-LIM_FNS_n3";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SEVERA_N3();
            mediador.CarregarDados_SheetRow_S_SE();
            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_LIM_FNS_n3.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SEVERA_N3[i], mediador.linhas_S_SE[i], mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    MaquinaInequacoesServiceReference.Variavel limite = Mediador.GetVariavelPorNome(memoriaCalculo, "lim");
                    MaquinaInequacoesServiceReference.Variavel limiteTexto = Mediador.GetVariavelPorNome(memoriaCalculo, "limTexto");

                    if (limiteTexto.Valor.ToString().Trim() != string.Empty)
                        Assert.AreEqual(limiteTexto.Valor, "!Maq.C.Brava!");
                    else
                        Assert.AreEqual(limite.Valor, mediador.linhas_SEVERA_N3[i].LDvalorplanilha_LIMIT_FNS);
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
        public void LimiteFSM()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Limites_MOPs-LIM_FSM_n3";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SEVERA_N3();
            mediador.CarregarDados_SheetRow_S_SE();
            mediador.CarregarDados_SheetRow_N_NE_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_N_NE_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_LIM_FSM_n3.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_SEVERA_N3[i], mediador.linhas_S_SE[i], mediador.linhas_N_NE_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SEVERA_N3[i].LDvalorplanilha_LIMIT_FSM);
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
        public void LimiteRSUL()
        {
            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();

            string nomeFuncao = "Modulo_Limites_MOPs-Limite_RSUL_n3";
            Mediador mediador = new Mediador();

            mediador.CarregarMemoriaDeCalculo(memoriaCalculo, nomeFuncao);
            mediador.CarregarListaDecisoes(listaDecisoes, nomeFuncao);

            mediador.CarregarDados_SheetRow_SEVERA_N3();
            mediador.CarregarDados_SheetRow_S_SE();

            try
            {
                for (int i = 0; i < mediador.linhas_S_SE.Count; i++)
                {
                    Modulo_Limites_MOPs_Limite_RSUL_n3.AtualizarVariaveisDaMemoriaDeCalculo(memoriaCalculo, mediador.linhas_S_SE[i]);
                    memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

                    Assert.AreEqual(Mediador.GetVariavelPorNome(memoriaCalculo, "lim").Valor, mediador.linhas_SEVERA_N3[i].LDvalorplanilha_LIMIT_RSUL);
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
