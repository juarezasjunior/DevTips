using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace FlurlExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Making a GET request using Flurl
            var post = await "https://jsonplaceholder.typicode.com/posts/1"
                .GetJsonAsync<Post>();

            // Displaying the data in the console
            Console.WriteLine($"Title: {post.Title}\nContent: {post.Body}");
        }
    }

    // Class to map the response
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}