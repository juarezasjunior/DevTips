// Classe Memento que armazena o estado
public class Memento
{
    public string Estado { get; private set; }

    public Memento(string estado)
    {
        Estado = estado;
    }
}

// Classe Originator que usa o Memento para salvar e restaurar seu estado
public class Originator
{
    public string Estado { get; set; }

    public Memento SalvarEstado()
    {
        return new Memento(Estado);
    }

    public void RestaurarEstado(Memento memento)
    {
        Estado = memento.Estado;
    }
}

// Classe Caretaker que gerencia o histórico dos estados
public class Caretaker
{
    private Stack<Memento> _historico = new Stack<Memento>();

    public void Salvar(Originator originator)
    {
        _historico.Push(originator.SalvarEstado());
    }

    public void Desfazer(Originator originator)
    {
        if (_historico.Count > 0)
        {
            originator.RestaurarEstado(_historico.Pop());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        // Definir o estado e salvar
        originator.Estado = "Estado 1";
        caretaker.Salvar(originator);

        // Alterar o estado e salvar
        originator.Estado = "Estado 2";
        caretaker.Salvar(originator);

        // Alterar o estado novamente
        originator.Estado = "Estado 3";
        Console.WriteLine($"Estado atual: {originator.Estado}");

        // Desfazer para o estado anterior
        caretaker.Desfazer(originator);
        Console.WriteLine($"Após desfazer: {originator.Estado}");

        // Desfazer novamente
        caretaker.Desfazer(originator);
        Console.WriteLine($"Após desfazer novamente: {originator.Estado}");
    }
}