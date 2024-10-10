// Observer interface
public interface IObserver
{
    void Update(string state);
}

// Subject interface
public interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Concrete Subject implementation
public class ConcreteSubject : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _state;

    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            NotifyObservers();
        }
    }

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_state);
        }
    }
}

// Concrete Observers
public class ConcreteObserver1 : IObserver
{
    public void Update(string state)
    {
        Console.WriteLine($"Observer 1 has been notified. New state: {state}");
    }
}

public class ConcreteObserver2 : IObserver
{
    public void Update(string state)
    {
        Console.WriteLine($"Observer 2 has been notified. New state: {state}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create the subject
        ConcreteSubject subject = new ConcreteSubject();

        // Create and add observers
        ConcreteObserver1 observer1 = new ConcreteObserver1();
        ConcreteObserver2 observer2 = new ConcreteObserver2();

        subject.AddObserver(observer1);
        subject.AddObserver(observer2);

        // Change the subject's state
        subject.State = "State A";
        subject.State = "State B";

        // Remove an observer and change the state
        subject.RemoveObserver(observer1);
        subject.State = "State C";
    }
}