using JornadaEscala.Domain.Entities;
using JornadaEscala.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JornadaEscala.Api.Endpoints
{
    public static class JornadaEndpoints
    {
        public static void MapJornadaEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/jornada", async (JornadaDbContext db) =>
            {
                var jornadas = await db.Jornadas.ToListAsync();
                return Results.Ok(jornadas);
            });

            app.MapGet("/jornada/{id:int}", async (int id, JornadaDbContext db) =>
            {
                var jornada = await db.Jornadas.FindAsync(id);
                return jornada is null ? Results.NotFound() : Results.Ok(jornada);
            });

            app.MapPost("/jornada", async (JornadaTrabalho input, JornadaDbContext db) =>
            {
                db.Jornadas.Add(input);
                await db.SaveChangesAsync();
                return Results.Created($"/jornada/{input.Id}", input);
            });

            app.MapPut("/jornada/{id:int}", async (int id, JornadaTrabalho input, JornadaDbContext db) =>
            {
                var jornada = await db.Jornadas.FindAsync(id);
                if (jornada is null) return Results.NotFound();

                jornada.Nome = input.Nome;
                jornada.HoraEntrada = input.HoraEntrada;
                jornada.HoraSaida = input.HoraSaida;
                jornada.DuracaoIntervaloMin = input.DuracaoIntervaloMin;
                jornada.PermiteHorarioNoturno = input.PermiteHorarioNoturno;

                await db.SaveChangesAsync();
                return Results.Ok(jornada);
            });

            app.MapDelete("/jornada/{id:int}", async (int id, JornadaDbContext db) =>
            {
                var jornada = await db.Jornadas.FindAsync(id);
                if (jornada is null) return Results.NotFound();

                db.Jornadas.Remove(jornada);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
