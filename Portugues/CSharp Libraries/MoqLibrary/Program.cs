using Moq;
using System;
using Xunit;

// Interface que será mockada
public interface ICalculadora
{
    int Somar(int a, int b);
}

// Classe que utiliza a interface
public class Operacoes
{
    private readonly ICalculadora _calculadora;

    public Operacoes(ICalculadora calculadora)
    {
        _calculadora = calculadora;
    }

    public int ExecutarSoma(int a, int b)
    {
        return _calculadora.Somar(a, b);
    }
}

public class OperacoesTests
{
    [Fact]
    public void ExecutarSoma_DeveRetornarSomaCorreta()
    {
        // Criando o mock da interface ICalculadora
        var mockCalculadora = new Mock<ICalculadora>();

        // Definindo o comportamento esperado para o método Somar
        mockCalculadora.Setup(c => c.Somar(2, 3)).Returns(5);

        // Usando o mock na classe Operacoes
        var operacoes = new Operacoes(mockCalculadora.Object);
        var resultado = operacoes.ExecutarSoma(2, 3);

        // Verificando se o resultado é o esperado
        Assert.Equal(5, resultado);

        // Verificando se o método Somar foi chamado exatamente uma vez
        mockCalculadora.Verify(c => c.Somar(2, 3), Times.Once);
    }
}