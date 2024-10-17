using Polly;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Defining a retry policy that retries 3 times with a 2-second interval between attempts
        var retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(2), 
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine($"Attempt {retryCount} failed. Retrying in {timeSpan.TotalSeconds} seconds...");
                });

        // Making an HTTP call with retry
        HttpClient httpClient = new HttpClient();
        var url = "https://example-api.com/fail";

        try
        {
            await retryPolicy.ExecuteAsync(async () =>
            {
                Console.WriteLine("Making request...");
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                Console.WriteLine("Request succeeded!");
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"All retry attempts failed: {ex.Message}");
        }
    }
}