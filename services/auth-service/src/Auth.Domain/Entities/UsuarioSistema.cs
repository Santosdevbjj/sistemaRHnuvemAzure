namespace Auth.Domain.Entities;

public class UsuarioSistema
{
    public int UsuarioId { get; set; }
    public int? FuncionarioId { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string SenhaHash { get; set; } = default!;
    public string PerfilAcesso { get; set; } = "Colaborador"; // Admin, RH, Gestor, Colaborador
    public bool Ativo { get; set; } = true;
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}
