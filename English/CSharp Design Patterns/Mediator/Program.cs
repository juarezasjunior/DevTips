// Mediator interface
public interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}

// Base class for colleagues that communicate through the mediator
public abstract class Colleague
{
    protected IMediator _mediator;

    public Colleague(IMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void ReceiveMessage(string message);
}

// Concrete Colleague 1
public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(IMediator mediator) : base(mediator) { }

    public void Send(string message)
    {
        Console.WriteLine($"Colleague 1 sending message: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Colleague 1 received message: {message}");
    }
}

// Concrete Colleague 2
public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(IMediator mediator) : base(mediator) { }

    public void Send(string message)
    {
        Console.WriteLine($"Colleague 2 sending message: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void ReceiveMessage(string message)
    {
        Console.WriteLine($"Colleague 2 received message: {message}");
    }
}

// Concrete Mediator managing the communication
public class ConcreteMediator : IMediator
{
    private ConcreteColleague1 _colleague1;
    private ConcreteColleague2 _colleague2;

    public ConcreteColleague1 Colleague1
    {
        set { _colleague1 = value; }
    }

    public ConcreteColleague2 Colleague2
    {
        set { _colleague2 = value; }
    }

    public void SendMessage(string message, Colleague colleague)
    {
        if (colleague == _colleague1)
        {
            _colleague2.ReceiveMessage(message);
        }
        else
        {
            _colleague1.ReceiveMessage(message);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create the mediator
        ConcreteMediator mediator = new ConcreteMediator();

        // Create colleagues
        ConcreteColleague1 colleague1 = new ConcreteColleague1(mediator);
        ConcreteColleague2 colleague2 = new ConcreteColleague2(mediator);

        // Set colleagues in the mediator
        mediator.Colleague1 = colleague1;
        mediator.Colleague2 = colleague2;

        // Colleague 1 sends a message
        colleague1.Send("Hello from Colleague 1");

        // Colleague 2 sends a message
        colleague2.Send("Hi from Colleague 2");
    }
}