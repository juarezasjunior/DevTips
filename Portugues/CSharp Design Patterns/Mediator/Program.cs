// Interface do Mediador
public interface IMediador
{
    void EnviarMensagem(string mensagem, Colega colega);
}

// Classe base para colegas que se comunicam através do mediador
public abstract class Colega
{
    protected IMediador _mediador;

    public Colega(IMediador mediador)
    {
        _mediador = mediador;
    }

    public abstract void ReceberMensagem(string mensagem);
}

// Colega Concreto 1
public class ColegaConcreto1 : Colega
{
    public ColegaConcreto1(IMediador mediador) : base(mediador) { }

    public void Enviar(string mensagem)
    {
        Console.WriteLine($"Colega 1 enviando mensagem: {mensagem}");
        _mediador.EnviarMensagem(mensagem, this);
    }

    public override void ReceberMensagem(string mensagem)
    {
        Console.WriteLine($"Colega 1 recebeu mensagem: {mensagem}");
    }
}

// Colega Concreto 2
public class ColegaConcreto2 : Colega
{
    public ColegaConcreto2(IMediador mediador) : base(mediador) { }

    public void Enviar(string mensagem)
    {
        Console.WriteLine($"Colega 2 enviando mensagem: {mensagem}");
        _mediador.EnviarMensagem(mensagem, this);
    }

    public override void ReceberMensagem(string mensagem)
    {
        Console.WriteLine($"Colega 2 recebeu mensagem: {mensagem}");
    }
}

// Mediador Concreto que gerencia a comunicação
public class MediadorConcreto : IMediador
{
    private ColegaConcreto1 _colega1;
    private ColegaConcreto2 _colega2;

    public ColegaConcreto1 Colega1
    {
        set { _colega1 = value; }
    }

    public ColegaConcreto2 Colega2
    {
        set { _colega2 = value; }
    }

    public void EnviarMensagem(string mensagem, Colega colega)
    {
        if (colega == _colega1)
        {
            _colega2.ReceberMensagem(mensagem);
        }
        else
        {
            _colega1.ReceberMensagem(mensagem);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar o mediador
        MediadorConcreto mediador = new MediadorConcreto();

        // Criar colegas
        ColegaConcreto1 colega1 = new ColegaConcreto1(mediador);
        ColegaConcreto2 colega2 = new ColegaConcreto2(mediador);

        // Definir colegas no mediador
        mediador.Colega1 = colega1;
        mediador.Colega2 = colega2;

        // Colega 1 envia uma mensagem
        colega1.Enviar("Olá do Colega 1");

        // Colega 2 envia uma mensagem
        colega2.Enviar("Oi do Colega 2");
    }
}