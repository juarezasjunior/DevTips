// Interface que define as operações da imagem
public interface IImagem
{
    void Exibir();
}

// Classe que representa a imagem real, que é "pesada" para carregar
public class ImagemReal : IImagem
{
    private string _caminhoArquivo;

    public ImagemReal(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
        CarregarImagem();
    }

    private void CarregarImagem()
    {
        Console.WriteLine($"Carregando imagem do arquivo {_caminhoArquivo}...");
    }

    public void Exibir()
    {
        Console.WriteLine($"Exibindo imagem {_caminhoArquivo}.");
    }
}

// Classe Proxy que controla o acesso à ImagemReal
public class ProxyImagem : IImagem
{
    private ImagemReal _imagemReal;
    private string _caminhoArquivo;

    public ProxyImagem(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
    }

    public void Exibir()
    {
        // Carregar a imagem real apenas quando for necessária
        if (_imagemReal == null)
        {
            _imagemReal = new ImagemReal(_caminhoArquivo);
        }
        _imagemReal.Exibir();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar uma imagem proxy
        IImagem imagem = new ProxyImagem("foto.jpg");

        // A imagem real só será carregada quando for realmente exibida
        Console.WriteLine("Imagem criada, mas ainda não carregada.");
        imagem.Exibir();  // Carregando e exibindo a imagem real
        imagem.Exibir();  // A imagem já está carregada, então só será exibida
    }
}