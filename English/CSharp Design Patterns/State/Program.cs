// State interface
public interface IState
{
    void InsertCoin(VendingMachine machine);
    void SelectProduct(VendingMachine machine);
    void DispenseProduct(VendingMachine machine);
}

// State: Waiting for coin
public class WaitingForCoin : IState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("Coin inserted. Select a product.");
        machine.SetState(new WaitingForSelection());
    }

    public void SelectProduct(VendingMachine machine)
    {
        Console.WriteLine("Insert a coin first.");
    }

    public void DispenseProduct(VendingMachine machine)
    {
        Console.WriteLine("Insert a coin and select a product.");
    }
}

// State: Waiting for product selection
public class WaitingForSelection : IState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("You've already inserted a coin. Select a product.");
    }

    public void SelectProduct(VendingMachine machine)
    {
        Console.WriteLine("Product selected. Dispensing product...");
        machine.SetState(new ProductDispensed());
    }

    public void DispenseProduct(VendingMachine machine)
    {
        Console.WriteLine("Select a product first.");
    }
}

// State: Dispensing product
public class ProductDispensed : IState
{
    public void InsertCoin(VendingMachine machine)
    {
        Console.WriteLine("Please wait, we're dispensing your product.");
    }

    public void SelectProduct(VendingMachine machine)
    {
        Console.WriteLine("Please wait, the product is being dispensed.");
    }

    public void DispenseProduct(VendingMachine machine)
    {
        Console.WriteLine("Product dispensed! Please take your product.");
        machine.SetState(new WaitingForCoin());
    }
}

// Vending Machine class
public class VendingMachine
{
    private IState _currentState;

    public VendingMachine()
    {
        _currentState = new WaitingForCoin();
    }

    public void SetState(IState newState)
    {
        _currentState = newState;
    }

    public void InsertCoin()
    {
        _currentState.InsertCoin(this);
    }

    public void SelectProduct()
    {
        _currentState.SelectProduct(this);
    }

    public void DispenseProduct()
    {
        _currentState.DispenseProduct(this);
    }
}

class Program
{
    static void Main(string[] args)
    {
        VendingMachine machine = new VendingMachine();

        // Test the vending machine
        machine.InsertCoin();
        machine.SelectProduct();
        machine.DispenseProduct();
    }
}