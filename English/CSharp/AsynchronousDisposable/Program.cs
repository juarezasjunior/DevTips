using System;
using System.IO;
using System.Threading.Tasks;

public class AsyncFile : IAsyncDisposable
{
    private readonly FileStream _fileStream;

    public AsyncFile(string path)
    {
        _fileStream = new FileStream(path, FileMode.OpenOrCreate);
    }

    public async Task WriteAsync(string content)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes(content);
        await _fileStream.WriteAsync(data, 0, data.Length);
    }

    public async ValueTask DisposeAsync()
    {
        await _fileStream.DisposeAsync(); // Asynchronously releasing the resources
    }
}

public class Program
{
    public static async Task Main()
    {
        // Using "await using" to ensure resources are released asynchronously
        await using (var file = new AsyncFile("file.txt"))
        {
            await file.WriteAsync("Asynchronous content");
        }
        // Resources are asynchronously released here without blocking the rest of the code
        Console.WriteLine("File written and resources released.");
    }
}