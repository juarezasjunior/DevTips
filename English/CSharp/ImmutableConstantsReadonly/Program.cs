public class Circle
{
    public readonly double PI;

    public Circle()
    {
        PI = 3.14159;
    }

    public double CalculateArea(double radius)
    {
        return PI * radius * radius;
    }
}

public class Program
{
    public static void Main()
    {
        Circle circle = new Circle();
        double area = circle.CalculateArea(5);
        Console.WriteLine($"Circle area: {area}");
    }
}