// Produto a ser construído
public class Casa
{
    public string Fundacao { get; set; }
    public string Estrutura { get; set; }
    public string Telhado { get; set; }
    public string Interior { get; set; }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Casa com Fundacao: {Fundacao}, Estrutura: {Estrutura}, Telhado: {Telhado}, Interior: {Interior}");
    }
}

// Interface do Builder
public interface ICasaBuilder
{
    ICasaBuilder ConstruirFundacao();
    ICasaBuilder ConstruirEstrutura();
    ICasaBuilder ConstruirTelhado();
    ICasaBuilder ConstruirInterior();
    Casa GetCasa();
}

// Implementação do Builder concreto
public class CasaBuilder : ICasaBuilder
{
    private Casa _casa = new Casa();

    public ICasaBuilder ConstruirFundacao()
    {
        _casa.Fundacao = "Fundação de concreto";
        return this;
    }

    public ICasaBuilder ConstruirEstrutura()
    {
        _casa.Estrutura = "Estrutura de madeira";
        return this;
    }

    public ICasaBuilder ConstruirTelhado()
    {
        _casa.Telhado = "Telhado de telhas";
        return this;
    }

    public ICasaBuilder ConstruirInterior()
    {
        _casa.Interior = "Interior padrão";
        return this;
    }

    public Casa GetCasa()
    {
        return _casa;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Uso do builder com chamadas encadeadas
        ICasaBuilder builder = new CasaBuilder();
        Casa casa = builder.ConstruirFundacao()
                           .ConstruirEstrutura()
                           .ConstruirTelhado()
                           .ConstruirInterior()
                           .GetCasa();

        casa.ExibirDetalhes();  // Saída: Casa com Fundacao: Fundação de concreto, Estrutura: Estrutura de madeira, Telhado: Telhado de telhas, Interior: Interior padrão
    }
}