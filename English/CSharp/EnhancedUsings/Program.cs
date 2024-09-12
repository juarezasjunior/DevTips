public class Program
{
    public static void Main()
    {
        using var file = new System.IO.StreamWriter("file.txt");
        file.WriteLine("Writing to the file without using blocks.");

        // The StreamWriter will automatically be closed at the end of the method
    }
}