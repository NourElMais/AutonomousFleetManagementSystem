using Fleet.API.Domain.Entities;
using MediatR;

namespace Fleet.API.Application.Vehicles.Queries.GetVehicleById;

public class GetVehicleByIdQuery: IRequest<Vehicle?> {
    public string Id { get; set; }

    public GetVehicleByIdQuery(string id)
    {
        Id = id;
    }
}