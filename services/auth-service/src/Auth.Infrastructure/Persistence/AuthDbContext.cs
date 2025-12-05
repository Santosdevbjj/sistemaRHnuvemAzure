using Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Persistence;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
    public DbSet<UsuarioSistema> UsuariosSistema => Set<UsuarioSistema>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsuarioSistema>(e =>
        {
            e.HasKey(x => x.UsuarioId);
            e.Property(x => x.Username).IsRequired().HasMaxLength(150);
            e.HasIndex(x => x.Username).IsUnique();
            e.Property(x => x.SenhaHash).IsRequired().HasMaxLength(500);
            e.Property(x => x.PerfilAcesso).IsRequired().HasMaxLength(50);
        });
    }
}
