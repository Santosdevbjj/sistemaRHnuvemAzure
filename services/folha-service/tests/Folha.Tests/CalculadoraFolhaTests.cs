using Folha.Domain.Services;
using FluentAssertions;
using Xunit;

public class CalculadoraFolhaTests
{
    [Fact]
    public void ValorHora_DeveDividirPor220()
    {
        var calc = new CalculadoraFolha();
        calc.ValorHora(2200m).Should().Be(10.00m);
    }

    [Theory]
    [InlineData(10, 12)]
    public void ValorHoraNoturna_DeveAdicionar20PorCento(decimal valorHora, decimal esperado)
    {
        var calc = new CalculadoraFolha();
        calc.ValorHoraNoturna(valorHora).Should().Be(esperado);
    }
}
