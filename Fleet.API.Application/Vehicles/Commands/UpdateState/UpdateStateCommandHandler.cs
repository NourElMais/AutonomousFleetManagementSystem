using Fleet.API.Application.Interfaces;
using Fleet.API.Domain.Entities;
using Fleet.API.Domain.Repositories;
using MediatR;

namespace Fleet.API.Application.Vehicles.Commands.UpdateState;

public class UpdateStateCommandHandler: IRequestHandler<UpdateStateCommand, Vehicle>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IRabbitMqPublisher _rabbitMqPublisher;
    public UpdateStateCommandHandler(IVehicleRepository vehicleRepository, IRabbitMqPublisher rabbitMqPublisher)
    {
        _vehicleRepository = vehicleRepository;
        _rabbitMqPublisher = rabbitMqPublisher;
    }

    public async Task<Vehicle> Handle(UpdateStateCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(command.VehicleId, cancellationToken);

        if (vehicle is null)
            throw new Exception("ProductNotFound");

        vehicle.UpdateState(command.NewStatus);
        if (command.NewStatus == VehicleStatus.Offline)
        {
            _rabbitMqPublisher.PublishAsync("vehicle.Offline",vehicle, cancellationToken);
        }

        await _vehicleRepository.UpdateAsync(vehicle, cancellationToken);
        return vehicle;
    }
}
