using Fleet.API.Application.DTOs;
using Fleet.API.Application.Vehicles.Commands.CreateVehicle;
using Fleet.API.Application.Vehicles.Commands.UpdateState;
using Fleet.API.Application.Vehicles.Queries.GetVehicleById;
using Fleet.API.Application.Vehicles.Queries.GetVehicles;
using Fleet.API.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Fleet.API.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
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

    [HttpGet]
    public async Task<IActionResult> GetVehicles(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetVehiclesQuery(), cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicleById(string id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetVehicleByIdQuery(id), cancellationToken));
    }

    [HttpPatch("state/{id}")]
    public async Task<IActionResult> AlterState(string id, [FromBody] VehicleStatus UpdatedStatus, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new UpdateStateCommand(id, UpdatedStatus), cancellationToken));
    }
}