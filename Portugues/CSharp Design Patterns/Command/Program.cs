// Interface para os comandos
public interface IComando
{
    void Executar();
}

// Classe que representa um receptor, ou seja, quem executa as ações reais
public class Luz
{
    public void Ligar()
    {
        Console.WriteLine("A luz está ligada.");
    }

    public void Desligar()
    {
        Console.WriteLine("A luz está desligada.");
    }
}

// Comando para ligar a luz
public class ComandoLigarLuz : IComando
{
    private Luz _luz;

    public ComandoLigarLuz(Luz luz)
    {
        _luz = luz;
    }

    public void Executar()
    {
        _luz.Ligar();
    }
}

// Comando para desligar a luz
public class ComandoDesligarLuz : IComando
{
    private Luz _luz;

    public ComandoDesligarLuz(Luz luz)
    {
        _luz = luz;
    }

    public void Executar()
    {
        _luz.Desligar();
    }
}

// O invocador, que chama os comandos
public class ControleRemoto
{
    private IComando _comando;

    public void DefinirComando(IComando comando)
    {
        _comando = comando;
    }

    public void PressionarBotao()
    {
        _comando.Executar();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar os objetos
        Luz luz = new Luz();
        IComando ligarLuz = new ComandoLigarLuz(luz);
        IComando desligarLuz = new ComandoDesligarLuz(luz);

        // Criar o invocador (controle remoto)
        ControleRemoto controle = new ControleRemoto();

        // Ligar a luz
        controle.DefinirComando(ligarLuz);
        controle.PressionarBotao();  // Saída: A luz está ligada.

        // Desligar a luz
        controle.DefinirComando(desligarLuz);
        controle.PressionarBotao();  // Saída: A luz está desligada.
    }
}