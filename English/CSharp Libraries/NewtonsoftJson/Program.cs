using Newtonsoft.Json;
using System;

namespace NewtonsoftJsonExample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Creating a sample object
            Product product = new Product { Id = 1, Name = "Laptop", Price = 1500.99m };

            // Serializing the object to JSON
            string json = JsonConvert.SerializeObject(product);
            Console.WriteLine("Serialized object: " + json);

            // Deserializing the JSON back to an object
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
            Console.WriteLine("Deserialized object: ");
            Console.WriteLine($"Id: {deserializedProduct.Id}, Name: {deserializedProduct.Name}, Price: {deserializedProduct.Price}");
        }
    }
}