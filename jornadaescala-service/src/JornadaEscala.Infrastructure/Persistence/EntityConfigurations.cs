using JornadaEscala.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JornadaEscala.Infrastructure.Persistence
{
    /// <summary>
    /// Classe utilitária para aplicar todas as configurações de entidades
    /// e seeds de forma centralizada no DbContext.
    /// </summary>
    public static class EntityConfigurations
    {
        /// <summary>
        /// Aplica todas as configurações de entidades do domínio Jornada/Escala/Funcionários.
        /// </summary>
        /// <param name="modelBuilder">Instância do ModelBuilder do EF Core.</param>
        public static void ApplyAll(ModelBuilder modelBuilder)
        {
            // Configurações de entidades
            modelBuilder.ApplyConfiguration(new FuncionarioConfig());
            modelBuilder.ApplyConfiguration(new EnderecoFuncionarioConfig());
            modelBuilder.ApplyConfiguration(new JornadaTrabalhoConfig());
            modelBuilder.ApplyConfiguration(new EscalaTrabalhoConfig());
            modelBuilder.ApplyConfiguration(new RegistroPontoConfig());

            // Seeds de JornadaTrabalho
            JornadaSeeds.Seed(modelBuilder);
        }
    }
}
