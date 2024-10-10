// Interface do Elemento que aceita visitantes
public interface IElemento
{
    void Aceitar(IVisitante visitante);
}

// Interface do Visitante
public interface IVisitante
{
    void Visitar(Livro livro);
    void Visitar(Filme filme);
}

// Implementação do Elemento: Livro
public class Livro : IElemento
{
    public string Titulo { get; }
    public double Preco { get; }

    public Livro(string titulo, double preco)
    {
        Titulo = titulo;
        Preco = preco;
    }

    public void Aceitar(IVisitante visitante)
    {
        visitante.Visitar(this);
    }
}

// Implementação do Elemento: Filme
public class Filme : IElemento
{
    public string Titulo { get; }
    public double Preco { get; }

    public Filme(string titulo, double preco)
    {
        Titulo = titulo;
        Preco = preco;
    }

    public void Aceitar(IVisitante visitante)
    {
        visitante.Visitar(this);
    }
}

// Visitante que calcula o imposto sobre os itens
public class CalculadoraImpostoVisitante : IVisitante
{
    private const double TaxaImposto = 0.1;

    public void Visitar(Livro livro)
    {
        double imposto = livro.Preco * TaxaImposto;
        Console.WriteLine($"Imposto sobre o livro '{livro.Titulo}': {imposto:C}");
    }

    public void Visitar(Filme filme)
    {
        double imposto = filme.Preco * TaxaImposto;
        Console.WriteLine($"Imposto sobre o filme '{filme.Titulo}': {imposto:C}");
    }
}

// Visitante que exibe detalhes dos itens
public class ExibirDetalhesVisitante : IVisitante
{
    public void Visitar(Livro livro)
    {
        Console.WriteLine($"Livro: {livro.Titulo}, Preço: {livro.Preco:C}");
    }

    public void Visitar(Filme filme)
    {
        Console.WriteLine($"Filme: {filme.Titulo}, Preço: {filme.Preco:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar os itens
        IElemento livro = new Livro("Design Patterns", 50.0);
        IElemento filme = new Filme("Inception", 30.0);

        // Criar visitantes
        IVisitante calculadoraImposto = new CalculadoraImpostoVisitante();
        IVisitante exibirDetalhes = new ExibirDetalhesVisitante();

        // Aplicar os visitantes
        Console.WriteLine("Detalhes dos Itens:");
        livro.Aceitar(exibirDetalhes);
        filme.Aceitar(exibirDetalhes);

        Console.WriteLine("\nCálculo de Impostos:");
        livro.Aceitar(calculadoraImposto);
        filme.Aceitar(calculadoraImposto);
    }
}