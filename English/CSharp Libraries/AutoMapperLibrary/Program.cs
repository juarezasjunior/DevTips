using AutoMapper;
using System;

namespace AutoMapperExample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Configuring AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>());
            var mapper = config.CreateMapper();

            // Creating a Product object
            Product product = new Product { Id = 1, Name = "Laptop", Price = 1500.99m };

            // Mapping Product to ProductDTO
            ProductDTO productDTO = mapper.Map<ProductDTO>(product);

            Console.WriteLine($"Name: {productDTO.Name}, Price: {productDTO.Price}");
        }
    }
}