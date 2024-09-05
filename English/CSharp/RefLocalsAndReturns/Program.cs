using System;

public class Program
{
    public static void Main()
    {
        int[] numbers = { 10, 20, 30 };
        
        // Get a reference to the second array element and modify its value
        ref int reference = ref GetReference(numbers, 1);
        reference = 50;
        
        Console.WriteLine(string.Join(", ", numbers)); // Output: 10, 50, 30
    }

    public static ref int GetReference(int[] array, int index)
    {
        return ref array[index]; // Returns the reference to the array element
    }
}