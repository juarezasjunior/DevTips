public class Matematica
{
    public const double PI = 3.14159;

    public double CalcularCircunferencia(double raio)
    {
        return 2 * PI * raio;
    }
}

public class Program
{
    public static void Main()
    {
        Matematica matematica = new Matematica();
        double circunferencia = matematica.CalcularCircunferencia(5);
        Console.WriteLine($"Circunferência: {circunferencia}");
    }
}