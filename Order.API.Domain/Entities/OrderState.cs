namespace Order.API.Domain.Entities;

public enum OrderState
{
    Created,
    Queued,
    Assigned,
    Running,
    Completed,
    Failed,
    Cancelled
}