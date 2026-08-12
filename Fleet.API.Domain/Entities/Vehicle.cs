namespace Fleet.API.Domain.Entities;

public class Vehicle
{
    public string Id { get; private set; }
    public string Model { get; private set; }
    public decimal Price { get; private set; }
    public string VehicleStatus { get; private set; }
    public decimal BatteryLevel { get; private set; }
    public CoordinateTelemetry coordinates { get; private set; }
}