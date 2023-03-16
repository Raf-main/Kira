using System.Reflection;
using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kira.Flight.Infrastructure.EfCore.Contexts;

public class FlightWriteDbContext : DbContext
{
    public DbSet<Domain.Entities.Flight> Flights { get; set; } = null!;
    public DbSet<Airplane> Airplanes { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;

    public FlightWriteDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}