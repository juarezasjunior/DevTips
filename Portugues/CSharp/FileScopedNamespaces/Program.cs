namespace MeuProjeto; // <- Veja como ficou mais simples a declaração do namespace

public class MinhaClasse
{
    public void ExibirMensagem()
    {
        Console.WriteLine("Usando File-Scoped Namespaces no C# 10.");
    }
}

public class Program
{
    public static void Main()
    {
        var obj = new MinhaClasse();
        obj.ExibirMensagem();
    }
}


