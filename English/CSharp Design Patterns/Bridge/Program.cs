// Interface for colors
public interface IColor
{
    void ApplyColor();
}

// Implementation for the red color
public class Red : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Applying red color.");
    }
}

// Implementation for the blue color
public class Blue : IColor
{
    public void ApplyColor()
    {
        Console.WriteLine("Applying blue color.");
    }
}

// Shape abstraction
public abstract class Shape
{
    protected IColor color;

    protected Shape(IColor color)
    {
        this.color = color;
    }

    public abstract void Draw();
}

// Circle implementation
public class Circle : Shape
{
    public Circle(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.WriteLine("Drawing a circle.");
        color.ApplyColor();
    }
}

// Square implementation
public class Square : Shape
{
    public Square(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.WriteLine("Drawing a square.");
        color.ApplyColor();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Drawing a red circle
        Shape redCircle = new Circle(new Red());
        redCircle.Draw();  // Output: Drawing a circle. Applying red color.

        // Drawing a blue square
        Shape blueSquare = new Square(new Blue());
        blueSquare.Draw();  // Output: Drawing a square. Applying blue color.
    }
}