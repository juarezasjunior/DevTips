public class Produto
{
    public required string Nome { get; set; }
    public required decimal Preco { get; set; }
}

public class Program
{
    public static void Main()
    {
        Produto produto = new Produto
        {
            Nome = "Caneta",
            // Vai gerar um erro ao compilar
            //Preco = 2.99m
        };

        Console.WriteLine($"Produto: {produto.Nome}, Preço: {produto.Preco}");
    }
}