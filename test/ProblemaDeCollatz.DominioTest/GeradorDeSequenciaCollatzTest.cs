using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProblemaDeCollatz.DominioTest
{
    [TestClass]
    public class GeradorDeSequenciaCollatzTest
    {
        [TestMethod]
        public void DeveGerar()
        {
            var sequenciaEsperada = new List<int>(){13, 40, 20, 10, 5, 16, 8, 4, 2, 1};
            var gerador = new GeradorDeSequenciaCollatz();

            var sequencia = gerador.Gerar(13);

            CollectionAssert.AreEquivalent(sequenciaEsperada, sequencia);
        }
    }

    
}
