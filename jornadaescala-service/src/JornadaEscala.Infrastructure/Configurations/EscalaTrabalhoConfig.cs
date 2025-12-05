using JornadaEscala.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaEscala.Infrastructure.Configurations
{
    /// <summary>
    /// Configuração da entidade EscalaTrabalho para o EF Core.
    /// Define chaves, índices e relacionamentos.
    /// </summary>
    public class EscalaTrabalhoConfig : IEntityTypeConfiguration<EscalaTrabalho>
    {
        public void Configure(EntityTypeBuilder<EscalaTrabalho> builder)
        {
            // Nome da tabela
            builder.ToTable("EscalaTrabalho");

            // Chave primária
            builder.HasKey(e => e.Id);

            // Propriedades obrigatórias
            builder.Property(e => e.DiaSemana)
                   .IsRequired();

            // Índice único para evitar duplicidade de escala por funcionário/dia
            builder.HasIndex(e => new { e.IdFuncionario, e.DiaSemana })
                   .IsUnique();

            // Relacionamentos
            builder.HasOne<JornadaTrabalho>()
                   .WithMany()
                   .HasForeignKey(e => e.IdJornada)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Funcionario>()
                   .WithMany()
                   .HasForeignKey(e => e.IdFuncionario)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
