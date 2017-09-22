using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProblemaDeCollatz.Dominio;

namespace ProblemaDeCollatz.DominioTest
{
    [TestClass]
    public class ContadorDeSequenciaDeCollatzTest
    {
        private Mock<IGeradorDoProximoNumeroDeCollatz> _geradorDoProximoNumeroDeCollatz;
        private ContadorDeSequenciaDeCollatz _contador;

        [TestInitialize]
        public void SetUp()
        {
            _geradorDoProximoNumeroDeCollatz = new Mock<IGeradorDoProximoNumeroDeCollatz>();

            _contador = new ContadorDeSequenciaDeCollatz(_geradorDoProximoNumeroDeCollatz.Object);
        }

        [TestMethod]
        public void DeveGerarQuantidadeAPartirDeUmNumero()
        {
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(5)).Returns(16);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(16)).Returns(8);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(8)).Returns(4);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(4)).Returns(2);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(2)).Returns(1);
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(1)).Returns(0);

            const int quantidadeEsperada = 6;

            var quantidade = _contador.ContarParaNumero(5);

            Assert.AreEqual(quantidadeEsperada, quantidade);
        }

        [TestMethod]
        public void DeveGerarQuantidadeIgualAUmQuandoNumeroAtualForIgualAUm()
        {
            const int quantidadeEsperada = 1;
            _geradorDoProximoNumeroDeCollatz.Setup(gerador => gerador.Gerar(1)).Returns(4);

            var quantidade = _contador.ContarParaNumero(1);

            Assert.AreEqual(quantidadeEsperada, quantidade);
        }
    }
}
