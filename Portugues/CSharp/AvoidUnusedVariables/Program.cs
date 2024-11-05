public class Calculadora
{
    public int Somar(int a, int b)
    {
        int resultado = a + b;
        return resultado;
    }

    public int Subtrair(int a, int b)
    {
        return a - b; // Nenhuma variável extra aqui
    }
}

public class Program
{
    public static void Main()
    {
        Calculadora calculadora = new Calculadora();
        int resultadoSoma = calculadora.Somar(5, 3);
        Console.WriteLine($"Resultado da soma: {resultadoSoma}");
    }
}