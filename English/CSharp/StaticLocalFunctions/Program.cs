public class Program
{
    public static void Main()
    {
        int result = Add(5, 10);
        Console.WriteLine($"Result of addition: {result}");

        static int Add(int a, int b)
        {
            return a + b; // Does not capture external variables because it is static
        }
    }
}