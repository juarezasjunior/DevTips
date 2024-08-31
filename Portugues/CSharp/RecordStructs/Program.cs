public readonly record struct Ponto(int X, int Y);

public class Program
{
    public static void Main()
    {
        Ponto ponto1 = new(10, 20);
        Ponto ponto2 = new(10, 20);

        Console.WriteLine(ponto1 == ponto2); // Saída: True
    }
}


