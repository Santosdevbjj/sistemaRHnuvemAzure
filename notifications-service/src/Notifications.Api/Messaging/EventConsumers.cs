using Notifications.Api.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Notifications.Api.Messaging;

public class EventConsumers : IHostedService
{
    private readonly IConfiguration _cfg;
    private readonly EmailSender _email;
    private readonly PushSender _push;
    private IConnection? _conn;
    private IModel? _channel;

    public EventConsumers(IConfiguration cfg, EmailSender email, PushSender push)
    {
        _cfg = cfg; _email = email; _push = push;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var factory = new ConnectionFactory
        {
            HostName = _cfg["RabbitMQ:HostName"],
            UserName = _cfg["RabbitMQ:User"],
            Password = _cfg["RabbitMQ:Password"]
        };
        _conn = factory.CreateConnection();
        _channel = _conn.CreateModel();
        _channel.ExchangeDeclare("rh", ExchangeType.Topic, durable: true);

        var q = _channel.QueueDeclare("notif-queue", durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind(q.QueueName, "rh", "funcionarios.*");
        _channel.QueueBind(q.QueueName, "rh", "folha.generated");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (_, ea) =>
        {
            var payload = Encoding.UTF8.GetString(ea.Body.ToArray());
            var data = JsonSerializer.Deserialize<JsonElement>(payload);

            if (ea.RoutingKey.StartsWith("funcionarios."))
            {
                await _email.SendAsync("rh@empresa.com", "Atualização de funcionário", payload);
            }
            if (ea.RoutingKey == "folha.generated")
            {
                await _push.SendAsync("GestorApp", "Folha gerada", payload);
            }
        };
        _channel.BasicConsume(q.QueueName, autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _channel?.Dispose();
        _conn?.Dispose();
        return Task.CompletedTask;
    }
}
