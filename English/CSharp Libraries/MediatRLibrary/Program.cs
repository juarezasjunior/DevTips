using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

// Defining the command
public class GreetCommand : IRequest<string>
{
    public string Name { get; set; }
}

// Defining the handler for the command
public class GreetCommandHandler : IRequestHandler<GreetCommand, string>
{
    public Task<string> Handle(GreetCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"Hello, {request.Name}!");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Configuring MediatR with dependency injection
        var services = new ServiceCollection();
        services.AddMediatR(typeof(Program));
        services.AddSingleton<GreetCommandHandler>(); // Registering the handler

        var provider = services.BuildServiceProvider();

        var mediator = provider.GetRequiredService<IMediator>();

        // Sending the command and receiving the response
        var result = await mediator.Send(new GreetCommand { Name = "Developer" });
        Console.WriteLine(result);
    }
}