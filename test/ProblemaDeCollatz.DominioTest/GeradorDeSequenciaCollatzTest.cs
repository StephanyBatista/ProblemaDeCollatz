using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProblemaDeCollatz.Dominio;

namespace ProblemaDeCollatz.DominioTest
{
    [TestClass]
    public class GeradorDeSequenciaCollatzTest
    {
        private Mock<IGeradorDoProximoNumeroDeCollatz> _geradorDoProximoNumeroDeCollatz;

        [TestInitialize]
        public void SetUp()
        {
            _geradorDoProximoNumeroDeCollatz = new Mock<IGeradorDoProximoNumeroDeCollatz>();
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(5)).Returns(16);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(16)).Returns(8);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(8)).Returns(4);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(4)).Returns(2);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(2)).Returns(1);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(1)).Returns(0);
        }

        [TestMethod]
        public void DeveGerar()
        {
            var sequenciaEsperada = new List<int>(){5, 16, 8, 4, 2, 1};
            var gerador = new GeradorDeSequenciaCollatz(_geradorDoProximoNumeroDeCollatz.Object);

            var sequencia = gerador.Gerar(5);

            CollectionAssert.AreEquivalent(sequenciaEsperada, sequencia);
        }
    }
}
