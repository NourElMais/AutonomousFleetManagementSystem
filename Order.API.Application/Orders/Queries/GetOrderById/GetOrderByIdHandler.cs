using MediatR;
using Order.API.Domain.Repositories;

namespace Order.API.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Domain.Entities.Order?>
{

    private readonly IOrderRepository _orderRepository;
    public GetOrderByIdHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Domain.Entities.Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id, cancellationToken);

        if (order is null)
        {
            throw new Exception("ProductNotFound");
        }

        return order;
    }

}
