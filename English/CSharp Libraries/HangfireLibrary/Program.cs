using Hangfire;
using Hangfire.MemoryStorage;
using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Configuring Hangfire with in-memory storage
        GlobalConfiguration.Configuration.UseMemoryStorage();

        using (var server = new BackgroundJobServer())
        {
            // Scheduling a job for immediate execution
            BackgroundJob.Enqueue(() => BackgroundTask());

            // Scheduling a recurring job (executed every minute)
            RecurringJob.AddOrUpdate("recurring-task", () => RecurringTask(), Cron.Minutely);

            Console.WriteLine("Jobs scheduled. Press Enter to exit...");
            Console.ReadLine();
        }
    }

    // Task that will run in the background
    public static void BackgroundTask()
    {
        Console.WriteLine("Background task executed.");
    }

    // Recurring task
    public static void RecurringTask()
    {
        Console.WriteLine("Recurring task executed.");
    }
}