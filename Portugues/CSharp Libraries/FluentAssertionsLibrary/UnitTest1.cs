using FluentAssertions;
using Xunit;

namespace FluentAssertionsExemplo
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_DeveTerValoresCorretos()
        {
            // Arrange: Criando um objeto Produto
            var produto = new Produto
            {
                Id = 1,
                Nome = "Notebook",
                Preco = 3500.99M
            };

            // Act & Assert: Usando FluentAssertions para validar os valores
            produto.Id.Should().Be(1);
            produto.Nome.Should().Be("Notebook");
            produto.Preco.Should().Be(3500.99M);
        }

        [Fact]
        public void Produto_DeveGerarExcecaoParaPrecoInvalido()
        {
            // Arrange
            var produto = new Produto();

            // Act
            Action action = () => produto.DefinirPreco(-10);

            // Assert: Usando FluentAssertions para verificar a exceção
            action.Should().Throw<ArgumentException>()
                .WithMessage("Preço deve ser maior que zero");
        }
    }

    // Classe Produto usada nos testes
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public void DefinirPreco(decimal preco)
        {
            if (preco <= 0)
                throw new ArgumentException("Preço deve ser maior que zero");
            Preco = preco;
        }
    }
}