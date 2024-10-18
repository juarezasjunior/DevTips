using AutoFixture;
using System;

namespace AutoFixtureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of the AutoFixture generator
            var fixture = new Fixture();

            // Generating a filled instance of the Order class
            var order = fixture.Create<Order>();

            // Displaying the automatically generated data
            Console.WriteLine($"Order Id: {order.Id}, Total Value: {order.TotalValue}, Customer: {order.Customer.Name}");
        }
    }

    // Order class
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalValue { get; set; }
        public Customer Customer { get; set; }
    }

    // Customer class
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}