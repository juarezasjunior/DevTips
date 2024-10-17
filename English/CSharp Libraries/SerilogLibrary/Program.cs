using Serilog;
using System;

namespace SerilogExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuring Serilog to log to a file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("serilog-log.txt")
                .CreateLogger();

            // Example logs
            Log.Information("The application has started.");
            Log.Warning("This is a warning.");
            Log.Error("An error occurred in the process.");

            Console.WriteLine("Logs generated. Check the serilog-log.txt file.");

            // Closing the logger
            Log.CloseAndFlush();
        }
    }
}