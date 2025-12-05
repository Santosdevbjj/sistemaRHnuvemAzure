using Notifications.Api.Messaging;
using Notifications.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<EmailSender>();
builder.Services.AddSingleton<PushSender>();
builder.Services.AddHostedService<EventConsumers>(); // consome eventos e envia notificações

var app = builder.Build();
app.MapGet("/notificacoes/health", () => Results.Ok("ok"));
app.Run();
