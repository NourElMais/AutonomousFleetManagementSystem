using Fleet.API.Domain.Entities;
using Fleet.API.Domain.Repositories;
using MediatR;

namespace Fleet.API.Application.Vehicles.Commands.CreateVehicle;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand,Vehicle>
{
    private readonly IVehicleRepository _vehicleRepository;

    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository =  vehicleRepository;
    }

    public async Task<Vehicle> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid().ToString(),
            Model = request.Model,
            Price = request.Price,
            Status = VehicleStatus.InStock, // i chose this as a default value
           BatteryLevel=request.BatteryLevel,
           coordinates = "0.0, 0.0"  //default value i got from google
        };
        await _vehicleRepository.AddAsync(vehicle, cancellationToken);
        return vehicle;
    }
}