public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice != Price)
        {
            Console.WriteLine($"{nameof(Price)} updated from {Price:C} to {newPrice:C}");
            Price = newPrice;
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Product: {Name}, {nameof(Price)}: {Price:C}");
    }
}

public class Program
{
    public static void Main()
    {
        Product product = new Product("Pen", 2.99m);
        product.DisplayInfo();

        product.UpdatePrice(3.49m); // Logs the price change
        product.DisplayInfo();
    }
}