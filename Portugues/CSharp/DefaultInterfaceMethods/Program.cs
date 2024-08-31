public interface IMinhaInterface
{
    void MostrarMensagem()
    {
        Console.WriteLine("Mensagem padrão da interface.");
    }
}

public class MinhaClasse : IMinhaInterface
{
    // A implementação padrão será usada se este método não for definido.
}

public class Program
{
    public static void Main()
    {
        IMinhaInterface obj = new MinhaClasse();
        obj.MostrarMensagem(); // Saída: "Mensagem padrão da interface."
    }
}


