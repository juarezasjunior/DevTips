using System;

public class Program
{
    public static void Main()
    {
        string input = "123";

        // Using out variable directly in the expression
        if (int.TryParse(input, out int result))
        {
            Console.WriteLine($"Conversion successful: {result}");
        }
        else
        {
            Console.WriteLine("Conversion failed.");
        }
    }
}