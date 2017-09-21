using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProblemaDeCollatz.DominioTest
{
    [TestClass]
    public class CalculadoraDoProximoNumeroDeCollatzTest
    {
        [TestMethod]
        public void DeveCalcularProximoNumeroParaIgualAZeroQuandoForUm()
        {
            var calculadora = new CalculadoraDoProximoNumeroDeCollatz();

            var resultado = calculadora.Calcular(1);
            
            Assert.AreEqual(0, resultado);
        }

        [TestMethod]
        public void DeveCalcularProximoNumeroParaIgualANumeroDivididoPorDoisQuandoForPar()
        {
            var calculadora = new CalculadoraDoProximoNumeroDeCollatz();

            var resultado = calculadora.Calcular(2);
            
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void DeveCalcularProximoNumeroParaIgualANumeroVezesTrezMaisUmQuandoForImpar()
        {
            var calculadora = new CalculadoraDoProximoNumeroDeCollatz();

            var resultado = calculadora.Calcular(3);
            
            Assert.AreEqual(10, resultado);
        }
    }

    public class CalculadoraDoProximoNumeroDeCollatz
    {
        public CalculadoraDoProximoNumeroDeCollatz()
        {
        }

        public int Calcular(int numero)
        {
            if(numero == 1)
                return 0;
            else if(numero % 2 == 0)
                return numero / 2;
            else
                return (numero * 3) + 1;
        }
    }
}