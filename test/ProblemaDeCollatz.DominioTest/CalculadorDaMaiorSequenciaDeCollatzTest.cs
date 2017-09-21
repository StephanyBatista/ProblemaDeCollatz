using System.Collections.Generic;
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
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.Gerar(1)).Returns(new List<int> { 1 });
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.Gerar(2)).Returns(new List<int> { 1, 2 });
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.Gerar(3)).Returns(new List<int> { 1, 2, 4, 8, 16, 5, 10 });
            _geradorDeSequenciaCollatz.Setup(gerador => gerador.Gerar(4)).Returns(new List<int> { 1, 2, 4 });

            _calculador = new CalculadorDaMaiorSequenciaDeCollatz(_geradorDeSequenciaCollatz.Object);
        }

        [TestMethod]
        public void DeveCalcularAMaiorSequenciaEntreDoisNumeros()
        {
            const int primeiroNumero = 1;
            const int segundoNumero = 4;
            const int numeroComMaiorSequenciaEsperado = 3;

            var numeroComMaiorSequencia = _calculador.Calcular(primeiroNumero, segundoNumero);

            Assert.AreEqual(numeroComMaiorSequencia, numeroComMaiorSequenciaEsperado);
        }

        [TestMethod]
        public void NaoDevePrimeiroNumeroSerMaiorOuIgualAoSegundoNumero()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _calculador.Calcular(2, 1)).Message;
            Assert.AreEqual("Primeiro número deve ser menor que segundo número", message);
        }
    }
}
