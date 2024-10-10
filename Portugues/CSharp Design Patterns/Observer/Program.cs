// Interface do Observador
public interface IObservador
{
    void Atualizar(string estado);
}

// Interface do Sujeito
public interface ISujeito
{
    void AdicionarObservador(IObservador observador);
    void RemoverObservador(IObservador observador);
    void NotificarObservadores();
}

// Implementação do Sujeito
public class SujeitoConcreto : ISujeito
{
    private List<IObservador> _observadores = new List<IObservador>();
    private string _estado;

    public string Estado
    {
        get { return _estado; }
        set
        {
            _estado = value;
            NotificarObservadores();
        }
    }

    public void AdicionarObservador(IObservador observador)
    {
        _observadores.Add(observador);
    }

    public void RemoverObservador(IObservador observador)
    {
        _observadores.Remove(observador);
    }

    public void NotificarObservadores()
    {
        foreach (var observador in _observadores)
        {
            observador.Atualizar(_estado);
        }
    }
}

// Implementação de Observadores
public class ObservadorConcreto1 : IObservador
{
    public void Atualizar(string estado)
    {
        Console.WriteLine($"Observador 1 foi notificado. Novo estado: {estado}");
    }
}

public class ObservadorConcreto2 : IObservador
{
    public void Atualizar(string estado)
    {
        Console.WriteLine($"Observador 2 foi notificado. Novo estado: {estado}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar o sujeito
        SujeitoConcreto sujeito = new SujeitoConcreto();

        // Criar e adicionar observadores
        ObservadorConcreto1 observador1 = new ObservadorConcreto1();
        ObservadorConcreto2 observador2 = new ObservadorConcreto2();

        sujeito.AdicionarObservador(observador1);
        sujeito.AdicionarObservador(observador2);

        // Alterar o estado do sujeito
        sujeito.Estado = "Estado A";
        sujeito.Estado = "Estado B";

        // Remover um observador e alterar o estado
        sujeito.RemoverObservador(observador1);
        sujeito.Estado = "Estado C";
    }
}