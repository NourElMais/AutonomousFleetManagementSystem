using Fleet.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fleet.API.Infrastructure.Data;

public class VehicleDbContext : DbContext
{
    public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
}
