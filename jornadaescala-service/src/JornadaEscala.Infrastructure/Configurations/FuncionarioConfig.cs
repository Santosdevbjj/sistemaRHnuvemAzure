using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaEscala.Infrastructure.Configurations
{
    /// <summary>
    /// Configuração da entidade Funcionario para o EF Core.
    /// Define chaves, propriedades, índices e relacionamentos.
    /// </summary>
    public class FuncionarioConfig : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            // Nome da tabela
            builder.ToTable("Funcionario");

            // Chave primária
            builder.HasKey(f => f.Id);

            // Propriedades obrigatórias
            builder.Property(f => f.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(f => f.CPF)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.HasIndex(f => f.CPF)
                   .IsUnique();

            builder.Property(f => f.RG)
                   .HasMaxLength(20);

            builder.Property(f => f.Email)
                   .HasMaxLength(200);

            builder.Property(f => f.Telefone)
                   .HasMaxLength(20);

            builder.Property(f => f.SalarioBase)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(f => f.Situacao)
                   .HasMaxLength(20)
                   .HasDefaultValue("ATIVO");

            // Relacionamentos
            builder.HasOne<Cargo>()
                   .WithMany()
                   .HasForeignKey(f => f.IdCargo)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Departamento>()
                   .WithMany()
                   .HasForeignKey(f => f.IdDepartamento)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.Enderecos)
                   .WithOne()
                   .HasForeignKey(e => e.IdFuncionario)
                   .OnDelete(DeleteBehavior.Cascade);

            // Índices adicionais recomendados
            builder.HasIndex(f => f.IdCargo);
            builder.HasIndex(f => f.IdDepartamento);
        }
    }
}
