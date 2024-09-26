// Interface para as cores
public interface ICor
{
    void AplicarCor();
}

// Implementação para a cor vermelha
public class Vermelho : ICor
{
    public void AplicarCor()
    {
        Console.WriteLine("Aplicando a cor vermelha.");
    }
}

// Implementação para a cor azul
public class Azul : ICor
{
    public void AplicarCor()
    {
        Console.WriteLine("Aplicando a cor azul.");
    }
}

// Abstração para as formas
public abstract class Forma
{
    protected ICor cor;

    protected Forma(ICor cor)
    {
        this.cor = cor;
    }

    public abstract void Desenhar();
}

// Implementação de um círculo
public class Circulo : Forma
{
    public Circulo(ICor cor) : base(cor) { }

    public override void Desenhar()
    {
        Console.WriteLine("Desenhando um círculo.");
        cor.AplicarCor();
    }
}

// Implementação de um quadrado
public class Quadrado : Forma
{
    public Quadrado(ICor cor) : base(cor) { }

    public override void Desenhar()
    {
        Console.WriteLine("Desenhando um quadrado.");
        cor.AplicarCor();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Desenhando um círculo vermelho
        Forma circuloVermelho = new Circulo(new Vermelho());
        circuloVermelho.Desenhar();  // Saída: Desenhando um círculo. Aplicando a cor vermelha.

        // Desenhando um quadrado azul
        Forma quadradoAzul = new Quadrado(new Azul());
        quadradoAzul.Desenhar();  // Saída: Desenhando um quadrado. Aplicando a cor azul.
    }
}