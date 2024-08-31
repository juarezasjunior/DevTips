using System;

public class Program
{
    public static void Main()
    {
        int number = 5;
        Console.WriteLine($"Factorial of {number} is {CalculateFactorial(number)}");

        // Local function to calculate factorial
        int CalculateFactorial(int n)
        {
            if (n <= 1) return 1;
            return n * CalculateFactorial(n - 1);
        }
    }
}