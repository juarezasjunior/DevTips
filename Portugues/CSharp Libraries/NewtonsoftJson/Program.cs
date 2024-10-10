using Newtonsoft.Json;
using System;

namespace NewtonsoftJsonExemplo
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criando um objeto de exemplo
            Produto produto = new Produto { Id = 1, Nome = "Laptop", Preco = 1500.99m };

            // Serializando o objeto para JSON
            string json = JsonConvert.SerializeObject(produto);
            Console.WriteLine("Objeto serializado: " + json);

            // Desserializando o JSON de volta para um objeto
            Produto produtoDesserializado = JsonConvert.DeserializeObject<Produto>(json);
            Console.WriteLine("Objeto desserializado: ");
            Console.WriteLine($"Id: {produtoDesserializado.Id}, Nome: {produtoDesserializado.Nome}, Preco: {produtoDesserializado.Preco}");
        }
    }
}