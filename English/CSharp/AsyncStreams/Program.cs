using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        await foreach (var number in GenerateNumbersAsync())
        {
            Console.WriteLine(number);
        }
    }

    public static async IAsyncEnumerable<int> GenerateNumbersAsync()
    {
        for (int i = 1; i <= 5; i++)
        {
            await Task.Delay(1000); // Simulates an asynchronous operation
            yield return i;
        }
    }
}