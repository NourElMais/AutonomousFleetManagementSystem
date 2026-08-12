using Microsoft.EntityFrameworkCore;
using Order.API.Domain.Repositories;
using Order.API.Infrastructure.Data;

namespace Order.API.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _db;

    public OrderRepository(OrderDbContext db)
    {
        _db = db;
    }
    public async Task<List<Domain.Entities.Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<Domain.Entities.Order> orders = await _db.Orders.ToListAsync(cancellationToken);
        return orders;
    }

    public async Task<Domain.Entities.Order> AddAsync(Domain.Entities.Order order, CancellationToken cancellationToken)
    {
        await _db.Orders.AddAsync(order, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return order;
    }
    
    public async Task<Domain.Entities.Order?> GetByIdAsync(string orderId, CancellationToken cancellationToken)
    {
        Domain.Entities.Order? v = await _db.Orders.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);

        if (v is null)
        {
            return null;
        }
        return v;
    }
}