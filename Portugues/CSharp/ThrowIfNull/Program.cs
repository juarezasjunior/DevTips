using System;

public class Program
{
    public static void Main()
    {
        string nome = null;

        // Verifica e lança uma ArgumentNullException se o argumento for null
        ArgumentNullException.ThrowIfNull(nome, nameof(nome));

        Console.WriteLine($"Nome: {nome}");
    }
}