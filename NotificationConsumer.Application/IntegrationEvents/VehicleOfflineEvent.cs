namespace NotificationConsumer.Application.IntegrationEvents;

public class VehicleOfflineEvent
{
    public Guid EventId { get; set; } = Guid.NewGuid();
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
    public string vehicleId { get; set; }
}