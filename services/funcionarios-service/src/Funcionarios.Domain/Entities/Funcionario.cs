namespace Funcionarios.Domain.Entities;

public class Funcionario
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = default!;
    public string CPF { get; set; } = default!;
    public string? RG { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime? DataDemissao { get; set; }
    public decimal SalarioBase { get; set; }
    public int IdCargo { get; set; }
    public int IdDepartamento { get; set; }
    public string Situacao { get; set; } = "ATIVO";
    public List<EnderecoFuncionario> Enderecos { get; set; } = new();
}
