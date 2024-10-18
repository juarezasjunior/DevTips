using Mapster;
using System;

namespace MapsterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of the entity Product
            var product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 3500.99M
            };

            // Configuring Mapster
            MapsterConfig.ConfigureMappings();

            // Mapping to the ProductDTO using Mapster
            var productDto = product.Adapt<ProductDTO>();

            // Displaying the mapped data in the console
            Console.WriteLine($"ProductDTO: Id={productDto.Id}, Name={productDto.Name}, PriceFormatted={productDto.PriceFormatted}");
        }
    }

    // Entity class Product
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // DTO class ProductDTO
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PriceFormatted { get; set; }
    }

    // Configuring the mapping to format the price
    public class MapsterConfig
    {
        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Product, ProductDTO>.NewConfig()
                .Map(dest => dest.PriceFormatted, src => src.Price.ToString("C2"));
        }
    }
}