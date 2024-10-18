using Bogus;
using System;
using System.Collections.Generic;

namespace BogusExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fake data generator for the Person class
            var faker = new Faker<Person>()
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Age, f => f.Random.Int(18, 60))
                .RuleFor(p => p.Address, f => f.Address.FullAddress());

            // Generating a list of 5 people
            var people = faker.Generate(5);

            // Displaying the generated data in the console
            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Email: {person.Email}, Age: {person.Age}, Address: {person.Address}");
            }
        }
    }

    // Class to represent a person
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
}