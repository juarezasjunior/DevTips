// Produto abstrato 1
public abstract class Carro
{
    public abstract void ExibirDetalhes();
}

// Produto concreto 1A
public class Sedan : Carro
{
    public override void ExibirDetalhes()
    {
        Console.WriteLine("Carro Sedan");
    }
}

// Produto concreto 1B
public class SUV : Carro
{
    public override void ExibirDetalhes()
    {
        Console.WriteLine("Carro SUV");
    }
}

// Produto abstrato 2
public abstract class Motor
{
    public abstract void ExibirTipo();
}

// Produto concreto 2A
public class MotorCombustao : Motor
{
    public override void ExibirTipo()
    {
        Console.WriteLine("Motor a combustão");
    }
}

// Produto concreto 2B
public class MotorEletrico : Motor
{
    public override void ExibirTipo()
    {
        Console.WriteLine("Motor elétrico");
    }
}

// Fábrica abstrata
public abstract class VeiculoFactory
{
    public abstract Carro CriarCarro();
    public abstract Motor CriarMotor();
}

// Fábrica concreta 1
public class SedanCombustaoFactory : VeiculoFactory
{
    public override Carro CriarCarro()
    {
        return new Sedan();
    }

    public override Motor CriarMotor()
    {
        return new MotorCombustao();
    }
}

// Fábrica concreta 2
public class SUVEletricoFactory : VeiculoFactory
{
    public override Carro CriarCarro()
    {
        return new SUV();
    }

    public override Motor CriarMotor()
    {
        return new MotorEletrico();
    }
}

class Program
{
    static void Main(string[] args)
    {
        VeiculoFactory factory = new SedanCombustaoFactory();
        Carro carro = factory.CriarCarro();
        Motor motor = factory.CriarMotor();

        carro.ExibirDetalhes(); // Saída: Carro Sedan
        motor.ExibirTipo();     // Saída: Motor a combustão

        factory = new SUVEletricoFactory();
        carro = factory.CriarCarro();
        motor = factory.CriarMotor();

        carro.ExibirDetalhes(); // Saída: Carro SUV
        motor.ExibirTipo();     // Saída: Motor elétrico
    }
}