public class Program
{
    public static void Main()
    {
        int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int[] subArray = numeros[2..5]; // Range para selecionar do índice 2 ao 4
        int ultimoElemento = numeros[^1]; // Acessa o último elemento com o operador ^

        Console.WriteLine("Subarray: " + string.Join(", ", subArray));
        Console.WriteLine("Último elemento: " + ultimoElemento);
    }
}