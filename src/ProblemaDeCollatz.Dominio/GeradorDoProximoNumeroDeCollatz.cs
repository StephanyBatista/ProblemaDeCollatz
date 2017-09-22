namespace ProblemaDeCollatz.Dominio
{
    public interface IGeradorDoProximoNumeroDeCollatz
    {
        int Gerar(int numero);
    }

    public class GeradorDoProximoNumeroDeCollatz : IGeradorDoProximoNumeroDeCollatz
    {
        public int Gerar(int numero)
        {
            return numero % 2 == 0 ? numero / 2 : 3 * numero + 1;
        }
    }
}