namespace Order.API.Domain.Entities;

public class Order
{

    public string Id { get;  set; }
    public string Number { get;  set; }
    public decimal TotalPrice { get;  set; }
    public int PriorityScore { get; set; }
    public OrderState State { get;  set; }
    public DateTime CreatedAt { get;  set; }
    public DateTime LastUpdatedAt { get;  set; }


    public Order(string Id, string Number, decimal TotalPrice, OrderState State, DateTime CreatedAt,
        DateTime LastUpdatedAt)
    {
        this.Id = Id;
        this.Number = Number;
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
