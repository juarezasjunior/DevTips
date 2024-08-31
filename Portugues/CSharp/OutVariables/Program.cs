using System;

public class Program
{
    public static void Main()
    {
        string input = "123";

        // Usando out variable diretamente na expressão
        if (int.TryParse(input, out int resultado))
        {
            Console.WriteLine($"Conversão bem-sucedida: {resultado}");
        }
        else
        {
            Console.WriteLine("Falha na conversão.");
        }
    }
}