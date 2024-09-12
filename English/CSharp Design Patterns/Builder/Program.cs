// Product to be built
public class House
{
    public string Foundation { get; set; }
    public string Structure { get; set; }
    public string Roof { get; set; }
    public string Interior { get; set; }

    public void ShowDetails()
    {
        Console.WriteLine($"House with Foundation: {Foundation}, Structure: {Structure}, Roof: {Roof}, Interior: {Interior}");
    }
}

// Builder interface
public interface IHouseBuilder
{
    IHouseBuilder BuildFoundation();
    IHouseBuilder BuildStructure();
    IHouseBuilder BuildRoof();
    IHouseBuilder BuildInterior();
    House GetHouse();
}

// Concrete Builder implementation
public class HouseBuilder : IHouseBuilder
{
    private House _house = new House();

    public IHouseBuilder BuildFoundation()
    {
        _house.Foundation = "Concrete foundation";
        return this;
    }

    public IHouseBuilder BuildStructure()
    {
        _house.Structure = "Wooden structure";
        return this;
    }

    public IHouseBuilder BuildRoof()
    {
        _house.Roof = "Tile roof";
        return this;
    }

    public IHouseBuilder BuildInterior()
    {
        _house.Interior = "Standard interior";
        return this;
    }

    public House GetHouse()
    {
        return _house;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Using the builder with method chaining
        IHouseBuilder builder = new HouseBuilder();
        House house = builder.BuildFoundation()
                             .BuildStructure()
                             .BuildRoof()
                             .BuildInterior()
                             .GetHouse();

        house.ShowDetails();  // Output: House with Foundation: Concrete foundation, Structure: Wooden structure, Roof: Tile roof, Interior: Standard interior
    }
}