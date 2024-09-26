// Complex subsystem: TV
public class TV
{
    public void TurnOn()
    {
        Console.WriteLine("TV turned on.");
    }

    public void SetChannel(int channel)
    {
        Console.WriteLine($"Channel set to {channel}.");
    }
}

// Complex subsystem: DVD player
public class DVDPlayer
{
    public void TurnOn()
    {
        Console.WriteLine("DVD player turned on.");
    }

    public void Play()
    {
        Console.WriteLine("Playing DVD.");
    }
}

// Complex subsystem: Sound system
public class SoundSystem
{
    public void TurnOn()
    {
        Console.WriteLine("Sound system turned on.");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"Volume set to {volume}.");
    }
}

// Facade: Home Theater
public class HomeTheaterFacade
{
    private TV _tv;
    private DVDPlayer _dvdPlayer;
    private SoundSystem _soundSystem;

    public HomeTheaterFacade(TV tv, DVDPlayer dvdPlayer, SoundSystem soundSystem)
    {
        _tv = tv;
        _dvdPlayer = dvdPlayer;
        _soundSystem = soundSystem;
    }

    public void WatchMovie()
    {
        Console.WriteLine("Starting Home Theater...");
        _tv.TurnOn();
        _tv.SetChannel(3);
        _dvdPlayer.TurnOn();
        _dvdPlayer.Play();
        _soundSystem.TurnOn();
        _soundSystem.SetVolume(20);
        Console.WriteLine("All set, enjoy your movie!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating the subsystems
        TV tv = new TV();
        DVDPlayer dvdPlayer = new DVDPlayer();
        SoundSystem soundSystem = new SoundSystem();

        // Using the facade
        HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, dvdPlayer, soundSystem);
        homeTheater.WatchMovie();
    }
}