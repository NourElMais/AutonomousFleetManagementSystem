using Fleet.API.Domain.Entities;

namespace Fleet.API.Domain.Repositories;

public interface IVehicleRepository
{
    Task <List<Vehicle>> GetAllAsync(CancellationToken cancellationToken);
    Task<Vehicle> AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
    
    Task<Vehicle?> GetByIdAsync(string vehicleId, CancellationToken cancellationToken);
    Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken);
}