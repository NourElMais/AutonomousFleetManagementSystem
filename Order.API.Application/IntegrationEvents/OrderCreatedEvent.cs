namespace Order.API.Application.IntegrationEvents;

public class OrderCreatedEvent
{
    public Guid EventId { get; set; } = Guid.NewGuid();
    public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
    public string OrderId { get;  set; }
    public string Number { get;  set; }
    public decimal TotalPrice { get;  set; }
}