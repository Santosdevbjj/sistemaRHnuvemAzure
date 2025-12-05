using Funcionarios.Api.Endpoints;
using Funcionarios.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Auth;
using SharedKernel.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FuncionariosDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddJwtAuth(builder.Configuration);

// RabbitMQ
builder.Services.AddSingleton<IRabbitMqProducer>(_ =>
    new RabbitMqProducer(
        hostName: builder.Configuration["RabbitMQ:HostName"]!,
        user: builder.Configuration["RabbitMQ:User"]!,
        pass: builder.Configuration["RabbitMQ:Password"]!
    )
);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/funcionarios/health", () => Results.Ok("ok"));
app.MapFuncionarioEndpoints();

app.Run();
