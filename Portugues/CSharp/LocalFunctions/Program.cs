using System;

public class Program
{
    public static void Main()
    {
        int numero = 5;
        Console.WriteLine($"Fatorial de {numero} é {CalcularFatorial(numero)}");

        // Função local para calcular o fatorial
        int CalcularFatorial(int n)
        {
            if (n <= 1) return 1;
            return n * CalcularFatorial(n - 1);
        }
    }
}