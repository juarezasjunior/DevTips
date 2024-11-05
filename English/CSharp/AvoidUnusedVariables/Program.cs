public class Calculator
{
    public int Add(int a, int b)
    {
        int result = a + b;
        return result;
    }

    public int Subtract(int a, int b)
    {
        return a - b; // No extra variable here
    }
}

public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();
        int sumResult = calculator.Add(5, 3);
        Console.WriteLine($"Sum result: {sumResult}");
    }
}