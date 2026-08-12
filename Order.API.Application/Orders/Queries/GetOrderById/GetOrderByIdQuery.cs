using MediatR;

namespace Order.API.Application.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery : IRequest<Domain.Entities.Order?> {
    public string Id { get; set; }

    public GetOrderByIdQuery(string id)
    {
        Id = id;
    }
}