using System;
using ProblemaDeCollatz.Dominio;

namespace ProblemaDeCollatz.UI
{
    static class Program
    {
        static void Main(string[] args)
        {
            IGeradorDoProximoNumeroDeCollatz geradorDoProximoNumeroDeCollatz = new GeradorDoProximoNumeroDeCollatz();
            IGeradorDeSequenciaCollatz geradorDeSequenciaCollatz = new ContadorDeSequenciaDeCollatz(geradorDoProximoNumeroDeCollatz);
            ICalculadorDaMaiorSequenciaDeCollatz calculadorDaMaiorSequenciaDeCollatz = new CalculadorDaMaiorSequenciaDeCollatz(geradorDeSequenciaCollatz);

            var maiorNumeroComSequencia = calculadorDaMaiorSequenciaDeCollatz.Calcular(1, 1000000);

            Console.WriteLine($"{maiorNumeroComSequencia} é número com maior sequencia de Collatz");
        }
    }
}
