using MediatR;
using Order.API.Domain.Entities;

namespace Order.API.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Domain.Entities.Order>
{
    public decimal TotalPrice { get;  set; }
}