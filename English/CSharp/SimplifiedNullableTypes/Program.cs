#nullable enable

public class Person
{
    public string Name { get; set; }
    public string? Nickname { get; set; }  // Can accept null
}

public class Program
{
    public static void Main()
    {
        Person person = new Person { Name = "John", Nickname = null };
        Console.WriteLine($"Name: {person.Name}, Nickname: {person.Nickname ?? "None"}");
    }
}