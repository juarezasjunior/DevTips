public sealed record Product(string Name, decimal Price);

// You cannot inherit from Product
//public record Pen(string color) : Product;

public class Program
{
    public static void Main()
    {
        Product product = new("Pen", 2.99m);
        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
    }
}