using JornadaEscala.Infrastructure.Persistence;
using JornadaEscala.Api.Endpoints;
using SharedKernel.Auth;

var builder = WebApplication.CreateBuilder(args);

// Registra DbContext e aplica migrations automaticamente
builder.Services.AddPersistence(builder.Configuration);

// Autenticação JWT
builder.Services.AddJwtAuth(builder.Configuration);

var app = builder.Build();

// Middleware de autenticação/autorização
app.UseAuthentication();
app.UseAuthorization();

// Endpoints de saúde
app.MapGet("/jornada/health", () => Results.Ok("ok"));

// Endpoints específicos do domínio Jornada/Escala/Ponto
app.MapJornadaEndpoints();
app.MapEscalaEndpoints();
app.MapPontoEndpoints();

app.Run();
