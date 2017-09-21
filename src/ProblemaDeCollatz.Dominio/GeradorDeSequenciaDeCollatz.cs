using System.Collections.Generic;

namespace ProblemaDeCollatz.Dominio
{
    public interface IGeradorDeSequenciaCollatz
    {
        List<int> Gerar(int numero);
    }

    public class GeradorDeSequenciaCollatz : IGeradorDeSequenciaCollatz
    {
        private readonly IGeradorDoProximoNumeroDeCollatz _geradorDoProximoNumeroDeCollatz;

        public GeradorDeSequenciaCollatz(IGeradorDoProximoNumeroDeCollatz geradorDoProximoNumeroDeCollatz)
        {
            _geradorDoProximoNumeroDeCollatz = geradorDoProximoNumeroDeCollatz;
        }

        public List<int> Gerar(int numero)
        {
            var sequencia = new List<int>();
            var numeroAtual = numero;

            while(numeroAtual > 0)
            {
                sequencia.Add(numeroAtual);
                numeroAtual = _geradorDoProximoNumeroDeCollatz.Gerar(numeroAtual);
            }

            return sequencia;
        }
    }
}