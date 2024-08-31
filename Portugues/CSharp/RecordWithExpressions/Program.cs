public record Produto(string Nome, decimal Preco);

public class Program
{
    public static void Main()
    {
        // Criando um record Produto
        var produto1 = new Produto("Caneta", 2.99m);

        // Criando uma cópia do record com o preço alterado
        var produto2 = produto1 with { Preco = 3.49m };

        Console.WriteLine(produto1); // Saída: Produto { Nome = Caneta, Preco = 2.99 }
        Console.WriteLine(produto2); // Saída: Produto { Nome = Caneta, Preco = 3.49 }
    }
}