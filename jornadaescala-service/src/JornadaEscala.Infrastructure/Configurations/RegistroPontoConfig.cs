using JornadaEscala.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaEscala.Infrastructure.Configurations
{
    /// <summary>
    /// Configuração da entidade RegistroPonto para o EF Core.
    /// Define chaves, índices e restrições de propriedades.
    /// </summary>
    public class RegistroPontoConfig : IEntityTypeConfiguration<RegistroPonto>
    {
        public void Configure(EntityTypeBuilder<RegistroPonto> builder)
        {
            // Nome da tabela
            builder.ToTable("RegistroPonto");

            // Chave primária
            builder.HasKey(r => r.Id);

            // Propriedades obrigatórias
            builder.Property(r => r.DataHora)
                   .IsRequired();

            builder.Property(r => r.Tipo)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(r => r.Origem)
                   .HasMaxLength(50)
                   .HasDefaultValue("SISTEMA");

            // Índices para otimizar consultas
            builder.HasIndex(r => r.IdFuncionario);
            builder.HasIndex(r => r.DataHora);

            // Relacionamento com Funcionario
            builder.HasOne<Funcionario>()
                   .WithMany()
                   .HasForeignKey(r => r.IdFuncionario)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
