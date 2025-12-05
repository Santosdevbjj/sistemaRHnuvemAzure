using JornadaEscala.Domain.Entities;
using JornadaEscala.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Xunit;

namespace JornadaEscala.Api.Tests
{
    public class EscalaEndpointsTests
    {
        private JornadaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<JornadaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new JornadaDbContext(options);
        }

        [Fact]
        public async Task Deve_Criar_Escala()
        {
            var db = GetDbContext();
            var escala = new EscalaTrabalho
            {
                IdFuncionario = 1,
                IdJornada = 1,
                DiaSemana = 2
            };

            db.Escalas.Add(escala);
            await db.SaveChangesAsync();

            var result = await db.Escalas.FirstOrDefaultAsync(x => x.IdFuncionario == 1);
            result.Should().NotBeNull();
            result!.DiaSemana.Should().Be(2);
        }

        [Fact]
        public async Task Deve_Atualizar_Escala()
        {
            var db = GetDbContext();
            var escala = new EscalaTrabalho { IdFuncionario = 1, IdJornada = 1, DiaSemana = 2 };
            db.Escalas.Add(escala);
            await db.SaveChangesAsync();

            escala.DiaSemana = 3;
            await db.SaveChangesAsync();

            var result = await db.Escalas.FirstOrDefaultAsync(x => x.Id == escala.Id);
            result!.DiaSemana.Should().Be(3);
        }

        [Fact]
        public async Task Deve_Deletar_Escala()
        {
            var db = GetDbContext();
            var escala = new EscalaTrabalho { IdFuncionario = 1, IdJornada = 1, DiaSemana = 2 };
            db.Escalas.Add(escala);
            await db.SaveChangesAsync();

            db.Escalas.Remove(escala);
            await db.SaveChangesAsync();

            var result = await db.Escalas.FirstOrDefaultAsync(x => x.Id == escala.Id);
            result.Should().BeNull();
        }
    }
}
