using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace DapperExample
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
            using (var connection = new SqliteConnection("Data Source=products.db"))
            {
                connection.Open();

                // Creating the table
                connection.Execute("CREATE TABLE IF NOT EXISTS Products (Id INTEGER PRIMARY KEY, Name TEXT, Price REAL)");

                // Inserting a product
                connection.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price)", new { Name = "Laptop", Price = 1500.99m });

                // Fetching the products
                IEnumerable<Product> products = connection.Query<Product>("SELECT Id, Name, Price FROM Products");

                // Displaying the products
                foreach (var product in products)
                {
                    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
                }
            }
        }
    }
}