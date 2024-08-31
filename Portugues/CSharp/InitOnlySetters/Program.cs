public class Produto
{
    public string Nome { get; init; }
    public decimal Preco { get; init; }
}

public class Program
{
    public static void Main()
    {
        var produto = new Produto { Nome = "Caneta", Preco = 2.99m };
        // produto.Preco = 3.99m; // Erro: propriedades init-only não podem ser modificadas
        Console.WriteLine(produto);
    }
}


