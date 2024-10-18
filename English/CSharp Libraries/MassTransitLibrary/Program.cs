using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassTransitExample
{
    // Defining the message
    public class OrderCreated
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
    }

    // Defining the message consumer
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        public Task Consume(ConsumeContext<OrderCreated> context)
        {
            Console.WriteLine($"Order received: {context.Message.Id} at {context.Message.Date}");
            return Task.CompletedTask;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Configuring MassTransit with RabbitMQ
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                // Configuring the consumer
                cfg.ReceiveEndpoint("order_queue", e =>
                {
                    e.Consumer<OrderCreatedConsumer>();
                });
            });

            // Starting the bus
            await busControl.StartAsync();

            try
            {
                // Publishing a message
                var order = new OrderCreated { Id = Guid.NewGuid().ToString(), Date = DateTime.Now };
                await busControl.Publish(order);

                Console.WriteLine("Order published.");
                Console.ReadLine();
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}