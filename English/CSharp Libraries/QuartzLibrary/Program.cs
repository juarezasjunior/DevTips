using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

public class ExampleTask : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine($"Task executed at: {DateTime.Now}");
        return Task.CompletedTask;
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Creating a task scheduler
        IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
        await scheduler.Start();

        // Defining the job to be scheduled
        IJobDetail job = JobBuilder.Create<ExampleTask>()
            .WithIdentity("exampleTask", "group1")
            .Build();

        // Creating a cron trigger to execute the task every minute
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("triggerExample", "group1")
            .StartNow()
            .WithCronSchedule("0 * * ? * *") // Executes every minute
            .Build();

        // Scheduling the job
        await scheduler.ScheduleJob(job, trigger);

        Console.WriteLine("Task scheduled. Press Enter to exit...");
        Console.ReadLine();

        await scheduler.Shutdown();
    }
}