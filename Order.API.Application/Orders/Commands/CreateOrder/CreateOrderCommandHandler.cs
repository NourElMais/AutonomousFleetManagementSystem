using MediatR;
using Order.API.Domain.Entities;
using Order.API.Domain.Repositories;

namespace Order.API.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand,Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
       _orderRepository = orderRepository;
    }

    public async Task<Domain.Entities.Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.Entities.Order(Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            request.TotalPrice,
            OrderState.Created,
            DateTime.UtcNow,
            DateTime.UtcNow);
        
        await _orderRepository.AddAsync(order, cancellationToken);
        return order;
    }
}