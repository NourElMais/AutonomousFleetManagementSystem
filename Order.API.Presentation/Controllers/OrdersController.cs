using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Order.API.Application.DTOs;
using Order.API.Application.Orders.Commands.CreateOrder;
using Order.API.Application.Orders.Queries.GetOrderById;
using Order.API.Application.Orders.Queries.GetOrders;

namespace Order.API.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateOrderDTO> _validator;
    public OrdersController(IMediator mediator, IValidator<CreateOrderDTO> validator)
    {
        _mediator = mediator;
        _validator = validator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO request, CancellationToken cancellationToken)
    {
        var command = new CreateOrderCommand()
        {
            TotalPrice =  request.TotalPrice
        };
        
        var order = await _mediator.Send(command, cancellationToken);
        return Ok(order);
    }

    [HttpGet]
    public async Task<List<Domain.Entities.Order>> GetAllOrders(CancellationToken cancellationToken)
    {
        var orders = await _mediator.Send(new GetOrdersQuery(), cancellationToken);
        return orders;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(string id, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken));
    }
}