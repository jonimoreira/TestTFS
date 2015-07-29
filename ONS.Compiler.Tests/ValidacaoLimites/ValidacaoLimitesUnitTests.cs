using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ONS.Compiler.Business;
using ONS.Compiler.Tests.ValidacaoLimites;
using System.Collections.Generic;
using Ciloci.Flee.Tests;

namespace ONS.Compiler.Tests.ValidacaoLimites
{
    [TestClass]
    public class ValidacaoLimitesUnitTests
    {
        [TestMethod]
        public void CarregarDadosPlanilhaAba_S_SE()
        {
            Mediador mediador = new Mediador();

            mediador.CarregarDados_SheetRow_S_SE();

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void CarregarDadosPlanilhaAba_SUL()
        {
            Mediador mediador = new Mediador();

            mediador.CarregarDados_SheetRow_SUL();

            Assert.AreEqual(true, true);

        }

        [TestMethod]
        public void CarregarDadosPlanilhaAba_N_NE_SE()
        {
            Mediador mediador = new Mediador();

            mediador.CarregarDados_SheetRow_N_NE_SE();

            Assert.AreEqual(true, true);

        }

    }
}
