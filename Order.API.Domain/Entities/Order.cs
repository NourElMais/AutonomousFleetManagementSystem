namespace Order.API.Domain.Entities;

public class Order
{

    public string Id { get; private set; }
    public string Name { get; private set; }
    public decimal TotalPrice { get; private set; }

    public OrderState State { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime LastUpdatedAt { get; private set; }


    public Order(string Id, string Name, decimal TotalPrice, OrderState State, DateTime CreatedAt,
        DateTime LastUpdatedAt)
    {
        this.Id = Id;
        this.Name = Name;
        this.TotalPrice = TotalPrice;
        this.State = State;
        this.CreatedAt = CreatedAt;
        this.LastUpdatedAt = LastUpdatedAt;
    }

    public void Create()
    { 
        State = OrderState.Created;
    }

    public void Queue()
    {
        State = OrderState.Queued;
    }

    public void Assign()
    {
        State = OrderState.Assigned;
    }

    public void StartRunning()
    {
        State = OrderState.Running;
    }

    public void Complete()
    {
        State = OrderState.Completed;
    }

    public void Fail()
    {
        State = OrderState.Failed;
    }

    public void Cancel()
    {
        // logic I implemented: we cannot cancel an order that is either running, completed, or failed
        if (State == OrderState.Running || State == OrderState.Completed || State == OrderState.Failed)
        {
            throw new InvalidOperationException("Cannot cancel Order");
        }

        State = OrderState.Cancelled;
    }

}
