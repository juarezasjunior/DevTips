using RestSharp;
using System;

namespace RestSharpExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Creating the RestSharp client
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("/posts/1", Method.Get);

            // Executing the request
            var response = await client.ExecuteAsync<Post>(request);

            if (response.IsSuccessful)
            {
                var post = response.Data;
                Console.WriteLine($"Title: {post.Title}\nContent: {post.Body}");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
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