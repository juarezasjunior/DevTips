// Interface for expressions
public interface IExpression
{
    int Interpret();
}

// Expression for numbers
public class Number : IExpression
{
    private int _value;

    public Number(int value)
    {
        _value = value;
    }

    public int Interpret()
    {
        return _value;
    }
}

// Expression for addition
public class Addition : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public Addition(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret()
    {
        return _left.Interpret() + _right.Interpret();
    }
}

// Expression for subtraction
public class Subtraction : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public Subtraction(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret()
    {
        return _left.Interpret() - _right.Interpret();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create expressions: (10 + 5) - 3
        IExpression expression = new Subtraction(
            new Addition(new Number(10), new Number(5)),
            new Number(3)
        );

        // Interpret and display the result
        int result = expression.Interpret();
        Console.WriteLine($"Result of the expression: {result}"); // Output: Result of the expression: 12
    }
}