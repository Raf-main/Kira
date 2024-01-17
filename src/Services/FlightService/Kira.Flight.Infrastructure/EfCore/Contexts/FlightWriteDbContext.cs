using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kira.Flight.Infrastructure.EfCore.Contexts;

public class FlightWriteDbContext : DbContext
{
    public FlightWriteDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Domain.Entities.Flight> Flights { get; set; } = null!;
    public DbSet<Airplane> Airplanes { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}