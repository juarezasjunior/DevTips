using System;

public class Program
{
    public static void Main()
    {
        int[] numeros = { 10, 20, 30 };
        
        // Obtém uma referência ao segundo elemento do array e modifica seu valor
        ref int referencia = ref ObterReferencia(numeros, 1);
        referencia = 50;
        
        Console.WriteLine(string.Join(", ", numeros)); // Saída: 10, 50, 30
    }

    public static ref int ObterReferencia(int[] array, int indice)
    {
        return ref array[indice]; // Retorna a referência ao elemento do array
    }
}