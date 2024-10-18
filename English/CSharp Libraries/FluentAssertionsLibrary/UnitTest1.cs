using FluentAssertions;
using Xunit;

namespace FluentAssertionsExample
{
    public class ProductTests
    {
        [Fact]
        public void Product_ShouldHaveCorrectValues()
        {
            // Arrange: Creating a Product object
            var product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 3500.99M
            };

            // Act & Assert: Using FluentAssertions to validate the values
            product.Id.Should().Be(1);
            product.Name.Should().Be("Laptop");
            product.Price.Should().Be(3500.99M);
        }

        [Fact]
        public void Product_ShouldThrowExceptionForInvalidPrice()
        {
            // Arrange
            var product = new Product();

            // Act
            Action action = () => product.SetPrice(-10);

            // Assert: Using FluentAssertions to check for the exception
            action.Should().Throw<ArgumentException>()
                .WithMessage("Price must be greater than zero");
        }
    }

    // Product class used in the tests
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero");
            Price = price;
        }
    }
}