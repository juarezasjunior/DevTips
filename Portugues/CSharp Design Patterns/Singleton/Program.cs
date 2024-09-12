public class Singleton
{
    private static Singleton _instance;

    // Construtor privado para impedir a criação de instâncias externas
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
        Console.WriteLine("Singleton instance ativa!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Singleton s1 = Singleton.Instance;
        Singleton s2 = Singleton.Instance;

        s1.ShowMessage();

        // Verificar se ambas as instâncias são iguais
        Console.WriteLine(s1 == s2);  // True
    }
}