public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Program
{
    public static void Main()
    {
        Product product = new Product { Name = "Pen", Price = 5.99m };

        string result = product switch
        {
            { Price: > 10.00m } => "Expensive product",
            { Price: <= 10.00m } => "Affordable product",
            _ => "Price unknown"
        };

        Console.WriteLine(result);
    }
}