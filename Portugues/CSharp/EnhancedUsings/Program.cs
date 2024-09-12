public class Program
{
    public static void Main()
    {
        using var arquivo = new System.IO.StreamWriter("arquivo.txt");
        arquivo.WriteLine("Escrevendo no arquivo sem usar blocos de using.");

        // O StreamWriter será automaticamente fechado ao final do método
    }
}