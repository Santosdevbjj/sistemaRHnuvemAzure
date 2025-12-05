using JornadaEscala.Domain.Entities;
using JornadaEscala.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JornadaEscala.Api.Endpoints
{
    public static class EscalaEndpoints
    {
        public static void MapEscalaEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/escala", async (JornadaDbContext db) =>
            {
                var escalas = await db.Escalas.ToListAsync();
                return Results.Ok(escalas);
            });

            app.MapGet("/escala/{id:int}", async (int id, JornadaDbContext db) =>
            {
                var escala = await db.Escalas.FindAsync(id);
                return escala is null ? Results.NotFound() : Results.Ok(escala);
            });

            app.MapPost("/escala", async (EscalaTrabalho input, JornadaDbContext db) =>
            {
                db.Escalas.Add(input);
                await db.SaveChangesAsync();
                return Results.Created($"/escala/{input.Id}", input);
            });

            app.MapPut("/escala/{id:int}", async (int id, EscalaTrabalho input, JornadaDbContext db) =>
            {
                var escala = await db.Escalas.FindAsync(id);
                if (escala is null) return Results.NotFound();

                escala.IdFuncionario = input.IdFuncionario;
                escala.IdJornada = input.IdJornada;
                escala.DiaSemana = input.DiaSemana;

                await db.SaveChangesAsync();
                return Results.Ok(escala);
            });

            app.MapDelete("/escala/{id:int}", async (int id, JornadaDbContext db) =>
            {
                var escala = await db.Escalas.FindAsync(id);
                if (escala is null) return Results.NotFound();

                db.Escalas.Remove(escala);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
