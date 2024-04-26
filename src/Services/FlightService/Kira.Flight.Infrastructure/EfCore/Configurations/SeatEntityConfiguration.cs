using Kira.Flight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kira.Flight.Infrastructure.EfCore.Configurations;

public class SeatEntityConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.IsReserved).IsRequired();
        builder.Property(p => p.SeatNumber).IsRequired().HasMaxLength(32);
        builder.Ignore(p => p.DomainEvents);
    }
}
