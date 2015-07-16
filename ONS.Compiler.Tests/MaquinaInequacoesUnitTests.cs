using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using ONS.Compiler.Tests.ValidacaoLimites;
using System.Collections.Generic;
using Ciloci.Flee.Tests;

namespace ONS.Compiler.Tests
{
    [TestClass]
    public class MaquinaInequacoesUnitTests
    {
        /// <summary>
        /// Execução dos testes internos da solução do FleeC#.
        /// </summary>
        [TestMethod]
        public void RodarTestesInternosSolucaoFlee()
        {
            var bulkTests = new BulkTests();

            bulkTests.TestInvalidExpressions();
            bulkTests.TestValidExpressions();

            var benches = new Benchmarks();
            benches.TestSimpleCalcEngine();

            Assert.AreEqual(true, true);
        }

        /// <summary>
        /// Verifica se a máquina de inequações aceita variáveis com mesmo nome.
        /// Se der erro a máquina está aceitando.
        /// </summary>
        [TestMethod]
        public void CarregarVariavelDuplicada()
        {
            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.String));
            try
            {
                maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.String));
            }
            catch (InequationEngineException iInEngEx)
            {
                Assert.AreEqual(iInEngEx.ExceptionType.ToString(), ExceptionType.ExistingVariableInCalcMemory.ToString());
                return;
            }
            Assert.Fail();
        }

        /// <summary>
        /// Testa execução simples de uma decisão (inequação, bloco V, bloco F).
        /// </summary>
        [TestMethod]
        public void ExecutarExpressaoSimples()
        {
            int a=1, b=2;
            string expressao = "(a+b)>0";
            string blocoAcaoTrue = "a=0;b=-1";
            string blocoAcaoFalse = "a=-1;b=0";

            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.Numeric, a));
            maquinaInequacoes.CalculationMemory.Add(new Variable("b", VariableDataType.Numeric, b));

            Inequation inequacao = new Inequation(expressao);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(blocoAcaoTrue);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(blocoAcaoFalse);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

            maquinaInequacoes.Compile();
            
            maquinaInequacoes.Execute();

            Assert.AreEqual(maquinaInequacoes.CalculationMemory["a"].GetValue(), 0.0);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["b"].GetValue(), -1.0);
        }

        /// <summary>
        /// Testa inequação com comparação simples de variáveis do tipo hora.
        /// </summary>
        [TestMethod]
        public void ExecutarOperacaoComparacaoSimplesHora()
        {
            string pattern = "HH:mm:ss";
            string horaA = "00:00:00";
            string horaB = "23:59:00";
            DateTime a = DateTime.Now;
            DateTime b = DateTime.Now;
            double result = double.MinValue;
            DateTime horaConvertidaFlee = DateTime.Now;
            
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }

            string expressao = "(a>b or a<b or a=b or a<>b or a>=b or a<=b)";
            string blocoAcaoTrue = "result=100;";
            //string blocoAcaoTrue = "result=100;horaConvertidaFlee=cast(" + horaA + ");";
            string blocoAcaoFalse = "result=0;";

            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.Time, a));
            maquinaInequacoes.CalculationMemory.Add(new Variable("b", VariableDataType.Time, b));
            maquinaInequacoes.CalculationMemory.Add(new Variable("result", VariableDataType.Numeric, result));
            maquinaInequacoes.CalculationMemory.Add(new Variable("horaA", VariableDataType.String, horaA));

            Inequation inequacao = new Inequation(expressao);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(blocoAcaoTrue);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(blocoAcaoFalse);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

            maquinaInequacoes.Compile();

            maquinaInequacoes.Execute();

            Assert.AreEqual(maquinaInequacoes.CalculationMemory["a"].GetValue(), a);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["b"].GetValue(), b);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);
        }

        /// <summary>
        /// Testa inequações com variações de comparação de variáveis do tipo hora.
        /// </summary>
        [TestMethod]
        public void ExecutarOperacaoComparacaoHora()
        {
            string pattern = "HH:mm:ss";
            string horaA = "20:27:31";
            string horaB = "20:09:50";
            DateTime a = DateTime.Now;
            DateTime b = DateTime.Now;
            double result = double.MinValue;
            DateTime horaConvertidaFlee = DateTime.Now;

            // Testa a maior que b 
            string expressao = "(a>b)";
            string blocoAcaoTrue = "result=100;";
            string blocoAcaoFalse = "result=0;";
            
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }

            InequationEngine maquinaInequacoes = new InequationEngine();
            maquinaInequacoes.CalculationMemory.Add(new Variable("a", VariableDataType.Time, a));
            maquinaInequacoes.CalculationMemory.Add(new Variable("b", VariableDataType.Time, b));
            maquinaInequacoes.CalculationMemory.Add(new Variable("result", VariableDataType.Numeric, result));
            maquinaInequacoes.CalculationMemory.Add(new Variable("horaA", VariableDataType.String, horaA));

            Inequation inequacao = new Inequation(expressao);
            ActionBlock blocoAcaoTrueObj = new ActionBlock(blocoAcaoTrue);
            ActionBlock blocoAcaoFalseObj = new ActionBlock(blocoAcaoFalse);

            Decision decisao = new Decision(inequacao, blocoAcaoTrueObj, blocoAcaoFalseObj);
            maquinaInequacoes.DecisionsList.AddDecision(decisao);

            maquinaInequacoes.Compile();

            maquinaInequacoes.Execute();

            Assert.AreEqual(maquinaInequacoes.CalculationMemory["a"].GetValue(), a);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["b"].GetValue(), b);
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a >= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a<b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a <= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a = b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            horaA = "15:17:31";
            horaB = "15:27:31";
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }
            maquinaInequacoes.CalculationMemory.UpdateVariable("a", a);
            maquinaInequacoes.CalculationMemory.UpdateVariable("b", b);

            expressao = "(a > b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);
            
            expressao = "(a < b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a >= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a <= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a = b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            horaA = "11:00:22";
            horaB = "11:00:22";
            if (!DateTime.TryParseExact(horaA, pattern, null, System.Globalization.DateTimeStyles.None, out a) || !DateTime.TryParseExact(horaB, pattern, null, System.Globalization.DateTimeStyles.None, out b))
            {
                throw new Exception("Erro no parsing das variáveis de hora.");
            }
            maquinaInequacoes.CalculationMemory.UpdateVariable("a", a);
            maquinaInequacoes.CalculationMemory.UpdateVariable("b", b);

            expressao = "(a > b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a < b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 0.0);

            expressao = "(a >= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a <= b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

            expressao = "(a = b)";
            decisao.Inequation.Expression = expressao;
            maquinaInequacoes.Compile();
            maquinaInequacoes.Execute();
            Assert.AreEqual(maquinaInequacoes.CalculationMemory["result"].GetValue(), 100.0);

        }


        [TestMethod]
        public void ChamarServico()
        {
            string memoriaCalculo = @"
                    a = 1.0
                    b = 2.0
                    ";
            //To get the randon value as input from the value collection
            string listaDecisoes = "(a>b),a=1;";

            //Created a service client
            var serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();

            // call the service method getdata
            var response = serviceClient.ExecutarString(memoriaCalculo, listaDecisoes);

        }

        [TestMethod]
        public void ExecutarExpressaoSimplesPorServico()
        {
            int a = 1, b = 2;
            string expressao = "(a+b)>0";
            string blocoAcaoTrue = "a=0;b=-1";

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

            MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient serviceClient = new MaquinaInequacoesServiceReference.MaquinaInequacoesServiceClient();
            memoriaCalculo = serviceClient.ExecutarObjeto(memoriaCalculo, listaDecisoes);

            Assert.AreEqual(memoriaCalculo.Variaveis[0].Valor, 0.0);
            Assert.AreEqual(memoriaCalculo.Variaveis[1].Valor, -1.0);

        }

    }
}
