public interface IProduct
{
    string Name { get; set; }
    decimal Price { get; set; }
    
    // Data member with default value
    decimal Tax => 0.15m;
    
    decimal CalculatePriceWithTax() => Price + (Price * Tax);
}

public class Product : IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Program
{
    public static void Main()
    {
        IProduct product = new Product { Name = "Pen", Price = 10.00m };
        Console.WriteLine($"Product: {product.Name}, Price with tax: {product.CalculatePriceWithTax():C}");
    }
}