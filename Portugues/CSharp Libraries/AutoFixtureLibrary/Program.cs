using AutoFixture;
using System;

namespace AutoFixtureExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando uma instância do gerador AutoFixture
            var fixture = new Fixture();

            // Gerando uma instância preenchida da classe Pedido
            var pedido = fixture.Create<Pedido>();

            // Exibindo os dados gerados automaticamente
            Console.WriteLine($"Pedido Id: {pedido.Id}, Valor: {pedido.ValorTotal}, Cliente: {pedido.Cliente.Nome}");
        }
    }

    // Classe Pedido
    public class Pedido
    {
        public int Id { get; set; }
        public decimal ValorTotal { get; set; }
        public Cliente Cliente { get; set; }
    }

    // Classe Cliente
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}