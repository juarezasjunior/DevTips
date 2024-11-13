public class Program
{
    public static void Main()
    {
        // Tipo evidente, bom uso de var
        var total = 100;

        // Prefira o tipo explícito para evitar ambiguidade
        List<int> numeros = Program.GetAList();

        // `decimal` com `var` é evidente pelo valor
        var valor = 100.0m;

        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Primeiro número: {numeros[0]}");
        Console.WriteLine($"Valor: {valor}");
    }

    public static List<int> GetAList() => new List<int> { 1, 2, 3, 4, 5 };
}