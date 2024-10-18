using Refit;
using System;
using System.Threading.Tasks;

namespace RefitExemplo
{
    // Definindo a interface que representa a API
    public interface IJsonPlaceholderApi
    {
        [Get("/posts/{id}")]
        Task<Post> GetPostAsync(int id);
    }

    // Classe para mapear a resposta
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Criando o cliente da API usando Refit
            var apiClient = RestService.For<IJsonPlaceholderApi>("https://jsonplaceholder.typicode.com");

            // Fazendo uma requisição GET para obter um post
            var post = await apiClient.GetPostAsync(1);

            // Exibindo os dados no console
            Console.WriteLine($"Título: {post.Title}\nConteúdo: {post.Body}");
        }
    }
}