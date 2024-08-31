public class Program
{
    public static void Main()
    {
        var (name, price) = GetProduct();

        Console.WriteLine($"Product: {name}, Price: {price}");
    }

    public static (string, decimal) GetProduct()
    {
        return ("Pen", 2.99m);
    }
}