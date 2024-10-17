using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace DapperExemplo
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
            using (var conexao = new SqliteConnection("Data Source=produtos.db"))
            {
                conexao.Open();

                // Criando a tabela
                conexao.Execute("CREATE TABLE IF NOT EXISTS Produtos (Id INTEGER PRIMARY KEY, Nome TEXT, Preco REAL)");

                // Inserindo um produto
                conexao.Execute("INSERT INTO Produtos (Nome, Preco) VALUES (@Nome, @Preco)", new { Nome = "Laptop", Preco = 1500.99m });

                // Buscando os produtos
                IEnumerable<Produto> produtos = conexao.Query<Produto>("SELECT Id, Nome, Preco FROM Produtos");

                // Exibindo os produtos
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"Id: {produto.Id}, Nome: {produto.Nome}, Preco: {produto.Preco}");
                }
            }
        }
    }
}