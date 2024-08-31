using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        await foreach (var numero in GerarNumerosAsync())
        {
            Console.WriteLine(numero);
        }
    }

    public static async IAsyncEnumerable<int> GerarNumerosAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            await Task.Delay(1000); // Simula uma operação assíncrona
            yield return i;
        }
    }
}