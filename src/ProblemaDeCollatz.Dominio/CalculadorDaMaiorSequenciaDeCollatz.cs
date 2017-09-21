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
        private readonly Dictionary<int, List<int>> _sequenciasGeradas;

        public CalculadorDaMaiorSequenciaDeCollatz(IGeradorDeSequenciaCollatz geradorDeSequenciaCollatz)
        {
            _geradorDeSequenciaCollatz = geradorDeSequenciaCollatz;
            _sequenciasGeradas = new Dictionary<int, List<int>>();
        }

        public int Calcular(int primeiroNumero, int segundoNumero)
        {
            ExcecaoDeDominio.Quando(primeiroNumero >= segundoNumero, "Primeiro número deve ser menor que segundo número");

            for (var index = primeiroNumero; index <= segundoNumero; index++)
            {
                var sequencia = _geradorDeSequenciaCollatz.Gerar(index);
                _sequenciasGeradas.Add(index, sequencia);
            }

            return _sequenciasGeradas.OrderByDescending(sequencia => sequencia.Value.Count).First().Key;
        }
    }
}