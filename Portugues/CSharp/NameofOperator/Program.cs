public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public void AtualizarPreco(decimal novoPreco)
    {
        if (novoPreco != Preco)
        {
            Console.WriteLine($"{nameof(Preco)} atualizado de {Preco:C} para {novoPreco:C}");
            Preco = novoPreco;
        }
    }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Produto: {Nome}, {nameof(Preco)}: {Preco:C}");
    }
}

public class Program
{
    public static void Main()
    {
        Produto produto = new Produto("Caneta", 2.99m);
        produto.ExibirInformacoes();

        produto.AtualizarPreco(3.49m); // Loga a mudança de preço
        produto.ExibirInformacoes();
    }
}