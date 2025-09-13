using Microsoft.EntityFrameworkCore;
using TestServer.Models; // Đảm bảo có using này

namespace TestServer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Driver> Drivers { get; set; }

    // Thêm đoạn code này để seeding data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Driver>().HasData(
            new Driver { Id = 1, Name = "Lewis Hamilton" },
            new Driver { Id = 2, Name = "Max Verstappen" },
            new Driver { Id = 3, Name = "Charles Leclerc" },
            new Driver { Id = 4, Name = "Sergio Pérez" } // Thêm một vài driver nữa
        );
    }
}