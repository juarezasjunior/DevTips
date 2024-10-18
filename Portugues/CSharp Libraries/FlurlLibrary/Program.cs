using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace FlurlExemplo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Fazendo uma requisição GET usando Flurl
            var post = await "https://jsonplaceholder.typicode.com/posts/1"
                .GetJsonAsync<Post>();

            // Exibindo os dados no console
            Console.WriteLine($"Título: {post.Title}\nConteúdo: {post.Body}");
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