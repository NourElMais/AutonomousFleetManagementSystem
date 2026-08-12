using Fleet.API.Application.DTOs;
using Fleet.API.Application.Vehicles.Commands.CreateVehicle;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.API.Presentation.Controllers;

// Fleet.API: POST /vehicles (Register Vehicle), GET /vehicles (List Tenant Vehicles), 
// PATCH /vehicles/{id}/state (Modify Vehicle State).  
[ApiController]
[Route("api/[controller]")]
public class VehiclesController: ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleDTO request, CancellationToken cancellationToken)
    {
        var command = new CreateVehicleCommand()
        {
            Model = request.Model,
            Price =  request.Price,
            BatteryLevel =  request.BatteryLevel
        };
        
        var vehicle = await _mediator.Send(command, cancellationToken);
        return Ok(vehicle);
    }
}