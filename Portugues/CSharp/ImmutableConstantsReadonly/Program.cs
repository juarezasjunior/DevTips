public class Circulo
{
    public readonly double PI;

    public Circulo()
    {
        PI = 3.14159;
    }

    public double CalcularArea(double raio)
    {
        return PI * raio * raio;
    }
}

public class Program
{
    public static void Main()
    {
        Circulo circulo = new Circulo();
        double area = circulo.CalcularArea(5);
        Console.WriteLine($"Área do círculo: {area}");
    }
}