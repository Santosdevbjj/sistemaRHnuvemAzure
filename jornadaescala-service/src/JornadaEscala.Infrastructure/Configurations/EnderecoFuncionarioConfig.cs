using Funcionarios.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JornadaEscala.Infrastructure.Configurations
{
    /// <summary>
    /// Configuração da entidade EnderecoFuncionario para o EF Core.
    /// Define chaves, propriedades, índices e relacionamentos.
    /// </summary>
    public class EnderecoFuncionarioConfig : IEntityTypeConfiguration<EnderecoFuncionario>
    {
        public void Configure(EntityTypeBuilder<EnderecoFuncionario> builder)
        {
            // Nome da tabela
            builder.ToTable("EnderecoFuncionario");

            // Chave primária
            builder.HasKey(e => e.Id);

            // Propriedades obrigatórias
            builder.Property(e => e.Tipo)
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(e => e.Logradouro)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.Numero)
                   .HasMaxLength(20);

            builder.Property(e => e.Complemento)
                   .HasMaxLength(200);

            builder.Property(e => e.Bairro)
                   .HasMaxLength(120);

            builder.Property(e => e.Cidade)
                   .HasMaxLength(120);

            builder.Property(e => e.Estado)
                   .HasMaxLength(2);

            builder.Property(e => e.CEP)
                   .HasMaxLength(8);

            // Relacionamento com Funcionario
            builder.HasOne<Funcionario>()
                   .WithMany(f => f.Enderecos)
                   .HasForeignKey(e => e.IdFuncionario)
                   .OnDelete(DeleteBehavior.Cascade);

            // Índice para otimizar consultas por funcionário
            builder.HasIndex(e => e.IdFuncionario);
        }
    }
}
