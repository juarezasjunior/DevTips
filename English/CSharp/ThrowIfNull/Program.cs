using System;

public class Program
{
    public static void Main()
    {
        string name = null;

        // Checks and throws an ArgumentNullException if the argument is null
        ArgumentNullException.ThrowIfNull(name, nameof(name));

        Console.WriteLine($"Name: {name}");
    }
}