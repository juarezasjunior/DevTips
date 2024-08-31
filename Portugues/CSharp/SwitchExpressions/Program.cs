public class Program
{
    public static void Main()
    {
        int dia = 3;
        string nomeDia = dia switch
        {
            1 => "Domingo",
            2 => "Segunda-feira",
            3 => "Terça-feira",
            4 => "Quarta-feira",
            5 => "Quinta-feira",
            6 => "Sexta-feira",
            7 => "Sábado",
            _ => "Dia inválido"
        };

        Console.WriteLine($"O dia {dia} é: {nomeDia}");
    }
}


