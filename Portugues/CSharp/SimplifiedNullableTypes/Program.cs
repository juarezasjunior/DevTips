#nullable enable

public class Pessoa
{
    public string Nome { get; set; }
    public string? Apelido { get; set; }  // Pode aceitar null
}

public class Program
{
    public static void Main()
    {
        Pessoa pessoa = new Pessoa { Nome = "João", Apelido = null };
        Console.WriteLine($"Nome: {pessoa.Nome}, Apelido: {pessoa.Apelido ?? "Nenhum"}");
    }
}