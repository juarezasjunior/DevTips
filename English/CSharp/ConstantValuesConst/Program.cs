public class Math
{
    public const double PI = 3.14159;

    public double CalculateCircumference(double radius)
    {
        return 2 * PI * radius;
    }
}

public class Program
{
    public static void Main()
    {
        Math math = new Math();
        double circumference = math.CalculateCircumference(5);
        Console.WriteLine($"Circumference: {circumference}");
    }
}