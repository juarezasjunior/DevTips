public class Product
{
    public string Name { get; set; }
    public decimal? Price { get; set; }
}

public class Program
{
    public static void Main()
    {
        Product product = null;
        // Using null-conditional operator to safely access members
        Console.WriteLine(product?.Name ?? "Product not specified");  // Output: Product not specified

        product = new Product { Name = "Pen", Price = 2.99m };
        Console.WriteLine(product?.Name);  // Output: Pen
    }
}