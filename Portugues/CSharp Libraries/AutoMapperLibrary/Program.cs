using AutoMapper;
using System;

namespace AutoMapperExemplo
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Configurando o AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Produto, ProdutoDTO>());
            var mapper = config.CreateMapper();

            // Criando um objeto Produto
            Produto produto = new Produto { Id = 1, Nome = "Laptop", Preco = 1500.99m };

            // Mapeando Produto para ProdutoDTO
            ProdutoDTO produtoDTO = mapper.Map<ProdutoDTO>(produto);

            Console.WriteLine($"Nome: {produtoDTO.Nome}, Preco: {produtoDTO.Preco}");
        }
    }
}