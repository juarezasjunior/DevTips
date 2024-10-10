// Classe abstrata que define o Template Method
public abstract class PrepararBebida
{
    // Método Template: define os passos do algoritmo
    public void Preparar()
    {
        FerverAgua();
        AdicionarIngredientePrincipal();
        Servir();
        if (AdicionarCondimentosDesejados())
        {
            AdicionarCondimentos();
        }
    }

    // Passos comuns
    private void FerverAgua()
    {
        Console.WriteLine("Fervendo água...");
    }

    private void Servir()
    {
        Console.WriteLine("Servindo a bebida...");
    }

    // Passos que serão implementados pelas subclasses
    protected abstract void AdicionarIngredientePrincipal();
    protected abstract void AdicionarCondimentos();

    // Hook method para condimentos opcionais
    protected virtual bool AdicionarCondimentosDesejados()
    {
        return true;
    }
}

// Subclasse para preparar café
public class PrepararCafe : PrepararBebida
{
    protected override void AdicionarIngredientePrincipal()
    {
        Console.WriteLine("Adicionando pó de café.");
    }

    protected override void AdicionarCondimentos()
    {
        Console.WriteLine("Adicionando açúcar e leite.");
    }
}

// Subclasse para preparar chá
public class PrepararCha : PrepararBebida
{
    protected override void AdicionarIngredientePrincipal()
    {
        Console.WriteLine("Adicionando o saquinho de chá.");
    }

    protected override void AdicionarCondimentos()
    {
        Console.WriteLine("Adicionando limão.");
    }

    protected override bool AdicionarCondimentosDesejados()
    {
        return false; // Não adicionar condimentos
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Preparando Café:");
        PrepararBebida cafe = new PrepararCafe();
        cafe.Preparar();

        Console.WriteLine("\nPreparando Chá:");
        PrepararBebida cha = new PrepararCha();
        cha.Preparar();
    }
}