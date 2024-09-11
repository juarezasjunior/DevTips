public record Documento(int Id, DateTime Data);

public record Fatura(int Id, DateTime Data, decimal Valor) : Documento(Id, Data);

public record Recibo(int Id, DateTime Data, string Pagador) : Documento(Id, Data);

public class Program
{
    public static void Main()
    {
        Fatura fatura = new(1, DateTime.Now, 150.00m);
        Recibo recibo = new(2, DateTime.Now, "João");

        Console.WriteLine(fatura); // Exibe: Fatura { Id = 1, Data = ..., Valor = 150.00 }
        Console.WriteLine(recibo); // Exibe: Recibo { Id = 2, Data = ..., Pagador = João }
    }
}