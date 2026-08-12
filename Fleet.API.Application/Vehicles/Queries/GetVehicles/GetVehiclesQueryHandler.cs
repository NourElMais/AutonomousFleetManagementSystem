using Fleet.API.Domain.Entities;
using Fleet.API.Domain.Repositories;
using MediatR;

namespace Fleet.API.Application.Vehicles.Queries.GetVehicles;

public class GetVehiclesQueryHandler: IRequestHandler<GetVehiclesQuery,List<Vehicle>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehiclesQueryHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<List<Vehicle>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
    { 
        List<Vehicle> vehicles = await _vehicleRepository.GetAllAsync(cancellationToken);
        return vehicles;
    }
}