using Fleet.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fleet.API.Infrastructure.Data;

public class VehicleDbContext : DbContext
{
    public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I had this problem in one of the labs where ef core stores enums as ints, and thats how i solved it
        modelBuilder.Entity<Vehicle>()
            .Property(v => v.Status)
            .HasConversion<string>(); 
    }
}
