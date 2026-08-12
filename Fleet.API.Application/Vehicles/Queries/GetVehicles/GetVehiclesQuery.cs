using Fleet.API.Domain.Entities;
using MediatR;

namespace Fleet.API.Application.Vehicles.Queries.GetVehicles;

public class GetVehiclesQuery: IRequest<List<Vehicle>>
{
    
}