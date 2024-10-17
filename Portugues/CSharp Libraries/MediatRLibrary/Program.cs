using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

// Definindo o comando
public class SaudarCommand : IRequest<string>
{
    public string Nome { get; set; }
}

// Definindo o manipulador para o comando
public class SaudarCommandHandler : IRequestHandler<SaudarCommand, string>
{
    public Task<string> Handle(SaudarCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"Olá, {request.Nome}!");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Configurando o MediatR com injeção de dependência
        var services = new ServiceCollection();
        services.AddMediatR(typeof(Program));
        var provider = services.BuildServiceProvider();

        var mediator = provider.GetRequiredService<IMediator>();

        // Enviando o comando e recebendo a resposta
        var resultado = await mediator.Send(new SaudarCommand { Nome = "Desenvolvedor" });
        Console.WriteLine(resultado);
    }
}