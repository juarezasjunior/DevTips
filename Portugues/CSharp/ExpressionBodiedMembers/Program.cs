public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    // Usando Expression-bodied Member para o método ToString
    public override string ToString() => $"Produto: {Nome}, Preço: {Preco:C}";
}

public class Program
{
    public static void Main()
    {
        var produto = new Produto { Nome = "Caneta", Preco = 2.99m };
        Console.WriteLine(produto);
    }
}