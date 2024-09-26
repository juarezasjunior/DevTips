// Classe existente (incompatível com o cliente)
public class TomadaEuropeia
{
    public void ConectarPlugEuropeu()
    {
        Console.WriteLine("Plug europeu conectado à tomada europeia.");
    }
}

// Interface do cliente
public interface ITomada
{
    void Conectar();
}

// Adapter que torna a classe TomadaEuropeia compatível com a interface ITomada
public class TomadaAdapter : ITomada
{
    private TomadaEuropeia _tomadaEuropeia;

    public TomadaAdapter(TomadaEuropeia tomadaEuropeia)
    {
        _tomadaEuropeia = tomadaEuropeia;
    }

    public void Conectar()
    {
        // Adaptando a chamada
        _tomadaEuropeia.ConectarPlugEuropeu();
    }
}

// Cliente que usa a interface ITomada
class Program
{
    static void Main(string[] args)
    {
        // Cliente precisa de uma tomada compatível com ITomada
        ITomada tomada = new TomadaAdapter(new TomadaEuropeia());
        tomada.Conectar();  // Saída: Plug europeu conectado à tomada europeia.
    }
}