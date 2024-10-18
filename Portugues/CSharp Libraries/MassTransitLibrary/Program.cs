using MassTransit;
using System;
using System.Threading.Tasks;

namespace MassTransitExemplo
{
    // Definindo a mensagem
    public class PedidoCriado
    {
        public string Id { get; set; }
        public DateTime Data { get; set; }
    }

    // Definindo o consumidor da mensagem
    public class PedidoCriadoConsumer : IConsumer<PedidoCriado>
    {
        public Task Consume(ConsumeContext<PedidoCriado> context)
        {
            Console.WriteLine($"Pedido recebido: {context.Message.Id} em {context.Message.Data}");
            return Task.CompletedTask;
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Configurando o MassTransit com RabbitMQ
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host("rabbitmq://localhost", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                // Configurando o consumidor
                cfg.ReceiveEndpoint("pedido_queue", e =>
                {
                    e.Consumer<PedidoCriadoConsumer>();
                });
            });

            // Iniciando o bus
            await busControl.StartAsync();

            try
            {
                // Publicando uma mensagem
                var pedido = new PedidoCriado { Id = Guid.NewGuid().ToString(), Data = DateTime.Now };
                await busControl.Publish(pedido);

                Console.WriteLine("Pedido publicado.");
                Console.ReadLine();
            }
            finally
            {
                await busControl.StopAsync();
            }
        }
    }
}