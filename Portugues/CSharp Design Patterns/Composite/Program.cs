// Componente base
public interface IComponente
{
    void Exibir();
}

// Objeto folha (um arquivo, por exemplo)
public class Arquivo : IComponente
{
    private string _nome;

    public Arquivo(string nome)
    {
        _nome = nome;
    }

    public void Exibir()
    {
        Console.WriteLine($"Arquivo: {_nome}");
    }
}

// Objeto composto (uma pasta, por exemplo)
public class Pasta : IComponente
{
    private string _nome;
    private List<IComponente> _componentes = new List<IComponente>();

    public Pasta(string nome)
    {
        _nome = nome;
    }

    public void Adicionar(IComponente componente)
    {
        _componentes.Add(componente);
    }

    public void Exibir()
    {
        Console.WriteLine($"Pasta: {_nome}");
        foreach (var componente in _componentes)
        {
            componente.Exibir();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar arquivos e pastas
        Arquivo arquivo1 = new Arquivo("arquivo1.txt");
        Arquivo arquivo2 = new Arquivo("arquivo2.txt");
        
        Pasta pasta1 = new Pasta("Documentos");
        pasta1.Adicionar(arquivo1);
        pasta1.Adicionar(arquivo2);

        // Exibir estrutura da pasta
        pasta1.Exibir();
    }
}