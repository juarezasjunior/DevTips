using Bogus;
using System;
using System.Collections.Generic;

namespace BogusExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Gerador de dados falsos para a classe Pessoa
            var faker = new Faker<Pessoa>()
                .RuleFor(p => p.Nome, f => f.Name.FullName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Idade, f => f.Random.Int(18, 60))
                .RuleFor(p => p.Endereco, f => f.Address.FullAddress());

            // Gerando uma lista de 5 pessoas
            var pessoas = faker.Generate(5);

            // Exibindo os dados gerados no console
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"Nome: {pessoa.Nome}, Email: {pessoa.Email}, Idade: {pessoa.Idade}, Endereço: {pessoa.Endereco}");
            }
        }
    }

    // Classe para representar a pessoa
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Idade { get; set; }
        public string Endereco { get; set; }
    }
}