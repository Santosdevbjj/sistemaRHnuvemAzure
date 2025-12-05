using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace SharedKernel.Messaging;

public interface IRabbitMqProducer
{
    void Publish<T>(string exchange, string routingKey, T message);
}

public class RabbitMqProducer : IRabbitMqProducer, IDisposable
{
    private readonly IConnection _conn;
    private readonly IModel _channel;

    public RabbitMqProducer(string hostName, string user, string pass)
    {
        var factory = new ConnectionFactory { HostName = hostName, UserName = user, Password = pass };
        _conn = factory.CreateConnection();
        _channel = _conn.CreateModel();
    }

    public void Publish<T>(string exchange, string routingKey, T message)
    {
        _channel.ExchangeDeclare(exchange, ExchangeType.Topic, durable: true);
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        _channel.BasicPublish(exchange: exchange, routingKey: routingKey, basicProperties: null, body: body);
    }

    public void Dispose()
    {
        _channel?.Dispose();
        _conn?.Dispose();
    }
}
