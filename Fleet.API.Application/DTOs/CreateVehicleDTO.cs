namespace Fleet.API.Application.DTOs;

public class CreateVehicleDTO
{
    public string Model { get;  set; }
    public decimal Price { get;  set; }
    public decimal BatteryLevel { get;  set; }
}