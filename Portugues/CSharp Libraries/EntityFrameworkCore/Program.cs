using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkCoreExample
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureCreated();

                // Inserindo um novo produto
                context.Products.Add(new Product { Name = "Laptop", Price = 1500.99m });
                context.SaveChanges();

                // Buscando e exibindo os produtos no banco de dados
                var products = context.Products.ToList();
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }
            }
        }
    }
}