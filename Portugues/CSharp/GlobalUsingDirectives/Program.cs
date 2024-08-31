// Em qualquer arquivo .cs
global using System;
global using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> lista = new() { "item1", "item2" };
        Console.WriteLine(string.Join(", ", lista));
    }
}


