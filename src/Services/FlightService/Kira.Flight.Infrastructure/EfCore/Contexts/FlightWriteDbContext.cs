using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kira.Flight.Infrastructure.EfCore.Contexts;

public class FlightWriteDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Domain.Entities.Flight> Flights { get; set; } = null!;
    public DbSet<Airplane> Airplanes { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}