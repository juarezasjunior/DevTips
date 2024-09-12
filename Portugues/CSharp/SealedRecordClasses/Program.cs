public sealed record Produto(string Nome, decimal Preco);

// Você não pode fazer herança
//public record Caneta(string cor) : Produto;

public class Program
{
    public static void Main()
    {
        Produto produto = new("Caneta", 2.99m);
        Console.WriteLine($"Produto: {produto.Nome}, Preço: {produto.Preco}");
    }
}