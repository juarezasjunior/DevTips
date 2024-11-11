public class Calculator
{
    public double Divide(double numerator, double denominator)
    {
        if (denominator == 0)
        {
            Console.WriteLine("Division by zero is not allowed.");
            return double.NaN; // Returns an indicative value instead of throwing an exception
        }

        return numerator / denominator;
    }
}

public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();
        double result = calculator.Divide(10, 0);
        Console.WriteLine($"Result: {result}");
    }
}