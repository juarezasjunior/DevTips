public class Produto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

public class Program
{
    public static void Main()
    {
        Produto produto = new Produto { Nome = "Caneta", Preco = 5.99m };

        string resultado = produto switch
        {
            { Preco: > 10.00m } => "Produto caro",
            { Preco: <= 10.00m } => "Produto acessível",
            _ => "Preço desconhecido"
        };

        Console.WriteLine(resultado);
    }
}