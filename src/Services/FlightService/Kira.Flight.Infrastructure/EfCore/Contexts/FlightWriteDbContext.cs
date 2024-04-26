using System.Reflection;
using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kira.Flight.Infrastructure.EfCore.Contexts;

public class FlightWriteDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Domain.Entities.Flight> Flights => Set<Domain.Entities.Flight>();
    public DbSet<Airplane> Airplanes => Set<Airplane>();
    public DbSet<Airport> Airports => Set<Airport>();
    public DbSet<Seat> Seats => Set<Seat>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
