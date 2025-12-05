using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Yarp.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);

var jwt = builder.Configuration.GetSection("Jwt");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddReverseProxy()
    .LoadFromMemory(new[]
    {
        new RouteConfig()
        {
            RouteId = "auth",
            ClusterId = "authCluster",
            Match = new() { Path = "/auth/{**catch-all}" }
        },
        new RouteConfig()
        {
            RouteId = "funcionarios",
            ClusterId = "funcCluster",
            Match = new() { Path = "/funcionarios/{**catch-all}" }
        },
        new RouteConfig()
        {
            RouteId = "jornada",
            ClusterId = "jornadaCluster",
            Match = new() { Path = "/jornada/{**catch-all}" }
        },
        new RouteConfig()
        {
            RouteId = "folha",
            ClusterId = "folhaCluster",
            Match = new() { Path = "/folha/{**catch-all}" }
        },
        new RouteConfig()
        {
            RouteId = "beneficios",
            ClusterId = "benefCluster",
            Match = new() { Path = "/beneficios/{**catch-all}" }
        },
        new RouteConfig()
        {
            RouteId = "logs",
            ClusterId = "logsCluster",
            Match = new() { Path = "/logs/{**catch-all}" }
        },
        new RouteConfig()
        {
            RouteId = "notificacoes",
            ClusterId = "notifCluster",
            Match = new() { Path = "/notificacoes/{**catch-all}" }
        }
    },
    new[]
    {
        new ClusterConfig()
        {
            ClusterId = "authCluster",
            Destinations = new Dictionary<string, DestinationConfig>{
                { "d1", new DestinationConfig(){ Address = "http://auth-service:8080" } }
            }
        },
        new ClusterConfig()
        {
            ClusterId = "funcCluster",
            Destinations = new(){
                { "d1", new DestinationConfig(){ Address = "http://funcionarios-service:8080" } }
            }
        },
        new ClusterConfig()
        {
            ClusterId = "jornadaCluster",
            Destinations = new(){
                { "d1", new DestinationConfig(){ Address = "http://jornadaescala-service:8080" } }
            }
        },
        new ClusterConfig()
        {
            ClusterId = "folhaCluster",
            Destinations = new(){
                { "d1", new DestinationConfig(){ Address = "http://folha-service:8080" } }
            }
        },
        new ClusterConfig()
        {
            ClusterId = "benefCluster",
            Destinations = new(){
                { "d1", new DestinationConfig(){ Address = "http://beneficios-service:8080" } }
            }
        },
        new ClusterConfig()
        {
            ClusterId = "logsCluster",
            Destinations = new(){
                { "d1", new DestinationConfig(){ Address = "http://logs-service:8080" } }
            }
        },
        new ClusterConfig()
        {
            ClusterId = "notifCluster",
            Destinations = new(){
                { "d1", new DestinationConfig(){ Address = "http://notifications-service:8080" } }
            }
        }
    });

var app = WebApplication.Create(args);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy(); // JWT aplicado no gateway
app.Run();
