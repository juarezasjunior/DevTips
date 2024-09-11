using System;
using System.IO;
using System.Threading.Tasks;

public class ArquivoAsync : IAsyncDisposable
{
    private readonly FileStream _fileStream;

    public ArquivoAsync(string caminho)
    {
        _fileStream = new FileStream(caminho, FileMode.OpenOrCreate);
    }

    public async Task EscreverAsync(string conteudo)
    {
        byte[] dados = System.Text.Encoding.UTF8.GetBytes(conteudo);
        await _fileStream.WriteAsync(dados, 0, dados.Length);
    }

    public async ValueTask DisposeAsync()
    {
        await _fileStream.DisposeAsync(); // Liberação assíncrona dos recursos
    }
}

public class Program
{
    public static async Task Main()
    {
        // Usando "await using" para garantir que os recursos sejam liberados de forma assíncrona
        await using (var arquivo = new ArquivoAsync("arquivo.txt"))
        {
            await arquivo.EscreverAsync("Conteúdo assíncrono");
        }
        // Aqui o recurso será liberado de forma assíncrona, sem bloquear o restante do código
        Console.WriteLine("Arquivo gravado e recursos liberados.");
    }
}