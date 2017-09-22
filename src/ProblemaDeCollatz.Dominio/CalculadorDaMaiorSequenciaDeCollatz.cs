using System.Collections.Generic;
using System.Linq;

namespace ProblemaDeCollatz.Dominio
{
    public interface ICalculadorDaMaiorSequenciaDeCollatz
    {
        int Calcular(int primeiroNumero, int segundoNumero);
    }

    public class CalculadorDaMaiorSequenciaDeCollatz : ICalculadorDaMaiorSequenciaDeCollatz
    {
        private readonly IContadorDeSequenciaDeCollatz _contadorDeSequenciaDeCollatz;

        public CalculadorDaMaiorSequenciaDeCollatz(IContadorDeSequenciaDeCollatz contadorDeSequenciaDeCollatz)
        {
            _contadorDeSequenciaDeCollatz = contadorDeSequenciaDeCollatz;
        }

        public int Calcular(int primeiroNumero, int segundoNumero)
        {
            ExcecaoDeDominio.Quando(primeiroNumero >= segundoNumero, "Primeiro número deve ser menor que segundo número");

            var numeroComMaiorQuantidade = 0;
            var maiorQuantidade = 0;

            for (var index = primeiroNumero; index <= segundoNumero; index++)
            {
                var quantidade = _contadorDeSequenciaDeCollatz.ContarParaNumero(index);

                if (maiorQuantidade >= quantidade) continue;

                numeroComMaiorQuantidade = index;
                maiorQuantidade = quantidade;
            }

            return numeroComMaiorQuantidade;
        }
    }
}