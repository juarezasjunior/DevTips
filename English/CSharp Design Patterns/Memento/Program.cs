// Memento class that stores the state
public class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}

// Originator class that uses the Memento to save and restore its state
public class Originator
{
    public string State { get; set; }

    public Memento SaveState()
    {
        return new Memento(State);
    }

    public void RestoreState(Memento memento)
    {
        State = memento.State;
    }
}

// Caretaker class that manages the history of states
public class Caretaker
{
    private Stack<Memento> _history = new Stack<Memento>();

    public void Save(Originator originator)
    {
        _history.Push(originator.SaveState());
    }

    public void Undo(Originator originator)
    {
        if (_history.Count > 0)
        {
            originator.RestoreState(_history.Pop());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        // Set state and save it
        originator.State = "State 1";
        caretaker.Save(originator);

        // Change state and save it
        originator.State = "State 2";
        caretaker.Save(originator);

        // Change state again
        originator.State = "State 3";
        Console.WriteLine($"Current state: {originator.State}");

        // Undo to the previous state
        caretaker.Undo(originator);
        Console.WriteLine($"After undo: {originator.State}");

        // Undo again
        caretaker.Undo(originator);
        Console.WriteLine($"After undo again: {originator.State}");
    }
}