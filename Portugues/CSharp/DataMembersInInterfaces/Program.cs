public interface IProduto
{
    string Nome { get; set; }
    decimal Preco { get; set; }
    
    // Membro de dados com valor padrão
    decimal Imposto => 0.15m;
    
    decimal CalcularPrecoComImposto() => Preco + (Preco * Imposto);
}

public class Produto : IProduto
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

public class Program
{
    public static void Main()
    {
        IProduto produto = new Produto { Nome = "Caneta", Preco = 10.00m };
        Console.WriteLine($"Produto: {produto.Nome}, Preço com imposto: {produto.CalcularPrecoComImposto():C}");
    }
}