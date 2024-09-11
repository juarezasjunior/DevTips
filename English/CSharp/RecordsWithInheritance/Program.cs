public record Document(int Id, DateTime Date);

public record Invoice(int Id, DateTime Date, decimal Amount) : Document(Id, Date);

public record Receipt(int Id, DateTime Date, string Payer) : Document(Id, Date);

public class Program
{
    public static void Main()
    {
        Invoice invoice = new(1, DateTime.Now, 150.00m);
        Receipt receipt = new(2, DateTime.Now, "John");

        Console.WriteLine(invoice); // Output: Invoice { Id = 1, Date = ..., Amount = 150.00 }
        Console.WriteLine(receipt); // Output: Receipt { Id = 2, Date = ..., Payer = John }
    }
}