public class Program
{
    const string Name = "C#";
    const string Version = "10";
    
    // Using interpolation in a constant
    const string Greeting = $"Welcome to {Name} version {Version}!";

    public static void Main()
    {
        Console.WriteLine(Greeting);
    }
}