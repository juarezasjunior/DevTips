public class Singleton
{
    private static Singleton _instance;

    // Private constructor to prevent external instantiation
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public void ShowMessage()
    {
        Console.WriteLine("Singleton instance active!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Singleton s1 = Singleton.Instance;
        Singleton s2 = Singleton.Instance;

        s1.ShowMessage();

        // Check if both instances are the same
        Console.WriteLine(s1 == s2);  // True
    }
}