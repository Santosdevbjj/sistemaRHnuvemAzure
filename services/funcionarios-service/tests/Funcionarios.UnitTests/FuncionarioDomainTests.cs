using Funcionarios.Domain.Entities;
using FluentAssertions;
using Xunit;

public class FuncionarioDomainTests
{
    [Fact]
    public void CriarFuncionario_DeveSerAtivoPorPadrao()
    {
        var f = new Funcionario { NomeCompleto = "Teste", CPF = "12345678901", DataAdmissao = DateTime.UtcNow, IdCargo = 1, IdDepartamento = 1, SalarioBase = 1000m };
        f.Situacao.Should().Be("ATIVO");
    }
}
