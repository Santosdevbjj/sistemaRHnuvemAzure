using JornadaEscala.Infrastructure.Persistence;
using JornadaEscala.Api.Endpoints;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JornadaDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddJwtAuth(builder.Configuration);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/jornada/health", () => Results.Ok("ok"));
app.MapJornadaEndpoints();
app.MapEscalaEndpoints();
app.MapPontoEndpoints();

app.Run();
