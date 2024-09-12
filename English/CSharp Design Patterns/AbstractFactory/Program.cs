// Abstract product 1
public abstract class Car
{
    public abstract void ShowDetails();
}

// Concrete product 1A
public class Sedan : Car
{
    public override void ShowDetails()
    {
        Console.WriteLine("Sedan Car");
    }
}

// Concrete product 1B
public class SUV : Car
{
    public override void ShowDetails()
    {
        Console.WriteLine("SUV Car");
    }
}

// Abstract product 2
public abstract class Engine
{
    public abstract void ShowType();
}

// Concrete product 2A
public class CombustionEngine : Engine
{
    public override void ShowType()
    {
        Console.WriteLine("Combustion Engine");
    }
}

// Concrete product 2B
public class ElectricEngine : Engine
{
    public override void ShowType()
    {
        Console.WriteLine("Electric Engine");
    }
}

// Abstract factory
public abstract class VehicleFactory
{
    public abstract Car CreateCar();
    public abstract Engine CreateEngine();
}

// Concrete factory 1
public class SedanCombustionFactory : VehicleFactory
{
    public override Car CreateCar()
    {
        return new Sedan();
    }

    public override Engine CreateEngine()
    {
        return new CombustionEngine();
    }
}

// Concrete factory 2
public class SUVElectricFactory : VehicleFactory
{
    public override Car CreateCar()
    {
        return new SUV();
    }

    public override Engine CreateEngine()
    {
        return new ElectricEngine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        VehicleFactory factory = new SedanCombustionFactory();
        Car car = factory.CreateCar();
        Engine engine = factory.CreateEngine();

        car.ShowDetails();   // Output: Sedan Car
        engine.ShowType();   // Output: Combustion Engine

        factory = new SUVElectricFactory();
        car = factory.CreateCar();
        engine = factory.CreateEngine();

        car.ShowDetails();   // Output: SUV Car
        engine.ShowType();   // Output: Electric Engine
    }
}