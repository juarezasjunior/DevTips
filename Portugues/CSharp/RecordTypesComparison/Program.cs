public record Produto(string Nome, decimal Preco);

public class Program
{
    public static void Main()
    {
        var produto1 = new Produto("Caneta", 2.99m);
        var produto2 = new Produto("Caneta", 2.99m);

        // Comparação entre dois objetos de Record Type
        bool saoIguais = produto1 == produto2;
        Console.WriteLine(saoIguais); // Saída: True
    }
}


