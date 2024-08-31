using System;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main()
    {
        var nomeProduto = "Caneta";

        // Tentativa de logar uma mensagem curta
        LogMessage($"Produto: {nomeProduto}");

        // Tentativa de logar uma mensagem que resultará em mais de 10 caracteres
        LogMessage($"O nome do produto é {nomeProduto}");

        Console.ReadKey();
    }

    public static void LogMessage(MaxLengthLogHandler handler)
    {
        if (handler.IsEnabled)
        {
            Console.WriteLine(handler.GetContent());
        }
    }
}

[InterpolatedStringHandler]
public ref struct MaxLengthLogHandler
{
    private readonly bool _isEnabled;
    private string _message;

    public bool IsEnabled => _isEnabled;

    public MaxLengthLogHandler(int literalLength, int formattedCount)
    {
        // Permite logar apenas se a mensagem resultante tiver 10 caracteres ou menos
        _isEnabled = literalLength <= 10;
        _message = string.Empty;
    }

    // Você poderia manipular os literais aqui
    // Literal é o texto: "Produto: " ou "O nome do produto é "
    public void AppendLiteral(string literal) => _message += literal;

    // Você poderia manipular os valores formatados aqui
    // Valor formatado é o valor da variável: nomeProduto
    public void AppendFormatted<T>(T valor) => _message += valor?.ToString();

    public string GetContent() => _message.Length <= 15 ? _message : string.Empty;
}

