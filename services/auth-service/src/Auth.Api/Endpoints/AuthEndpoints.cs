using Auth.Domain.Entities;
using Auth.Infrastructure.Persistence;
using Auth.Infrastructure.Services;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace Auth.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/auth/register", async (UsuarioSistema input, AuthDbContext db) =>
        {
            input.SenhaHash = BCrypt.Net.BCrypt.HashPassword(input.SenhaHash);
            db.UsuariosSistema.Add(input);
            await db.SaveChangesAsync();
            return Results.Created($"/auth/users/{input.UsuarioId}", new { input.UsuarioId, input.Username });
        });

        app.MapPost("/auth/login", async (LoginDto dto, AuthDbContext db, TokenService tokenSvc) =>
        {
            var user = await db.UsuariosSistema.FirstOrDefaultAsync(x => x.Username == dto.Username);
            if (user is null) return Results.Unauthorized();

            var ok = BCrypt.Net.BCrypt.Verify(dto.Password, user.SenhaHash);
            if (!ok || !user.Ativo) return Results.Unauthorized();

            var token = tokenSvc.GenerateToken(user);
            // TODO: emitir RefreshToken e persistir (tabela própria)
            return Results.Ok(new { access_token = token, token_type = "Bearer", expires_in = 900 });
        });
    }
}

public record LoginDto(string Username, string Password);
