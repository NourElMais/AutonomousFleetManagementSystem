using MediatR;

namespace Order.API.Application.Orders.Queries.GetOrders;

public class GetOrdersQuery: IRequest<List<Domain.Entities.Order>>
{
    
}