public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Using Expression-bodied Member for the ToString method
    public override string ToString() => $"Product: {Name}, Price: {Price:C}";
}

public class Program
{
    public static void Main()
    {
        var product = new Product { Name = "Pen", Price = 2.99m };
        Console.WriteLine(product);
    }
}