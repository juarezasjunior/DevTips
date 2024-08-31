public class Produto(string Nome, decimal Preco)
{
    public void Exibir()
    {
        Console.WriteLine($"Produto: {Nome}, Preço: {Preco}");
    }
}

public class Program
{
    public static void Main()
    {
        var produto = new Produto("Caneta", 2.99m);
        produto.Exibir();
    }
}


