using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        string url = "https://api.github.com/repos/dotnet/runtime";

        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "C# App");

        string response = await client.GetStringAsync(url);

        Console.WriteLine("API Data:");
        Console.WriteLine(response);
    }
}