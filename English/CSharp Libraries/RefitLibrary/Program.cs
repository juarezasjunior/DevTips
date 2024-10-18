using Refit;
using System;
using System.Threading.Tasks;

namespace RefitExample
{
    // Defining the interface that represents the API
    public interface IJsonPlaceholderApi
    {
        [Get("/posts/{id}")]
        Task<Post> GetPostAsync(int id);
    }

    // Class to map the response
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
            // Creating the API client using Refit
            var apiClient = RestService.For<IJsonPlaceholderApi>("https://jsonplaceholder.typicode.com");

            // Making a GET request to retrieve a post
            var post = await apiClient.GetPostAsync(1);

            // Displaying the data in the console
            Console.WriteLine($"Title: {post.Title}\nContent: {post.Body}");
        }
    }
}