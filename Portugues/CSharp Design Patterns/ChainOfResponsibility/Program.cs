// Classe base para manipuladores
public abstract class Aprovador
{
    protected Aprovador _sucessor;

    public void DefinirSucessor(Aprovador sucessor)
    {
        _sucessor = sucessor;
    }

    public abstract void ProcessarPedido(int valor);
}

// Aprovador nível baixo (pode aprovar até 1000)
public class Gerente : Aprovador
{
    public override void ProcessarPedido(int valor)
    {
        if (valor <= 1000)
        {
            Console.WriteLine($"Gerente aprovou a solicitação de {valor} reais.");
        }
        else if (_sucessor != null)
        {
            _sucessor.ProcessarPedido(valor);
        }
    }
}

// Aprovador nível médio (pode aprovar até 5000)
public class Diretor : Aprovador
{
    public override void ProcessarPedido(int valor)
    {
        if (valor <= 5000)
        {
            Console.WriteLine($"Diretor aprovou a solicitação de {valor} reais.");
        }
        else if (_sucessor != null)
        {
            _sucessor.ProcessarPedido(valor);
        }
    }
}

// Aprovador nível alto (pode aprovar qualquer valor)
public class Presidente : Aprovador
{
    public override void ProcessarPedido(int valor)
    {
        Console.WriteLine($"Presidente aprovou a solicitação de {valor} reais.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando a cadeia de responsabilidade
        Aprovador gerente = new Gerente();
        Aprovador diretor = new Diretor();
        Aprovador presidente = new Presidente();

        gerente.DefinirSucessor(diretor);
        diretor.DefinirSucessor(presidente);

        // Testando a cadeia com diferentes valores
        gerente.ProcessarPedido(500);   // Gerente aprova
        gerente.ProcessarPedido(3000);  // Diretor aprova
        gerente.ProcessarPedido(10000); // Presidente aprova
    }
}