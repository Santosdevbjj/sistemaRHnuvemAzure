using Azure.Data.Tables;
using Logs.Infrastructure.TableStorage;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Logs.Infrastructure.Messaging;

public class FuncionarioEventsConsumer : IHostedService
{
    private readonly IConfiguration _cfg;
    private IConnection? _conn;
    private IModel? _channel;

    public FuncionarioEventsConsumer(IConfiguration cfg) => _cfg = cfg;

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
        var queue = _channel.QueueDeclare(queue: "logs-funcionarios", durable: true, exclusive: false, autoDelete: false);
        _channel.QueueBind(queue.QueueName, "rh", "funcionarios.*");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (_, ea) =>
        {
            var json = Encoding.UTF8.GetString(ea.Body.ToArray());
            var data = JsonSerializer.Deserialize<JsonElement>(json);

            var tableSvc = new TableServiceClient(_cfg["AzureTable:ConnectionString"]);
            var table = tableSvc.GetTableClient("funcionarioslog");
            await table.CreateIfNotExistsAsync();

            var id = data.TryGetProperty("Id", out var idProp) ? idProp.GetInt32() : data.GetProperty("FuncionarioId").GetInt32();
            var entity = new FuncionarioLogEntity
            {
                PartitionKey = $"FUNC-{id}",
                RowKey = Guid.NewGuid().ToString(),
                FuncionarioId = id,
                SnapshotJson = json,
                TipoAlteracao = ea.RoutingKey.Contains("created") ? "INSERT" :
                                ea.RoutingKey.Contains("updated") ? "UPDATE" : "DELETE"
            };
            await table.AddEntityAsync(entity);
        };

        _channel.BasicConsume(queue: queue.QueueName, autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _channel?.Dispose();
        _conn?.Dispose();
        return Task.CompletedTask;
    }
}
