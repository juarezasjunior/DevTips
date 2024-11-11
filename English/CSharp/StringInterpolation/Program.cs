public class Program
{
    public static void Main()
    {
        string name = "John";
        int age = 30;

        // Using interpolation instead of concatenation
        string message = $"Name: {name}, Age: {age}";

        Console.WriteLine(message);
    }
}