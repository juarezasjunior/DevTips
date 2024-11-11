using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        StringBuilder texto = new StringBuilder();

        texto.AppendLine("Primeira linha do texto.");
        texto.AppendLine("Segunda linha do texto.");
        texto.AppendLine("Terceira linha do texto.");

        Console.WriteLine(texto.ToString());
    }
}