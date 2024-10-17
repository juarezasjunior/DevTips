using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

public class TarefaExemplo : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"Tarefa executada em: {DateTime.Now}");
        return Task.CompletedTask;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Criando um agendador de tarefas
        IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        await scheduler.Start();

        // Definindo a tarefa que será agendada
        IJobDetail job = JobBuilder.Create<TarefaExemplo>()
            .WithIdentity("tarefaExemplo", "grupo1")
            .Build();

        // Criando um cron trigger para execução a cada minuto
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("triggerExemplo", "grupo1")
            .StartNow()
            .WithCronSchedule("0 * * ? * *") // Executa todo minuto
            .Build();

        // Agendando a tarefa
        await scheduler.ScheduleJob(job, trigger);

        Console.WriteLine("Tarefa agendada. Pressione Enter para sair...");
        Console.ReadLine();

        await scheduler.Shutdown();
    }
}