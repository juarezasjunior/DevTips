using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkCoreExemplo
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=produtos.db");
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
                context.Produtos.Add(new Produto { Nome = "Laptop", Preco = 1500.99m });
                context.SaveChanges();

                // Buscando e exibindo os produtos no banco de dados
                var produtos = context.Produtos.ToList();
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"Id: {produto.Id}, Nome: {produto.Nome}, Preco: {produto.Preco}");
                }
            }
        }
    }
}