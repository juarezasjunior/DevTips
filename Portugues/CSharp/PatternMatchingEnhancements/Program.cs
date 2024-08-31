public class Program
{
    public static void Main()
    {
        int numero = 42;

        // Verifica se o número está entre 40 e 50, ou se é igual a 100, e se não é 45
        if (numero is (>= 40 and <= 50) or 100 and not 45)
        {
            Console.WriteLine("O número está entre 40 e 50, ou é igual a 100, mas não é 45.");
        }
        else
        {
            Console.WriteLine("O número não atende aos critérios.");
        }
    }
}


