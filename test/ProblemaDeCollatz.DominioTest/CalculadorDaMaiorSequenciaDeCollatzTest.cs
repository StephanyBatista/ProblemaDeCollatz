using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProblemaDeCollatz.Dominio;

namespace ProblemaDeCollatz.DominioTest
{
    [TestClass]
    public class CalculadorDaMaiorSequenciaDeCollatzTest
    {
        private Mock<IGeradorDeSequenciaCollatz> _geradorDeSequenciaCollatz;
        private CalculadorDaMaiorSequenciaDeCollatz _calculador;

        [TestInitialize]
        public void Setup()
        {
            _geradorDeSequenciaCollatz = new Mock<IGeradorDeSequenciaCollatz>();
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.ContarParaNumero(1)).Returns(1);
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.ContarParaNumero(2)).Returns(2);
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.ContarParaNumero(3)).Returns(7);
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.ContarParaNumero(4)).Returns(3);

            _calculador = new CalculadorDaMaiorSequenciaDeCollatz(_geradorDeSequenciaCollatz.Object);
        }

        [TestMethod]
        public void DeveCalcularAMaiorSequenciaEntreDoisNumeros()
        {
            const int primeiroNumero = 1;
            const int segundoNumero = 4;
            const int numeroComMaiorSequenciaEsperado = 3;

            var numeroComMaiorSequencia = _calculador.Calcular(primeiroNumero, segundoNumero);

            Assert.AreEqual(numeroComMaiorSequenciaEsperado, numeroComMaiorSequencia);
        }

        [TestMethod]
        public void NaoDevePrimeiroNumeroSerMaiorAoSegundoNumero()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _calculador.Calcular(2, 1)).Message;
            Assert.AreEqual("Primeiro número deve ser menor que segundo número", message);
        }

        [TestMethod]
        public void NaoDevePrimeiroNumeroSerIgualAoSegundoNumero()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _calculador.Calcular(2, 2)).Message;
            Assert.AreEqual("Primeiro número deve ser menor que segundo número", message);
        }
    }
}
