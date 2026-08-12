using Fleet.API.Domain.Entities;
using Fleet.API.Domain.Repositories;
using Fleet.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Fleet.API.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly VehicleDbContext _db;

    public VehicleRepository(VehicleDbContext db)
    {
        _db = db;
    }
    public async Task<List<Vehicle>> GetAllAsync(CancellationToken cancellationToken)
    {
        List<Vehicle> vehicles = await _db.Vehicles.ToListAsync(cancellationToken);
        return vehicles;
    }

    public async Task<Vehicle> AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await _db.Vehicles.AddAsync(vehicle, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return vehicle;
    }
}