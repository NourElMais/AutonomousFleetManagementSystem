using Fleet.API.Domain.Entities;
using Fleet.API.Domain.Repositories;
using MediatR;

namespace Fleet.API.Application.Vehicles.Commands.UpdateState;

public class UpdateStateCommandHandler: IRequestHandler<UpdateStateCommand, Vehicle>
{
    private readonly IVehicleRepository _vehicleRepository;

    public UpdateStateCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;

    }

    public async Task<Vehicle> Handle(UpdateStateCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(command.VehicleId, cancellationToken);

        if (vehicle is null)
            throw new Exception("ProductNotFound");

        vehicle.UpdateState(command.NewStatus);

        await _vehicleRepository.UpdateAsync(vehicle, cancellationToken);
        return vehicle;
    }
}
