public class Program
{
    public static void Main()
    {
        var produto = new { Nome = "Caneta", Preco = 2.99m };

        Console.WriteLine($"Produto: {produto.Nome}, Preço: {produto.Preco}");
    }
}