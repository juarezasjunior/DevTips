using RestSharp;
using System;

namespace RestSharpExemplo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Criando o cliente RestSharp
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Get);

            // Executando a requisição
            var response = await client.ExecuteAsync<Post>(request);

            if (response.IsSuccessful)
            {
                var post = response.Data;
                Console.WriteLine($"Título: {post.Title}\nConteúdo: {post.Body}");
            }
            else
            {
                Console.WriteLine($"Erro: {response.StatusCode}");
            }
        }
    }

    // Classe para mapear a resposta
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}