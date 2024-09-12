public class Program
{
    public static void Main()
    {
        var product = new { Name = "Pen", Price = 2.99m };

        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
    }
}