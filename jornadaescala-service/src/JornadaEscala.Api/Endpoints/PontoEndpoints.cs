using JornadaEscala.Domain.Entities;
using JornadaEscala.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JornadaEscala.Api.Endpoints
{
    public static class PontoEndpoints
    {
        public static void MapPontoEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/ponto", async (JornadaDbContext db) =>
            {
                var registros = await db.RegistrosPonto.ToListAsync();
                return Results.Ok(registros);
            });

            app.MapGet("/ponto/{id:long}", async (long id, JornadaDbContext db) =>
            {
                var registro = await db.RegistrosPonto.FindAsync(id);
                return registro is null ? Results.NotFound() : Results.Ok(registro);
            });

            app.MapPost("/ponto", async (RegistroPonto input, JornadaDbContext db) =>
            {
                db.RegistrosPonto.Add(input);
                await db.SaveChangesAsync();
                return Results.Created($"/ponto/{input.Id}", input);
            });

            app.MapPut("/ponto/{id:long}", async (long id, RegistroPonto input, JornadaDbContext db) =>
            {
                var registro = await db.RegistrosPonto.FindAsync(id);
                if (registro is null) return Results.NotFound();

                registro.IdFuncionario = input.IdFuncionario;
                registro.DataHora = input.DataHora;
                registro.Tipo = input.Tipo;
                registro.Origem = input.Origem;

                await db.SaveChangesAsync();
                return Results.Ok(registro);
            });

            app.MapDelete("/ponto/{id:long}", async (long id, JornadaDbContext db) =>
            {
                var registro = await db.RegistrosPonto.FindAsync(id);
                if (registro is null) return Results.NotFound();

                db.RegistrosPonto.Remove(registro);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}
