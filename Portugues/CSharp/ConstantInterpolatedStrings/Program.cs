public class Program
{
    const string Nome = "C#";
    const string Versao = "10";
    
    // Usando interpolação em uma constante
    const string Saudacao = $"Bem-vindo ao {Nome} versão {Versao}!";

    public static void Main()
    {
        Console.WriteLine(Saudacao);
    }
}