using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        using (StreamWriter writer = new StreamWriter("file.txt"))
        {
            writer.WriteLine("Writing to the file using the using block.");
        }
        // The StreamWriter is automatically released after the block ends
    }
}