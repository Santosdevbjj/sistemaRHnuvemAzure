using JornadaEscala.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaEscala.Infrastructure.Configurations
{
    /// <summary>
    /// Configuração da entidade JornadaTrabalho para o EF Core.
    /// Define chaves, propriedades, restrições e valores padrão.
    /// </summary>
    public class JornadaTrabalhoConfig : IEntityTypeConfiguration<JornadaTrabalho>
    {
        public void Configure(EntityTypeBuilder<JornadaTrabalho> builder)
        {
            // Nome da tabela
            builder.ToTable("JornadaTrabalho");

            // Chave primária
            builder.HasKey(j => j.Id);

            // Propriedades obrigatórias
            builder.Property(j => j.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(j => j.HoraEntrada)
                   .IsRequired();

            builder.Property(j => j.HoraSaida)
                   .IsRequired();

            builder.Property(j => j.DuracaoIntervaloMin)
                   .IsRequired();

            // Valor padrão para PermiteHorarioNoturno
            builder.Property(j => j.PermiteHorarioNoturno)
                   .HasDefaultValue(false);
        }
    }
}
