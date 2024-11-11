public class Calculadora
{
    public double Dividir(double numerador, double denominador)
    {
        if (denominador == 0)
        {
            Console.WriteLine("Divisão por zero não é permitida.");
            return double.NaN; // Retorna um valor indicativo em vez de lançar exceção
        }

        return numerador / denominador;
    }
}

public class Program
{
    public static void Main()
    {
        Calculadora calculadora = new Calculadora();
        double resultado = calculadora.Dividir(10, 0);
        Console.WriteLine($"Resultado: {resultado}");
    }
}