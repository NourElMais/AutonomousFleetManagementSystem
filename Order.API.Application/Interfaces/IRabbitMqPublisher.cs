namespace Order.API.Application.Interfaces;

public interface IRabbitMqPublisher
{
    public Task PublishAsync<T>(string routingKey, T message, CancellationToken cancellationToken);
}