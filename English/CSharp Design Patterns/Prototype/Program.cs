// Prototype Interface
public interface IPrototype<T>
{
    T Clone();
}

// Concrete class implementing Prototype
public class Circle : IPrototype<Circle>
{
    public int Radius { get; set; }

    public Circle(int radius)
    {
        Radius = radius;
    }

    public Circle Clone()
    {
        // Clone the current object
        return new Circle(this.Radius);
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Circle with radius: {Radius}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create an original circle
        Circle circle1 = new Circle(10);
        circle1.ShowDetails();  // Output: Circle with radius: 10

        // Clone the circle
        Circle circle2 = circle1.Clone();
        circle2.ShowDetails();  // Output: Circle with radius: 10

        // Modify the clone
        circle2.Radius = 20;
        circle2.ShowDetails();  // Output: Circle with radius: 20
        circle1.ShowDetails();  // Output: Circle with radius: 10
    }
}