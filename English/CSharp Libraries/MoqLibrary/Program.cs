using Moq;
using System;
using Xunit;

// Interface to be mocked
public interface ICalculator
{
    int Add(int a, int b);
}

// Class that uses the interface
public class Operations
{
    private readonly ICalculator _calculator;

    public Operations(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public int ExecuteSum(int a, int b)
    {
        return _calculator.Add(a, b);
    }
}

public class OperationsTests
{
    [Fact]
    public void ExecuteSum_ShouldReturnCorrectSum()
    {
        // Creating the mock for the ICalculator interface
        var mockCalculator = new Mock<ICalculator>();

        // Defining the expected behavior for the Add method
        mockCalculator.Setup(c => c.Add(2, 3)).Returns(5);

        // Using the mock in the Operations class
        var operations = new Operations(mockCalculator.Object);
        var result = operations.ExecuteSum(2, 3);

        // Verifying if the result is as expected
        Assert.Equal(5, result);

        // Verifying if the Add method was called exactly once
        mockCalculator.Verify(c => c.Add(2, 3), Times.Once);
    }
}