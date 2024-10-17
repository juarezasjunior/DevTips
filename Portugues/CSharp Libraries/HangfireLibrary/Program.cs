using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Configurando Hangfire com armazenamento em memória
        GlobalConfiguration.Configuration.UseMemoryStorage();

        using (var server = new BackgroundJobServer())
        {
            // Agendando um job para execução imediata
            BackgroundJob.Enqueue(() => TarefaEmSegundoPlano());

            // Agendando um job recorrente (executado a cada minuto)
            RecurringJob.AddOrUpdate("tarefa-recorrente", () => TarefaRecorrente(), Cron.Minutely);

            Console.WriteLine("Jobs agendados. Pressione Enter para sair...");
            Console.ReadLine();
        }
    }

    // Tarefa que será executada em segundo plano
    public static void TarefaEmSegundoPlano()
    {
        Console.WriteLine("Tarefa em segundo plano executada.");
    }

    // Tarefa recorrente
    public static void TarefaRecorrente()
    {
        Console.WriteLine("Tarefa recorrente executada.");
    }
}