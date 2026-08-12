using MediatR;
using Order.API.Domain.Repositories;

namespace Order.API.Application.Orders.Queries.GetOrders;

public class GetOrdersQueryHandler :IRequestHandler<GetOrdersQuery,List<Domain.Entities.Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<Domain.Entities.Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    { 
        List<Domain.Entities.Order> vehicles = await _orderRepository.GetAllAsync(cancellationToken);
        return vehicles;
    }
}