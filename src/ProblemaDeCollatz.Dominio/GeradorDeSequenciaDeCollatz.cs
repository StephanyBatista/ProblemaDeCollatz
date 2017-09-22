using System.Collections.Generic;

namespace ProblemaDeCollatz.Dominio
{
    public interface IContadorDeSequenciaDeCollatz
    {
        int ContarParaNumero(int numero);
    }

    public class ContadorDeSequenciaDeCollatz : IContadorDeSequenciaDeCollatz
    {
        private readonly IGeradorDoProximoNumeroDeCollatz _geradorDoProximoNumeroDeCollatz;

        public ContadorDeSequenciaDeCollatz(IGeradorDoProximoNumeroDeCollatz geradorDoProximoNumeroDeCollatz)
        {
            _geradorDoProximoNumeroDeCollatz = geradorDoProximoNumeroDeCollatz;
        }

        public int ContarParaNumero(int numero)
        {
            var quantidade = 0;
            var numeroAtual = numero;

            while(numeroAtual > 0)
            {
                quantidade++;

                if(numeroAtual == 1)
                    break;

                numeroAtual = _geradorDoProximoNumeroDeCollatz.Gerar(numeroAtual);
            }

            return quantidade;
        }
    }
}