public class Program
{
    public static void Main()
    {
        var (nome, preco) = ObterProduto();

        Console.WriteLine($"Produto: {nome}, Preço: {preco}");
    }

    public static (string, decimal) ObterProduto()
    {
        return ("Caneta", 2.99m);
    }
}