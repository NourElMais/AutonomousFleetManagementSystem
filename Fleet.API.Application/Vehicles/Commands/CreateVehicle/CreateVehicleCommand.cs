using Fleet.API.Domain.Entities;
using MediatR;

namespace Fleet.API.Application.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommand : IRequest<Vehicle>
{
    public string Model { get;  set; }
    public decimal Price { get;  set; }
    public decimal BatteryLevel { get;  set; }
}