// Interface de Estratégia
public interface ICalculoPreco
{
    decimal CalcularPreco(decimal precoBase);
}

// Implementação de uma estratégia para preço normal
public class PrecoNormal : ICalculoPreco
{
    public decimal CalcularPreco(decimal precoBase)
    {
        return precoBase;
    }
}

// Implementação de uma estratégia para desconto
public class PrecoComDesconto : ICalculoPreco
{
    private decimal _percentualDesconto;

    public PrecoComDesconto(decimal percentualDesconto)
    {
        _percentualDesconto = percentualDesconto;
    }

    public decimal CalcularPreco(decimal precoBase)
    {
        return precoBase - (precoBase * _percentualDesconto / 100);
    }
}

// Implementação de uma estratégia para preço premium
public class PrecoPremium : ICalculoPreco
{
    public decimal CalcularPreco(decimal precoBase)
    {
        return precoBase + (precoBase * 0.20m); // Adiciona 20% ao preço
    }
}

// Classe que utiliza uma estratégia de cálculo de preço
public class Produto
{
    private ICalculoPreco _estrategiaPreco;
    private decimal _precoBase;

    public Produto(ICalculoPreco estrategiaPreco, decimal precoBase)
    {
        _estrategiaPreco = estrategiaPreco;
        _precoBase = precoBase;
    }

    public void DefinirEstrategia(ICalculoPreco estrategiaPreco)
    {
        _estrategiaPreco = estrategiaPreco;
    }

    public void ExibirPrecoFinal()
    {
        Console.WriteLine($"Preço final: {_estrategiaPreco.CalcularPreco(_precoBase)}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar um produto com preço base de 100
        Produto produto = new Produto(new PrecoNormal(), 100);

        // Exibir preço com estratégia normal
        produto.ExibirPrecoFinal(); // Saída: Preço final: 100

        // Alterar para a estratégia de desconto e exibir o preço
        produto.DefinirEstrategia(new PrecoComDesconto(10)); // 10% de desconto
        produto.ExibirPrecoFinal(); // Saída: Preço final: 90

        // Alterar para a estratégia de preço premium e exibir o preço
        produto.DefinirEstrategia(new PrecoPremium());
        produto.ExibirPrecoFinal(); // Saída: Preço final: 120
    }
}