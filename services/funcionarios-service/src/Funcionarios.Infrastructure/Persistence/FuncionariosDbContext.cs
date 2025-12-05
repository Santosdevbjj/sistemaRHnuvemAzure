using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.Infrastructure.Persistence;

public class FuncionariosDbContext : DbContext
{
    public FuncionariosDbContext(DbContextOptions<FuncionariosDbContext> options) : base(options) { }

    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<EnderecoFuncionario> Enderecos => Set<EnderecoFuncionario>();
    public DbSet<Cargo> Cargos => Set<Cargo>();
    public DbSet<Departamento> Departamentos => Set<Departamento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.NomeCompleto).IsRequired().HasMaxLength(200);
            e.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            e.HasIndex(x => x.CPF).IsUnique();
            e.Property(x => x.SalarioBase).HasColumnType("decimal(18,2)");
            e.HasMany(x => x.Enderecos).WithOne().HasForeignKey(x => x.IdFuncionario).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EnderecoFuncionario>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Tipo).IsRequired().HasMaxLength(30);
            e.Property(x => x.Logradouro).IsRequired().HasMaxLength(200);
            e.Property(x => x.Estado).HasMaxLength(2);
            e.Property(x => x.CEP).HasMaxLength(8);
        });

        modelBuilder.Entity<Cargo>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Nome).IsRequired().HasMaxLength(120);
        });

        modelBuilder.Entity<Departamento>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Nome).IsRequired().HasMaxLength(120);
        });
    }
}
