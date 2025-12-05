using JornadaEscala.Domain.Entities;
using JornadaEscala.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Xunit;

namespace JornadaEscala.Api.Tests
{
    public class PontoEndpointsTests
    {
        private JornadaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<JornadaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new JornadaDbContext(options);
        }

        [Fact]
        public async Task Deve_Criar_RegistroPonto()
        {
            var db = GetDbContext();
            var ponto = new RegistroPonto
            {
                IdFuncionario = 1,
                DataHora = DateTime.UtcNow,
                Tipo = "Entrada",
                Origem = "SISTEMA"
            };

            db.RegistrosPonto.Add(ponto);
            await db.SaveChangesAsync();

            var result = await db.RegistrosPonto.FirstOrDefaultAsync(x => x.IdFuncionario == 1);
            result.Should().NotBeNull();
            result!.Tipo.Should().Be("Entrada");
        }

        [Fact]
        public async Task Deve_Atualizar_RegistroPonto()
        {
            var db = GetDbContext();
            var ponto = new RegistroPonto
            {
                IdFuncionario = 1,
                DataHora = DateTime.UtcNow,
                Tipo = "Entrada"
            };
            db.RegistrosPonto.Add(ponto);
            await db.SaveChangesAsync();

            ponto.Tipo = "Saída";
            await db.SaveChangesAsync();

            var result = await db.RegistrosPonto.FirstOrDefaultAsync(x => x.Id == ponto.Id);
            result!.Tipo.Should().Be("Saída");
        }

        [Fact]
        public async Task Deve_Deletar_RegistroPonto()
        {
            var db = GetDbContext();
            var ponto = new RegistroPonto
            {
                IdFuncionario = 1,
                DataHora = DateTime.UtcNow,
                Tipo = "Entrada"
            };
            db.RegistrosPonto.Add(ponto);
            await db.SaveChangesAsync();

            db.RegistrosPonto.Remove(ponto);
            await db.SaveChangesAsync();

            var result = await db.RegistrosPonto.FirstOrDefaultAsync(x => x.Id == ponto.Id);
            result.Should().BeNull();
        }
    }
}
