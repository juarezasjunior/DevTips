// Interface for commands
public interface ICommand
{
    void Execute();
}

// Class representing a receiver, the one who actually performs actions
public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("The light is on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("The light is off.");
    }
}

// Command to turn on the light
public class TurnOnLightCommand : ICommand
{
    private Light _light;

    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }
}

// Command to turn off the light
public class TurnOffLightCommand : ICommand
{
    private Light _light;

    public TurnOffLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }
}

// The invoker, which calls the commands
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create objects
        Light light = new Light();
        ICommand turnOn = new TurnOnLightCommand(light);
        ICommand turnOff = new TurnOffLightCommand(light);

        // Create the invoker (remote control)
        RemoteControl remote = new RemoteControl();

        // Turn the light on
        remote.SetCommand(turnOn);
        remote.PressButton();  // Output: The light is on.

        // Turn the light off
        remote.SetCommand(turnOff);
        remote.PressButton();  // Output: The light is off.
    }
}