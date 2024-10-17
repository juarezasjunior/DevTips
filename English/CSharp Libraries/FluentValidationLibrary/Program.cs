using FluentValidation;
using System;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        // Defining validation rules
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("The product name is required.")
            .Length(3, 50).WithMessage("The product name must be between 3 and 50 characters.");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("The price must be greater than zero.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a sample product
        var product = new Product { Name = "Laptop", Price = -10 };

        // Validating the product
        var validator = new ProductValidator();
        var results = validator.Validate(product);

        if (!results.IsValid)
        {
            foreach (var error in results.Errors)
            {
                Console.WriteLine($"Error: {error.ErrorMessage}");
            }
        }
        else
        {
            Console.WriteLine("Product is valid!");
        }
    }
}