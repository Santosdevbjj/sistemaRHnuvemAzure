using Auth.Api.Endpoints;
using Auth.Infrastructure.Persistence;
using Auth.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Auth;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AuthDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddSingleton<TokenService>();

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/auth/health", () => Results.Ok("ok"));
app.MapAuthEndpoints();

app.Run();
