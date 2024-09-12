public class Produto
{
    public string Nome { get; set; }
    public decimal? Preco { get; set; }
}

public class Program
{
    public static void Main()
    {
        Produto produto = null;
        // Usando operador null-conditional para acessar membros de forma segura
        Console.WriteLine(produto?.Nome ?? "Produto não informado");  // Saída: Produto não informado

        produto = new Produto { Nome = "Caneta", Preco = 2.99m };
        Console.WriteLine(produto?.Nome);  // Saída: Caneta
    }
}