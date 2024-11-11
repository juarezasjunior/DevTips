using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        using (StreamWriter escritor = new StreamWriter("arquivo.txt"))
        {
            escritor.WriteLine("Escrevendo no arquivo usando o bloco using.");
        }
        // O StreamWriter é automaticamente liberado após o fim do bloco
    }
}