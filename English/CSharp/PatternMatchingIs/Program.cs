public class Program
{
    public static void Main()
    {
        object value = 123;

        if (value is int number)
        {
            Console.WriteLine($"The value is a number: {number}");
        }
        else
        {
            Console.WriteLine("The value is not a number.");
        }
    }
}