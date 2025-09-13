using Microsoft.EntityFrameworkCore;
using TestServer.Models;

namespace TestServer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Driver> Drivers { get; set; }
}