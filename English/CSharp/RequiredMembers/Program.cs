public class Product
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}

public class Program
{
    public static void Main()
    {
        Product product = new Product
        {
            Name = "Pen",
            // An exception will be thrown when compiling
            //Price = 2.99m
        };

        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}");
    }
}