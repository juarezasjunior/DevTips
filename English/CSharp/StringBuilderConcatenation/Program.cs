using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        StringBuilder text = new StringBuilder();

        text.AppendLine("First line of the text.");
        text.AppendLine("Second line of the text.");
        text.AppendLine("Third line of the text.");

        Console.WriteLine(text.ToString());
    }
}