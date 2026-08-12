using Fleet.API.Domain.Entities;
using Fleet.API.Domain.Repositories;
using MediatR;

namespace Fleet.API.Application.Vehicles.Queries.GetVehicleById;

public class GetVehicleByIdHandler : IRequestHandler<GetVehicleByIdQuery,Vehicle?>
{
    private readonly IVehicleRepository _vehicleRepository;
    public GetVehicleByIdHandler(IVehicleRepository vehicleRepository)
    {
       _vehicleRepository = vehicleRepository;
    }

    public async Task<Vehicle> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (vehicle is null)
        {
            throw new Exception("ProductNotFound");
        }

        return vehicle;
    }
    
    
}