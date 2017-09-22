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
        private readonly IGeradorDeSequenciaCollatz _geradorDeSequenciaCollatz;

        public CalculadorDaMaiorSequenciaDeCollatz(IGeradorDeSequenciaCollatz geradorDeSequenciaCollatz)
        {
            _geradorDeSequenciaCollatz = geradorDeSequenciaCollatz;
        }

        public int Calcular(int primeiroNumero, int segundoNumero)
        {
            ExcecaoDeDominio.Quando(primeiroNumero >= segundoNumero, "Primeiro número deve ser menor que segundo número");

            var numeroComMaiorQuantidade = 0;
            var maiorQuantidade = 0;

            for (var index = primeiroNumero; index <= segundoNumero; index++)
            {
                var quantidade = _geradorDeSequenciaCollatz.ContarParaNumero(index);

                if (maiorQuantidade >= quantidade) continue;

                numeroComMaiorQuantidade = index;
                maiorQuantidade = quantidade;
            }

            return numeroComMaiorQuantidade;
        }
    }
}