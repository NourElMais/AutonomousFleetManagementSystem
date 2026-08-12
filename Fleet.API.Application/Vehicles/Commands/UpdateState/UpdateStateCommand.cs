using Fleet.API.Application.Interfaces;
using Fleet.API.Domain.Entities;
using MediatR;

namespace Fleet.API.Application.Vehicles.Commands.UpdateState;

public class UpdateStateCommand : IRequest<Vehicle>
{
    public string VehicleId { get; set; }
    public VehicleStatus NewStatus { get; set; }

    public UpdateStateCommand(string VehicleId, VehicleStatus NewStatus)
    {
        this.VehicleId = VehicleId;
        this.NewStatus = NewStatus;
    }
}