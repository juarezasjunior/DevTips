// Interface Prototype
public interface IPrototype<T>
{
    T Clonar();
}

// Classe concreta que implementa Prototype
public class Circulo : IPrototype<Circulo>
{
    public int Raio { get; set; }

    public Circulo(int raio)
    {
        Raio = raio;
    }

    public Circulo Clonar()
    {
        // Clona o objeto atual
        return new Circulo(this.Raio);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Círculo com raio: {Raio}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criar um círculo original
        Circulo circulo1 = new Circulo(10);
        circulo1.ExibirDetalhes();  // Saída: Círculo com raio: 10

        // Clonar o círculo
        Circulo circulo2 = circulo1.Clonar();
        circulo2.ExibirDetalhes();  // Saída: Círculo com raio: 10

        // Modificar o clone
        circulo2.Raio = 20;
        circulo2.ExibirDetalhes();  // Saída: Círculo com raio: 20
        circulo1.ExibirDetalhes();  // Saída: Círculo com raio: 10
    }
}