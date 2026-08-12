using System.Text;
using System.Text.Json;
using MassTransit;
using MassTransit.Mediator;
using NotificationConsumer.Application.IntegrationEvents;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NotificationConsumer.Presentation.Consumers;

public class VehicleOfflineEventConsumer:BackgroundService
{
     private readonly IServiceScopeFactory _scopeFactory;
    private readonly IConfiguration _configuration;
    public VehicleOfflineEventConsumer(IServiceScopeFactory scopeFactory, IConfiguration configuration)
    {
        _scopeFactory = scopeFactory;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                await StartConsumerAsync(cancellationToken);

                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception exception)
            {
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }

        }
    }
    private async Task StartConsumerAsync(CancellationToken cancellationToken)
    {
        var connectionFactory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:HostName"],
            UserName = _configuration["RabbitMQ:UserName"],
            Password = _configuration["RabbitMQ:Password"]
        };

        var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);

        var channel = await connection.CreateChannelAsync(cancellationToken: cancellationToken);

        await channel.QueueDeclareAsync(
            queue: "vehicle.Offline.queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            cancellationToken: cancellationToken);

        await channel.QueueBindAsync(
            queue: "vehicle.Offline.queue",
            exchange: "fleet.events",
            routingKey: "vehicle.Offline",
            cancellationToken: cancellationToken);

        var consumer = new AsyncEventingBasicConsumer(channel);
        
        await channel.BasicConsumeAsync(
            queue: "vehicle.Offline.queue",
            autoAck: true,
            consumer: consumer,
            cancellationToken: cancellationToken);
    }

    
}