public class Program
{
    public static void Main()
    {
        int[] numeros = { 1, 2, 3, 4, 5 };

        // Verifica se a lista começa com 1, tem qualquer número de elementos no meio e termina com 5
        if (numeros is [1, .., 5])
        {
            Console.WriteLine("A lista começa com 1 e termina com 5.");
        }
        else
        {
            Console.WriteLine("A lista não atende aos critérios.");
        }
    }
}