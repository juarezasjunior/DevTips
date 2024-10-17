using NLog;
using System;

namespace NLogExample
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // Configuring NLog
            var config = new NLog.Config.LoggingConfiguration();

            // Target: file
            var logFile = new NLog.Targets.FileTarget("logFile") { FileName = "log.txt" };

            // Logging rules
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logFile);

            // Applying the configuration
            LogManager.Configuration = config;

            // Example logs
            logger.Info("The application has started.");
            logger.Warn("This is a warning.");
            logger.Error("An error occurred.");

            Console.WriteLine("Logs generated. Check the log.txt file.");
        }
    }
}