using System;
using ProblemaDeCollatz.Dominio;

namespace ProblemaDeCollatz.UI
{
    static class Program
    {
        static void Main(string[] args)
        {
            IGeradorDoProximoNumeroDeCollatz geradorDoProximoNumeroDeCollatz = new GeradorDoProximoNumeroDeCollatz();
            IGeradorDeSequenciaCollatz geradorDeSequenciaCollatz = new GeradorDeSequenciaCollatz(geradorDoProximoNumeroDeCollatz);
            ICalculadorDaMaiorSequenciaDeCollatz calculadorDaMaiorSequenciaDeCollatz = new CalculadorDaMaiorSequenciaDeCollatz(geradorDeSequenciaCollatz);

            var maiorNumeroComSequencia = calculadorDaMaiorSequenciaDeCollatz.Calcular(1, 1000000);

            Console.WriteLine(maiorNumeroComSequencia);
            Console.ReadKey();
        }
    }
}
