using Serilog;
using System;

namespace SerilogExemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configurando o Serilog para registrar logs em um arquivo
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("serilog-log.txt")
                .CreateLogger();

            // Exemplos de logs
            Log.Information("A aplicação começou.");
            Log.Warning("Este é um aviso.");
            Log.Error("Um erro ocorreu no processo.");

            Console.WriteLine("Logs gerados. Verifique o arquivo serilog-log.txt.");

            // Encerrando o logger
            Log.CloseAndFlush();
        }
    }
}