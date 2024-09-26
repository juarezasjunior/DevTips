// Subsistema complexo: TV
public class TV
{
    public void Ligar()
    {
        Console.WriteLine("TV ligada.");
    }

    public void DefinirCanal(int canal)
    {
        Console.WriteLine($"Canal definido para {canal}.");
    }
}

// Subsistema complexo: DVD player
public class DVDPlayer
{
    public void Ligar()
    {
        Console.WriteLine("DVD player ligado.");
    }

    public void Reproduzir()
    {
        Console.WriteLine("Reproduzindo DVD.");
    }
}

// Subsistema complexo: Sistema de Som
public class SistemaDeSom
{
    public void Ligar()
    {
        Console.WriteLine("Sistema de som ligado.");
    }

    public void DefinirVolume(int volume)
    {
        Console.WriteLine($"Volume definido para {volume}.");
    }
}

// Facade: Home Theater
public class HomeTheaterFacade
{
    private TV _tv;
    private DVDPlayer _dvdPlayer;
    private SistemaDeSom _som;

    public HomeTheaterFacade(TV tv, DVDPlayer dvdPlayer, SistemaDeSom som)
    {
        _tv = tv;
        _dvdPlayer = dvdPlayer;
        _som = som;
    }

    public void AssistirFilme()
    {
        Console.WriteLine("Iniciando o Home Theater...");
        _tv.Ligar();
        _tv.DefinirCanal(3);
        _dvdPlayer.Ligar();
        _dvdPlayer.Reproduzir();
        _som.Ligar();
        _som.DefinirVolume(20);
        Console.WriteLine("Tudo pronto, aproveite o filme!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Criando os subsistemas
        TV tv = new TV();
        DVDPlayer dvdPlayer = new DVDPlayer();
        SistemaDeSom som = new SistemaDeSom();

        // Usando a facade
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, dvdPlayer, som);
        homeTheater.AssistirFilme();
    }
}