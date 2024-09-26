// Flyweight: Ícone de Arquivo
public class IconeArquivo
{
    private string _nomeIcone;

    public IconeArquivo(string nomeIcone)
    {
        _nomeIcone = nomeIcone;
        Console.WriteLine($"Carregando ícone {_nomeIcone} da memória...");
    }

    public void Exibir(int tamanho)
    {
        Console.WriteLine($"Exibindo ícone {_nomeIcone} com tamanho {tamanho}.");
    }
}

// Flyweight Factory: Gerenciador de ícones de arquivos
public class IconeFactory
{
    private Dictionary<string, IconeArquivo> _icones = new Dictionary<string, IconeArquivo>();

    public IconeArquivo ObterIcone(string tipoArquivo)
    {
        if (!_icones.ContainsKey(tipoArquivo))
        {
            _icones[tipoArquivo] = new IconeArquivo(tipoArquivo);
        }
        return _icones[tipoArquivo];
    }
}

// Classe que representa um arquivo individual
public class Arquivo
{
    private string _nome;
    private IconeArquivo _icone;

    public Arquivo(string nome, IconeArquivo icone)
    {
        _nome = nome;
        _icone = icone;
    }

    public void Exibir()
    {
        Console.WriteLine($"Exibindo arquivo: {_nome}");
        _icone.Exibir(32);
    }
}

class Program
{
    static void Main(string[] args)
    {
        IconeFactory fabrica = new IconeFactory();

        // Carregar e compartilhar ícones para diferentes tipos de arquivos
        IconeArquivo iconePDF = fabrica.ObterIcone("PDF");
        IconeArquivo iconeWord = fabrica.ObterIcone("Word");
        IconeArquivo iconeImagem = fabrica.ObterIcone("Imagem");

        // Criar arquivos com ícones compartilhados
        Arquivo arquivo1 = new Arquivo("Documento1.pdf", iconePDF);
        Arquivo arquivo2 = new Arquivo("Documento2.pdf", iconePDF);
        Arquivo arquivo3 = new Arquivo("Relatório.docx", iconeWord);
        Arquivo arquivo4 = new Arquivo("Foto.jpg", iconeImagem);

        // Exibir arquivos com seus ícones
        arquivo1.Exibir();  // Saída: Exibindo arquivo: Documento1.pdf. Exibindo ícone PDF com tamanho 32.
        arquivo2.Exibir();  // Saída: Exibindo arquivo: Documento2.pdf. Exibindo ícone PDF com tamanho 32.
        arquivo3.Exibir();  // Saída: Exibindo arquivo: Relatório.docx. Exibindo ícone Word com tamanho 32.
        arquivo4.Exibir();  // Saída: Exibindo arquivo: Foto.jpg. Exibindo ícone Imagem com tamanho 32.
    }
}