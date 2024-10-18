using Mapster;
using System;

namespace MapsterExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando uma instância da entidade Produto
            var produto = new Produto
            {
                Id = 1,
                Nome = "Notebook",
                Preco = 3500.99M
            };

            // Configurando o Mapster
            MapsterConfig.ConfigurarMapeamentos();

            // Mapeando para o DTO ProdutoDTO usando Mapster
            var produtoDto = produto.Adapt<ProdutoDTO>();

            // Exibindo os dados mapeados no console
            Console.WriteLine($"ProdutoDTO: Id={produtoDto.Id}, Nome={produtoDto.Nome}, Preço={produtoDto.PrecoFormatado}");
        }
    }

    // Classe de entidade Produto
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }

    // Classe de DTO ProdutoDTO
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string PrecoFormatado { get; set; }
    }

    // Configurando o mapeamento para formatar o preço
    public class MapsterConfig
    {
        public static void ConfigurarMapeamentos()
        {
            TypeAdapterConfig<Produto, ProdutoDTO>.NewConfig()
                .Map(dest => dest.PrecoFormatado, src => src.Preco.ToString("C2"));
        }
    }
}