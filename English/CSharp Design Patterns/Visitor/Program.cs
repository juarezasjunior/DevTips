// Element interface that accepts visitors
public interface IElement
{
    void Accept(IVisitor visitor);
}

// Visitor interface
public interface IVisitor
{
    void Visit(Book book);
    void Visit(Movie movie);
}

// Element implementation: Book
public class Book : IElement
{
    public string Title { get; }
    public double Price { get; }

    public Book(string title, double price)
    {
        Title = title;
        Price = price;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Element implementation: Movie
public class Movie : IElement
{
    public string Title { get; }
    public double Price { get; }

    public Movie(string title, double price)
    {
        Title = title;
        Price = price;
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Visitor that calculates taxes on the items
public class TaxCalculatorVisitor : IVisitor
{
    private const double TaxRate = 0.1;

    public void Visit(Book book)
    {
        double tax = book.Price * TaxRate;
        Console.WriteLine($"Tax on the book '{book.Title}': {tax:C}");
    }

    public void Visit(Movie movie)
    {
        double tax = movie.Price * TaxRate;
        Console.WriteLine($"Tax on the movie '{movie.Title}': {tax:C}");
    }
}

// Visitor that displays item details
public class DisplayDetailsVisitor : IVisitor
{
    public void Visit(Book book)
    {
        Console.WriteLine($"Book: {book.Title}, Price: {book.Price:C}");
    }

    public void Visit(Movie movie)
    {
        Console.WriteLine($"Movie: {movie.Title}, Price: {movie.Price:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create the items
        IElement book = new Book("Design Patterns", 50.0);
        IElement movie = new Movie("Inception", 30.0);

        // Create visitors
        IVisitor taxCalculator = new TaxCalculatorVisitor();
        IVisitor displayDetails = new DisplayDetailsVisitor();

        // Apply the visitors
        Console.WriteLine("Item Details:");
        book.Accept(displayDetails);
        movie.Accept(displayDetails);

        Console.WriteLine("\nTax Calculation:");
        book.Accept(taxCalculator);
        movie.Accept(taxCalculator);
    }
}