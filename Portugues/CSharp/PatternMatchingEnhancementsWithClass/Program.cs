public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

public class Program
{
    public static void Main()
    {
        Produto produto = new Produto { Nome = "Caneta", Preco = 2.99m };

        if (produto is { Nome: "Caneta", Preco: <= 5.00m })
        {
            Console.WriteLine("Produto válido e com preço acessível.");
        }
        else
        {
            Console.WriteLine("Produto inválido ou preço alto.");
        }
    }
}


