using System.Collections.Generic;

namespace ProblemaDeCollatz.Dominio
{
    public class GeradorDeSequenciaCollatz
    {
        public GeradorDeSequenciaCollatz()
        {
        }

        internal List<int> Gerar(int numero)
        {
            var sequencia = new List<int>();
            var numeroAtual = numero;

            while(numeroAtual > 0)
            {
                sequencia.Add(numeroAtual);

                if(numeroAtual == 1)
                    numeroAtual = 0;
                else if(numeroAtual % 2 == 0)
                    numeroAtual = numeroAtual / 2;
                else
                    numeroAtual = (numeroAtual * 3) + 1;
            }

            return sequencia;
        }
    }
}