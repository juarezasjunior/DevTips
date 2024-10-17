using FluentValidation;
using System;

public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {
        // Definindo regras de validação
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .Length(3, 50).WithMessage("O nome do produto deve ter entre 3 e 50 caracteres.");

        RuleFor(p => p.Preco)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando um produto de exemplo
        var produto = new Produto { Nome = "Laptop", Preco = -10 };

        // Validando o produto
        var validator = new ProdutoValidator();
        var resultados = validator.Validate(produto);

        if (!resultados.IsValid)
        {
            foreach (var erro in resultados.Errors)
            {
                Console.WriteLine($"Erro: {erro.ErrorMessage}");
            }
        }
        else
        {
            Console.WriteLine("Produto válido!");
        }
    }
}