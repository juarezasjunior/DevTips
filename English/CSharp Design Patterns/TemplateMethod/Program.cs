// Abstract class that defines the Template Method
public abstract class PrepareBeverage
{
    // Template Method: defines the steps of the algorithm
    public void Prepare()
    {
        BoilWater();
        AddMainIngredient();
        Serve();
        if (AddCondimentsDesired())
        {
            AddCondiments();
        }
    }

    // Common steps
    private void BoilWater()
    {
        Console.WriteLine("Boiling water...");
    }

    private void Serve()
    {
        Console.WriteLine("Serving the beverage...");
    }

    // Steps to be implemented by subclasses
    protected abstract void AddMainIngredient();
    protected abstract void AddCondiments();

    // Hook method for optional condiments
    protected virtual bool AddCondimentsDesired()
    {
        return true;
    }
}

// Subclass for preparing coffee
public class PrepareCoffee : PrepareBeverage
{
    protected override void AddMainIngredient()
    {
        Console.WriteLine("Adding coffee powder.");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk.");
    }
}

// Subclass for preparing tea
public class PrepareTea : PrepareBeverage
{
    protected override void AddMainIngredient()
    {
        Console.WriteLine("Adding tea bag.");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon.");
    }

    protected override bool AddCondimentsDesired()
    {
        return false; // Do not add condiments
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Preparing Coffee:");
        PrepareBeverage coffee = new PrepareCoffee();
        coffee.Prepare();

        Console.WriteLine("\nPreparing Tea:");
        PrepareBeverage tea = new PrepareTea();
        tea.Prepare();
    }
}