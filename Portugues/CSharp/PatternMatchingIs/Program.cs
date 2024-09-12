public class Program
{
    public static void Main()
    {
        object valor = 123;

        if (valor is int numero)
        {
            Console.WriteLine($"O valor é um número: {numero}");
        }
        else
        {
            Console.WriteLine("O valor não é um número.");
        }
    }
}