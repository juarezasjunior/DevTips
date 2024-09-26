// Classe de exemplo que será gerenciada pelo Object Pool
public class Conexao
{
    public string Id { get; set; }

    public Conexao(string id)
    {
        Id = id;
        Console.WriteLine($"Conexão {Id} criada.");
    }

    public void Conectar()
    {
        Console.WriteLine($"Conexão {Id} conectada.");
    }

    public void Desconectar()
    {
        Console.WriteLine($"Conexão {Id} desconectada.");
    }
}

// Classe Object Pool para gerenciar as conexões
public class ConexaoPool
{
    private List<Conexao> _disponiveis = new List<Conexao>();
    private List<Conexao> _emUso = new List<Conexao>();

    public Conexao ObterConexao()
    {
        Conexao conexao;

        if (_disponiveis.Count > 0)
        {
            conexao = _disponiveis[0];
            _disponiveis.RemoveAt(0);
            Console.WriteLine($"Conexão {conexao.Id} reutilizada.");
        }
        else
        {
            conexao = new Conexao(Guid.NewGuid().ToString());
        }

        _emUso.Add(conexao);
        return conexao;
    }

    public void LiberarConexao(Conexao conexao)
    {
        _emUso.Remove(conexao);
        _disponiveis.Add(conexao);
        Console.WriteLine($"Conexão {conexao.Id} liberada e retornada ao pool.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConexaoPool pool = new ConexaoPool();

        // Obter e usar conexões
        Conexao conexao1 = pool.ObterConexao();
        conexao1.Conectar();

        Conexao conexao2 = pool.ObterConexao();
        conexao2.Conectar();

        // Liberar conexões de volta ao pool
        conexao1.Desconectar();
        pool.LiberarConexao(conexao1);

        Conexao conexao3 = pool.ObterConexao();  // Reutilizando conexão liberada
        conexao3.Conectar();

        conexao2.Desconectar();
        pool.LiberarConexao(conexao2);
    }
}