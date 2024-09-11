public class Program
{
    public static void Main()
    {
        int resultado = Somar(5, 10);
        Console.WriteLine($"Resultado da soma: {resultado}");

        static int Somar(int a, int b)
        {
            return a + b; // Não captura variáveis externas, pois é static
        }
    }
}