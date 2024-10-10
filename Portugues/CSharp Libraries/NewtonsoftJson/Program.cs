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
            // Criando um objeto de exemplo
            Product product = new Product { Id = 1, Name = "Laptop", Price = 1500.99m };

            // Serializando o objeto para JSON
            string json = JsonConvert.SerializeObject(product);
            Console.WriteLine("Objeto serializado: " + json);

            // Desserializando o JSON de volta para um objeto
            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
            Console.WriteLine("Objeto desserializado: ");
            Console.WriteLine($"Id: {deserializedProduct.Id}, Name: {deserializedProduct.Name}, Price: {deserializedProduct.Price}");
        }
    }
}