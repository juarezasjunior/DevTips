public class Program
{
    public static void Main()
    {
        string nome = "João";
        int idade = 30;

        // Usando interpolação ao invés de concatenação
        string mensagem = $"Nome: {nome}, Idade: {idade}";

        Console.WriteLine(mensagem);
    }
}