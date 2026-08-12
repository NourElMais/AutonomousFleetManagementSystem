namespace Order.API.Domain.Repositories;

public interface IOrderRepository
{
    Task<Entities.Order> AddAsync(Entities.Order vehicle, CancellationToken cancellationToken);
    Task<List<Entities.Order>> GetAllAsync(CancellationToken cancellationToken);
    Task<Entities.Order?> GetByIdAsync(string vehicleId, CancellationToken cancellationToken);
}