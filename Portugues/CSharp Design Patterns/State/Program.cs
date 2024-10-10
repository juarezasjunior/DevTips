// Interface de Estado
public interface IEstado
{
    void InserirMoeda(MaquinaVendas maquina);
    void SelecionarProduto(MaquinaVendas maquina);
    void DispensarProduto(MaquinaVendas maquina);
}

// Estado de aguardando moeda
public class AguardandoMoeda : IEstado
{
    public void InserirMoeda(MaquinaVendas maquina)
    {
        Console.WriteLine("Moeda inserida. Selecione o produto.");
        maquina.DefinirEstado(new AguardandoSelecao());
    }

    public void SelecionarProduto(MaquinaVendas maquina)
    {
        Console.WriteLine("Insira uma moeda primeiro.");
    }

    public void DispensarProduto(MaquinaVendas maquina)
    {
        Console.WriteLine("Insira uma moeda e selecione um produto.");
    }
}

// Estado de aguardando seleção de produto
public class AguardandoSelecao : IEstado
{
    public void InserirMoeda(MaquinaVendas maquina)
    {
        Console.WriteLine("Você já inseriu uma moeda. Selecione o produto.");
    }

    public void SelecionarProduto(MaquinaVendas maquina)
    {
        Console.WriteLine("Produto selecionado. Dispensando o produto...");
        maquina.DefinirEstado(new ProdutoDispensado());
    }

    public void DispensarProduto(MaquinaVendas maquina)
    {
        Console.WriteLine("Selecione um produto primeiro.");
    }
}

// Estado de dispensando produto
public class ProdutoDispensado : IEstado
{
    public void InserirMoeda(MaquinaVendas maquina)
    {
        Console.WriteLine("Aguarde, já estamos dispensando o produto.");
    }

    public void SelecionarProduto(MaquinaVendas maquina)
    {
        Console.WriteLine("Aguarde, o produto está sendo dispensado.");
    }

    public void DispensarProduto(MaquinaVendas maquina)
    {
        Console.WriteLine("Produto dispensado! Retire o produto.");
        maquina.DefinirEstado(new AguardandoMoeda());
    }
}

// Classe Maquina de Vendas
public class MaquinaVendas
{
    private IEstado _estadoAtual;

    public MaquinaVendas()
    {
        _estadoAtual = new AguardandoMoeda();
    }

    public void DefinirEstado(IEstado novoEstado)
    {
        _estadoAtual = novoEstado;
    }

    public void InserirMoeda()
    {
        _estadoAtual.InserirMoeda(this);
    }

    public void SelecionarProduto()
    {
        _estadoAtual.SelecionarProduto(this);
    }

    public void DispensarProduto()
    {
        _estadoAtual.DispensarProduto(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MaquinaVendas maquina = new MaquinaVendas();

        // Testando a máquina de vendas
        maquina.InserirMoeda();
        maquina.SelecionarProduto();
        maquina.DispensarProduto();
    }
}