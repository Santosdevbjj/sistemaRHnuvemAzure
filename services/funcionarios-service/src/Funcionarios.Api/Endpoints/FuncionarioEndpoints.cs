using Funcionarios.Domain.Entities;
using Funcionarios.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Messaging;

namespace Funcionarios.Api.Endpoints;

public static class FuncionarioEndpoints
{
    public static void MapFuncionarioEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/funcionarios", async (FuncionariosDbContext db) =>
        {
            var list = await db.Funcionarios.Include(x => x.Enderecos).ToListAsync();
            return Results.Ok(list);
        });

        app.MapGet("/funcionarios/{id:int}", async (int id, FuncionariosDbContext db) =>
        {
            var f = await db.Funcionarios.Include(x => x.Enderecos).FirstOrDefaultAsync(x => x.Id == id);
            return f is null ? Results.NotFound() : Results.Ok(f);
        });

        app.MapPost("/funcionarios", async (Funcionario input, FuncionariosDbContext db, IRabbitMqProducer bus) =>
        {
            db.Funcionarios.Add(input);
            await db.SaveChangesAsync();

            bus.Publish("rh", "funcionarios.created", new { input.Id, input.NomeCompleto, input.CPF });
            return Results.Created($"/funcionarios/{input.Id}", input);
        });

        app.MapPut("/funcionarios/{id:int}", async (int id, Funcionario input, FuncionariosDbContext db, IRabbitMqProducer bus) =>
        {
            var f = await db.Funcionarios.Include(x => x.Enderecos).FirstOrDefaultAsync(x => x.Id == id);
            if (f is null) return Results.NotFound();

            f.NomeCompleto = input.NomeCompleto;
            f.Email = input.Email;
            f.Telefone = input.Telefone;
            f.SalarioBase = input.SalarioBase;
            f.IdCargo = input.IdCargo;
            f.IdDepartamento = input.IdDepartamento;
            f.Situacao = input.Situacao;
            f.Enderecos = input.Enderecos;

            await db.SaveChangesAsync();
            bus.Publish("rh", "funcionarios.updated", new { f.Id, f.NomeCompleto, f.CPF });
            return Results.Ok(f);
        });

        app.MapDelete("/funcionarios/{id:int}", async (int id, FuncionariosDbContext db, IRabbitMqProducer bus) =>
        {
            var f = await db.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
            if (f is null) return Results.NotFound();

            db.Funcionarios.Remove(f);
            await db.SaveChangesAsync();
            bus.Publish("rh", "funcionarios.deleted", new { Id = id });
            return Results.NoContent();
        });
    }
}
