// Base class for handlers
public abstract class Approver
{
    protected Approver _successor;

    public void SetSuccessor(Approver successor)
    {
        _successor = successor;
    }

    public abstract void ProcessRequest(int amount);
}

// Low-level approver (can approve up to 1000)
public class Manager : Approver
{
    public override void ProcessRequest(int amount)
    {
        if (amount <= 1000)
        {
            Console.WriteLine($"Manager approved the request of {amount} dollars.");
        }
        else if (_successor != null)
        {
            _successor.ProcessRequest(amount);
        }
    }
}

// Mid-level approver (can approve up to 5000)
public class Director : Approver
{
    public override void ProcessRequest(int amount)
    {
        if (amount <= 5000)
        {
            Console.WriteLine($"Director approved the request of {amount} dollars.");
        }
        else if (_successor != null)
        {
            _successor.ProcessRequest(amount);
        }
    }
}

// High-level approver (can approve any amount)
public class President : Approver
{
    public override void ProcessRequest(int amount)
    {
        Console.WriteLine($"President approved the request of {amount} dollars.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating the chain of responsibility
        Approver manager = new Manager();
        Approver director = new Director();
        Approver president = new President();

        manager.SetSuccessor(director);
        director.SetSuccessor(president);

        // Testing the chain with different amounts
        manager.ProcessRequest(500);   // Manager approves
        manager.ProcessRequest(3000);  // Director approves
        manager.ProcessRequest(10000); // President approves
    }
}