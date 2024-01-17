using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kira.Flight.Infrastructure.EfCore.Configurations;

public class FlightEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Flight>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Flight> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.UtcDateTime).IsRequired();
        builder.HasOne<Airport>().WithMany().HasForeignKey(p => p.ToAirportId).IsRequired();
        builder.HasOne<Airport>().WithMany().HasForeignKey(p => p.FromAirportId).IsRequired();
        builder.HasOne<Airplane>().WithMany().HasForeignKey(p => p.AirplaneId);
        builder.Ignore(p => p.DomainEvents);
    }
}