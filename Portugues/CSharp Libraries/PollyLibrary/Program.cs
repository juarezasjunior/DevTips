using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Definindo uma política de retry que tenta 3 vezes com um intervalo de 2 segundos entre tentativas
        var retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(2), 
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Tentativa {retryCount} falhou. Tentando novamente em {timeSpan.TotalSeconds} segundos...");
                });

        // Fazendo uma chamada HTTP com retry
        HttpClient httpClient = new HttpClient();
        var url = "https://exemplo-api.com/falha";

        try
        {
            await retryPolicy.ExecuteAsync(async () =>
            {
                Console.WriteLine("Fazendo requisição...");
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Requisição bem-sucedida!");
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Todas as tentativas falharam: {ex.Message}");
        }
    }
}