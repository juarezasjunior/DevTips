// Interface do Iterador
public interface IIterador<T>
{
    bool HasNext();
    T Next();
}

// Interface da Coleção
public interface IColecao<T>
{
    IIterador<T> CriarIterador();
}

// Implementação da Coleção de Itens
public class ColecaoDeItens : IColecao<string>
{
    private List<string> _itens = new List<string>();

    public void AdicionarItem(string item)
    {
        _itens.Add(item);
    }

    public IIterador<string> CriarIterador()
    {
        return new IteradorDeItens(this);
    }

    public List<string> GetItens()
    {
        return _itens;
    }
}

// Implementação do Iterador para a Coleção de Itens
public class IteradorDeItens : IIterador<string>
{
    private ColecaoDeItens _colecao;
    private int _posicao = 0;

    public IteradorDeItens(ColecaoDeItens colecao)
    {
        _colecao = colecao;
    }

    public bool HasNext()
    {
        return _posicao < _colecao.GetItens().Count;
    }

    public string Next()
    {
        if (HasNext())
        {
            return _colecao.GetItens()[_posicao++];
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar uma coleção de itens
        ColecaoDeItens colecao = new ColecaoDeItens();
        colecao.AdicionarItem("Item 1");
        colecao.AdicionarItem("Item 2");
        colecao.AdicionarItem("Item 3");

        // Criar o iterador
        IIterador<string> iterador = colecao.CriarIterador();

        // Percorrer a coleção usando o iterador
        while (iterador.HasNext())
        {
            Console.WriteLine(iterador.Next());
        }
    }
}