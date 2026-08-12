namespace Fleet.API.Domain.Entities;

public class Vehicle
{
    public string Id { get;  set; }
    public string Model { get;  set; }
    public decimal Price { get;  set; }
    public VehicleStatus Status { get;  set; }
    public decimal BatteryLevel { get;  set; }
    public string coordinates { get;  set; }
    
    public void UpdateState(VehicleStatus updatedStatus)
    {
        Status = updatedStatus;
    }
}