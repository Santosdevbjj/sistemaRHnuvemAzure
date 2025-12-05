using JornadaEscala.Domain.Entities;
using Microsoft.EntityFrameworkCore;

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // Aplica configurações separadas
    modelBuilder.ApplyConfiguration(new JornadaTrabalhoConfig());
    modelBuilder.ApplyConfiguration(new EscalaTrabalhoConfig());
    modelBuilder.ApplyConfiguration(new RegistroPontoConfig());

    // Seeds de JornadaTrabalho
    JornadaSeeds.Seed(modelBuilder);
}
namespace JornadaEscala.Infrastructure.Persistence
{
    /// <summary>
    /// DbContext responsável pelo serviço de Jornada e Escala.
    /// Inclui entidades de JornadaTrabalho, EscalaTrabalho e RegistroPonto.
    /// </summary>
    public class JornadaDbContext : DbContext
    {
        public JornadaDbContext(DbContextOptions<JornadaDbContext> options) : base(options) { }

        // DbSets principais
        public DbSet<JornadaTrabalho> Jornadas { get; set; } = default!;
        public DbSet<EscalaTrabalho> Escalas { get; set; } = default!;
        public DbSet<RegistroPonto> RegistrosPonto { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade JornadaTrabalho
            modelBuilder.Entity<JornadaTrabalho>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Nome).IsRequired().HasMaxLength(100);
                e.Property(x => x.HoraEntrada).IsRequired();
                e.Property(x => x.HoraSaida).IsRequired();
                e.Property(x => x.DuracaoIntervaloMin).IsRequired();
                e.Property(x => x.PermiteHorarioNoturno).HasDefaultValue(false);
            });

            // Configuração da entidade EscalaTrabalho
            modelBuilder.Entity<EscalaTrabalho>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.DiaSemana).IsRequired();
                e.HasIndex(x => new { x.IdFuncionario, x.DiaSemana }).IsUnique();
            });

            // Configuração da entidade RegistroPonto
            modelBuilder.Entity<RegistroPonto>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.DataHora).IsRequired();
                e.Property(x => x.Tipo).IsRequired().HasMaxLength(20);
                e.Property(x => x.Origem).HasMaxLength(50).HasDefaultValue("SISTEMA");
                e.HasIndex(x => x.IdFuncionario);
                e.HasIndex(x => x.DataHora);
            });

            // Chamada para popular os seeds de JornadaTrabalho
            JornadaSeeds.Seed(modelBuilder);
        }
    }
}
