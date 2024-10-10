// Strategy interface
public interface IPriceCalculation
{
    decimal CalculatePrice(decimal basePrice);
}

// Implementation of a strategy for normal price
public class NormalPrice : IPriceCalculation
{
    public decimal CalculatePrice(decimal basePrice)
    {
        return basePrice;
    }
}

// Implementation of a strategy for discounted price
public class DiscountPrice : IPriceCalculation
{
    private decimal _discountPercentage;

    public DiscountPrice(decimal discountPercentage)
    {
        _discountPercentage = discountPercentage;
    }

    public decimal CalculatePrice(decimal basePrice)
    {
        return basePrice - (basePrice * _discountPercentage / 100);
    }
}

// Implementation of a strategy for premium price
public class PremiumPrice : IPriceCalculation
{
    public decimal CalculatePrice(decimal basePrice)
    {
        return basePrice + (basePrice * 0.20m); // Adds 20% to the price
    }
}

// Class that uses a pricing strategy
public class Product
{
    private IPriceCalculation _priceStrategy;
    private decimal _basePrice;

    public Product(IPriceCalculation priceStrategy, decimal basePrice)
    {
        _priceStrategy = priceStrategy;
        _basePrice = basePrice;
    }

    public void SetStrategy(IPriceCalculation priceStrategy)
    {
        _priceStrategy = priceStrategy;
    }

    public void DisplayFinalPrice()
    {
        Console.WriteLine($"Final price: {_priceStrategy.CalculatePrice(_basePrice)}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a product with a base price of 100
        Product product = new Product(new NormalPrice(), 100);

        // Display price with normal strategy
        product.DisplayFinalPrice(); // Output: Final price: 100

        // Change to discount strategy and display the price
        product.SetStrategy(new DiscountPrice(10)); // 10% discount
        product.DisplayFinalPrice(); // Output: Final price: 90

        // Change to premium strategy and display the price
        product.SetStrategy(new PremiumPrice());
        product.DisplayFinalPrice(); // Output: Final price: 120
    }
}