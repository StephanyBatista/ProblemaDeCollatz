using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemaDeCollatz.Dominio;

namespace ProblemaDeCollatz.DominioTest
{
    [TestClass]
    public class CalculadoraDoProximoNumeroDeCollatzTest
    {
        private GeradorDoProximoNumeroDeCollatz _gerador;

        [TestInitialize]
        public void SetUp()
        {
            _gerador = new GeradorDoProximoNumeroDeCollatz();
        }

        [TestMethod]
        public void DeveCalcularProximoNumeroParaIgualANumeroDivididoPorDoisQuandoForPar()
        {
            var resultado = _gerador.Gerar(2);
            
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void DeveCalcularProximoNumeroParaIgualANumeroVezesTrezMaisUmQuandoForImpar()
        {
            var resultado = _gerador.Gerar(3);
            
            Assert.AreEqual(10, resultado);
        }
    }
}