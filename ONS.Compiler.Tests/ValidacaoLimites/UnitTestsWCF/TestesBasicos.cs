using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ONS.Compiler.Tests.ValidacaoLimites.UnitTestsWCF
{
    [TestClass]
    public class TestesBasicos
    {
        public static string MsgExceptionServicoNaoAtivo = "O serviço parece não estar ativo, verifique se o caminho é válido.";

        [TestMethod]
        public void ChamarServicoSimples()
        {
            string memoriaCalculo = @"
                    a = 1.0
                    b = 2.0
                    ";
            //To get the randon value as input from the value collection
            string listaDecisoes = "(a>b),a=1;";

            //Created a service client
            var serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();

            try
            {
                // call the service method getdata
                var response = serviceClient.ExecutarJSONcomGPL(memoriaCalculo, listaDecisoes);
            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();
                }
            }
        }


        [TestMethod]
        public void ExecutarExpressaoSimplesPorServico()
        {
            int a = 1, b = 2;
            string expressao = "(a+b)>0";
            string blocoAcaoTrue = "a=0;b=-1";

            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            MaquinaInequacoesServiceReference.Variavel variavelA = new MaquinaInequacoesServiceReference.Variavel();
            variavelA.Nome = "a";
            variavelA.TipoDado = MaquinaInequacoesServiceReference.TipoDado.Numerico;
            variavelA.Valor = a;

            MaquinaInequacoesServiceReference.Variavel variavelB = new MaquinaInequacoesServiceReference.Variavel();
            variavelB.Nome = "b";
            variavelB.TipoDado = MaquinaInequacoesServiceReference.TipoDado.Numerico;
            variavelB.Valor = b;

            MaquinaInequacoesServiceReference.MemoriaCalculo memoriaCalculo = new MaquinaInequacoesServiceReference.MemoriaCalculo();
            memoriaCalculo.Variaveis = new List<MaquinaInequacoesServiceReference.Variavel>();
            memoriaCalculo.Variaveis.Add(variavelA);
            memoriaCalculo.Variaveis.Add(variavelB);

            MaquinaInequacoesServiceReference.Decisao decisao = new MaquinaInequacoesServiceReference.Decisao();
            decisao.Inequacao = expressao;
            decisao.BlocoDeAcao = blocoAcaoTrue;

            MaquinaInequacoesServiceReference.ListaDecisoes listaDecisoes = new MaquinaInequacoesServiceReference.ListaDecisoes();
            listaDecisoes.Decisoes = new List<MaquinaInequacoesServiceReference.Decisao>();
            listaDecisoes.Decisoes.Add(decisao);

            try
            {
                memoriaCalculo = serviceClient.ExecutarJSONcomObjetos(memoriaCalculo, listaDecisoes);

                Assert.AreEqual(memoriaCalculo.Variaveis[0].Valor, 0.0);
                Assert.AreEqual(memoriaCalculo.Variaveis[1].Valor, -1.0);
            }
            catch (Exception iEx)
            {
                if (iEx is System.ServiceModel.EndpointNotFoundException)
                    throw new Exception(MsgExceptionServicoNaoAtivo, iEx);
                else
                {
                    if (serviceClient != null && serviceClient.State != System.ServiceModel.CommunicationState.Closed)
                        serviceClient.Close();
                }
            }
        }

    }
}
