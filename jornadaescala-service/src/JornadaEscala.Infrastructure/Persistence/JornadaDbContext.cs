using JornadaEscala.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        /// <summary>
        /// Aplica todas as configurações e seeds de forma centralizada.
        /// </summary>
        /// <param name="modelBuilder">Instância do ModelBuilder do EF Core.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityConfigurations.ApplyAll(modelBuilder);
        }
    }
}
