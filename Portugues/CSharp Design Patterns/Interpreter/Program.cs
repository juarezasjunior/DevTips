// Interface para expressões
public interface IExpressao
{
    int Interpretar();
}

// Expressão para números
public class Numero : IExpressao
{
    private int _valor;

    public Numero(int valor)
    {
        _valor = valor;
    }

    public int Interpretar()
    {
        return _valor;
    }
}

// Expressão para adição
public class Adicao : IExpressao
{
    private IExpressao _esquerda;
    private IExpressao _direita;

    public Adicao(IExpressao esquerda, IExpressao direita)
    {
        _esquerda = esquerda;
        _direita = direita;
    }

    public int Interpretar()
    {
        return _esquerda.Interpretar() + _direita.Interpretar();
    }
}

// Expressão para subtração
public class Subtracao : IExpressao
{
    private IExpressao _esquerda;
    private IExpressao _direita;

    public Subtracao(IExpressao esquerda, IExpressao direita)
    {
        _esquerda = esquerda;
        _direita = direita;
    }

    public int Interpretar()
    {
        return _esquerda.Interpretar() - _direita.Interpretar();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar expressões: (10 + 5) - 3
        IExpressao expressao = new Subtracao(
            new Adicao(new Numero(10), new Numero(5)),
            new Numero(3)
        );

        // Interpretar e exibir o resultado
        int resultado = expressao.Interpretar();
        Console.WriteLine($"Resultado da expressão: {resultado}"); // Saída: Resultado da expressão: 12
    }
}