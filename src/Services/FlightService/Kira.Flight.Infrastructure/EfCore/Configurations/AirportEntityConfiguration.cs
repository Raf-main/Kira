using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kira.Flight.Infrastructure.EfCore.Configurations;

public class AirportEntityConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Name).IsRequired().HasMaxLength(32);
        builder.Ignore(p => p.DomainEvents);
    }
}
