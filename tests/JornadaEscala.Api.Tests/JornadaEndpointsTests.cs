using JornadaEscala.Api.Endpoints;
using JornadaEscala.Domain.Entities;
using JornadaEscala.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using Xunit;

namespace JornadaEscala.Api.Tests
{
    public class JornadaEndpointsTests
    {
        private JornadaDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<JornadaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new JornadaDbContext(options);
        }

        [Fact]
        public async Task Deve_Criar_Jornada()
        {
            var db = GetDbContext();
            var jornada = new JornadaTrabalho
            {
                Nome = "Teste Jornada",
                HoraEntrada = new TimeSpan(8, 0, 0),
                HoraSaida = new TimeSpan(14, 0, 0),
                DuracaoIntervaloMin = 15,
                PermiteHorarioNoturno = false
            };

            db.Jornadas.Add(jornada);
            await db.SaveChangesAsync();

            var result = await db.Jornadas.FirstOrDefaultAsync(x => x.Nome == "Teste Jornada");
            result.Should().NotBeNull();
            result!.HoraEntrada.Should().Be(new TimeSpan(8, 0, 0));
        }

        [Fact]
        public async Task Deve_Atualizar_Jornada()
        {
            var db = GetDbContext();
            var jornada = new JornadaTrabalho
            {
                Nome = "Original",
                HoraEntrada = new TimeSpan(7, 0, 0),
                HoraSaida = new TimeSpan(13, 0, 0),
                DuracaoIntervaloMin = 15
            };
            db.Jornadas.Add(jornada);
            await db.SaveChangesAsync();

            jornada.Nome = "Atualizado";
            await db.SaveChangesAsync();

            var result = await db.Jornadas.FirstOrDefaultAsync(x => x.Id == jornada.Id);
            result!.Nome.Should().Be("Atualizado");
        }

        [Fact]
        public async Task Deve_Deletar_Jornada()
        {
            var db = GetDbContext();
            var jornada = new JornadaTrabalho
            {
                Nome = "Deletar",
                HoraEntrada = new TimeSpan(9, 0, 0),
                HoraSaida = new TimeSpan(15, 0, 0),
                DuracaoIntervaloMin = 15
            };
            db.Jornadas.Add(jornada);
            await db.SaveChangesAsync();

            db.Jornadas.Remove(jornada);
            await db.SaveChangesAsync();

            var result = await db.Jornadas.FirstOrDefaultAsync(x => x.Id == jornada.Id);
            result.Should().BeNull();
        }
    }
}
