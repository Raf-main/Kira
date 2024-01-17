using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kira.Flight.Infrastructure.EfCore.Configurations;

public class AirplaneEntityConfiguration : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Model).IsRequired();
        builder.Ignore(p => p.DomainEvents);
    }
}