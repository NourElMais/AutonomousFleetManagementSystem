using Microsoft.EntityFrameworkCore;

namespace Order.API.Infrastructure.Data;

public class OrderDbContext : DbContext
{
    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I had this problem in one of the labs where ef core stores enums as ints, and thats how i solved it
        modelBuilder.Entity<Domain.Entities.Order>()
            .Property(o => o.State)
            .HasConversion<string>(); 
    }
}