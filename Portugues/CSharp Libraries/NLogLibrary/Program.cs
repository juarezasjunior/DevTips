using NLog;
using System;

namespace NLogExemplo
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            // Configurando NLog
            var config = new NLog.Config.LoggingConfiguration();

            // Destino: arquivo
            var logArquivo = new NLog.Targets.FileTarget("logArquivo") { FileName = "log.txt" };

            // Regras de logging
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logArquivo);

            // Aplicando a configuração
            LogManager.Configuration = config;

            // Exemplo de logs
            logger.Info("A aplicação começou.");
            logger.Warn("Este é um aviso.");
            logger.Error("Um erro ocorreu.");

            Console.WriteLine("Logs gerados. Verifique o arquivo log.txt.");
        }
    }
}