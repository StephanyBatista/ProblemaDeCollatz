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
            if(numero == 1)
                return 0;
            if(numero % 2 == 0)
                return numero / 2;
            return (numero * 3) + 1;
        }
    }
}