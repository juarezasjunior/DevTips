public class Pessoa
{
    public string Nome { get; set; }
    public int Idade { get; set; }
}

public class Program
{
    public static void Main()
    {
        Pessoa pessoa = new("João", 30); // Usando Target-Typed New Expressions

        Console.WriteLine($"Nome: {pessoa.Nome}, Idade: {pessoa.Idade}");
    }
}