public class Program
{
    public static void Main()
    {
        // Obvious type, good use of var
        var total = 100;

        // Prefer explicit type to avoid ambiguity
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // `decimal` with `var` is evident by the value
        var amount = 100.0m;

        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"First number: {numbers[0]}");
        Console.WriteLine($"Amount: {amount}");
    }
}